using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectManagementApplication
{
    public partial class ÇalışanProjeDetay : Form
    {
        private const string CONNECTION_STRING = @"Server=tubasarıkaya\SQLEXPRESS;Database=ProjectManagementDB;Trusted_Connection=True;";
        private readonly string _projectName;
        private readonly int _projectId;
        private int _totalOnTimeCount;
        private int _totalLateCount;

        private enum TaskStatus
        {
            Completed = 1,
            InProgress = 2,
            Pending = 3
        }

        public ÇalışanProjeDetay(int projectId, string projectName)
        {
            InitializeComponent();
            _projectId = projectId;
            _projectName = projectName;
            _totalOnTimeCount = 0;
            _totalLateCount = 0;
            InitializeForm();
            LoadProjectTasks();
        }

        private void InitializeForm()
        {
            Text = $"Proje Detayı: {_projectName}";
        }

        // Projeye ait görevleri yüklemek için kullanılır.
        private void LoadProjectTasks()
        {
            try
            {
                using (var connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    var tasks = GetProjectTasks(connection);
                    DisplayTasks(tasks);
                    DisplayTotalCompletionMetrics();
                }
            }
            catch (SqlException sqlEx)
            {
                ShowErrorMessage($"SQL Hatası: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Hata: {ex.Message}");
            }
        }

        // Veritabanından projeye ait görevleri çeker.
        private DataTable GetProjectTasks(SqlConnection connection)
        {
            const string query = @"
                SELECT TaskName, TaskStatus
                FROM TaskTable
                WHERE ProjectID = @ProjectID";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProjectID", _projectId);

                var tasksTable = new DataTable();
                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(tasksTable);
                }
                return tasksTable;
            }
        }

        // Görevleri ekranda gösterir.
        private void DisplayTasks(DataTable tasks)
        {
            foreach (DataRow task in tasks.Rows)
            {
                var taskName = task["TaskName"].ToString();
                var taskStatus = task["TaskStatus"].ToString().Trim().ToLower();
                AddTaskToPanel(taskName, taskStatus);
            }
        }

        private void AddTaskToPanel(string taskName, string taskStatus)
        {
            var taskLabel = CreateTaskLabel(taskName);
            var currentStatus = DetermineTaskStatus(taskStatus);

            switch (currentStatus)
            {
                case TaskStatus.Completed:
                    HandleCompletedTask(taskLabel);
                    break;
                case TaskStatus.InProgress:
                    ongoingTasksFlow.Controls.Add(taskLabel);
                    break;
                case TaskStatus.Pending:
                    pendingTasksFlow.Controls.Add(taskLabel);
                    break;
            }
        }

        private Label CreateTaskLabel(string taskName)
        {
            return new Label
            {
                Text = $"- {taskName}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Padding = new Padding(5)
            };
        }

        // Görev durumunu belirler.
        private TaskStatus DetermineTaskStatus(string status)
        {
            switch (status)
            {
                case "tamamlandı":
                    return TaskStatus.Completed;
                case "devam ediyor":
                    return TaskStatus.InProgress;
                case "tamamlanacak":
                    return TaskStatus.Pending;
                default:
                    throw new ArgumentException($"Geçersiz görev durumu: {status}");
            }
        }

        // Tamamlanan bir görevi işler ve ilgili metrikleri günceller.
        private void HandleCompletedTask(Label taskLabel)
        {
            completedTasksFlow.Controls.Add(taskLabel);
            UpdateTaskCompletionMetrics(taskLabel.Text.Substring(2));
        }

        // Görev tamamlama metriklerini günceller.
        private void UpdateTaskCompletionMetrics(string taskName)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                var finishDate = GetTaskFinishDate(connection, taskName);

                if (finishDate.HasValue)
                {
                    if (DateTime.Now > finishDate.Value)
                    {
                        _totalLateCount++;
                    }
                    else
                    {
                        _totalOnTimeCount++;
                    }
                }
            }
        }
        // Bir görevin bitiş tarihini getirir.
        private DateTime? GetTaskFinishDate(SqlConnection connection, string taskName)
        {
            const string query = "SELECT TaskFinishDate FROM TaskTable WHERE TaskName = @TaskName";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TaskName", taskName);
                var result = command.ExecuteScalar();
                return result != DBNull.Value ? (DateTime?)Convert.ToDateTime(result) : null;
            }
        }

        // Zamanında tamamlanan ile zamanında tamamlanmayan görev sayısını gösterir.
        private void DisplayTotalCompletionMetrics()
        {
            AddSpacerToCompletedTasks();
            AddMetricLabel($"Zamanında Tamamlanan Görev Sayısı = {_totalOnTimeCount}");
            AddMetricLabel($"Zamanında Tamamlanmayan Görev Sayısı = {_totalLateCount}");
        }

        private void AddSpacerToCompletedTasks()
        {
            completedTasksFlow.Controls.Add(new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 8),
                AutoSize = true
            });
        }

        private void AddMetricLabel(string text)
        {
            completedTasksFlow.Controls.Add(new Label
            {
                Text = text,
                Font = new Font("Segoe UI Semibold", 10),
                ForeColor = Color.Black,
                AutoSize = true
            });
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void completedTasksFlow_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}