using System.Windows.Forms;

namespace ExamServer
{
    partial class ServerInterface
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
            this.label_ExamStartTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimePicker_ExamEndTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_ExamStartTime = new System.Windows.Forms.DateTimePicker();
            this.label_ExamEndTime = new System.Windows.Forms.Label();
            this.button_SaveExamConfig = new System.Windows.Forms.Button();
            this.panel_StudentInfo = new System.Windows.Forms.Panel();
            this.label_ConnectedStudent = new System.Windows.Forms.Label();
            this.dataGridView_StudentInfo = new System.Windows.Forms.DataGridView();
            this.StudentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.richTextBox_DirectionForUser = new System.Windows.Forms.RichTextBox();
            this.button_OpenQuestionFile = new System.Windows.Forms.Button();
            this.openFileDialog_Question = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.richTextBox_ExamTimeInfo = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_StudentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_StudentInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // label_ExamStartTime
            // 
            this.label_ExamStartTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_ExamStartTime.AutoSize = true;
            this.label_ExamStartTime.Location = new System.Drawing.Point(4, 6);
            this.label_ExamStartTime.Name = "label_ExamStartTime";
            this.label_ExamStartTime.Size = new System.Drawing.Size(84, 13);
            this.label_ExamStartTime.TabIndex = 0;
            this.label_ExamStartTime.Text = "Exam Start Time";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker_ExamEndTime, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker_ExamStartTime, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_ExamStartTime, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_ExamEndTime, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_SaveExamConfig, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(386, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(310, 83);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dateTimePicker_ExamEndTime
            // 
            this.dateTimePicker_ExamEndTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePicker_ExamEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_ExamEndTime.Location = new System.Drawing.Point(96, 29);
            this.dateTimePicker_ExamEndTime.Name = "dateTimePicker_ExamEndTime";
            this.dateTimePicker_ExamEndTime.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_ExamEndTime.TabIndex = 6;
            // 
            // dateTimePicker_ExamStartTime
            // 
            this.dateTimePicker_ExamStartTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePicker_ExamStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_ExamStartTime.Location = new System.Drawing.Point(96, 3);
            this.dateTimePicker_ExamStartTime.Name = "dateTimePicker_ExamStartTime";
            this.dateTimePicker_ExamStartTime.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_ExamStartTime.TabIndex = 5;
            // 
            // label_ExamEndTime
            // 
            this.label_ExamEndTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_ExamEndTime.AutoSize = true;
            this.label_ExamEndTime.Location = new System.Drawing.Point(6, 32);
            this.label_ExamEndTime.Name = "label_ExamEndTime";
            this.label_ExamEndTime.Size = new System.Drawing.Size(81, 13);
            this.label_ExamEndTime.TabIndex = 1;
            this.label_ExamEndTime.Text = "Exam End Time";
            // 
            // button_SaveExamConfig
            // 
            this.button_SaveExamConfig.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_SaveExamConfig.Location = new System.Drawing.Point(164, 56);
            this.button_SaveExamConfig.Name = "button_SaveExamConfig";
            this.button_SaveExamConfig.Size = new System.Drawing.Size(75, 23);
            this.button_SaveExamConfig.TabIndex = 2;
            this.button_SaveExamConfig.Text = "Save ";
            this.button_SaveExamConfig.UseVisualStyleBackColor = true;
            this.button_SaveExamConfig.Click += new System.EventHandler(this.button_SaveExamConfig_Click);
            // 
            // panel_StudentInfo
            // 
            this.panel_StudentInfo.Controls.Add(this.label_ConnectedStudent);
            this.panel_StudentInfo.Controls.Add(this.dataGridView_StudentInfo);
            this.panel_StudentInfo.Location = new System.Drawing.Point(51, 147);
            this.panel_StudentInfo.Name = "panel_StudentInfo";
            this.panel_StudentInfo.Size = new System.Drawing.Size(645, 450);
            this.panel_StudentInfo.TabIndex = 2;
            // 
            // label_ConnectedStudent
            // 
            this.label_ConnectedStudent.AutoSize = true;
            this.label_ConnectedStudent.Location = new System.Drawing.Point(32, 13);
            this.label_ConnectedStudent.Name = "label_ConnectedStudent";
            this.label_ConnectedStudent.Size = new System.Drawing.Size(104, 13);
            this.label_ConnectedStudent.TabIndex = 1;
            this.label_ConnectedStudent.Text = "Connected Students";
            // 
            // dataGridView_StudentInfo
            // 
            this.dataGridView_StudentInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_StudentInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentId,
            this.StudentIp});
            this.dataGridView_StudentInfo.Location = new System.Drawing.Point(32, 60);
            this.dataGridView_StudentInfo.Name = "dataGridView_StudentInfo";
            this.dataGridView_StudentInfo.Size = new System.Drawing.Size(326, 364);
            this.dataGridView_StudentInfo.TabIndex = 0;
            // 
            // StudentId
            // 
            this.StudentId.HeaderText = "Student Id";
            this.StudentId.Name = "StudentId";
            this.StudentId.ReadOnly = true;
            // 
            // StudentIp
            // 
            this.StudentIp.HeaderText = "StudentIp";
            this.StudentIp.Name = "StudentIp";
            this.StudentIp.ReadOnly = true;
            // 
            // richTextBox_DirectionForUser
            // 
            this.richTextBox_DirectionForUser.Location = new System.Drawing.Point(51, 12);
            this.richTextBox_DirectionForUser.Name = "richTextBox_DirectionForUser";
            this.richTextBox_DirectionForUser.ReadOnly = true;
            this.richTextBox_DirectionForUser.Size = new System.Drawing.Size(277, 36);
            this.richTextBox_DirectionForUser.TabIndex = 3;
            this.richTextBox_DirectionForUser.Text = "Please upload the question file and set exam start and exnd time. Otherwise they " +
    "will be set at a default location";
            // 
            // button_OpenQuestionFile
            // 
            this.button_OpenQuestionFile.Location = new System.Drawing.Point(51, 68);
            this.button_OpenQuestionFile.Name = "button_OpenQuestionFile";
            this.button_OpenQuestionFile.Size = new System.Drawing.Size(136, 27);
            this.button_OpenQuestionFile.TabIndex = 4;
            this.button_OpenQuestionFile.Text = "Choose Question File";
            this.button_OpenQuestionFile.UseVisualStyleBackColor = true;
            this.button_OpenQuestionFile.Click += new System.EventHandler(this.button_OpenQuestionFile_Click);
            // 
            // openFileDialog_Question
            // 
            this.openFileDialog_Question.FileName = "ServerQuestionFile";
            // 
            // richTextBox_ExamTimeInfo
            // 
            this.richTextBox_ExamTimeInfo.Enabled = false;
            this.richTextBox_ExamTimeInfo.Location = new System.Drawing.Point(386, 112);
            this.richTextBox_ExamTimeInfo.Name = "richTextBox_ExamTimeInfo";
            this.richTextBox_ExamTimeInfo.Size = new System.Drawing.Size(310, 29);
            this.richTextBox_ExamTimeInfo.TabIndex = 5;
            this.richTextBox_ExamTimeInfo.Text = "";
            // 
            // ServerInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 642);
            this.Controls.Add(this.richTextBox_ExamTimeInfo);
            this.Controls.Add(this.button_OpenQuestionFile);
            this.Controls.Add(this.richTextBox_DirectionForUser);
            this.Controls.Add(this.panel_StudentInfo);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ServerInterface";
            this.Text = "ServerInterface";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel_StudentInfo.ResumeLayout(false);
            this.panel_StudentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_StudentInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_ExamStartTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_ExamEndTime;
        private System.Windows.Forms.Button button_SaveExamConfig;
        private System.Windows.Forms.Panel panel_StudentInfo;
        private System.Windows.Forms.DataGridView dataGridView_StudentInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentIp;
        private System.Windows.Forms.Label label_ConnectedStudent;
        private System.Windows.Forms.RichTextBox richTextBox_DirectionForUser;
        private System.Windows.Forms.Button button_OpenQuestionFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Question;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ExamStartTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ExamEndTime;
        private RichTextBox richTextBox_ExamTimeInfo;
    }
}