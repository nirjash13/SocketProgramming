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



        private static void ShowErrorDialog(string message)
        {
            MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void StartServer()
        {
            try
            {
                //var content = this.ReadQuestionFile();
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, 3333));
                serverSocket.Listen(10);
                serverSocket.BeginAccept(AcceptCallbackOnConnect, null);
                
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

        private void AcceptCallbackOnConnect(IAsyncResult AR)
        {
            try
            {
                clientSocket = serverSocket.EndAccept(AR);
                buffer = new byte[clientSocket.ReceiveBufferSize];

                /*var student = StudentManager.ExtractStudentInformationFromClientMsg(buffer);

                StudentManager.SaveStudentInformation(student);

                var sendData = StudentManager.GetConnectionMessageForStudent(student);*/

                var sendData = StudentManager.GetConnectionMessageForStudent(); ;
                clientSocket.BeginSend(sendData, 0, sendData.Length, SocketFlags.None, SendCallback, null);
                // Listen for client data.
                clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallbackDataFromClient, null);
                // Continue listening for clients.
                serverSocket.BeginAccept(AcceptCallbackOnConnect, null);
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
            var filePath = ConfigurationManager.AppSettings["filePath"];

            var fullFilePath = AppDomain.CurrentDomain.BaseDirectory + filePath;
            if (File.Exists(fullFilePath))
            {
                byte[] content = File.ReadAllBytes(filePath);
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

        private void ReceiveCallbackDataFromClient(IAsyncResult AR)
        {
            try
            {

                int received = clientSocket.EndReceive(AR);

                if (received == 0)
                {
                    return;
                }

                /* var student = StudentManager.ExtractStudentInformationFromClientMsg(buffer);


                 this.SaveStudentInformation(student);*/

                //TO DO 
                // SubmitStudentToDataGrid(student);  


                //TODO: Send Questions from server to client

                clientSocket = serverSocket.EndAccept(AR);
                buffer = new byte[clientSocket.ReceiveBufferSize];

                var student = StudentManager.ExtractStudentInformationFromClientMsg(buffer);


                if (StudentManager.VerifyStudentId(student.StudentId))
                {
                    AddStudentToServerList(student);
                    if (StudentManager.IsExamStarted())
                    {
                        student.IsExamStarted = true;
                        StartReceivingAnswers(student);
                    }
                    else
                    {
                        student.IsExamStarted = false;
                        SendExamTimeToServer(student);

                    }
                    
                }

                else
                {
                    var sendData = StudentManager.GetInValidStudentIdMessage(student);

                    //var sendData = Encoding.ASCII.GetBytes("Connected To Server Successfully!");
                    clientSocket.BeginSend(sendData, 0, sendData.Length, SocketFlags.None, SendCallback, null);


                    // Start receiving data again.
                    clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallbackDataFromClient, null);

                }




                
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

        private void SendExamTimeToServer(StudentInformation student)
        {
            var sendData = StudentManager.GetExamTimeForStudent(student);

            //var sendData = Encoding.ASCII.GetBytes("Connected To Server Successfully!");
            clientSocket.BeginSend(sendData, 0, sendData.Length, SocketFlags.None, SendCallback, null);


            // Start receiving data again.
            clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveAnswersFromClient, null);
        }

        private void AddStudentToServerList( StudentInformation student)
        {
            IPEndPoint remoteIpEndPoint = clientSocket.RemoteEndPoint as IPEndPoint;

            if (remoteIpEndPoint != null)
            {
                // Using the RemoteEndPoint property.
                student.IPAddress = remoteIpEndPoint.Address.ToString();
            }

            var studentExists = StudentManager.CheckIfStudentAlreadyConnectedOnce(student.StudentId);

            if (!studentExists)
            {
                StudentManager.AddStudentToList(student);
            }
            else
            {
                //TODO: Optional
            }
        }

        private void StartReceivingAnswers(StudentInformation student)
        {
            

            //student.IPAddress = studentIp.ToString();
            //StudentManager.SaveStudentInformation(student);

            var sendData = StudentManager.GetQuestionForStudent(student);

            //var sendData = Encoding.ASCII.GetBytes("Connected To Server Successfully!");
            clientSocket.BeginSend(sendData, 0, sendData.Length, SocketFlags.None, SendCallback, null);


            // Start receiving data again.
            clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveAnswersFromClient, null);
        }

        private void ReceiveAnswersFromClient(IAsyncResult ar)
        {
            try
            {

                //TODO: Receive Answers from Client Here

                /*int received = clientSocket.EndReceive(AR);

                if (received == 0)
                {
                    return;
                }

                var student = StudentManager.ExtractStudentInformationFromClientMsg(buffer);


                this.SaveStudentInformation(student);

                //TO DO 
                // SubmitStudentToDataGrid(student);  


                //TODO: Send Questions from server to client

                clientSocket = serverSocket.EndAccept(AR);
                buffer = new byte[clientSocket.ReceiveBufferSize];

                /*var student = StudentManager.ExtractStudentInformationFromClientMsg(buffer);

                StudentManager.SaveStudentInformation(student);

                var sendData = StudentManager.GetConnectionMessageForStudent(student);#1#

                var sendData = Encoding.ASCII.GetBytes("Connected To Server Successfully!");
                clientSocket.BeginSend(sendData, 0, sendData.Length, SocketFlags.None, SendCallback, null);



                // Start receiving data again.
                clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveAnswersFromClient, null);*/
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

        private void SaveStudentInformation(StudentInformation studentInformation)
        {
            //var student = new StudentInformation();
            StudentManager.SaveAnswerIntoServer(studentInformation);
            if (studentInformation.OperationType == 1)
            {
                MessageBox.Show("Answers Received at Server. Please go to specific folder to read the answers",
                    "File received!", MessageBoxButtons.OK);
            }

        }

        private void button_OpenQuestionFile_Click(object sender, EventArgs e)
        {
            this.openFileDialog_Question.Filter = "Doc files | *.docx";
            openFileDialog_Question.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (openFileDialog_Question.ShowDialog() == DialogResult.OK) // if user clicked OK
            {
                String path = openFileDialog_Question.FileName; // get name of file
                /*using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open), new UTF8Encoding())) // do anything you want, e.g. read it
                {
                   
                }*/

                 

                var systemPath = System.Environment.
                             GetFolderPath(
                                 Environment.SpecialFolder.CommonApplicationData
                             );
                var complete = Path.Combine(systemPath, @"ExamServer\files\");
                QuestionFilePath = complete;
                if (!Directory.Exists(complete))
                {
                    Directory.CreateDirectory(complete);
                }

                var fileName = @"Questions.docx";

                StudentManager.FullQuestionFilePath = complete + fileName;

                try
                {
                    File.Copy(path, complete + fileName, true);
                }
                catch (Exception ex)
                {
                    ShowErrorDialog("File can not be uploaded!");
                }
                MessageBox.Show("File Uploaded Successfully to server!");
            }
        }

        private void button_SaveExamConfig_Click(object sender, EventArgs e)
        {
            var examStartTime = dateTimePicker_ExamStartTime.Value;
            var examEndTime = dateTimePicker_ExamEndTime.Value;

            ConfigurationManager.AppSettings["StartTime"] = examStartTime.ToString("dd/MM/yyyy HH:mm");
            ConfigurationManager.AppSettings["EndTime"] = examEndTime.ToString("dd/MM/yyyy HH:mm");

            StudentManager.examStartTime = examStartTime;
            StudentManager.examEndTime = examEndTime;

            richTextBox_ExamTimeInfo.Text = string.Format(@"Exam will start at {0} and will end at {1}",
                examStartTime.ToString("dd/MM/yyyy HH:mm"), examEndTime.ToString("dd/MM/yyyy HH:mm"));

            MessageBox.Show(
                "Exam times have been set successfully. You can change it any time through application config file");
        }

        /*private void SubmitStudentToDataGrid(StudentInformation student)
        {
            /* Invoke((Action)delegate
             {
                 dataGridView.Rows.Add(student.StudentId);
             });#1#
            var index = dataGridView.Rows.Add();
            dataGridView.Rows[index].Cells["Column1"].Value = student.StudentId;
            //DataGridViewRow row = (DataGridViewRow) dataGridView.Rows[0]
        }*/
    }
}
