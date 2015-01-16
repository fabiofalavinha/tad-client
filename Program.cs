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
                    // TODO: get authentication result
                    // set 'signIn' variable
                }
            }
            Application.Run(new MainForm());
        }
    }
}
