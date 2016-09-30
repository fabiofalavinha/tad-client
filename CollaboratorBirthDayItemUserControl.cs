using System;
using System.Text;
using System.Windows.Forms;
using TadManagementTool.Model;

namespace TadManagementTool
{
    public partial class CollaboratorBirthDayItemUserControl : UserControl
    {
        private readonly BirthdayList birthDayList;

        public CollaboratorBirthDayItemUserControl(BirthdayList birthDayList)
        {
            InitializeComponent();
            this.birthDayList = birthDayList;
        }

        private void CollaboratorBirthDayItemUserControl_Load(object sender, EventArgs e)
        {
            dateLabel.Text = birthDayList.CurrentMonth.Text;
            var builder = new StringBuilder();
            foreach (var person in birthDayList.People)
            {
                builder.Append(builder.Length > 0 ? "\n\r" : string.Empty).AppendFormat("{0} - {1}", person.BirthDate.Day, person.Name.Length > 20 ? person.Name.Substring(0, 19) + "..." : person.Name);
            }
            personNameLabel.Text = builder.ToString();
        }
    }
}
