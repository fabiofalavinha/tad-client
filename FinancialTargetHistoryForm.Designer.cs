namespace TadManagementTool
{
    partial class FinancialTargetHistoryForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinancialTargetHistoryForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.referenceTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.referenceTypeComboBox = new System.Windows.Forms.ComboBox();
            this.dateFilterGroupBox = new System.Windows.Forms.GroupBox();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateToLabel = new System.Windows.Forms.Label();
            this.dateFromLabel = new System.Windows.Forms.Label();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financialHistoryDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financialHistoryReferenceTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financialHistoryObservationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financialHistoryValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financialHistoryValueTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modalWaitingPanel = new TadManagementTool.ModalWaitingPanel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contentPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.referenceTypeGroupBox.SuspendLayout();
            this.dateFilterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.financialHistoryDateColumn,
            this.financialHistoryReferenceTypeColumn,
            this.financialHistoryObservationColumn,
            this.financialHistoryValueColumn,
            this.financialHistoryValueTypeColumn});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(556, 277);
            this.dataGridView.TabIndex = 0;
            // 
            // contentPanel
            // 
            this.contentPanel.AutoScroll = true;
            this.contentPanel.Controls.Add(this.dataGridView);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 76);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(556, 277);
            this.contentPanel.TabIndex = 3;
            // 
            // headerPanel
            // 
            this.headerPanel.AutoSize = true;
            this.headerPanel.Controls.Add(this.referenceTypeGroupBox);
            this.headerPanel.Controls.Add(this.dateFilterGroupBox);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(556, 76);
            this.headerPanel.TabIndex = 2;
            // 
            // referenceTypeGroupBox
            // 
            this.referenceTypeGroupBox.Controls.Add(this.searchButton);
            this.referenceTypeGroupBox.Controls.Add(this.referenceTypeComboBox);
            this.referenceTypeGroupBox.Location = new System.Drawing.Point(189, 3);
            this.referenceTypeGroupBox.Name = "referenceTypeGroupBox";
            this.referenceTypeGroupBox.Size = new System.Drawing.Size(161, 70);
            this.referenceTypeGroupBox.TabIndex = 1;
            this.referenceTypeGroupBox.TabStop = false;
            this.referenceTypeGroupBox.Text = "Tipo de Lançamento";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(79, 43);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Buscar";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // referenceTypeComboBox
            // 
            this.referenceTypeComboBox.DisplayMember = "Description";
            this.referenceTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.referenceTypeComboBox.FormattingEnabled = true;
            this.referenceTypeComboBox.Location = new System.Drawing.Point(6, 19);
            this.referenceTypeComboBox.Name = "referenceTypeComboBox";
            this.referenceTypeComboBox.Size = new System.Drawing.Size(148, 21);
            this.referenceTypeComboBox.TabIndex = 0;
            this.referenceTypeComboBox.ValueMember = "Id";
            // 
            // dateFilterGroupBox
            // 
            this.dateFilterGroupBox.Controls.Add(this.toDateTimePicker);
            this.dateFilterGroupBox.Controls.Add(this.fromDateTimePicker);
            this.dateFilterGroupBox.Controls.Add(this.dateToLabel);
            this.dateFilterGroupBox.Controls.Add(this.dateFromLabel);
            this.dateFilterGroupBox.Location = new System.Drawing.Point(3, 3);
            this.dateFilterGroupBox.Name = "dateFilterGroupBox";
            this.dateFilterGroupBox.Size = new System.Drawing.Size(180, 70);
            this.dateFilterGroupBox.TabIndex = 0;
            this.dateFilterGroupBox.TabStop = false;
            this.dateFilterGroupBox.Text = "Data de Lançamento";
            // 
            // toDateTimePicker
            // 
            this.toDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.toDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.toDateTimePicker.Location = new System.Drawing.Point(38, 45);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(113, 20);
            this.toDateTimePicker.TabIndex = 4;
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.fromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromDateTimePicker.Location = new System.Drawing.Point(38, 20);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(113, 20);
            this.fromDateTimePicker.TabIndex = 3;
            // 
            // dateToLabel
            // 
            this.dateToLabel.AutoSize = true;
            this.dateToLabel.Location = new System.Drawing.Point(6, 48);
            this.dateToLabel.Name = "dateToLabel";
            this.dateToLabel.Size = new System.Drawing.Size(26, 13);
            this.dateToLabel.TabIndex = 2;
            this.dateToLabel.Text = "Até:";
            // 
            // dateFromLabel
            // 
            this.dateFromLabel.AutoSize = true;
            this.dateFromLabel.Location = new System.Drawing.Point(8, 22);
            this.dateFromLabel.Name = "dateFromLabel";
            this.dateFromLabel.Size = new System.Drawing.Size(24, 13);
            this.dateFromLabel.TabIndex = 1;
            this.dateFromLabel.Text = "De:";
            // 
            // financialHistoryDateColumn
            // 
            this.financialHistoryDateColumn.DataPropertyName = "Date";
            this.financialHistoryDateColumn.Frozen = true;
            this.financialHistoryDateColumn.HeaderText = "Data";
            this.financialHistoryDateColumn.Name = "financialHistoryDateColumn";
            this.financialHistoryDateColumn.ReadOnly = true;
            // 
            // financialHistoryReferenceTypeColumn
            // 
            this.financialHistoryReferenceTypeColumn.DataPropertyName = "TypeReferenceName";
            this.financialHistoryReferenceTypeColumn.Frozen = true;
            this.financialHistoryReferenceTypeColumn.HeaderText = "Tipo de Lançamento";
            this.financialHistoryReferenceTypeColumn.Name = "financialHistoryReferenceTypeColumn";
            this.financialHistoryReferenceTypeColumn.ReadOnly = true;
            // 
            // financialHistoryObservationColumn
            // 
            this.financialHistoryObservationColumn.DataPropertyName = "AdditionalText";
            this.financialHistoryObservationColumn.Frozen = true;
            this.financialHistoryObservationColumn.HeaderText = "Observação";
            this.financialHistoryObservationColumn.Name = "financialHistoryObservationColumn";
            this.financialHistoryObservationColumn.ReadOnly = true;
            // 
            // financialHistoryValueColumn
            // 
            this.financialHistoryValueColumn.DataPropertyName = "Value";
            this.financialHistoryValueColumn.Frozen = true;
            this.financialHistoryValueColumn.HeaderText = "Valor";
            this.financialHistoryValueColumn.Name = "financialHistoryValueColumn";
            this.financialHistoryValueColumn.ReadOnly = true;
            // 
            // financialHistoryValueTypeColumn
            // 
            this.financialHistoryValueTypeColumn.DataPropertyName = "Category";
            this.financialHistoryValueTypeColumn.HeaderText = "D/C";
            this.financialHistoryValueTypeColumn.Name = "financialHistoryValueTypeColumn";
            this.financialHistoryValueTypeColumn.ReadOnly = true;
            this.financialHistoryValueTypeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // modalWaitingPanel
            // 
            this.modalWaitingPanel.DisplayText = null;
            this.modalWaitingPanel.RelatedControl = this;
            // 
            // FinancialTargetHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(556, 353);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.headerPanel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FinancialTargetHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Histórico de Lançamentos...";
            this.Load += new System.EventHandler(this.FinancialTargetHistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contentPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.referenceTypeGroupBox.ResumeLayout(false);
            this.dateFilterGroupBox.ResumeLayout(false);
            this.dateFilterGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private ModalWaitingPanel modalWaitingPanel;
        private System.Windows.Forms.GroupBox referenceTypeGroupBox;
        private System.Windows.Forms.ComboBox referenceTypeComboBox;
        private System.Windows.Forms.GroupBox dateFilterGroupBox;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.Label dateToLabel;
        private System.Windows.Forms.Label dateFromLabel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn financialHistoryDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn financialHistoryReferenceTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn financialHistoryObservationColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn financialHistoryValueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn financialHistoryValueTypeColumn;
    }
}