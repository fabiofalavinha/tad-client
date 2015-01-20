using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TadManagementTool.View.Impl;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.Model;

namespace TadManagementTool
{
    public partial class CollaboratorView : UserControl, ICollaboratorView
    {
        private readonly IMainView parentView;
        private readonly ICollaboratorPresenter presenter;
        private readonly Collaborator collaborator;

        public CollaboratorView(IMainView parentView)
        {
            InitializeComponent();
            this.parentView = parentView;
            this.presenter = new CollaboratorPresenter(this);
        }

        public CollaboratorView(IMainView parentView, Collaborator collaborator)
            : this(parentView)
        {
            this.collaborator = collaborator;
        }

        private void CollaboratorView_Load(object sender, EventArgs e)
        {
            presenter.InitView();
        }

        private void releaseDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
        }

        public void ShowWarningMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void ShowErrorMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void ShowWaitingPanel(string message = null)
        {
            throw new NotImplementedException();
        }

        public void HideWaitingPanel()
        {
            throw new NotImplementedException();
        }

        private void backToListCollaboratorButton_Click(object sender, EventArgs e)
        {
            presenter.OnBackToListCollaboratorView();
        }

        public void OpenListCollaboratorView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(OpenListCollaboratorView));
                return;
            }
            parentView.ShowControlView(new ListCollaboratorUserControl(parentView)
            {
                Dock = DockStyle.Fill
            });
        }
    }
}
