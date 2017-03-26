namespace Client
{
    partial class StudentInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_InformationMesage = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_DownloadQuestion = new System.Windows.Forms.Button();
            this.button_SendInformation = new System.Windows.Forms.Button();
            this.button_Answer = new System.Windows.Forms.Button();
            this.textBox_studentId = new System.Windows.Forms.TextBox();
            this.button_ConnectToServer = new System.Windows.Forms.Button();
            this.textBox_ServerIP = new System.Windows.Forms.TextBox();
            this.label_ServerIp = new System.Windows.Forms.Label();
            this.label_StudentId = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_InformationMesage
            // 
            this.label_InformationMesage.Enabled = false;
            this.label_InformationMesage.Location = new System.Drawing.Point(44, 207);
            this.label_InformationMesage.Margin = new System.Windows.Forms.Padding(2);
            this.label_InformationMesage.Multiline = true;
            this.label_InformationMesage.Name = "label_InformationMesage";
            this.label_InformationMesage.Size = new System.Drawing.Size(362, 59);
            this.label_InformationMesage.TabIndex = 14;
            this.label_InformationMesage.Text = "Not Connected to Server!";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.63523F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.36477F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.Controls.Add(this.button_DownloadQuestion, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_SendInformation, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Answer, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_studentId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_ConnectToServer, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_ServerIP, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_ServerIp, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_StudentId, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(44, 26);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(461, 77);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // button_DownloadQuestion
            // 
            this.button_DownloadQuestion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_DownloadQuestion.Location = new System.Drawing.Point(109, 38);
            this.button_DownloadQuestion.Name = "button_DownloadQuestion";
            this.button_DownloadQuestion.Size = new System.Drawing.Size(107, 35);
            this.button_DownloadQuestion.TabIndex = 0;
            this.button_DownloadQuestion.Text = "Save Questions";
            this.button_DownloadQuestion.UseVisualStyleBackColor = true;
            this.button_DownloadQuestion.Click += new System.EventHandler(this.button_DownloadQuestion_Click);
            // 
            // button_SendInformation
            // 
            this.button_SendInformation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_SendInformation.Location = new System.Drawing.Point(2, 41);
            this.button_SendInformation.Margin = new System.Windows.Forms.Padding(2);
            this.button_SendInformation.Name = "button_SendInformation";
            this.button_SendInformation.Size = new System.Drawing.Size(102, 29);
            this.button_SendInformation.TabIndex = 5;
            this.button_SendInformation.Text = "Send Information";
            this.button_SendInformation.UseVisualStyleBackColor = true;
            this.button_SendInformation.Click += new System.EventHandler(this.button_SendInformation_Click_1);
            // 
            // button_Answer
            // 
            this.button_Answer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Answer.Location = new System.Drawing.Point(232, 41);
            this.button_Answer.Margin = new System.Windows.Forms.Padding(2);
            this.button_Answer.Name = "button_Answer";
            this.button_Answer.Size = new System.Drawing.Size(97, 28);
            this.button_Answer.TabIndex = 11;
            this.button_Answer.Text = "Send Answer";
            this.button_Answer.UseVisualStyleBackColor = true;
            this.button_Answer.Click += new System.EventHandler(this.button_Answer_Click);
            // 
            // textBox_studentId
            // 
            this.textBox_studentId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_studentId.Location = new System.Drawing.Point(108, 7);
            this.textBox_studentId.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_studentId.Name = "textBox_studentId";
            this.textBox_studentId.Size = new System.Drawing.Size(109, 20);
            this.textBox_studentId.TabIndex = 1;
            // 
            // button_ConnectToServer
            // 
            this.button_ConnectToServer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_ConnectToServer.Location = new System.Drawing.Point(348, 41);
            this.button_ConnectToServer.Margin = new System.Windows.Forms.Padding(2);
            this.button_ConnectToServer.Name = "button_ConnectToServer";
            this.button_ConnectToServer.Size = new System.Drawing.Size(108, 29);
            this.button_ConnectToServer.TabIndex = 2;
            this.button_ConnectToServer.Text = "Connect";
            this.button_ConnectToServer.UseVisualStyleBackColor = true;
            this.button_ConnectToServer.Visible = false;
            // 
            // textBox_ServerIP
            // 
            this.textBox_ServerIP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_ServerIP.Location = new System.Drawing.Point(347, 7);
            this.textBox_ServerIP.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ServerIP.Name = "textBox_ServerIP";
            this.textBox_ServerIP.Size = new System.Drawing.Size(109, 20);
            this.textBox_ServerIP.TabIndex = 4;
            // 
            // label_ServerIp
            // 
            this.label_ServerIp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_ServerIp.AutoSize = true;
            this.label_ServerIp.Location = new System.Drawing.Point(235, 10);
            this.label_ServerIp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ServerIp.Name = "label_ServerIp";
            this.label_ServerIp.Size = new System.Drawing.Size(92, 13);
            this.label_ServerIp.TabIndex = 3;
            this.label_ServerIp.Text = "Server IP Address";
            // 
            // label_StudentId
            // 
            this.label_StudentId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_StudentId.AutoSize = true;
            this.label_StudentId.Location = new System.Drawing.Point(26, 10);
            this.label_StudentId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_StudentId.Name = "label_StudentId";
            this.label_StudentId.Size = new System.Drawing.Size(53, 13);
            this.label_StudentId.TabIndex = 0;
            this.label_StudentId.Text = "StudentId";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // StudentInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 561);
            this.Controls.Add(this.label_InformationMesage);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StudentInterface";
            this.Text = "StudentInterface";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox label_InformationMesage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_DownloadQuestion;
        private System.Windows.Forms.Button button_SendInformation;
        private System.Windows.Forms.Button button_Answer;
        private System.Windows.Forms.TextBox textBox_studentId;
        private System.Windows.Forms.Button button_ConnectToServer;
        private System.Windows.Forms.TextBox textBox_ServerIP;
        private System.Windows.Forms.Label label_ServerIp;
        private System.Windows.Forms.Label label_StudentId;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}