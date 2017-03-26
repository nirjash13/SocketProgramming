using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace ExamServer
{
    public partial class ServerInterface : Form
    {
        private Socket serverSocket;
        private Socket clientSocket;
        private byte[] buffer;


        private static string QuestionFilePath;

        
        public ServerInterface()
        {
            InitializeComponent();
            StartServer();

        }

        private void StartServer()
        {
            try
            {
                //var content = this.ReadQuestionFile();
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, 3333));
                serverSocket.Listen(10);
                serverSocket.BeginAccept(AcceptCallback, null);
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

        private void AcceptCallback(IAsyncResult AR)
        {
            try
            {
                clientSocket = serverSocket.EndAccept(AR);



                buffer = new byte[clientSocket.ReceiveBufferSize];



                /*var sendData = new byte[2000];

                //var sendData = Encoding.ASCII.GetBytes("Hello");
                clientSocket.BeginSend(sendData, 0, sendData.Length, SocketFlags.None, SendCallback, null);*/



                // Listen for client data.
                clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, null);
                // Continue listening for clients.
                serverSocket.BeginAccept(AcceptCallback, null);
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

        private byte[] ReadQuestionFile()
        {
            
            if (File.Exists(StudentManager.FullQuestionFilePath))
            {
                byte[] content = File.ReadAllBytes(StudentManager.FullQuestionFilePath);
                return content;

            }

            return null;
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

                student.ServerOperationType = ServerOperationType.ConnectionSuccessful;
                if (student.OperationType == OperationType.ClientConnect)
                {
                    if (StudentManager.VerifyStudentId(student.StudentId))
                    {
                        student.IsStudentIdValid = true;

                        student.ExamStartTime = StudentManager.examStartTime;
                        student.ExamEndTime = StudentManager.examEndTime;

                        if (StudentManager.IsExamStarted())
                        {
                            student.IsExamStarted = true;

                            student.QuestionFileData = ReadQuestionFile();
                            student.ServerOperationType = ServerOperationType.ServerQuestionFileSent;
                            student.BackUpInterValInMinute = StudentManager.BackUpIntervalInMinute;


                            student.ExamStartedMessage =
                                string.Format("Your exam has started. please save the question file and answer!");
                        }
                        else
                        {
                            student.IsExamStarted = false;
                            student.ServerOperationType = ServerOperationType.ServerExamInfo;
                            

                        }

                        if (StudentManager.CheckIfStudentAlreadyConnectedOnce(student.StudentId))
                        {
                            student.IsAlreadyRegistered = true;
                            student.QuestionFileData = GetLastBackedUpAnswer(ref student);

                        }
                        else
                        {
                            StudentManager.CreateStudentDirectory(student);
                            StudentManager.AddStudentToList(student);

                            
                        }



                    }
                    else
                    {
                        student.IsStudentIdValid = false;
                        student.StudentIdInvalidMessage =
                            string.Format("Student Id invalid. please send a student id between a valid range!");

                    }


                    var sendData = StudentManager.ConvertMessageToByteArray(student);

                    //var sendData = Encoding.ASCII.GetBytes("Hello");
                    clientSocket.BeginSend(sendData, 0, sendData.Length, SocketFlags.None, SendCallback, null);

                    // Start receiving data again.
                    clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, null);

                }


                else if(student.OperationType == OperationType.ClientAnswer)
                {


                    var path = Path.Combine(StudentManager.GetStudentAnswerPath(student.StudentId), "Answer.docx");


                    if (!Directory.Exists(StudentManager.GetStudentAnswerPath(student.StudentId)))
                    {
                        Directory.CreateDirectory(StudentManager.GetStudentAnswerPath(student.StudentId));
                    }

                    StudentManager.GrantAccess(StudentManager.GetStudentAnswerPath(student.StudentId));


                    //StudentManager.GrantAccess(path);

                    try
                    {
                        File.WriteAllBytes(path, student.QuestionFileData);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error!");
                    }

                }

                else if (student.OperationType == OperationType.ClientBackupAnswer)
                {


                    var path = Path.Combine(StudentManager.GetStudentAnswerPath(student.StudentId), "Answer_Backup.docx");


                    if (!Directory.Exists(StudentManager.GetStudentAnswerPath(student.StudentId)))
                    {
                        Directory.CreateDirectory(StudentManager.GetStudentAnswerPath(student.StudentId));
                    }

                    StudentManager.GrantAccess(StudentManager.GetStudentAnswerPath(student.StudentId));


                    //StudentManager.GrantAccess(path);

                    try
                    {
                        File.WriteAllBytes(path, student.QuestionFileData);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error!");
                    }

                }




                //TODO 
                // SubmitStudentToDataGrid(student);


            }
            // Avoid Pokemon exception handling in cases like these.
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }

        private byte[] GetLastBackedUpAnswer(ref StudentInformation student)
        {
            var path = Path.Combine(StudentManager.GetStudentAnswerPath(student.StudentId), "Answer_Backup.docx");
            if (File.Exists(path))
            {
                student.IsBackedUpAnswerAvailable = true;
                var data = File.ReadAllBytes(path);
                return data;
            }
            else
            {
                student.IsBackedUpAnswerAvailable = false;
                
                return null;
            }
            
        }

        private void SaveStudentInformation(StudentInformation studentInformation)
        {
            //var student = new StudentInformation();
            //StudentManager.CreateStudentDataInServer(studentInformation);
            if (studentInformation.OperationType == OperationType.ClientAnswer)
            {
                MessageBox.Show("Answers Received at Server. Please go to specific folder to read the answers",
                    "File received!", MessageBoxButtons.OK);
            }

        }

        private static void ShowErrorDialog(string message)
        {
            MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_SaveExamConfig_Click(object sender, EventArgs e)
        {
            var startTime = dateTimePicker_ExamStartTime.Value;

            var endTime = dateTimePicker_ExamEndTime.Value;

            ConfigurationManager.AppSettings["StartTime"] = startTime.ToString();
            ConfigurationManager.AppSettings["EndTime"] = endTime.ToString();

            StudentManager.examStartTime = startTime;
            StudentManager.examEndTime = endTime;

            richTextBox_ExamTimeInfo.Text = string.Format("Exam will start at {0} and end at {1}", startTime.ToString(), endTime.ToString());


        }

        private void button_OpenQuestionFile_Click(object sender, EventArgs e)
        {

            openFileDialog_Question.Filter = "Doc files|*.docx";
            openFileDialog_Question.Title = "Select a Docx File";

            string filePath = string.Empty;

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (openFileDialog_Question.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Assign the cursor in the Stream to the Form's Cursor property.  
                filePath = openFileDialog_Question.FileName;
            }

            var fileName = ConfigurationManager.AppSettings["FilePath"];

            var fullFilePath = Path.Combine(StudentManager.StudentQuestionFolder, fileName);
            StudentManager.GrantAccess(fullFilePath);
            if (!Directory.Exists(StudentManager.StudentQuestionFolder))
            {
                //StudentManager.GrantAccess(fullFilePath);
                Directory.CreateDirectory(StudentManager.StudentQuestionFolder);
            }
            try
            {
                File.Copy(filePath, fullFilePath, true);
                MessageBox.Show("Question uploaded");
                StudentManager.FullQuestionFilePath = fullFilePath;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings["StudentIdRangeStart"] = textBox_StduentIDStartRange.Text;
            ConfigurationManager.AppSettings["StudentIdRangeEnd"] = textBox_StduentIDEndRange.Text;
            MessageBox.Show("Student Id Range set successfully!");
        }
    }
}
