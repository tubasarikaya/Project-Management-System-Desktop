namespace ProjectManagementApplication
{
    partial class ProjeEkle
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
            this.textBoxProjectName = new System.Windows.Forms.TextBox();
            this.dateTimePickerProjectStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerProjectFinishDate = new System.Windows.Forms.DateTimePicker();
            this.buttonOKProject = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxProjectName
            // 
            this.textBoxProjectName.Location = new System.Drawing.Point(336, 82);
            this.textBoxProjectName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxProjectName.Name = "textBoxProjectName";
            this.textBoxProjectName.Size = new System.Drawing.Size(112, 26);
            this.textBoxProjectName.TabIndex = 0;
            // 
            // dateTimePickerProjectStartDate
            // 
            this.dateTimePickerProjectStartDate.Location = new System.Drawing.Point(336, 142);
            this.dateTimePickerProjectStartDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePickerProjectStartDate.Name = "dateTimePickerProjectStartDate";
            this.dateTimePickerProjectStartDate.Size = new System.Drawing.Size(224, 26);
            this.dateTimePickerProjectStartDate.TabIndex = 1;
            // 
            // dateTimePickerProjectFinishDate
            // 
            this.dateTimePickerProjectFinishDate.Location = new System.Drawing.Point(336, 211);
            this.dateTimePickerProjectFinishDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePickerProjectFinishDate.Name = "dateTimePickerProjectFinishDate";
            this.dateTimePickerProjectFinishDate.Size = new System.Drawing.Size(224, 26);
            this.dateTimePickerProjectFinishDate.TabIndex = 2;
            // 
            // buttonOKProject
            // 
            this.buttonOKProject.Location = new System.Drawing.Point(316, 296);
            this.buttonOKProject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonOKProject.Name = "buttonOKProject";
            this.buttonOKProject.Size = new System.Drawing.Size(90, 29);
            this.buttonOKProject.TabIndex = 3;
            this.buttonOKProject.Text = "KAYDET";
            this.buttonOKProject.UseVisualStyleBackColor = true;
            this.buttonOKProject.Click += new System.EventHandler(this.buttonOKProject_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(254, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Proje Adı:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Başlangıç Tarihi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bitiş Tarihi:";
            // 
            // ProjeEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOKProject);
            this.Controls.Add(this.dateTimePickerProjectFinishDate);
            this.Controls.Add(this.dateTimePickerProjectStartDate);
            this.Controls.Add(this.textBoxProjectName);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProjeEkle";
            this.Text = "AddProject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxProjectName;
        private System.Windows.Forms.DateTimePicker dateTimePickerProjectStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerProjectFinishDate;
        private System.Windows.Forms.Button buttonOKProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}