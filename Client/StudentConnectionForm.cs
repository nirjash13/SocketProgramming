namespace Client
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Windows.Forms;

    using Common;

    public partial class StudentConnectionForm : Form
    {
        private static byte[] buffer;

        private static Socket clientSocket;

        public StudentConnectionForm()
        {
            this.InitializeComponent();
        }

        private void button_ConnectToServer_Click(object sender, EventArgs e)
        {
            var serverIp = this.textBox_ServerIP.Text;
            this.ConnectToServer(serverIp);
        }

        private void ConnectToServer(string serverIp)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Connect to the specified host.
            var endPoint = new IPEndPoint(IPAddress.Parse(serverIp), 3333);
            clientSocket.BeginConnect(endPoint, ReceiveCallBackMessageOnConnection, null);
        }

        private void ReceiveCallBackMessageOnConnection(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndConnect(ar);
                this.UpdateStudentInformationSendStates(true);
                buffer = new byte[clientSocket.ReceiveBufferSize];
                clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, this.SendCallback,
                    null);
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

        private static void ShowErrorDialog(string message)
        {
            MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void UpdateStudentInformationSendStates(bool toggle)
        {
            Invoke((Action) delegate
            {
                this.label_StudentId.Visible = toggle;
                this.button_SendInformation.Enabled = toggle;
                this.button_SendInformation.Visible = toggle;
                this.textBox_studentId.Visible = toggle;

                this.button_ConnectToServer.Enabled = !toggle;
                this.label_ServerIp.Visible = this.textBox_ServerIP.Visible = !toggle;

            });
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                int received = clientSocket.EndReceive(ar);

                if (received == 0)
                {
                    return;
                }

                var studentInfo = StudentManager.ExtractStudentInformationFromClientMsg(buffer);


                if (studentInfo.IsExamStarted)
                {
                    SetInformationText(studentInfo.ExamStartedMessage);

                }
                else
                {
                    var examTime = string.Format("Your exam will start at {0} and end at {1}",
                        studentInfo.ExamStartTime.ToString(), studentInfo.ExamEndTime.ToString());
                    SetInformationText(examTime);

                }



                //this.label_InformationMesage.Text = connectionMessage.CustomMessage;


                // Start receiving data again.
                clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, this.SendCallback,
                    null);
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


        private delegate void SetTextCallback(string text);

        private void SetInformationText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.label_InformationMesage.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetInformationText);
                this.Invoke(d, new object[] {text});
            }
            else
            {
                this.label_InformationMesage.Text = text;
            }
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


        private void ConnectCallback(IAsyncResult AR)
        {
            try
            {
                clientSocket.EndConnect(AR);

                int received = clientSocket.EndReceive(AR);

                if (received == 0)
                {
                    return;
                }

                var studentInfo = StudentManager.ExtractStudentInformationFromClientMsg(buffer);

                //UpdateControlStates(true);
                buffer = new byte[clientSocket.ReceiveBufferSize];
                clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, SendCallback, null);
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

        

        
        private void button_DownloadQuestion_Click(object sender, EventArgs e)
        {

        }
    }
}