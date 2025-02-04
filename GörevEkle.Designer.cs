namespace ProjectManagementApplication
{
    partial class GörevEkle
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
            this.components = new System.ComponentModel.Container();
            this.textBoxTaskName = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dateTimePickerTaskStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTaskFinishDate = new System.Windows.Forms.DateTimePicker();
            this.buttonOKTask = new System.Windows.Forms.Button();
            this.comboBoxEmployee = new System.Windows.Forms.ComboBox();
            this.textBoxPDValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxTaskName
            // 
            this.textBoxTaskName.Location = new System.Drawing.Point(326, 42);
            this.textBoxTaskName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxTaskName.Name = "textBoxTaskName";
            this.textBoxTaskName.Size = new System.Drawing.Size(112, 26);
            this.textBoxTaskName.TabIndex = 0;
            
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dateTimePickerTaskStartDate
            // 
            this.dateTimePickerTaskStartDate.Location = new System.Drawing.Point(326, 100);
            this.dateTimePickerTaskStartDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePickerTaskStartDate.Name = "dateTimePickerTaskStartDate";
            this.dateTimePickerTaskStartDate.Size = new System.Drawing.Size(224, 26);
            this.dateTimePickerTaskStartDate.TabIndex = 2;
            // 
            // dateTimePickerTaskFinishDate
            // 
            this.dateTimePickerTaskFinishDate.Location = new System.Drawing.Point(326, 162);
            this.dateTimePickerTaskFinishDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePickerTaskFinishDate.Name = "dateTimePickerTaskFinishDate";
            this.dateTimePickerTaskFinishDate.Size = new System.Drawing.Size(224, 26);
            this.dateTimePickerTaskFinishDate.TabIndex = 3;
            // 
            // buttonOKTask
            // 
            this.buttonOKTask.Location = new System.Drawing.Point(293, 411);
            this.buttonOKTask.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonOKTask.Name = "buttonOKTask";
            this.buttonOKTask.Size = new System.Drawing.Size(84, 29);
            this.buttonOKTask.TabIndex = 4;
            this.buttonOKTask.Text = "Kaydet";
            this.buttonOKTask.UseVisualStyleBackColor = true;
            this.buttonOKTask.Click += new System.EventHandler(this.buttonOKTask_Click);
            // 
            // comboBoxEmployee
            // 
            this.comboBoxEmployee.FormattingEnabled = true;
            this.comboBoxEmployee.Location = new System.Drawing.Point(326, 276);
            this.comboBoxEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxEmployee.Name = "comboBoxEmployee";
            this.comboBoxEmployee.Size = new System.Drawing.Size(136, 28);
            this.comboBoxEmployee.TabIndex = 5;
            // 
            // textBoxPDValue
            // 
            this.textBoxPDValue.Location = new System.Drawing.Point(326, 213);
            this.textBoxPDValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPDValue.Name = "textBoxPDValue";
            this.textBoxPDValue.Size = new System.Drawing.Size(112, 26);
            this.textBoxPDValue.TabIndex = 6;
           
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Görev Adı:";
           
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Başlangıç Tarihi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Bitiş Tarihi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(163, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Adam Gün Değeri:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(136, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Görevlendirelecek Kişi:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Tamamlanacak ",
            "Devam Ediyor",
            "Tamamlandı"});
            this.comboBox1.Location = new System.Drawing.Point(326, 346);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(144, 28);
            this.comboBox1.TabIndex = 12;
           
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(180, 349);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Görev Durumu:";
            // 
            // AddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPDValue);
            this.Controls.Add(this.comboBoxEmployee);
            this.Controls.Add(this.buttonOKTask);
            this.Controls.Add(this.dateTimePickerTaskFinishDate);
            this.Controls.Add(this.dateTimePickerTaskStartDate);
            this.Controls.Add(this.textBoxTaskName);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AddTask";
            this.Text = "AddTask";
            this.Load += new System.EventHandler(this.AddTask_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTaskName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DateTimePicker dateTimePickerTaskStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerTaskFinishDate;
        private System.Windows.Forms.Button buttonOKTask;
        private System.Windows.Forms.ComboBox comboBoxEmployee;
        private System.Windows.Forms.TextBox textBoxPDValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
    }
}