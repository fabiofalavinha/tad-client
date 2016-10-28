using System;
using System.Windows.Forms;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool
{
    public partial class NewsletterUserView : AbstractForm, INewsletterUserView
    {
        private readonly INewsletterUserPresenter presenter;
           
        public NewsletterUserView()
            : this(null)
        {
        }

        public NewsletterUserView(NewsletterUserViewItem viewItem)
        {
            InitializeComponent();
            presenter = new NewsletterUserPresenter(this, viewItem);
        }

        private void NewsletterUserView_Load(object sender, EventArgs e)
        {
            presenter.InitView();
        }

        private void addNewsletterUserButton_Click(object sender, EventArgs e)
        {
            presenter.OnSave();
        }

        private void backToListNewsletterUserButton_Click(object sender, EventArgs e)
        {
            presenter.OnCancel();
        }

        public string GetName()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(GetName));
            }
            return nameTextBox.Text;
        }
    

        public string GetEmail()
        {
            if (InvokeRequired)
            {
                return (string)Invoke(new Func<string>(GetEmail));
            }
            return emailTextBox.Text;
        }
       
        public void ShowWaitingPanel(string message = null)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ShowWaitingPanel), message);
                return;
            }
            if (string.IsNullOrWhiteSpace(message))
            {
                message = "Processando...";
            }
            modalWaitingPanel.Show(message);
        }

        public void HideWaitingPanel()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(HideWaitingPanel));
                return;
            }
            modalWaitingPanel.Hide();
        }
        
        public void SetName(string name)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetName), name);
                return;
            }
            nameTextBox.Text = name;
        }

        public void SetEmail(string email)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetEmail), email);
                return;
            }
            emailTextBox.Text = email;
        }
    }
}
