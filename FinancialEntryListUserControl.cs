using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
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

        private FinancialReferenceViewItem[] currentFinancialReferenceViewItems;

        public FinancialEntryListUserControl(IMainView parentView)
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
            this.parentView = parentView;
            presenter = new FinancialEntryListPresenter(this);
            currentFinancialReferenceViewItems = new FinancialReferenceViewItem[] { };
        }

        private void FinancialEntryListUserControl_Load(object sender, EventArgs e)
        {
            presenter.InitView();
        }

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Console.WriteLine("Row added");
            var gridView = (DataGridView)sender;
            var row = gridView.Rows[e.RowIndex];
            var financialEntryTargetColumn = row.Cells["financialEntryTargetColumn"] as DataGridViewComboBoxCell;
            financialEntryTargetColumn.DataSource = currentFinancialReferenceViewItems;
            financialEntryTargetColumn.DisplayMember = "Description";
            financialEntryTargetColumn.ValueMember = "Id";
            presenter.OnNewFinancialEntryAdded();
        }

        private void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            Console.WriteLine("Users row added");
            var gridView = (DataGridView)sender;
            var dataBoundItem = e.Row.DataBoundItem;
            Console.WriteLine(dataBoundItem);
            presenter.OnNewFinancialEntryAdded();
        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Console.WriteLine($"DataBindingComplete {e.ListChangedType}");
        }

        private void dataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            Console.WriteLine("Row validating");
        }

        private void dataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            Console.WriteLine("Users deleted row");
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Console.WriteLine("Users deleting row");
        }

        private void dataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("Row validated");
        }

        public void SetFinancialReferenceList(IList<FinancialReferenceViewItem> list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<IList<FinancialReferenceViewItem>>(SetFinancialReferenceList), list);
                return;
            }
            currentFinancialReferenceViewItems = list.ToArray();
        }

        private void dataGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.CellType.Name == "financialReferenceTypeColumn")
            {
                Console.WriteLine("financialReferenceTypeColumn added");
            }
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
            throw new NotImplementedException();
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

        /*
         TODO

            - Ao setar a lista na grid, trocar o template da celula do botão de emissao de recibo

            var recoveryColumn = mainMachinesDataGridView.Columns.Cast<DataGridViewColumn>().SingleOrDefault(c => c.Name == "RecoverButtonColumn");
            if (recoveryColumn != null)
                recoveryColumn.CellTemplate = new DataGridViewRecoveryCell();

         */

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
                        case PushButtonState.Normal: return buttonImageNormal;
                        case PushButtonState.Pressed: return buttonImageNormal;
                        case PushButtonState.Default: return buttonImageNormal;
                        default: return buttonImageNormal;
                    }
                }
            }
        }
    }
}
