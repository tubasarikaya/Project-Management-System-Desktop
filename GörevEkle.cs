using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectManagementApplication
{
    public partial class GörevEkle : Form
    {
        public string TaskName { get; private set; }
        public DateTime TaskStartDate { get; private set; }
        public DateTime TaskFinishDate { get; private set; }
        public decimal PDValue { get; private set; }
        public int ProjectID { get; private set; }
        public int EmployeeID { get; private set; }
        public string TaskStatus { get; private set; }

        public GörevEkle(int projectID)
        {
            InitializeComponent();
            ProjectID = projectID;
        }



        private void AddTask_Load(object sender, EventArgs e)
        {
            LoadEmployeesIntoComboBox();
            ConfigureToolTipForPDValueTextBox();
        }



        // Çalışanları veritabanından çekip combobox'a ekler
        private void LoadEmployeesIntoComboBox()
        {
            string connectionString = "Server=tubasarıkaya\\SQLEXPRESS;Database=ProjectManagementDB;Trusted_Connection=True;";
            string query = "SELECT EmployeeID, EmployeeName, EmployeeSurname FROM EmployeeTable";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var employee = new
                            {
                                FullName = $"{reader["EmployeeName"]} {reader["EmployeeSurname"]}",
                                EmployeeID = Convert.ToInt32(reader["EmployeeID"])
                            };
                            comboBoxEmployee.Items.Add(employee);
                        }
                    }

                    // Combobox'ta gösterilecek alan olarak çalışan adı belirtilir
                    comboBoxEmployee.DisplayMember = "FullName";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        // PD Değeri metin kutusu için tooltip ayarlanır
        private void ConfigureToolTipForPDValueTextBox()
        {
            var toolTip = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 100,
                ReshowDelay = 50,
                ShowAlways = true
            };
            toolTip.SetToolTip(textBoxPDValue, "Lütfen değeri virgül ile giriniz (örnek: 0,7).");
        }



        // "Tamam" butonuna tıklama olayı
        private void buttonOKTask_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                CollectTaskDetails();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }



        // Kullanıcıdan alınan girdilerin doğruluğunu kontrol eder
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(textBoxTaskName.Text))
            {
                MessageBox.Show("Görev adı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen görev durumu seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboBoxEmployee.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir çalışan seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(textBoxPDValue.Text, out _))
            {
                MessageBox.Show("Lütfen geçerli bir Adam Gün Değeri giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        // Kullanıcı tarafından girilen görev detaylarını toplar
        private void CollectTaskDetails()
        {
            TaskName = textBoxTaskName.Text;
            TaskStartDate = dateTimePickerTaskStartDate.Value;
            TaskFinishDate = dateTimePickerTaskFinishDate.Value;
            PDValue = decimal.Parse(textBoxPDValue.Text);
            TaskStatus = comboBox1.SelectedItem.ToString();

            // Seçili çalışan nesnesi üzerinden EmployeeID alınır
            var selectedItem = comboBoxEmployee.SelectedItem;
            EmployeeID = (int)selectedItem.GetType().GetProperty("EmployeeID").GetValue(selectedItem);
        }
    }
}
