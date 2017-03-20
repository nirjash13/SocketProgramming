using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Common;

namespace Client
{
    public partial class ClientForm : Form
    {
        private Socket clientSocket;
        private byte[] buffer;

        public ClientForm()
        {
            InitializeComponent();
        }

        private static void ShowErrorDialog(string message)
        {
            MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ReceiveExamInfoFromServer(IAsyncResult AR)
        {
            try
            {
                int received = clientSocket.EndReceive(AR);

                if (received == 0)
                {
                    return;
                }

                /*var questionDir = @"questions";

                if (!Directory.Exists(questionDir))
                {
                    Directory.CreateDirectory(questionDir);
                }
                
                var filePath = @"questions/" + textBoxStudent.Text+ ".txt";
                //string message = Encoding.ASCII.GetString(buffer);

                File.WriteAllBytes(filePath, buffer);

                var answerDir = @"Answers/" + textBoxStudent.Text;
                Directory.CreateDirectory(answerDir);
                MessageBox.Show(@"File Sent from Server");
                Invoke((Action)delegate
               {
                   Text = @"Server says: " + @"File Sent from server";
               });*/


                var msg = StudentManager.GetConnectionMessageFromServer(buffer);


                // Start receiving data again.
                clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, this.ReceiveExamInfoFromServer, null);
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

        private void ReceiveCallBackMessageOnConnection(IAsyncResult AR)
        {
            try
            {
                clientSocket.EndConnect(AR);
                UpdateControlStates(true);
                buffer = new byte[clientSocket.ReceiveBufferSize];
                clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, this.ReceiveExamInfoFromServer, null);
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

        
        private void UpdateControlStates(bool toggle)
        {
            Invoke((Action)delegate
            {
                buttonSend.Enabled = toggle;
                buttonConnect.Enabled = !toggle;
                labelIP.Visible = textBoxAddress.Visible = !toggle;
            });
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
                var studentId = Int32.Parse(textBoxStudent.Text);
                var ip = textBoxAddress.Text;

                //TODO: add file Data

                var path = @"Answers/" + textBoxStudent.Text + "/answer.txt"; ;

                var fileData = File.ReadAllBytes(path);

                var student = new StudentInformation();
                student.StudentId = studentId;
                student.IPAddress = ip;
                student.OperationType = 1;
                //student.FileData = fileData;




                byte[] buffer = StudentManager.ConvertMessageToStudentInformation(student);

                clientSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, SendCallback, null);

                MessageBox.Show("Answers submitted to server", "Submission Successful", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
                UpdateControlStates(false);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
                UpdateControlStates(false);
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //var studentId = Int32.Parse(textBoxStudent.Text);
                var ip = textBoxAddress.Text;



                /*var student = new StudentInformation();
                student.StudentId = studentId;
                student.IPAddress = ip;
                student.OperationType = 0;

                byte[] buffer = StudentManager.ConvertMessageToStudentInformation(student);*/

                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // Connect to the specified host.
                var endPoint = new IPEndPoint(IPAddress.Parse(textBoxAddress.Text), 3333);
                clientSocket.BeginConnect(endPoint, ReceiveCallBackMessageOnConnection, null);


                //clientSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, SendCallback, null);
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

        
    }
}
