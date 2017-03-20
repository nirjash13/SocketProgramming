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
            this.button_SendInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_StudentId
            // 
            this.label_StudentId.AutoSize = true;
            this.label_StudentId.Location = new System.Drawing.Point(30, 55);
            this.label_StudentId.Name = "label_StudentId";
            this.label_StudentId.Size = new System.Drawing.Size(68, 17);
            this.label_StudentId.TabIndex = 0;
            this.label_StudentId.Text = "StudentId";
            // 
            // textBox_studentId
            // 
            this.textBox_studentId.Location = new System.Drawing.Point(117, 52);
            this.textBox_studentId.Name = "textBox_studentId";
            this.textBox_studentId.Size = new System.Drawing.Size(100, 22);
            this.textBox_studentId.TabIndex = 1;
            // 
            // button_SendInfo
            // 
            this.button_SendInfo.Location = new System.Drawing.Point(493, 273);
            this.button_SendInfo.Name = "button_SendInfo";
            this.button_SendInfo.Size = new System.Drawing.Size(145, 49);
            this.button_SendInfo.TabIndex = 2;
            this.button_SendInfo.Text = "Send Information";
            this.button_SendInfo.UseVisualStyleBackColor = true;
            // 
            // StudentConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 366);
            this.Controls.Add(this.button_SendInfo);
            this.Controls.Add(this.textBox_studentId);
            this.Controls.Add(this.label_StudentId);
            this.Name = "StudentConnectionForm";
            this.Text = "StudentConnectionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_StudentId;
        private System.Windows.Forms.TextBox textBox_studentId;
        private System.Windows.Forms.Button button_SendInfo;
    }
}