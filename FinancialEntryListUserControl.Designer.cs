namespace TadManagementTool
{
    partial class FinancialEntryListUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.financialEntryDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financialEntryTargetColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.financialReferenceTypeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.financialEntryObservationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financialEntryBalanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financialEntryBalanceTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financialEntryTotalBalanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.financialEntryDateColumn,
            this.financialEntryTargetColumn,
            this.financialReferenceTypeColumn,
            this.financialEntryObservationColumn,
            this.financialEntryBalanceColumn,
            this.financialEntryBalanceTypeColumn,
            this.financialEntryTotalBalanceColumn});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(828, 617);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView_ColumnAdded);
            this.dataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_DataBindingComplete);
            this.dataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_RowsAdded);
            this.dataGridView.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_RowValidated);
            this.dataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_RowValidating);
            this.dataGridView.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_UserAddedRow);
            this.dataGridView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_UserDeletedRow);
            this.dataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_UserDeletingRow);
            // 
            // financialEntryDateColumn
            // 
            this.financialEntryDateColumn.DataPropertyName = "FinancialEntryDate";
            this.financialEntryDateColumn.HeaderText = "Data";
            this.financialEntryDateColumn.Name = "financialEntryDateColumn";
            // 
            // financialEntryTargetColumn
            // 
            this.financialEntryTargetColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.financialEntryTargetColumn.DataPropertyName = "TargetType";
            this.financialEntryTargetColumn.HeaderText = "Nome";
            this.financialEntryTargetColumn.Name = "financialEntryTargetColumn";
            this.financialEntryTargetColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.financialEntryTargetColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // financialReferenceTypeColumn
            // 
            this.financialReferenceTypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.financialReferenceTypeColumn.DataPropertyName = "FinancialReferenceType";
            this.financialReferenceTypeColumn.HeaderText = "Tipo de Lançamento";
            this.financialReferenceTypeColumn.Name = "financialReferenceTypeColumn";
            this.financialReferenceTypeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.financialReferenceTypeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // financialEntryObservationColumn
            // 
            this.financialEntryObservationColumn.DataPropertyName = "Observation";
            this.financialEntryObservationColumn.HeaderText = "Observações";
            this.financialEntryObservationColumn.Name = "financialEntryObservationColumn";
            // 
            // financialEntryBalanceColumn
            // 
            this.financialEntryBalanceColumn.DataPropertyName = "Balance";
            this.financialEntryBalanceColumn.HeaderText = "Valor";
            this.financialEntryBalanceColumn.Name = "financialEntryBalanceColumn";
            // 
            // financialEntryBalanceTypeColumn
            // 
            this.financialEntryBalanceTypeColumn.DataPropertyName = "BalanceType";
            this.financialEntryBalanceTypeColumn.HeaderText = "D/C";
            this.financialEntryBalanceTypeColumn.Name = "financialEntryBalanceTypeColumn";
            // 
            // financialEntryTotalBalanceColumn
            // 
            this.financialEntryTotalBalanceColumn.DataPropertyName = "TotalBalance";
            this.financialEntryTotalBalanceColumn.HeaderText = "Saldo";
            this.financialEntryTotalBalanceColumn.Name = "financialEntryTotalBalanceColumn";
            // 
            // FinancialEntryListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView);
            this.Name = "FinancialEntryListUserControl";
            this.Size = new System.Drawing.Size(828, 617);
            this.Load += new System.EventHandler(this.FinancialEntryListUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn financialEntryDateColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn financialEntryTargetColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn financialReferenceTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn financialEntryObservationColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn financialEntryBalanceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn financialEntryBalanceTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn financialEntryTotalBalanceColumn;
    }
}
