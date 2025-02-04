using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectManagementApplication
{
    public partial class ProjeSayfası : Form
    {
        private readonly string connectionString = "Server=tubasarıkaya\\SQLEXPRESS;Database=ProjectManagementDB;Trusted_Connection=True;";

        public ProjeSayfası()
        {
            InitializeComponent();
            this.Load += Projects_Load;
        }


        // İlk açılışta projeleri yükler
        private void Projects_Load(object sender, EventArgs e)
        {
            TryExecuteDatabaseOperation(
                "SELECT TOP 1 * FROM ProjectTable",
                command => { },
                reader => { }
            );
            LoadProjectsFromDatabase();
        }



        // Proje ekle formunu açar
        private void AddProjectButton_Click(object sender, EventArgs e)
        {
            var addProject = new ProjeEkle();
            if (addProject.ShowDialog() == DialogResult.OK)
            {
                // Yeni projeyi veritabanına ekler
                InsertProjectToDatabase(addProject.ProjectName, addProject.ProjectStartDate, addProject.ProjectFinishDate, 0);
            }
        }



        // Proje butonuna tıklanıldığında ilgili proje bilgilerini yükler
        private void ProjectButton_Click(object sender, EventArgs e)
        {
            if (sender is Button projectButton && projectButton.Tag is ProjectData projectData)
            {
                // Proje detaylarını günceller ve görevleri yükler
                UpdateProjectDetailsPanel(projectData);
                GetProjectIDAndLoadTasks(projectData.ProjectName);
            }
        }



        // Görev ekleme butonuna tıklanıldığında çalışır
        private void AddTaskButton_Click(object sender, EventArgs e)
        {
            if (sender is Button addTaskButton && addTaskButton.Tag is int projectID)
            {
                var addTaskForm = new GörevEkle(projectID);
                if (addTaskForm.ShowDialog() == DialogResult.OK)
                {

                    // Yeni görevi veritabanına ekler
                    InsertTaskToDatabase(
                        addTaskForm.TaskName,
                        addTaskForm.TaskStartDate,
                        addTaskForm.TaskFinishDate,
                        addTaskForm.PDValue,
                        projectID,
                        addTaskForm.EmployeeID,
                        addTaskForm.TaskStatus
                    );
                }
            }
        }


        // Tüm projeleri veritabanından yükler ve kullanıcı arayüzüne ekler
        private void LoadProjectsFromDatabase()
        {
            TryExecuteDatabaseOperation(
                "SELECT ProjectName, ProjectStartDate, ProjectFinishDate, DelayAmount FROM ProjectTable",
                command => { },
                reader =>
                {
                    while (reader.Read())
                    {
                        // Her bir projeyi bir buton olarak panelde gösterir
                        AddProjectButtonToPanel(
                            reader["ProjectName"].ToString(),
                            Convert.ToDateTime(reader["ProjectStartDate"]),
                            Convert.ToDateTime(reader["ProjectFinishDate"]),
                            reader["DelayAmount"] != DBNull.Value ? Convert.ToInt32(reader["DelayAmount"]) : 0
                        );
                    }
                }
            );
        }



        // Belirli bir projeye ait görevleri yükler
        private void LoadTasksFromDatabase(int projectID)
        {
            AddAddTaskButton(projectID);

            TryExecuteDatabaseOperation(
                "SELECT t.TaskID, t.TaskName, t.TaskStartDate, t.TaskFinishDate, t.PDValue, t.TaskStatus, e.EmployeeName, e.EmployeeSurname " +
                "FROM TaskTable t JOIN EmployeeTable e ON t.EmployeeID = e.EmployeeID WHERE t.ProjectID = @ProjectID",
                command => command.Parameters.AddWithValue("@ProjectID", projectID),
                reader =>
                {
                    while (reader.Read())
                    {
                        // Görevleri birer kart olarak listeye ekler
                        listtaskpanel.Controls.Add(CreateTaskCard(reader, projectID));
                    }
                }
            );
        }


        // Yeni bir projeyi veritabanına ekler
        private void InsertProjectToDatabase(string projectName, DateTime startDate, DateTime finishDate, int delayAmount)
        {
            TryExecuteDatabaseOperation(
                "INSERT INTO ProjectTable (ProjectName, ProjectStartDate, ProjectFinishDate, DelayAmount) VALUES (@ProjectName, @StartDate, @FinishDate, @DelayAmount); SELECT SCOPE_IDENTITY();",
                command =>
                {
                    command.Parameters.AddWithValue("@ProjectName", projectName);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@FinishDate", finishDate);
                    command.Parameters.AddWithValue("@DelayAmount", delayAmount);
                },
                reader =>
                {
                    // Arayüze yeni proje butonu ekler ve kullanıcıya bilgi verir
                    AddProjectButtonToPanel(projectName, startDate, finishDate, delayAmount);
                    MessageBox.Show("Proje başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            );
        }



        // Görev bilgilerini veritabanına ekler
        private void InsertTaskToDatabase(string taskName, DateTime taskStartDate, DateTime taskFinishDate, decimal PDValue, int projectID, int employeeID, string taskStatus)
        {
            TryExecuteDatabaseOperation(
                "INSERT INTO TaskTable (TaskName, TaskStartDate, TaskFinishDate, PDValue, ProjectID, EmployeeID, TaskStatus) " +
                "VALUES (@TaskName, @StartDate, @FinishDate, @PDValue, @ProjectID, @EmployeeID, @TaskStatus);",
                command =>
                {
                    command.Parameters.AddWithValue("@TaskName", taskName);
                    command.Parameters.AddWithValue("@StartDate", taskStartDate);
                    command.Parameters.AddWithValue("@FinishDate", taskFinishDate);
                    command.Parameters.AddWithValue("@PDValue", PDValue);
                    command.Parameters.AddWithValue("@ProjectID", projectID);
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    command.Parameters.AddWithValue("@TaskStatus", taskStatus);
                },
               reader =>
               {

                   // Görev listesini yeniden yükler ve kullanıcıya bilgi verir
                   LoadTasksFromDatabase(projectID);
                   MessageBox.Show("Görev başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }

            );
        }



        // Veritabanı işlemleri için genel bir hata yönetimi fonksiyonu
        private void TryExecuteDatabaseOperation(string query, Action<SqlCommand> parameterizeCommand, Action<SqlDataReader> processReader)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        parameterizeCommand?.Invoke(command);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            processReader?.Invoke(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        // Görev ekleme butonunu oluşturur ve ekler
        private void AddAddTaskButton(int projectID)
        {
            var addTaskButton = new Button
            {
                Text = "Yeni Görev+",
                Width = 132,
                Height = 35,
                BackColor = Color.FromArgb(33, 150, 243),
                ForeColor = Color.White,
                Margin = new Padding(5),
                Tag = projectID
            };
            addTaskButton.Click += AddTaskButton_Click;

            listtaskpanel.Controls.Clear();
            listtaskpanel.Controls.Add(addTaskButton);
        }



        // Projeyi temsil eden bir buton oluşturur ve panele ekler
        private void AddProjectButtonToPanel(string projectName, DateTime startDate, DateTime finishDate, int delayAmount)
        {
            var projectButton = new Button
            {
                Text = projectName,
                Width = flowProjectList.Width - 10,
                Height = 40,
                Tag = new ProjectData
                {
                    ProjectName = projectName,
                    StartDate = startDate,
                    FinishDate = finishDate,
                    DelayAmount = delayAmount
                }
            };
            projectButton.Click += ProjectButton_Click;
            flowProjectList.Controls.Add(projectButton);
        }




        // Görevleri listelemek için bir kart oluşturur
        private Panel CreateTaskCard(SqlDataReader reader, int projectID)
        {
            var taskCard = new Panel
            {
                Width = listtaskpanel.Width - 25,
                Height = 160,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
                BackColor = Color.White
            };

            taskCard.Controls.Add(CreateLabel(reader["TaskName"].ToString(), new Point(10, 10), 12, FontStyle.Bold));
            taskCard.Controls.Add(CreateLabel($"Sorumlu: {reader["EmployeeName"]} {reader["EmployeeSurname"]}", new Point(10, 40), 10));
            taskCard.Controls.Add(CreateLabel($"Başlangıç: {Convert.ToDateTime(reader["TaskStartDate"]):dd.MM.yyyy}", new Point(10, 70), 10));
            taskCard.Controls.Add(CreateLabel($"Bitiş: {Convert.ToDateTime(reader["TaskFinishDate"]):dd.MM.yyyy}", new Point(10, 90), 10));
            taskCard.Controls.Add(CreateLabel($"PD Değeri: {reader["PDValue"]}", new Point(10, 110), 10));
            taskCard.Controls.Add(CreateLabel($"Görev Durumu: {reader["TaskStatus"]}", new Point(10, 130), 10));

            var statusComboBox = CreateStatusComboBox(reader["TaskStatus"].ToString(), taskCard.Width);
            var updateButton = CreateUpdateButton(Convert.ToInt32(reader["TaskID"]), projectID, statusComboBox);

            taskCard.Controls.Add(statusComboBox);
            taskCard.Controls.Add(updateButton);

            return taskCard;
        }



        // Etiket oluşturur ve geri döner
        private Label CreateLabel(string text, Point location, int fontSize, FontStyle fontStyle = FontStyle.Regular)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Arial", fontSize, fontStyle),
                Location = location,
                AutoSize = true
            };
        }


        // Görev durumu için bir combobox oluşturur
        private ComboBox CreateStatusComboBox(string selectedValue, int panelWidth)
        {
            var comboBox = new ComboBox
            {
                Location = new Point(panelWidth - 140, 30),
                Width = 120,
                Height = 30
            };
            comboBox.Items.AddRange(new[] { "Tamamlanacak", "Devam Ediyor", "Tamamlandı" });
            comboBox.SelectedItem = selectedValue;
            return comboBox;
        }



        // Görev durumu güncelleme butonu oluşturur
        private Button CreateUpdateButton(int taskID, int projectID, ComboBox statusComboBox)
        {
            var button = new Button
            {
                Text = "Durum Güncelle",
                Location = new Point(listtaskpanel.Width - 165, 60),
                Width = 120,
                Height = 30,
                BackColor = Color.FromArgb(33, 150, 243),
                ForeColor = Color.White,
                Tag = taskID
            };
            button.Click += (s, e) => UpdateTaskStatus(taskID, statusComboBox.SelectedItem.ToString(), projectID);
            return button;
        }


        // Görev durumunu günceller
        private void UpdateTaskStatus(int taskID, string newStatus, int projectID)
        {
            TryExecuteDatabaseOperation(
                "UPDATE TaskTable SET TaskStatus = @Status WHERE TaskID = @TaskID",
                command =>
                {
                    command.Parameters.AddWithValue("@Status", newStatus);
                    command.Parameters.AddWithValue("@TaskID", taskID);
                },
                reader => { }
            );

            if (newStatus == "Tamamlandı")
            {
                UpdateProjectDetailsForCompletion(projectID);
            }

            LoadTasksFromDatabase(projectID);
            MessageBox.Show("Görev durumu başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }




        // Proje detaylarını günceller
        private void UpdateProjectDetailsForCompletion(int projectID)
        {
            DateTime originalFinishDate;
            int totalDelay;

            TryExecuteDatabaseOperation(
                "SELECT ProjectFinishDate, DelayAmount FROM ProjectTable WHERE ProjectID = @ProjectID",
                command => command.Parameters.AddWithValue("@ProjectID", projectID),
                reader =>
                {
                    if (reader.Read())
                    {
                        originalFinishDate = Convert.ToDateTime(reader["ProjectFinishDate"]).AddDays(-Convert.ToInt32(reader["DelayAmount"]));
                        totalDelay = CalculateTotalProjectDelay(projectID);

                        // Yeni kontrol: Eğer toplam gecikme pozitif değilse proje bitiş tarihini değiştirme
                        if (totalDelay > 0)
                        {
                            UpdateProjectFinishDateAndDelay(projectID, originalFinishDate.AddDays(totalDelay), totalDelay);
                        }
                        else
                        {
                            LoadProjectDetailsFromDatabase(projectID);
                        }
                    }
                }
            );
        }




        // Toplam görev gecikme miktarını hesaplar
        private int CalculateTotalProjectDelay(int projectID)
        {
            int totalDelay = 0;

            TryExecuteDatabaseOperation(
                "SELECT SUM(CASE WHEN TaskStatus = 'Tamamlandı' THEN DATEDIFF(DAY, TaskFinishDate, GETDATE()) ELSE 0 END) AS TotalDelay FROM TaskTable WHERE ProjectID = @ProjectID",
                command => command.Parameters.AddWithValue("@ProjectID", projectID),
                reader =>
                {
                    if (reader.Read())
                    {
                        totalDelay = reader["TotalDelay"] != DBNull.Value ? Convert.ToInt32(reader["TotalDelay"]) : 0;
                    }
                }
            );

            return totalDelay;
        }



        // Proje bitiş tarihini ve gecikme miktarını günceller
        private void UpdateProjectFinishDateAndDelay(int projectID, DateTime newFinishDate, int totalDelay)
        {
            TryExecuteDatabaseOperation(
                "UPDATE ProjectTable SET ProjectFinishDate = @NewFinishDate, DelayAmount = @DelayAmount WHERE ProjectID = @ProjectID",
                command =>
                {
                    command.Parameters.AddWithValue("@NewFinishDate", newFinishDate);
                    command.Parameters.AddWithValue("@DelayAmount", totalDelay);
                    command.Parameters.AddWithValue("@ProjectID", projectID);
                },
                reader => { }
            );

            LoadProjectDetailsFromDatabase(projectID);
        }




        // Proje detaylarını veritabanından yükler
        private void LoadProjectDetailsFromDatabase(int projectID)
        {
            TryExecuteDatabaseOperation(
                "SELECT ProjectName, ProjectStartDate, ProjectFinishDate, DelayAmount FROM ProjectTable WHERE ProjectID = @ProjectID",
                command => command.Parameters.AddWithValue("@ProjectID", projectID),
                reader =>
                {
                    if (reader.Read())
                    {
                        UpdateProjectDetailsPanel(new ProjectData
                        {
                            ProjectName = reader["ProjectName"].ToString(),
                            StartDate = Convert.ToDateTime(reader["ProjectStartDate"]),
                            FinishDate = Convert.ToDateTime(reader["ProjectFinishDate"]),
                            DelayAmount = Convert.ToInt32(reader["DelayAmount"])
                        });
                    }
                }
            );
        }




        // Proje detaylarını günceller ve kullanıcı arayüzüne yansıtır
        private void UpdateProjectDetailsPanel(ProjectData projectData)
        {
            labelProjectName.Text = $"Proje Adı: {projectData.ProjectName}";
            labelProjectStartDate.Text = $"Başlangıç Tarihi: {projectData.StartDate:dd/MM/yyyy}";
            labelProjectFinishDate.Text = $"Bitiş Tarihi: {projectData.FinishDate:dd/MM/yyyy}";
            labelProjectDelay.Text = $"Gecikme Miktarı: {projectData.DelayAmount} gün";
        }




        // Proje ID'sini alır ve ilgili görevleri yükler
        private void GetProjectIDAndLoadTasks(string projectName)
        {
            TryExecuteDatabaseOperation(
                "SELECT ProjectID FROM ProjectTable WHERE ProjectName = @ProjectName",
                command => command.Parameters.AddWithValue("@ProjectName", projectName),
                reader =>
                {
                    if (reader.Read())
                    {
                        int projectID = Convert.ToInt32(reader["ProjectID"]);
                        LoadTasksFromDatabase(projectID);
                    }
                }
            );
        }


        private class ProjectData
        {
            public string ProjectName { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime FinishDate { get; set; }
            public int DelayAmount { get; set; }
        }
    }
}
