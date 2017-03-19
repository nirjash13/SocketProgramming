using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Common;

namespace ExamServer
{
    using System.Text;

    public partial class ServerForm : Form
    {
        private Socket serverSocket;
        private Socket clientSocket; 
        private byte[] buffer;
        public ServerForm()
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

                StudentManager.SaveStudentInformation(student);

                var sendData = StudentManager.GetConnectionMessageForStudent();

                //var sendData = Encoding.ASCII.GetBytes("Connected To Server Successfully!");
                clientSocket.BeginSend(sendData, 0, sendData.Length, SocketFlags.None, SendCallback, null);



                // Start receiving data again.
                clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveAnswersFromClient, null);
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

        private void SubmitStudentToDataGrid(StudentInformation student)
        {
            /* Invoke((Action)delegate
             {
                 dataGridView.Rows.Add(student.StudentId);
             });*/
            var index = dataGridView.Rows.Add();
            dataGridView.Rows[index].Cells["Column1"].Value = student.StudentId;
            //DataGridViewRow row = (DataGridViewRow) dataGridView.Rows[0]
        }
    }
}
