using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TadManagementTool
{
    public partial class CurrencyTextBox : TextBox
    {
        private string str;
        public CurrencyTextBox()
        {
            InitializeComponent();
            str = string.Empty;
            TextAlign = HorizontalAlignment.Right;
        }

        public decimal Value
        {
            get
            {
                decimal d = 0;
                decimal.TryParse(this.Text, out d);
                return d;
            }
            set
            {
                Text = value.ToString("f2");
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            int KeyCode = e.KeyValue;

            if (!IsNumeric(KeyCode))
            {
                e.Handled = true;

                if ((KeyCode >= 96) && (KeyCode <= 105))
                    KeyCode -= 48;
                else
                    return;
            }
            else
            {
                e.Handled = true;
            }
            if (((KeyCode == 8) || (KeyCode == 46)) && (str.Length > 0))
            {
                str = str.Substring(0, str.Length - 1);
            }
            else if (!((KeyCode == 8) || (KeyCode == 46)))
            {
                str = str + Convert.ToChar(KeyCode);
            }
            if (str.Length == 0)
            {
                Text = "";
            }
            if (str.Length == 1)
            {
                Text = "0.0" + str;
            }
            else if (str.Length == 2)
            {
                Text = "0." + str;
            }
            else if (str.Length > 2)
            {
                Text = str.Substring(0, str.Length - 2) + "." + str.Substring(str.Length - 2);
            }
        }

        private bool IsNumeric(int Val)
        {
            return ((Val >= 48 && Val <= 57) || (Val == 8) || (Val == 46));
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = true;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
            }
        }
    }
}
