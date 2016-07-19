using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TadManagementTool.Model.Financial;
using TadManagementTool.Presenter;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.Properties;
using TadManagementTool.View;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool
{
    public partial class FinancialEntryListUserControl : BaseUserControl, IFinancialEntryListView
    {
        private readonly IMainView parentView;
        private readonly IFinancialEntryListPresenter presenter;

        public FinancialEntryListUserControl(IMainView parentView)
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
            this.parentView = parentView;
            presenter = new FinancialEntryListPresenter(this);
        }

        private void FinancialEntryListUserControl_Load(object sender, EventArgs e)
        {
            presenter.InitView();
        }

        private void openFinancialEntryViewButton_Click(object sender, EventArgs e)
        {
            presenter.OnOpenFinancialEntryView();
        }

        private void financialEntrySearchButton_Click(object sender, EventArgs e)
        {
            presenter.OnSearchFinancialEntries();
        }

        public DialogResult OpenFinancialEntryView()
        {
            if (InvokeRequired)
            {
                return (DialogResult)Invoke(new Func<DialogResult>(OpenFinancialEntryView));

            }
            using (var form = new FinancialEntryEnrollmentForm())
            {
                return form.ShowDialog();
            }
        }

        public DateTime GetFinancialEntryFromDate()
        {
            if (InvokeRequired)
            {
                return (DateTime)Invoke(new Func<DateTime>(GetFinancialEntryFromDate));
            }
            return financialEntryDateFromPicker.Value;
        }

        public DateTime GetFinancialEntryToDate()
        {
            if (InvokeRequired)
            {
                return (DateTime)Invoke(new Func<DateTime>(GetFinancialEntryToDate));
            }
            return financialEntryDateToPicker.Value;
        }

        public void SetFinancialEntryFilterDateFrom(DateTime date)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<DateTime>(SetFinancialEntryFilterDateFrom), date);
                return;
            }
            financialEntryDateFromPicker.Value = date;
        }

        public void SetFinancialEntryFilterDateTo(DateTime date)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<DateTime>(SetFinancialEntryFilterDateTo), date);
                return;
            }
            financialEntryDateToPicker.Value = date;
        }

        public void SetFinancialEntryList(IList<FinancialEntryViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<FinancialEntryViewItem>>(SetFinancialEntryList), list);
                return;
            }
            var receiptColumn = dataGridView.Columns.Cast<DataGridViewColumn>().SingleOrDefault(c => c.Name == "financialReceiptActionColumn");
            if (receiptColumn != null)
                receiptColumn.CellTemplate = new FinancialReceiptDataGridViewCell();

            bindingSource.DataSource = list;
            dataGridView.DataSource = bindingSource;
            bindingSource.ResetBindings(false);
            dataGridView.ClearSelection();
            dataGridView.AutoResizeColumns();
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            presenter.OnSelectFinancialEntryView();
        }

        public FinancialEntryViewItem GetFinancialEntryViewSelected()
        {
            if (InvokeRequired)
            {
                return (FinancialEntryViewItem)Invoke(new Func<FinancialEntryViewItem>(GetFinancialEntryViewSelected));
            }
            var selectedRow = dataGridView.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
            if (selectedRow != null)
            {
                return (FinancialEntryViewItem)selectedRow.DataBoundItem;
            }
            return null;
        }

        public DialogResult OpenFinancialEntryView(FinancialEntryViewItem selected)
        {
            if (InvokeRequired)
            {
                return (DialogResult)Invoke(new Func<FinancialEntryViewItem, DialogResult>(OpenFinancialEntryView));
            }
            using (var form = new FinancialEntryEnrollmentForm(selected))
            {
                return form.ShowDialog();
            }
        }

        public void SetCurrentBalance(Balance balance)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Balance>(SetCurrentBalance), balance);
                return;
            }
            currentBalanceLabel.Text = balance.Value.ToString("#,#.00#;(#,#.00#)", new CultureInfo("pt-BR"));
        }

        public void SetCurrentBalanceColor(Color color)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Color>(SetCurrentBalanceColor), color);
                return;
            }
            currentBalanceLabel.ForeColor = color;
        }

        public void SetTargetTypeFilterList(IList<FinancialTargetTypeViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<FinancialTargetTypeViewItem>>(SetTargetTypeFilterList), list);
                return;
            }
            targetTypeFilterComboBox.Items.Clear();
            targetTypeFilterComboBox.Items.AddRange(list.ToArray());
        }

        public FinancialTargetTypeViewItem GetTargetTypeFilterSelected()
        {
            if (InvokeRequired)
            {
                return (FinancialTargetTypeViewItem)Invoke(new Func<FinancialTargetTypeViewItem>(GetTargetTypeFilterSelected));
            }
            return (FinancialTargetTypeViewItem)targetTypeFilterComboBox.SelectedItem;
        }

        private class FinancialReceiptDataGridViewCell : DataGridViewImageButtonCell
        {
            public FinancialReceiptDataGridViewCell()
            {
                buttonImageHot = Resources.receipt_send_hot;
                buttonImageNormal = Resources.receipt_send_normal;
                buttonImageDisabled = Resources.receipt_send_disabled;
            }
        }

        public abstract class DataGridViewImageButtonCell : DataGridViewButtonCell
        {
            private readonly int buttonImageOffset;

            private bool enabled;
            protected Image buttonImageHot;
            protected Image buttonImageNormal;
            protected Image buttonImageDisabled;

            public PushButtonState ButtonState { get; set; }

            protected DataGridViewImageButtonCell()
            {
                enabled = false;
                ButtonState = PushButtonState.Disabled;

                // Changing this value affects the appearance of the image on the button.
                buttonImageOffset = 2;
            }

            public bool Enabled
            {
                get
                {
                    return enabled;
                }
                set
                {
                    enabled = value;
                    ButtonState = value ? PushButtonState.Normal : PushButtonState.Disabled;
                }
            }

            protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {
                // Draw the cell background
                if ((paintParts & DataGridViewPaintParts.Background) == DataGridViewPaintParts.Background)
                {
                    var cellBackground = new SolidBrush(cellStyle.BackColor);
                    graphics.FillRectangle(cellBackground, cellBounds);
                    cellBackground.Dispose();
                }

                // Draw the cell borders
                if ((paintParts & DataGridViewPaintParts.Border) == DataGridViewPaintParts.Border)
                {
                    PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
                }

                // Calculate the area in which to draw the button.
                // Adjusting the following algorithm and values affects
                // how the image will appear on the button.
                var buttonArea = cellBounds;

                var buttonAdjustment = BorderWidths(advancedBorderStyle);

                buttonArea.X += buttonAdjustment.X;
                buttonArea.Y += buttonAdjustment.Y;
                buttonArea.Height -= buttonAdjustment.Height;
                buttonArea.Width -= buttonAdjustment.Width;

                var imageArea = new Rectangle(buttonArea.X + buttonImageOffset, buttonArea.Y + buttonImageOffset, 16, 16);

                ButtonRenderer.DrawButton(graphics, buttonArea, ButtonImage, imageArea, false, ButtonState);
            }

            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
                if (buttonImageHot != null)
                    buttonImageHot.Dispose();
                if (buttonImageNormal != null)
                    buttonImageNormal.Dispose();
                if (buttonImageDisabled != null)
                    buttonImageDisabled.Dispose();
            }

            private Image ButtonImage
            {
                get
                {
                    switch (ButtonState)
                    {
                        case PushButtonState.Disabled: return buttonImageDisabled;
                        case PushButtonState.Hot: return buttonImageHot;
                        case PushButtonState.Normal:
                        case PushButtonState.Pressed:
                        case PushButtonState.Default: return buttonImageNormal;
                        default: return buttonImageNormal;
                    }
                }
            }
        }
    }
}
