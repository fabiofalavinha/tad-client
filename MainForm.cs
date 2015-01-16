using System.Windows.Forms;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.View.Impl;

namespace TadManagementTool
{
    public partial class MainForm : Form, IMainView
    {
        private readonly IMainPresenter presenter;

        public MainForm()
        {
            InitializeComponent();
            presenter = new MainPresenter(this);
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            presenter.InitView();
        }
    }
}
