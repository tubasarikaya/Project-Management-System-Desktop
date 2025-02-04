using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectManagementApplication
{
    public partial class Ekle : Form
    {
        public Ekle()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan veriler
            string employeeName = textBox1.Text.Trim(); // Çalışan Adı
            string employeeSurname = textBox2.Text.Trim(); // Çalışan Soyadı
            string position = textBox3.Text.Trim(); // Pozisyon

            // Boş alan kontrolü
            if (string.IsNullOrWhiteSpace(employeeName) ||
                string.IsNullOrWhiteSpace(employeeSurname) ||
                string.IsNullOrWhiteSpace(position))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // SQL Server bağlantı dizesi
            string connectionString = "Server=tubasarıkaya\\SQLEXPRESS;Database=ProjectManagementDB;Trusted_Connection=True;";
            // SQL sorgusu
            string query = "INSERT INTO EmployeeTable (EmployeeName, EmployeeSurname, Position) VALUES (@EmployeeName, @EmployeeSurname, @Position)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Parametrelerin atanması
                        command.Parameters.AddWithValue("@EmployeeName", employeeName);
                        command.Parameters.AddWithValue("@EmployeeSurname", employeeSurname);
                        command.Parameters.AddWithValue("@Position", position);

                        // Sorgunun çalıştırılması
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Kayıt başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Formu kapat
                            this.DialogResult = DialogResult.OK; // ÇalışanSayfası.cs tarafında değişiklik tetiklenmesi için
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Kayıt eklenemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}