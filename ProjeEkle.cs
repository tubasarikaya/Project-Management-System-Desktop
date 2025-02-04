using System;
using System.Windows.Forms;

namespace ProjectManagementApplication
{
    public partial class ProjeEkle : Form
    {
        public string ProjectName { get; private set; }
        public DateTime ProjectStartDate { get; private set; }
        public DateTime ProjectFinishDate { get; private set; }

        public ProjeEkle()
        {
            InitializeComponent();
        }



        // "Tamam" butonuna tıklama olayı
        private void buttonOKProject_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                CollectProjectDetails();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        // Kullanıcıdan alınan girdilerin doğruluğunu kontrol eder
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(textBoxProjectName.Text))
            {
                MessageBox.Show("Proje adı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dateTimePickerProjectStartDate.Value > dateTimePickerProjectFinishDate.Value)
            {
                MessageBox.Show("Proje başlangıç tarihi bitiş tarihinden önce olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }



        // Kullanıcı tarafından girilen proje detaylarını toplar
        private void CollectProjectDetails()
        {
            ProjectName = textBoxProjectName.Text;
            ProjectStartDate = dateTimePickerProjectStartDate.Value;
            ProjectFinishDate = dateTimePickerProjectFinishDate.Value;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
