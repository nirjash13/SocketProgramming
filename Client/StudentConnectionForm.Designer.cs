namespace Client
{
    partial class StudentConnectionForm
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
            this.label_StudentId = new System.Windows.Forms.Label();
            this.textBox_studentId = new System.Windows.Forms.TextBox();
            this.button_ConnectToServer = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_SendInformation = new System.Windows.Forms.Button();
            this.textBox_ServerIP = new System.Windows.Forms.TextBox();
            this.label_ServerIp = new System.Windows.Forms.Label();
            this.splitContainer_QA = new System.Windows.Forms.SplitContainer();
            this.label_AnswerQuestionsBelow = new System.Windows.Forms.Label();
            this.button_Answer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_Question = new System.Windows.Forms.TextBox();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.label_PrevAnsweredQuestion = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.AnsweredQuestionNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AnsweredQuestionText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label_InformationMesage = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_QA)).BeginInit();
            this.splitContainer_QA.Panel1.SuspendLayout();
            this.splitContainer_QA.Panel2.SuspendLayout();
            this.splitContainer_QA.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_StudentId
            // 
            this.label_StudentId.AutoSize = true;
            this.label_StudentId.Location = new System.Drawing.Point(3, 0);
            this.label_StudentId.Name = "label_StudentId";
            this.label_StudentId.Size = new System.Drawing.Size(68, 17);
            this.label_StudentId.TabIndex = 0;
            this.label_StudentId.Text = "StudentId";
            this.label_StudentId.Visible = false;
            // 
            // textBox_studentId
            // 
            this.textBox_studentId.Location = new System.Drawing.Point(170, 3);
            this.textBox_studentId.Name = "textBox_studentId";
            this.textBox_studentId.Size = new System.Drawing.Size(145, 22);
            this.textBox_studentId.TabIndex = 1;
            this.textBox_studentId.Visible = false;
            // 
            // button_ConnectToServer
            // 
            this.button_ConnectToServer.Location = new System.Drawing.Point(511, 36);
            this.button_ConnectToServer.Name = "button_ConnectToServer";
            this.button_ConnectToServer.Size = new System.Drawing.Size(144, 36);
            this.button_ConnectToServer.TabIndex = 2;
            this.button_ConnectToServer.Text = "Connect";
            this.button_ConnectToServer.UseVisualStyleBackColor = true;
            this.button_ConnectToServer.Click += new System.EventHandler(this.button_ConnectToServer_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.63523F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.36477F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.button_SendInformation, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_studentId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_StudentId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_ConnectToServer, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_ServerIP, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_ServerIp, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(659, 75);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // button_SendInformation
            // 
            this.button_SendInformation.Location = new System.Drawing.Point(3, 36);
            this.button_SendInformation.Name = "button_SendInformation";
            this.button_SendInformation.Size = new System.Drawing.Size(145, 36);
            this.button_SendInformation.TabIndex = 5;
            this.button_SendInformation.Text = "Send Information";
            this.button_SendInformation.UseVisualStyleBackColor = true;
            this.button_SendInformation.Visible = false;
            this.button_SendInformation.Click += new System.EventHandler(this.button_SendInformation_Click);
            // 
            // textBox_ServerIP
            // 
            this.textBox_ServerIP.Location = new System.Drawing.Point(511, 3);
            this.textBox_ServerIP.Name = "textBox_ServerIP";
            this.textBox_ServerIP.Size = new System.Drawing.Size(144, 22);
            this.textBox_ServerIP.TabIndex = 4;
            // 
            // label_ServerIp
            // 
            this.label_ServerIp.AutoSize = true;
            this.label_ServerIp.Location = new System.Drawing.Point(346, 0);
            this.label_ServerIp.Name = "label_ServerIp";
            this.label_ServerIp.Size = new System.Drawing.Size(122, 17);
            this.label_ServerIp.TabIndex = 3;
            this.label_ServerIp.Text = "Server IP Address";
            // 
            // splitContainer_QA
            // 
            this.splitContainer_QA.Location = new System.Drawing.Point(12, 115);
            this.splitContainer_QA.Name = "splitContainer_QA";
            // 
            // splitContainer_QA.Panel1
            // 
            this.splitContainer_QA.Panel1.Controls.Add(this.label_AnswerQuestionsBelow);
            this.splitContainer_QA.Panel1.Controls.Add(this.button_Answer);
            this.splitContainer_QA.Panel1.Controls.Add(this.panel1);
            this.splitContainer_QA.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer_QA.Panel2
            // 
            this.splitContainer_QA.Panel2.Controls.Add(this.label_PrevAnsweredQuestion);
            this.splitContainer_QA.Panel2.Controls.Add(this.listView1);
            this.splitContainer_QA.Size = new System.Drawing.Size(1226, 542);
            this.splitContainer_QA.SplitterDistance = 803;
            this.splitContainer_QA.TabIndex = 4;
            // 
            // label_AnswerQuestionsBelow
            // 
            this.label_AnswerQuestionsBelow.AutoSize = true;
            this.label_AnswerQuestionsBelow.Location = new System.Drawing.Point(15, 72);
            this.label_AnswerQuestionsBelow.Name = "label_AnswerQuestionsBelow";
            this.label_AnswerQuestionsBelow.Size = new System.Drawing.Size(169, 17);
            this.label_AnswerQuestionsBelow.TabIndex = 3;
            this.label_AnswerQuestionsBelow.Text = "Write your answers below";
            // 
            // button_Answer
            // 
            this.button_Answer.Location = new System.Drawing.Point(197, 483);
            this.button_Answer.Name = "button_Answer";
            this.button_Answer.Size = new System.Drawing.Size(129, 35);
            this.button_Answer.TabIndex = 2;
            this.button_Answer.Text = "Send Answer";
            this.button_Answer.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Location = new System.Drawing.Point(12, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(581, 350);
            this.panel1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(575, 344);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.77741F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.22259F));
            this.tableLayoutPanel2.Controls.Add(this.textBox_Question, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelQuestion, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 15);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(534, 50);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // textBox_Question
            // 
            this.textBox_Question.Enabled = false;
            this.textBox_Question.Location = new System.Drawing.Point(92, 3);
            this.textBox_Question.Multiline = true;
            this.textBox_Question.Name = "textBox_Question";
            this.textBox_Question.Size = new System.Drawing.Size(439, 44);
            this.textBox_Question.TabIndex = 7;
            this.textBox_Question.Text = "Your Question will appear here!";
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Location = new System.Drawing.Point(3, 0);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(72, 17);
            this.labelQuestion.TabIndex = 0;
            this.labelQuestion.Text = "Questions";
            // 
            // label_PrevAnsweredQuestion
            // 
            this.label_PrevAnsweredQuestion.AutoSize = true;
            this.label_PrevAnsweredQuestion.Location = new System.Drawing.Point(13, 27);
            this.label_PrevAnsweredQuestion.Name = "label_PrevAnsweredQuestion";
            this.label_PrevAnsweredQuestion.Size = new System.Drawing.Size(197, 17);
            this.label_PrevAnsweredQuestion.TabIndex = 1;
            this.label_PrevAnsweredQuestion.Text = "Previous Answered Questions";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AnsweredQuestionNumber,
            this.AnsweredQuestionText});
            this.listView1.Location = new System.Drawing.Point(13, 112);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(363, 347);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label_InformationMesage
            // 
            this.label_InformationMesage.Enabled = false;
            this.label_InformationMesage.Location = new System.Drawing.Point(713, 12);
            this.label_InformationMesage.Multiline = true;
            this.label_InformationMesage.Name = "label_InformationMesage";
            this.label_InformationMesage.Size = new System.Drawing.Size(482, 72);
            this.label_InformationMesage.TabIndex = 6;
            this.label_InformationMesage.Text = "Not Connected to Server!";
            // 
            // StudentConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 746);
            this.Controls.Add(this.label_InformationMesage);
            this.Controls.Add(this.splitContainer_QA);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StudentConnectionForm";
            this.Text = "StudentConnectionForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer_QA.Panel1.ResumeLayout(false);
            this.splitContainer_QA.Panel1.PerformLayout();
            this.splitContainer_QA.Panel2.ResumeLayout(false);
            this.splitContainer_QA.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_QA)).EndInit();
            this.splitContainer_QA.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_StudentId;
        private System.Windows.Forms.TextBox textBox_studentId;
        private System.Windows.Forms.Button button_ConnectToServer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer_QA;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Button button_Answer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader AnsweredQuestionNumber;
        private System.Windows.Forms.ColumnHeader AnsweredQuestionText;
        private System.Windows.Forms.Label label_AnswerQuestionsBelow;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label_PrevAnsweredQuestion;
        private System.Windows.Forms.Button button_SendInformation;
        private System.Windows.Forms.TextBox textBox_ServerIP;
        private System.Windows.Forms.Label label_ServerIp;
        private System.Windows.Forms.TextBox label_InformationMesage;
        private System.Windows.Forms.TextBox textBox_Question;
    }
}