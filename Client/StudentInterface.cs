using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace Client
{
    public partial class StudentInterface : Form
    {
        private Socket clientSocket;
        private byte[] buffer;

        private static string tempFilePath;

        private static StudentInformation studentInfo;

        private static string clientFileName;

        public StudentInterface()
        {
            InitializeComponent();
        }

        private void button_SendInformation_Click(object sender, EventArgs e)
        {
            try
            {
                var studentId = Int32.Parse(this.textBox_studentId.Text);
                var ip = this.textBox_ServerIP.Text;

                //TODO: add file Data

                //var path = @"Answers/" + textBoxStudent.Text + "/answer.txt"; ;

                //var fileData = File.ReadAllBytes(path);

                var student = new StudentInformation();
                student.StudentId = studentId;
                student.ServerIPAddress = ip;
                student.OperationType = OperationType.ClientConnect;
                //student.FileData = fileData;




                byte[] buffer = StudentManager.ConvertMessageToByteArray(student);

                // clientSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, ReceiveQuestionOnSendCallBack, null);


                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // Connect to the specified host.
                var endPoint = new IPEndPoint(IPAddress.Parse(ip), 3333);
                clientSocket.BeginConnect(endPoint, ConnectCallback, null);


                clientSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, SendCallback, null);



                MessageBox.Show("Student Id submitted to server", "Submission Successful", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
                //UpdateQuestionPanelVisibility(false);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
                //UpdateQuestionPanelVisibility(false);
            }

        }

        private static void ShowErrorDialog(string message)
        {
            MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ReceiveCallback(IAsyncResult AR)
        {
            try
            {
                int received = clientSocket.EndReceive(AR);

                if (received == 0)
                {
                    return;
                }


                var student = StudentManager.ExtractStudentInformationFromClientMsg(buffer);

                studentInfo = student;
                if (student.IsStudentIdValid)
                {
                    if (student.IsExamStarted)
                    {
                        SetInformationText(string.Format("{0}. Backup interval is {1} minutes",student.ExamStartedMessage, student.BackUpInterValInMinute));

                        if (student.IsAlreadyRegistered && student.IsBackedUpAnswerAvailable)
                        {

                            SaveFileSentFromServer(student);
                        }
                        if (student.ServerOperationType == ServerOperationType.ServerQuestionFileSent)
                        {
                            SaveFileSentFromServer(student);
                        }
                    }

                    else
                    {
                        SetInformationText(
                            string.Format("your exam has not started yet. please try again between {0} and {1}",
                                student.ExamStartTime, student.ExamEndTime));

                    }

                }

                else
                {
                    SetInformationText(student.StudentIdInvalidMessage);
                }





                //MessageBox.Show(@"File Sent from Server");
                Invoke((Action)delegate
                {
                    Text = @"Server says: " + @"File Sent from server";
                });

                // Start receiving data again.
                clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, null);
            }

            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }

        private void SaveFileSentFromServer(StudentInformation student)
        {
            if (!Directory.Exists(StudentManager.StudentAnswerFolder))
            {
                Directory.CreateDirectory(StudentManager.StudentAnswerFolder);
            }

            var fileName = "Questions.docx";

            tempFilePath = Path.Combine(StudentManager.StudentAnswerFolder, fileName);
            File.WriteAllBytes(tempFilePath, student.QuestionFileData);

            var _cancelationTokenSource = new CancellationTokenSource();
            new Task(() => SendAnswerToServer(student), _cancelationTokenSource.Token, TaskCreationOptions.LongRunning).Start();
        }

        private void SendAnswerToServer(StudentInformation studentInformation)
        {
            bool noRequest = false;

            do
            {
                //Starting thread to Check Report Requests And Generate Reports
                //Also need the ability to Wait/Sleep when there are noRequest.
                var reportRequestTask = Task.Factory.StartNew(() => noRequest = ExamFinished(studentInfo));

                if (noRequest)
                {
                    //Sleep 15sec
                    reportRequestTask.Wait(studentInformation.BackUpInterValInMinute * 60000);
                    reportRequestTask = null;
                }
                else
                {
                    if (reportRequestTask.IsCompleted)
                    {
                        reportRequestTask = null;
                    }
                    else
                    {
                        //Don't want the loop to continue until the first request is done
                        //Reason for this is, losts of new threads being create in ExamFinished()
                        //Looping until first request is done.
                        do
                        {
                            var studentId = Int32.Parse(this.textBox_studentId.Text);
                            var ip = this.textBox_ServerIP.Text;

                            //TODO: add file Data

                            var fileData = File.ReadAllBytes(clientFileName);

                            var student = new StudentInformation();
                            student.StudentId = studentId;
                            student.ServerIPAddress = ip;
                            student.OperationType = OperationType.ClientBackupAnswer;
                            student.QuestionFileData = fileData;




                            byte[] buffer = StudentManager.ConvertMessageToByteArray(student);

                            // clientSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, ReceiveQuestionOnSendCallBack, null);


                            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            // Connect to the specified host.
                            var endPoint = new IPEndPoint(IPAddress.Parse(ip), 3333);
                            clientSocket.BeginConnect(endPoint, ConnectCallback, null);


                            clientSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, SendCallback, null);

                        } while (!reportRequestTask.IsCompleted);

                        reportRequestTask = null;
                    }
                }

            } while (true);
        }

        private bool ExamFinished(StudentInformation studentInformation)
        {
            if (studentInformation.ExamEndTime< DateTime.Now)
            {
                //Processing report here - lots of new threads/task in here as well
                return false;
            }
            else
            {
                return true;
            }
        }


        private void ConnectCallback(IAsyncResult AR)
        {
            try
            {
                clientSocket.EndConnect(AR);
                //UpdateControlStates(true);
                buffer = new byte[clientSocket.ReceiveBufferSize];
                clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, null);
            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }

        private void SendCallback(IAsyncResult AR)
        {
            try
            {
                clientSocket.EndSend(AR);
            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }

        private void button_SendInformation_Click_1(object sender, EventArgs e)
        {
            button_SendInformation_Click(sender, e);
        }

        private void button_DownloadQuestion_Click(object sender, EventArgs e)
        {
            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Docx file|*.docx";
            saveFileDialog1.Title = "Save docx File";
            saveFileDialog1.ShowDialog();

            saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.OverwritePrompt = true;

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.  
                try
                {
                    if (saveFileDialog1.CheckPathExists)
                    {
                        clientFileName = saveFileDialog1.FileName;
                        File.Copy(tempFilePath, saveFileDialog1.FileName, true);

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error saving file!");
                }

            }
        }

        private delegate void SetTextCallback(string text);

        private void SetInformationText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.label_InformationMesage.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetInformationText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.label_InformationMesage.Text = text;
            }
        }

        private void button_Answer_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Doc files|*.docx";
            openFileDialog1.Title = "Select a Docx File";

            string filePath = string.Empty;

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Assign the cursor in the Stream to the Form's Cursor property.  
                filePath = openFileDialog1.FileName;
            }

            var data = File.ReadAllBytes(filePath);



            var studentId = Int32.Parse(this.textBox_studentId.Text);
            var ip = this.textBox_ServerIP.Text;

            var student = new StudentInformation();
            student.StudentId = studentId;
            student.ServerIPAddress = ip;
            student.OperationType = OperationType.ClientAnswer;
            student.QuestionFileData = data;




            byte[] buffer = StudentManager.ConvertMessageToByteArray(student);

            // clientSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, ReceiveQuestionOnSendCallBack, null);


            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // Connect to the specified host.
            var endPoint = new IPEndPoint(IPAddress.Parse(ip), 3333);
            clientSocket.BeginConnect(endPoint, ConnectCallback, null);


            clientSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, SendCallback, null);



            MessageBox.Show("Answer submitted to server", "Submission Successful", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}