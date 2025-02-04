using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementApplication
{
    public partial class ÇalışanSayfası : Form
    {
        private const string ConnectionString = "Server=tubasarıkaya\\SQLEXPRESS;Database=ProjectManagementDB;Trusted_Connection=True;";

        public ÇalışanSayfası()
        {
            InitializeComponent();
            InitializeSearchControls();
            LoadEmployeeData();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            using (var addEmployeeForm = new Ekle())
            {
                if (addEmployeeForm.ShowDialog() == DialogResult.OK)
                {
                    LoadEmployeeData();
                }
            }
        }
        private void InitializeSearchControls()
        {
            var searchTextBox = CreateSearchTextBox();
            panel1.Controls.Add(searchTextBox);
        }
        private TextBox CreateSearchTextBox() // Arama kutusunu oluşturur ve gerekli özellikleri ayarlar.
        {
            var searchTextBox = new TextBox
            {
                Width = 150,
                Location = new Point(10, 40),
                ForeColor = Color.Gray,
                Text = "Çalışan Adı Ara..."
            };

            searchTextBox.GotFocus += (sender, e) => HandleSearchBoxFocus(searchTextBox);
            searchTextBox.LostFocus += (sender, e) => HandleSearchBoxLostFocus(searchTextBox);
            searchTextBox.TextChanged += (sender, e) => HandleSearchBoxTextChanged(searchTextBox);

            return searchTextBox;
        }
        private void HandleSearchBoxFocus(TextBox searchTextBox) // Arama kutusuna odaklanıldığında yapılacak işlemleri tanımlar.
        {
            if (searchTextBox.Text == "Çalışan Adı Ara...")
            {
                searchTextBox.Text = string.Empty;
                searchTextBox.ForeColor = Color.Black;
            }
        }
        private void HandleSearchBoxLostFocus(TextBox searchTextBox)  // Arama kutusundan odak kaybolduğunda yapılacak işlemleri tanımlar.
        {
            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                searchTextBox.Text = "Çalışan Adı Ara...";
                searchTextBox.ForeColor = Color.Gray;
            }
        }
        private void HandleSearchBoxTextChanged(TextBox searchTextBox) // Arama kutusundaki metin değiştiğinde yapılacak işlemleri tanımlar.
        {
            if (searchTextBox.Text != "Çalışan Adı Ara...")
            {
                SearchEmployee(searchTextBox.Text.Trim());
            }
            else
            {
                LoadEmployeeData();
            }
        }
        private void LoadEmployeeData() // Çalışan verilerini veritabanından alır ve ekrana yükler.
        {
            ClearDynamicControls();

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand("SELECT EmployeeId, EmployeeName, EmployeeSurname FROM EmployeeTable", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    CreateEmployeeLabels(reader);
                }
            }
        }
        private void CreateEmployeeLabels(SqlDataReader reader) // Veritabanı üzerinden gelen çalışan bilgilerini etiketler olarak ekrana ekler.
        {
            int yOffset = 70;
            while (reader.Read())
            {
                var employeeInfo = $"{reader["EmployeeName"]} {reader["EmployeeSurname"]}";
                int employeeId = Convert.ToInt32(reader["EmployeeId"]);

                var employeeLabel = CreateEmployeeLabel(employeeInfo, employeeId, yOffset);
                employeeLabel.Click += EmployeeLabel_Click;
                panel1.Controls.Add(employeeLabel);

                yOffset += 25;
            }
        }
        private Label CreateEmployeeLabel(string text, int employeeId, int yOffset) // Çalışan etiketini oluşturur.
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Regular),
                Location = new Point(10, yOffset),
                Tag = employeeId,
                Cursor = Cursors.Hand,
                BackColor = panel1.BackColor
            };
        }
        private void ClearDynamicControls() // Dinamik olarak eklenen kontrolleri temizler.
        {
            foreach (var label in panel1.Controls.OfType<Label>().Where(label => label.Tag != null).ToList())
            {
                panel1.Controls.Remove(label);
            }
        }
        private void SearchEmployee(string searchQuery) // Arama sorgusuna göre çalışanları arar ve etiketleri oluşturur.
        {
            ClearDynamicControls();

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(@"SELECT EmployeeId, EmployeeName, EmployeeSurname 
                                                 FROM EmployeeTable 
                                                 WHERE EmployeeName LIKE @search OR EmployeeSurname LIKE @search", connection))
            {
                command.Parameters.AddWithValue("@search", $"%{searchQuery}%");

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    CreateEmployeeLabels(reader);
                }
            }
        }

        private void EmployeeLabel_Click(object sender, EventArgs e) // Bir çalışan etiketine tıklandığında yapılacak işlemi tanımlar.
        {
            if (sender is Label clickedLabel && clickedLabel.Tag is int employeeId)
            {
                ResetDetailPanel();
                DisplayEmployeeDetails(employeeId);
                AddUpdateAndDeleteButtons(employeeId);
            }
        }
        private void ResetDetailPanel() // Çalışan detayları panelini sıfırlar ve başlık ekler.
        {
            panel2.Controls.Clear();
            panel2.BackColor = Color.White;
            panel2.Padding = new Padding(20);

            var titleLabel = new Label
            {
                Text = "Çalışan Detayları",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true,
                Location = new Point(20, 20)
            };
            panel2.Controls.Add(titleLabel);
        }
        private void DisplayEmployeeDetails(int employeeId) // Çalışanın detaylarını veritabanından alır ve gösterir.
        {
            ResetDetailPanel();

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(@"SELECT e.EmployeeName, e.EmployeeSurname, e.Position, p.ProjectName, p.ProjectID 
                 FROM EmployeeTable e 
                 LEFT JOIN TaskTable t ON e.EmployeeId = t.EmployeeId 
                 LEFT JOIN ProjectTable p ON t.ProjectID = p.ProjectID 
                 WHERE e.EmployeeId = @id", connection))
            {
                command.Parameters.AddWithValue("@id", employeeId);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        AddDetailLabel("Ad Soyad:", $"{reader["EmployeeName"]} {reader["EmployeeSurname"]}");
                        AddDetailLabel("Pozisyon:", reader["Position"].ToString());

                        // Projeler başlığını ekle
                        var projectsLabel = new Label
                        {
                            Text = "Projeler:",
                            Font = new Font("Segoe UI", 12, FontStyle.Bold),
                            Location = new Point(20, panel2.Controls[panel2.Controls.Count - 1].Bottom + 20),
                            AutoSize = true
                        };
                        panel2.Controls.Add(projectsLabel);

                        // Projeleri listele
                        bool hasProjects = false;
                        int projectIndex = 1;
                        var addedProjects = new HashSet<string>();

                        do
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("ProjectName")))
                            {
                                var projectName = reader["ProjectName"].ToString();
                                if (!addedProjects.Contains(projectName))
                                {
                                    hasProjects = true;
                                    addedProjects.Add(projectName);

                                    var projectId = Convert.ToInt32(reader["ProjectID"]);
                                    AddProjectLabel(projectName, projectId, projectIndex++, 20);
                                }
                            }
                        } while (reader.Read());

                        if (!hasProjects)
                        {
                            var noProjectsLabel = new Label
                            {
                                Text = "Bu Çalışanın Proje Bilgisi Yok",
                                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                                ForeColor = Color.Gray,
                                Location = new Point(20, projectsLabel.Bottom + 10),
                                AutoSize = true
                            };
                            panel2.Controls.Add(noProjectsLabel);
                        }
                    }
                }
            }
        }
        private void AddProjectLabel(string projectName, int projectId, int index, int yOffset) // Çalışanın projelerini listelemek için etiket oluşturur.
        {
            var projectLabel = new Label
            {
                Text = $"{index}. {projectName}",
                Font = new Font("Segoe UI", 10, FontStyle.Underline),
                Location = new Point(40, panel2.Controls[panel2.Controls.Count - 1].Bottom + yOffset),
                AutoSize = true,
                ForeColor = Color.Black,
                Cursor = Cursors.Hand,
                Tag = projectId
            };

            projectLabel.Click += ProjectLabel_Click;
            panel2.Controls.Add(projectLabel);
        }

        private void ProjectLabel_Click(object sender, EventArgs e) // Proje etiketine tıklandığında yapılacak işlemi tanımlar
        {
            if (sender is Label projectLabel)
            {
                int projectId = (int)projectLabel.Tag;
                string projectName = projectLabel.Text.Substring(projectLabel.Text.IndexOf(' ') + 1);

                using (var projectDetailForm = new ÇalışanProjeDetay(projectId, projectName))
                {
                    projectDetailForm.ShowDialog();
                }
            }
        }


        private void AddDetailLabel(string title, string value, int yOffset = 20) // Çalışanın detaylarını göstermek için etiket oluşturur.
        {
            var label = new Label
            {
                Text = $"{title} {value}",
                Font = new Font("Segoe UI", 10),
                Location = new Point(20, panel2.Controls[panel2.Controls.Count - 1].Bottom + yOffset),
                AutoSize = true
            };
            panel2.Controls.Add(label);
        }

        private void AddUpdateAndDeleteButtons(int employeeId) // Çalışan için Güncelle ve Sil butonlarını ekler.
        {
            var existingUpdateButton = panel2.Controls.OfType<Button>().FirstOrDefault(b => b.Name == $"UpdateButton_{employeeId}");
            var existingDeleteButton = panel2.Controls.OfType<Button>().FirstOrDefault(b => b.Name == $"DeleteButton_{employeeId}");

            if (existingUpdateButton == null)
            {
                var updateButton = CreateActionButton("Güncelle", Color.LightBlue, employeeId, UpdateButton_Click);
                updateButton.Name = $"UpdateButton_{employeeId}";
                updateButton.Location = new Point(20, panel2.Controls[panel2.Controls.Count - 1].Bottom + 20);
                panel2.Controls.Add(updateButton);
            }

            if (existingDeleteButton == null)
            {
                var deleteButton = CreateActionButton("Sil", Color.LightCoral, employeeId, DeleteButton_Click);
                deleteButton.Name = $"DeleteButton_{employeeId}";

                var updateButton = panel2.Controls.OfType<Button>().FirstOrDefault(b => b.Name == $"UpdateButton_{employeeId}");
                int deleteButtonX = updateButton == null ? 20 : updateButton.Right + 10;

                deleteButton.Location = new Point(deleteButtonX, updateButton == null ? panel2.Controls[panel2.Controls.Count - 1].Bottom + 20 : updateButton.Top);
                panel2.Controls.Add(deleteButton);
            }
        }
        private Button CreateActionButton(string text, Color color, int employeeId, EventHandler clickEvent) // Güncelleme ve Sil butonlarını oluşturur.
        {
            var button = new Button
            {
                Text = text,
                Width = 100,
                Height = 30,
                BackColor = color,
                Tag = employeeId
            };

            button.Click += clickEvent;
            return button;
        }
        private void UpdateButton_Click(object sender, EventArgs e) // Güncelle butonuna tıklanıldığında yapılacak işlemleri tanımlar
        {
            if (sender is Button updateButton && updateButton.Tag is int employeeId)
            {
                using (var updateForm = new Güncelle(employeeId))
                {

                    updateForm.OnEmployeeUpdated += () =>
                    {
                        DisplayEmployeeDetails(employeeId);
                    };

                    updateForm.ShowDialog();

                    AddUpdateAndDeleteButtons(employeeId);
                }
            }

        }
        // Models/EmployeeTask.cs
        public class EmployeeTask
        {
            public int TaskId { get; set; }
            public int EmployeeId { get; set; }
            public string TaskStatus { get; set; }
        }


        // Services/EmployeeTaskService.cs
        public class EmployeeTaskService
        {
            private readonly string _connectionString;

            public EmployeeTaskService(string connectionString)
            {
                _connectionString = connectionString;
            }


            public async Task<List<EmployeeTask>> GetActiveTasksAsync(int employeeId)
            {
                const string query = @"
        SELECT 
            t.TaskId, 
            t.EmployeeId, 
            t.TaskStatus
        FROM TaskTable t
        WHERE t.EmployeeId = @employeeId 
        AND t.TaskStatus IN ('Devam Ediyor', 'Tamamlanacak' , 'Tamamlandı')";

                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@employeeId", employeeId);

                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        var tasks = new List<EmployeeTask>();
                        while (await reader.ReadAsync())
                        {
                            tasks.Add(new EmployeeTask
                            {
                                TaskId = reader.GetInt32(0),
                                EmployeeId = reader.GetInt32(1),
                                TaskStatus = reader.GetString(2),
                            });
                        }

                        return tasks;
                    }
                }
            }

            public async Task ReassignTasksAsync(int oldEmployeeId, int newEmployeeId)
            {
                const string updateActiveTasks = @"
        UPDATE TaskTable 
        SET EmployeeId = @newEmployeeId
        WHERE EmployeeId = @oldEmployeeId 
        AND TaskStatus IN ('Devam Ediyor', 'Tamamlanacak' , 'Tamamlandı')";

                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    // Aktif görevleri yeni çalışana ata
                    using (var command = new SqlCommand(updateActiveTasks, connection))
                    {
                        command.Parameters.AddWithValue("@oldEmployeeId", oldEmployeeId);
                        command.Parameters.AddWithValue("@newEmployeeId", newEmployeeId);
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
        }

        // Forms/EmployeeReassignmentForm.cs
        public class EmployeeReassignmentForm : Form
        {
            private readonly ComboBox _employeeComboBox;
            private readonly int _oldEmployeeId;
            private readonly List<(int Id, string Name)> _availableEmployees;

            public int? SelectedEmployeeId { get; private set; }


            // Yeni çalışan seçimi için bir form oluşturur ve kullanıcıdan bir seçim yapmasını ister.
            public EmployeeReassignmentForm(int oldEmployeeId, List<(int Id, string Name)> availableEmployees)
            {
                _oldEmployeeId = oldEmployeeId;
                _availableEmployees = availableEmployees;

                Text = "Görev Devir İşlemi";
                Size = new Size(400, 200);
                FormBorderStyle = FormBorderStyle.FixedDialog;
                StartPosition = FormStartPosition.CenterParent;

                var label = new Label
                {
                    Text = "Lütfen görevlerin devredileceği çalışanı seçin:",
                    Location = new Point(20, 20),
                    Size = new Size(350, 20)
                };

                _employeeComboBox = new ComboBox
                {
                    Location = new Point(20, 50),
                    Size = new Size(350, 25),
                    DropDownStyle = ComboBoxStyle.DropDownList
                };

                foreach (var employee in availableEmployees)
                {
                    _employeeComboBox.Items.Add(new { Id = employee.Id, Text = employee.Name });
                }

                _employeeComboBox.DisplayMember = "Text";
                _employeeComboBox.ValueMember = "Id";

                var confirmButton = new Button
                {
                    Text = "Onayla",
                    Location = new Point(190, 100),
                    Size = new Size(80, 30),
                    DialogResult = DialogResult.OK
                };

                var cancelButton = new Button
                {
                    Text = "İptal",
                    Location = new Point(290, 100),
                    Size = new Size(80, 30),
                    DialogResult = DialogResult.Cancel
                };

                confirmButton.Click += (s, e) =>
                {
                    if (_employeeComboBox.SelectedItem != null)
                    {
                        SelectedEmployeeId = ((dynamic)_employeeComboBox.SelectedItem).Id;
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Lütfen bir çalışan seçin.", "Uyarı",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };

                Controls.AddRange(new Control[] { label, _employeeComboBox, confirmButton, cancelButton });
            }
        }

        //Çalışan silme işlemini yönetir, gerekli görev devrini yapar ve kullanıcı arayüzünü günceller.
        private async Task HandleEmployeeDeletion(int employeeId)
        {
            var taskService = new EmployeeTaskService(ConnectionString);

            try
            {
                // Silme onayı al
                if (!await ConfirmDeletion("Bu çalışanı silmek istediğinize emin misiniz?"))
                {
                    return;
                }

                // Aktif görevleri kontrol et
                var activeTasks = await taskService.GetActiveTasksAsync(employeeId);

                if (!activeTasks.Any())
                {
                    // Görev yoksa direkt sil
                    await DeleteEmployeeAsync(employeeId);
                    await RefreshUI();

                    MessageBox.Show("Çalışan başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Mevcut çalışanları getir
                var availableEmployees = await GetAvailableEmployeesAsync(employeeId);

                if (!availableEmployees.Any())
                {
                    MessageBox.Show("Görevleri devredebilecek başka çalışan bulunmuyor.",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Görev devri için form göster
                EmployeeReassignmentForm reassignForm = null;
                using (reassignForm = new EmployeeReassignmentForm(employeeId, availableEmployees))
                {
                    if (reassignForm.ShowDialog() != DialogResult.OK)
                        return;
                }

                var newEmployeeId = reassignForm.SelectedEmployeeId.Value;

                // Görevleri devret ve çalışanı sil
                await taskService.ReassignTasksAsync(employeeId, newEmployeeId);
                await DeleteEmployeeAsync(employeeId);
                await RefreshUI();

                MessageBox.Show("Görevler başarıyla devredildi ve çalışan silindi.",
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşlem sırasında bir hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Silme butonuna tıklandığında silme işlemini başlatır.
        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            if (sender is Button deleteButton && deleteButton.Tag is int employeeId)
            {
                await HandleEmployeeDeletion(employeeId);
            }
        }

        // Belirli bir çalışan hariç diğer tüm çalışanları getirir.
        private async Task<List<(int Id, string Name)>> GetAvailableEmployeesAsync(int excludedEmployeeId)
        {
            const string query = @"
        SELECT EmployeeId, EmployeeName, EmployeeSurname 
        FROM EmployeeTable 
        WHERE EmployeeId != @excludedId";

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@excludedId", excludedEmployeeId);

                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    var employees = new List<(int Id, string Name)>();
                    while (await reader.ReadAsync())
                    {
                        var fullName = $"{reader["EmployeeName"]} {reader["EmployeeSurname"]}";
                        employees.Add((reader.GetInt32(0), fullName));
                    }

                    return employees;
                }
            }
        }
        // Verilen kimlikteki çalışanı veritabanından siler.
        private async Task DeleteEmployeeAsync(int employeeId)
        {
            const string query = "DELETE FROM EmployeeTable WHERE EmployeeId = @id";

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", employeeId);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }

        private async Task RefreshUI()
        {
            await LoadEmployeeDataAsync();
            ResetDetailPanel();
        }

        private async Task LoadEmployeeDataAsync()
        {
            ClearDynamicControls();

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand("SELECT EmployeeId, EmployeeName, EmployeeSurname FROM EmployeeTable", connection))
            {
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    CreateEmployeeLabels(reader);
                }
            }
        }
        private Task<bool> ConfirmDeletion(string message)
        {
            var result = MessageBox.Show(message, "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            return Task.FromResult(result);
        }


    }
}