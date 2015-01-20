using System;
using System.Windows.Forms;

namespace TadManagementTool
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var loginForm = new LoginForm())
            {
                var loginDialogResult = loginForm.ShowDialog();
                if (loginDialogResult == DialogResult.OK)
                {
                    Application.Run(new MainForm());
                }
            }
        }
    }
}
