namespace ProjectManagementApplication
{
    partial class ÇalışanProjeDetay
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
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel completedTasksPanel;
        private System.Windows.Forms.Panel ongoingTasksPanel;
        private System.Windows.Forms.Panel pendingTasksPanel;
        private System.Windows.Forms.Label lblCompletedTasks;
        private System.Windows.Forms.Label lblOngoingTasks;
        private System.Windows.Forms.Label lblPendingTasks;
        private System.Windows.Forms.Label lblCompletedDesc;
        private System.Windows.Forms.Label lblOngoingDesc;
        private System.Windows.Forms.Label lblPendingDesc;
        private System.Windows.Forms.Panel completedColorBar;
        private System.Windows.Forms.Panel ongoingColorBar;
        private System.Windows.Forms.Panel pendingColorBar;
        private System.Windows.Forms.FlowLayoutPanel completedTasksFlow;
        private System.Windows.Forms.FlowLayoutPanel ongoingTasksFlow;
        private System.Windows.Forms.FlowLayoutPanel pendingTasksFlow;

        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.completedTasksPanel = new System.Windows.Forms.Panel();
            this.completedColorBar = new System.Windows.Forms.Panel();
            this.lblCompletedTasks = new System.Windows.Forms.Label();
            this.lblCompletedDesc = new System.Windows.Forms.Label();
            this.completedTasksFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.ongoingTasksPanel = new System.Windows.Forms.Panel();
            this.ongoingColorBar = new System.Windows.Forms.Panel();
            this.lblOngoingTasks = new System.Windows.Forms.Label();
            this.lblOngoingDesc = new System.Windows.Forms.Label();
            this.ongoingTasksFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.pendingTasksPanel = new System.Windows.Forms.Panel();
            this.pendingColorBar = new System.Windows.Forms.Panel();
            this.lblPendingTasks = new System.Windows.Forms.Label();
            this.lblPendingDesc = new System.Windows.Forms.Label();
            this.pendingTasksFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.mainPanel.SuspendLayout();
            this.completedTasksPanel.SuspendLayout();
            this.ongoingTasksPanel.SuspendLayout();
            this.pendingTasksPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.mainPanel.Controls.Add(this.completedTasksPanel);
            this.mainPanel.Controls.Add(this.completedTasksFlow);
            this.mainPanel.Controls.Add(this.ongoingTasksPanel);
            this.mainPanel.Controls.Add(this.ongoingTasksFlow);
            this.mainPanel.Controls.Add(this.pendingTasksPanel);
            this.mainPanel.Controls.Add(this.pendingTasksFlow);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.mainPanel.Size = new System.Drawing.Size(1310, 746);
            this.mainPanel.TabIndex = 0;
            // 
            // completedTasksPanel
            // 
            this.completedTasksPanel.BackColor = System.Drawing.Color.White;
            this.completedTasksPanel.Controls.Add(this.completedColorBar);
            this.completedTasksPanel.Controls.Add(this.lblCompletedTasks);
            this.completedTasksPanel.Controls.Add(this.lblCompletedDesc);
            this.completedTasksPanel.Location = new System.Drawing.Point(218, 39);
            this.completedTasksPanel.Name = "completedTasksPanel";
            this.completedTasksPanel.Padding = new System.Windows.Forms.Padding(15);
            this.completedTasksPanel.Size = new System.Drawing.Size(769, 60);
            this.completedTasksPanel.TabIndex = 0;
            // 
            // completedColorBar
            // 
            this.completedColorBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.completedColorBar.Location = new System.Drawing.Point(0, 10);
            this.completedColorBar.Name = "completedColorBar";
            this.completedColorBar.Size = new System.Drawing.Size(4, 40);
            this.completedColorBar.TabIndex = 0;
            // 
            // lblCompletedTasks
            // 
            this.lblCompletedTasks.AutoSize = true;
            this.lblCompletedTasks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCompletedTasks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblCompletedTasks.Location = new System.Drawing.Point(15, 10);
            this.lblCompletedTasks.Name = "lblCompletedTasks";
            this.lblCompletedTasks.Size = new System.Drawing.Size(264, 32);
            this.lblCompletedTasks.TabIndex = 1;
            this.lblCompletedTasks.Text = "Tamamlanan Görevler";
            // 
            // lblCompletedDesc
            // 
            this.lblCompletedDesc.AutoSize = true;
            this.lblCompletedDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCompletedDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblCompletedDesc.Location = new System.Drawing.Point(15, 35);
            this.lblCompletedDesc.Name = "lblCompletedDesc";
            this.lblCompletedDesc.Size = new System.Drawing.Size(262, 25);
            this.lblCompletedDesc.TabIndex = 2;
            this.lblCompletedDesc.Text = "Başarıyla tamamlanmış görevler";
            // 
            // completedTasksFlow
            // 
            this.completedTasksFlow.AutoScroll = true;
            this.completedTasksFlow.AutoSize = true;
            this.completedTasksFlow.BackColor = System.Drawing.Color.White;
            this.completedTasksFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.completedTasksFlow.Location = new System.Drawing.Point(258, 105);
            this.completedTasksFlow.Name = "completedTasksFlow";
            this.completedTasksFlow.Size = new System.Drawing.Size(707, 120);
            this.completedTasksFlow.TabIndex = 1;
            this.completedTasksFlow.WrapContents = false;
            this.completedTasksFlow.Paint += new System.Windows.Forms.PaintEventHandler(this.completedTasksFlow_Paint);
            // 
            // ongoingTasksPanel
            // 
            this.ongoingTasksPanel.BackColor = System.Drawing.Color.White;
            this.ongoingTasksPanel.Controls.Add(this.ongoingColorBar);
            this.ongoingTasksPanel.Controls.Add(this.lblOngoingTasks);
            this.ongoingTasksPanel.Controls.Add(this.lblOngoingDesc);
            this.ongoingTasksPanel.Location = new System.Drawing.Point(218, 266);
            this.ongoingTasksPanel.Name = "ongoingTasksPanel";
            this.ongoingTasksPanel.Padding = new System.Windows.Forms.Padding(15);
            this.ongoingTasksPanel.Size = new System.Drawing.Size(769, 60);
            this.ongoingTasksPanel.TabIndex = 2;
            // 
            // ongoingColorBar
            // 
            this.ongoingColorBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.ongoingColorBar.Location = new System.Drawing.Point(0, 10);
            this.ongoingColorBar.Name = "ongoingColorBar";
            this.ongoingColorBar.Size = new System.Drawing.Size(4, 40);
            this.ongoingColorBar.TabIndex = 0;
            // 
            // lblOngoingTasks
            // 
            this.lblOngoingTasks.AutoSize = true;
            this.lblOngoingTasks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblOngoingTasks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblOngoingTasks.Location = new System.Drawing.Point(15, 10);
            this.lblOngoingTasks.Name = "lblOngoingTasks";
            this.lblOngoingTasks.Size = new System.Drawing.Size(261, 32);
            this.lblOngoingTasks.TabIndex = 1;
            this.lblOngoingTasks.Text = "Devam Eden Görevler";
            // 
            // lblOngoingDesc
            // 
            this.lblOngoingDesc.AutoSize = true;
            this.lblOngoingDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOngoingDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblOngoingDesc.Location = new System.Drawing.Point(15, 35);
            this.lblOngoingDesc.Name = "lblOngoingDesc";
            this.lblOngoingDesc.Size = new System.Drawing.Size(283, 25);
            this.lblOngoingDesc.TabIndex = 2;
            this.lblOngoingDesc.Text = "Şu anda üzerinde çalışılan görevler";
            // 
            // ongoingTasksFlow
            // 
            this.ongoingTasksFlow.AutoScroll = true;
            this.ongoingTasksFlow.AutoSize = true;
            this.ongoingTasksFlow.BackColor = System.Drawing.Color.White;
            this.ongoingTasksFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ongoingTasksFlow.Location = new System.Drawing.Point(258, 332);
            this.ongoingTasksFlow.Name = "ongoingTasksFlow";
            this.ongoingTasksFlow.Size = new System.Drawing.Size(707, 100);
            this.ongoingTasksFlow.TabIndex = 3;
            this.ongoingTasksFlow.WrapContents = false;
            // 
            // pendingTasksPanel
            // 
            this.pendingTasksPanel.BackColor = System.Drawing.Color.White;
            this.pendingTasksPanel.Controls.Add(this.pendingColorBar);
            this.pendingTasksPanel.Controls.Add(this.lblPendingTasks);
            this.pendingTasksPanel.Controls.Add(this.lblPendingDesc);
            this.pendingTasksPanel.Location = new System.Drawing.Point(218, 478);
            this.pendingTasksPanel.Name = "pendingTasksPanel";
            this.pendingTasksPanel.Padding = new System.Windows.Forms.Padding(15);
            this.pendingTasksPanel.Size = new System.Drawing.Size(769, 60);
            this.pendingTasksPanel.TabIndex = 4;
            // 
            // pendingColorBar
            // 
            this.pendingColorBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(162)))), ((int)(((byte)(158)))));
            this.pendingColorBar.Location = new System.Drawing.Point(0, 10);
            this.pendingColorBar.Name = "pendingColorBar";
            this.pendingColorBar.Size = new System.Drawing.Size(4, 40);
            this.pendingColorBar.TabIndex = 0;
            // 
            // lblPendingTasks
            // 
            this.lblPendingTasks.AutoSize = true;
            this.lblPendingTasks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPendingTasks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblPendingTasks.Location = new System.Drawing.Point(15, 10);
            this.lblPendingTasks.Name = "lblPendingTasks";
            this.lblPendingTasks.Size = new System.Drawing.Size(242, 32);
            this.lblPendingTasks.TabIndex = 1;
            this.lblPendingTasks.Text = "Başlayacak Görevler";
            // 
            // lblPendingDesc
            // 
            this.lblPendingDesc.AutoSize = true;
            this.lblPendingDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPendingDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblPendingDesc.Location = new System.Drawing.Point(15, 35);
            this.lblPendingDesc.Name = "lblPendingDesc";
            this.lblPendingDesc.Size = new System.Drawing.Size(241, 25);
            this.lblPendingDesc.TabIndex = 2;
            this.lblPendingDesc.Text = "Henüz başlanmamış görevler";
            // 
            // pendingTasksFlow
            // 
            this.pendingTasksFlow.AutoScroll = true;
            this.pendingTasksFlow.AutoSize = true;
            this.pendingTasksFlow.BackColor = System.Drawing.Color.White;
            this.pendingTasksFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pendingTasksFlow.Location = new System.Drawing.Point(258, 544);
            this.pendingTasksFlow.Name = "pendingTasksFlow";
            this.pendingTasksFlow.Size = new System.Drawing.Size(707, 103);
            this.pendingTasksFlow.TabIndex = 5;
            this.pendingTasksFlow.WrapContents = false;
            // 
            // ÇalışanProjeDetay
            // 
            this.ClientSize = new System.Drawing.Size(1310, 746);
            this.Controls.Add(this.mainPanel);
            this.Name = "ÇalışanProjeDetay";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.completedTasksPanel.ResumeLayout(false);
            this.completedTasksPanel.PerformLayout();
            this.ongoingTasksPanel.ResumeLayout(false);
            this.ongoingTasksPanel.PerformLayout();
            this.pendingTasksPanel.ResumeLayout(false);
            this.pendingTasksPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}