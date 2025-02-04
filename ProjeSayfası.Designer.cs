namespace ProjectManagementApplication
{
    partial class ProjeSayfası
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddProjectButton = new System.Windows.Forms.Button();
            this.leftpanel = new System.Windows.Forms.Panel();
            this.flowProjectList = new System.Windows.Forms.FlowLayoutPanel();
            this.AddTaskButton = new System.Windows.Forms.Button();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.listtaskpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.projectdetailspanel = new System.Windows.Forms.Panel();
            this.labelProjectDelay = new System.Windows.Forms.Label();
            this.labelProjectFinishDate = new System.Windows.Forms.Label();
            this.labelProjectStartDate = new System.Windows.Forms.Label();
            this.labelProjectName = new System.Windows.Forms.Label();
            this.labelProjectDetails = new System.Windows.Forms.Label();
            this.leftpanel.SuspendLayout();
            this.mainpanel.SuspendLayout();
            this.listtaskpanel.SuspendLayout();
            this.projectdetailspanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddProjectButton
            // 
            this.AddProjectButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.AddProjectButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddProjectButton.ForeColor = System.Drawing.Color.White;
            this.AddProjectButton.Location = new System.Drawing.Point(10, 10);
            this.AddProjectButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.AddProjectButton.Name = "AddProjectButton";
            this.AddProjectButton.Size = new System.Drawing.Size(230, 40);
            this.AddProjectButton.TabIndex = 0;
            this.AddProjectButton.Text = "Yeni Proje+";
            this.AddProjectButton.UseVisualStyleBackColor = false;
            this.AddProjectButton.Click += new System.EventHandler(this.AddProjectButton_Click);
            // 
            // leftpanel
            // 
            this.leftpanel.BackColor = System.Drawing.Color.White;
            this.leftpanel.Controls.Add(this.flowProjectList);
            this.leftpanel.Controls.Add(this.AddProjectButton);
            this.leftpanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftpanel.Location = new System.Drawing.Point(10, 10);
            this.leftpanel.Name = "leftpanel";
            this.leftpanel.Padding = new System.Windows.Forms.Padding(10);
            this.leftpanel.Size = new System.Drawing.Size(250, 724);
            this.leftpanel.TabIndex = 3;
            // 
            // flowProjectList
            // 
            this.flowProjectList.AutoScroll = true;
            this.flowProjectList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowProjectList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowProjectList.Location = new System.Drawing.Point(10, 50);
            this.flowProjectList.Name = "flowProjectList";
            this.flowProjectList.Size = new System.Drawing.Size(230, 664);
            this.flowProjectList.TabIndex = 1;
            this.flowProjectList.WrapContents = false;
            // 
            // AddTaskButton
            // 
            this.AddTaskButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.AddTaskButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddTaskButton.ForeColor = System.Drawing.Color.White;
            this.AddTaskButton.Location = new System.Drawing.Point(13, 15);
            this.AddTaskButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.AddTaskButton.Name = "AddTaskButton";
            this.AddTaskButton.Size = new System.Drawing.Size(132, 35);
            this.AddTaskButton.TabIndex = 2;
            this.AddTaskButton.Text = "Yeni Görev+";
            this.AddTaskButton.UseVisualStyleBackColor = false;
            this.AddTaskButton.Click += new System.EventHandler(this.AddTaskButton_Click);
            // 
            // mainpanel
            // 
            this.mainpanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mainpanel.Controls.Add(this.listtaskpanel);
            this.mainpanel.Controls.Add(this.projectdetailspanel);
            this.mainpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainpanel.Location = new System.Drawing.Point(260, 10);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainpanel.Size = new System.Drawing.Size(908, 724);
            this.mainpanel.TabIndex = 4;
            // 
            // listtaskpanel
            // 
            this.listtaskpanel.AutoScroll = true;
            this.listtaskpanel.BackColor = System.Drawing.Color.White;
            this.listtaskpanel.Controls.Add(this.AddTaskButton);
            this.listtaskpanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listtaskpanel.Location = new System.Drawing.Point(20, 256);
            this.listtaskpanel.Name = "listtaskpanel";
            this.listtaskpanel.Padding = new System.Windows.Forms.Padding(10);
            this.listtaskpanel.Size = new System.Drawing.Size(868, 448);
            this.listtaskpanel.TabIndex = 1;
            // 
            // projectdetailspanel
            // 
            this.projectdetailspanel.BackColor = System.Drawing.Color.White;
            this.projectdetailspanel.Controls.Add(this.labelProjectDelay);
            this.projectdetailspanel.Controls.Add(this.labelProjectFinishDate);
            this.projectdetailspanel.Controls.Add(this.labelProjectStartDate);
            this.projectdetailspanel.Controls.Add(this.labelProjectName);
            this.projectdetailspanel.Controls.Add(this.labelProjectDetails);
            this.projectdetailspanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.projectdetailspanel.Location = new System.Drawing.Point(20, 20);
            this.projectdetailspanel.Name = "projectdetailspanel";
            this.projectdetailspanel.Padding = new System.Windows.Forms.Padding(20);
            this.projectdetailspanel.Size = new System.Drawing.Size(868, 213);
            this.projectdetailspanel.TabIndex = 0;
            // 
            // labelProjectDelay
            // 
            this.labelProjectDelay.AutoSize = true;
            this.labelProjectDelay.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelProjectDelay.Location = new System.Drawing.Point(34, 160);
            this.labelProjectDelay.Name = "labelProjectDelay";
            this.labelProjectDelay.Size = new System.Drawing.Size(139, 21);
            this.labelProjectDelay.TabIndex = 5;
            this.labelProjectDelay.Text = "Gecikme Miktarı:";
            // 
            // labelProjectFinishDate
            // 
            this.labelProjectFinishDate.AutoSize = true;
            this.labelProjectFinishDate.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelProjectFinishDate.Location = new System.Drawing.Point(34, 125);
            this.labelProjectFinishDate.Name = "labelProjectFinishDate";
            this.labelProjectFinishDate.Size = new System.Drawing.Size(94, 21);
            this.labelProjectFinishDate.TabIndex = 4;
            this.labelProjectFinishDate.Text = "Bitiş Tarihi:";
            // 
            // labelProjectStartDate
            // 
            this.labelProjectStartDate.AutoSize = true;
            this.labelProjectStartDate.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelProjectStartDate.Location = new System.Drawing.Point(34, 88);
            this.labelProjectStartDate.Name = "labelProjectStartDate";
            this.labelProjectStartDate.Size = new System.Drawing.Size(134, 21);
            this.labelProjectStartDate.TabIndex = 3;
            this.labelProjectStartDate.Text = "Başlangıç Tarihi:";
            // 
            // labelProjectName
            // 
            this.labelProjectName.AutoSize = true;
            this.labelProjectName.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelProjectName.Location = new System.Drawing.Point(34, 54);
            this.labelProjectName.Name = "labelProjectName";
            this.labelProjectName.Size = new System.Drawing.Size(84, 21);
            this.labelProjectName.TabIndex = 2;
            this.labelProjectName.Text = "Proje Adı:";
            // 
            // labelProjectDetails
            // 
            this.labelProjectDetails.AutoSize = true;
            this.labelProjectDetails.Location = new System.Drawing.Point(20, 20);
            this.labelProjectDetails.Name = "labelProjectDetails";
            this.labelProjectDetails.Size = new System.Drawing.Size(138, 25);
            this.labelProjectDetails.TabIndex = 1;
            this.labelProjectDetails.Text = "Proje Detayları";
            // 
            // ProjeSayfası
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 744);
            this.Controls.Add(this.mainpanel);
            this.Controls.Add(this.leftpanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ProjeSayfası";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Proje Yönetimi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.leftpanel.ResumeLayout(false);
            this.mainpanel.ResumeLayout(false);
            this.listtaskpanel.ResumeLayout(false);
            this.projectdetailspanel.ResumeLayout(false);
            this.projectdetailspanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AddProjectButton;
        private System.Windows.Forms.Panel leftpanel;
        private System.Windows.Forms.FlowLayoutPanel flowProjectList;
        private System.Windows.Forms.Button AddTaskButton;
        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.Label labelProjectDetails;
        private System.Windows.Forms.FlowLayoutPanel listtaskpanel;
        private System.Windows.Forms.Panel projectdetailspanel;
        private System.Windows.Forms.Label labelProjectDelay;
        private System.Windows.Forms.Label labelProjectFinishDate;
        private System.Windows.Forms.Label labelProjectStartDate;
        private System.Windows.Forms.Label labelProjectName;
    }
}