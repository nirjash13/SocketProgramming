﻿namespace Client
{
    using System;
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

        private static void ShowErrorDialog(string message)
        {
            MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void UpdateStudentInformationSendStates(bool toggle)
        {
            Invoke((Action)delegate
            {
                this.label_StudentId.Visible = toggle;
                this.button_SendInformation.Enabled = toggle;
                this.button_SendInformation.Visible = toggle;
                this.textBox_studentId.Visible = toggle;

                this.button_ConnectToServer.Enabled = !toggle;
                this.label_ServerIp.Visible = this.textBox_ServerIP.Visible = !toggle;
                
            });
        }

        private void ReceiveExamInfoFromServer(IAsyncResult ar)
        {
            try
            {
                int received = clientSocket.EndReceive(ar);

                if (received == 0)
                {
                    return;
                }

                var connectionMessage = StudentManager.GetConnectionMessageFromServer(buffer);


                SetInformationText(connectionMessage.CustomMessage);
                //this.label_InformationMesage.Text = connectionMessage.CustomMessage;


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


        delegate void SetTextCallback(string text);

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
    }
}