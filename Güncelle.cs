using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectManagementApplication
{
    public partial class Güncelle : Form
    {
        private int employeeId; // Güncellenecek çalışanın ID'si
        private string connectionString = "Server=tubasarıkaya\\SQLEXPRESS;Database=ProjectManagementDB;Trusted_Connection=True;";
        public event Action OnEmployeeUpdated;
        public Güncelle(int selectedEmployeeId)
        {
            InitializeComponent();
            employeeId = selectedEmployeeId;

            LoadEmployeeData(); // Çalışan bilgilerini doldur
        }

        private void LoadEmployeeData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT EmployeeName, EmployeeSurname, Position FROM EmployeeTable WHERE EmployeeId = @id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", employeeId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox3.Text = reader["EmployeeName"].ToString(); // Çalışan Adı
                                textBox4.Text = reader["EmployeeSurname"].ToString(); // Çalışan Soyadı
                                textBox5.Text = reader["Position"].ToString(); // Pozisyon
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bilgiler yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Hata durumunda formu kapat
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE EmployeeTable SET EmployeeName = @name, EmployeeSurname = @surname, Position = @position WHERE EmployeeId = @id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", textBox3.Text.Trim());
                        command.Parameters.AddWithValue("@surname", textBox4.Text.Trim());
                        command.Parameters.AddWithValue("@position", textBox5.Text.Trim());
                        command.Parameters.AddWithValue("@id", employeeId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Çalışan bilgileri başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Güncelleme tamamlandığında olayı tetikle
                            OnEmployeeUpdated?.Invoke();

                            this.Close(); // Güncellemeden sonra formu kapat
                        }
                        else
                        {
                            MessageBox.Show("Bilgiler güncellenemedi. Lütfen tekrar deneyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bilgiler güncellenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}