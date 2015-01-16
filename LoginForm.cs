using System;
using System.Windows.Forms;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.View.Impl;

namespace TadManagementTool
{
    public partial class LoginForm : Form, ILoginView
    {
        private readonly ILoginPresenter presenter;

        public LoginForm()
        {
            InitializeComponent();
            presenter = new LoginPresenter(this);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            presenter.InitView();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            presenter.OnCancel();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            presenter.OnSingIn();
        }
    }
}
