using System;
using System.Windows.Forms;

namespace ProjectManagementApplication
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        // "Projeler" butonuna tıklama olayı
        private void button1_Click(object sender, EventArgs e)
        {
            // Projeler formunu açıyoruz
            ProjeSayfası projectsForm = new ProjeSayfası();
            projectsForm.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Employee formunu açıyoruz
            ÇalışanSayfası employeeForm = new ÇalışanSayfası();
            employeeForm.Show(); // Yeni bir Employee formu açılır
        }
    }
}
