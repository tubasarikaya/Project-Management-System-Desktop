using System;
using System.Windows.Forms;

namespace ProjectManagementApplication
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // AnaSayfa formunun açılmasını sağlıyoruz
            Application.Run(new AnaSayfa());
        }
    }
}
