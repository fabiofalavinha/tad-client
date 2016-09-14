﻿namespace TadManagementTool
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.exportToExcelButton = new System.Windows.Forms.Button();
            this.removeOpenedFinancialEntryButton = new System.Windows.Forms.Button();
            this.closeFinancialEntryBalanceButton = new System.Windows.Forms.Button();
            this.openAddFinancialEntryViewButton = new System.Windows.Forms.Button();
            this.financialEntryFilterPanel = new System.Windows.Forms.Panel();
            this.targetTypeFilterGroupBox = new System.Windows.Forms.GroupBox();
            this.financialReferenceFilterComboBox = new System.Windows.Forms.ComboBox();
            this.targetTypeFilterComboBox = new System.Windows.Forms.ComboBox();
            this.totalBalanceGroupBox = new System.Windows.Forms.GroupBox();
            this.currentBalanceLabel = new System.Windows.Forms.Label();
            this.financialEntrySearchButton = new System.Windows.Forms.Button();
            this.financialEntryDateFilterGroupBox = new System.Windows.Forms.GroupBox();
            this.financialEntryDateToLabel = new System.Windows.Forms.Label();
            this.financialEntryDateFromLabel = new System.Windows.Forms.Label();
            this.financialEntryDateToPicker = new System.Windows.Forms.DateTimePicker();
            this.financialEntryDateFromPicker = new System.Windows.Forms.DateTimePicker();
            this.financialEntryContentPanel = new System.Windows.Forms.Panel();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.exportToExcelSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.financialEntryDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financialEntryTargetColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financialReferenceTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financialEntryObservationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financialEntryBalanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financialEntryBalanceTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financialEntryTotalBalanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financialReceiptActionColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.financialEntryFilterPanel.SuspendLayout();
            this.targetTypeFilterGroupBox.SuspendLayout();
            this.totalBalanceGroupBox.SuspendLayout();
            this.financialEntryDateFilterGroupBox.SuspendLayout();
            this.financialEntryContentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.financialEntryDateColumn,
            this.financialEntryTargetColumn,
            this.financialReferenceTypeColumn,
            this.financialEntryObservationColumn,
            this.financialEntryBalanceColumn,
            this.financialEntryBalanceTypeColumn,
            this.financialEntryTotalBalanceColumn,
            this.financialReceiptActionColumn});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(828, 472);
            this.dataGridView.TabIndex = 7;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            this.dataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseClick);
            this.dataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_DataBindingComplete);
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.exportToExcelButton);
            this.buttonPanel.Controls.Add(this.removeOpenedFinancialEntryButton);
            this.buttonPanel.Controls.Add(this.closeFinancialEntryBalanceButton);
            this.buttonPanel.Controls.Add(this.openAddFinancialEntryViewButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 574);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(828, 43);
            this.buttonPanel.TabIndex = 8;
            // 
            // exportToExcelButton
            // 
            this.exportToExcelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportToExcelButton.Location = new System.Drawing.Point(604, 6);
            this.exportToExcelButton.Name = "exportToExcelButton";
            this.exportToExcelButton.Size = new System.Drawing.Size(95, 30);
            this.exportToExcelButton.TabIndex = 12;
            this.exportToExcelButton.Text = "Export p/ Excel";
            this.exportToExcelButton.UseVisualStyleBackColor = true;
            this.exportToExcelButton.Click += new System.EventHandler(this.exportToExcelButton_Click);
            // 
            // removeOpenedFinancialEntryButton
            // 
            this.removeOpenedFinancialEntryButton.Enabled = false;
            this.removeOpenedFinancialEntryButton.Location = new System.Drawing.Point(131, 6);
            this.removeOpenedFinancialEntryButton.Name = "removeOpenedFinancialEntryButton";
            this.removeOpenedFinancialEntryButton.Size = new System.Drawing.Size(123, 30);
            this.removeOpenedFinancialEntryButton.TabIndex = 11;
            this.removeOpenedFinancialEntryButton.Text = "Apagar Lançamento";
            this.removeOpenedFinancialEntryButton.UseVisualStyleBackColor = true;
            this.removeOpenedFinancialEntryButton.Click += new System.EventHandler(this.removeOpenedFinancialEntryButton_Click);
            // 
            // closeFinancialEntryBalanceButton
            // 
            this.closeFinancialEntryBalanceButton.Location = new System.Drawing.Point(15, 6);
            this.closeFinancialEntryBalanceButton.Name = "closeFinancialEntryBalanceButton";
            this.closeFinancialEntryBalanceButton.Size = new System.Drawing.Size(110, 30);
            this.closeFinancialEntryBalanceButton.TabIndex = 10;
            this.closeFinancialEntryBalanceButton.Text = "Fechar Caixa";
            this.closeFinancialEntryBalanceButton.UseVisualStyleBackColor = true;
            this.closeFinancialEntryBalanceButton.Click += new System.EventHandler(this.closeFinancialEntryBalanceButton_Click);
            // 
            // openAddFinancialEntryViewButton
            // 
            this.openAddFinancialEntryViewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openAddFinancialEntryViewButton.Location = new System.Drawing.Point(705, 6);
            this.openAddFinancialEntryViewButton.Name = "openAddFinancialEntryViewButton";
            this.openAddFinancialEntryViewButton.Size = new System.Drawing.Size(110, 30);
            this.openAddFinancialEntryViewButton.TabIndex = 9;
            this.openAddFinancialEntryViewButton.Text = "Novo Lançamento";
            this.openAddFinancialEntryViewButton.UseVisualStyleBackColor = true;
            this.openAddFinancialEntryViewButton.Click += new System.EventHandler(this.openFinancialEntryViewButton_Click);
            // 
            // financialEntryFilterPanel
            // 
            this.financialEntryFilterPanel.Controls.Add(this.targetTypeFilterGroupBox);
            this.financialEntryFilterPanel.Controls.Add(this.totalBalanceGroupBox);
            this.financialEntryFilterPanel.Controls.Add(this.financialEntrySearchButton);
            this.financialEntryFilterPanel.Controls.Add(this.financialEntryDateFilterGroupBox);
            this.financialEntryFilterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.financialEntryFilterPanel.Location = new System.Drawing.Point(0, 0);
            this.financialEntryFilterPanel.Name = "financialEntryFilterPanel";
            this.financialEntryFilterPanel.Size = new System.Drawing.Size(828, 102);
            this.financialEntryFilterPanel.TabIndex = 3;
            // 
            // targetTypeFilterGroupBox
            // 
            this.targetTypeFilterGroupBox.Controls.Add(this.financialReferenceFilterComboBox);
            this.targetTypeFilterGroupBox.Controls.Add(this.targetTypeFilterComboBox);
            this.targetTypeFilterGroupBox.Location = new System.Drawing.Point(171, 3);
            this.targetTypeFilterGroupBox.Name = "targetTypeFilterGroupBox";
            this.targetTypeFilterGroupBox.Size = new System.Drawing.Size(218, 75);
            this.targetTypeFilterGroupBox.TabIndex = 7;
            this.targetTypeFilterGroupBox.TabStop = false;
            this.targetTypeFilterGroupBox.Text = "Origem / Tipo de Lançamento";
            // 
            // financialReferenceFilterComboBox
            // 
            this.financialReferenceFilterComboBox.DisplayMember = "Description";
            this.financialReferenceFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.financialReferenceFilterComboBox.FormattingEnabled = true;
            this.financialReferenceFilterComboBox.Location = new System.Drawing.Point(17, 46);
            this.financialReferenceFilterComboBox.Name = "financialReferenceFilterComboBox";
            this.financialReferenceFilterComboBox.Size = new System.Drawing.Size(175, 21);
            this.financialReferenceFilterComboBox.TabIndex = 0;
            this.financialReferenceFilterComboBox.ValueMember = "Id";
            // 
            // targetTypeFilterComboBox
            // 
            this.targetTypeFilterComboBox.DisplayMember = "Name";
            this.targetTypeFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetTypeFilterComboBox.FormattingEnabled = true;
            this.targetTypeFilterComboBox.Location = new System.Drawing.Point(17, 19);
            this.targetTypeFilterComboBox.Name = "targetTypeFilterComboBox";
            this.targetTypeFilterComboBox.Size = new System.Drawing.Size(175, 21);
            this.targetTypeFilterComboBox.TabIndex = 0;
            this.targetTypeFilterComboBox.ValueMember = "Id";
            this.targetTypeFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.targetTypeFilterComboBox_SelectedIndexChanged);
            // 
            // totalBalanceGroupBox
            // 
            this.totalBalanceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalBalanceGroupBox.Controls.Add(this.currentBalanceLabel);
            this.totalBalanceGroupBox.Location = new System.Drawing.Point(615, 3);
            this.totalBalanceGroupBox.Name = "totalBalanceGroupBox";
            this.totalBalanceGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.totalBalanceGroupBox.Size = new System.Drawing.Size(200, 75);
            this.totalBalanceGroupBox.TabIndex = 6;
            this.totalBalanceGroupBox.TabStop = false;
            this.totalBalanceGroupBox.Text = "Saldo Atual";
            // 
            // currentBalanceLabel
            // 
            this.currentBalanceLabel.AutoSize = true;
            this.currentBalanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentBalanceLabel.Location = new System.Drawing.Point(6, 29);
            this.currentBalanceLabel.Name = "currentBalanceLabel";
            this.currentBalanceLabel.Size = new System.Drawing.Size(46, 25);
            this.currentBalanceLabel.TabIndex = 0;
            this.currentBalanceLabel.Text = "N/A";
            // 
            // financialEntrySearchButton
            // 
            this.financialEntrySearchButton.Location = new System.Drawing.Point(395, 48);
            this.financialEntrySearchButton.Name = "financialEntrySearchButton";
            this.financialEntrySearchButton.Size = new System.Drawing.Size(82, 30);
            this.financialEntrySearchButton.TabIndex = 5;
            this.financialEntrySearchButton.Text = "Buscar...";
            this.financialEntrySearchButton.UseVisualStyleBackColor = true;
            this.financialEntrySearchButton.Click += new System.EventHandler(this.financialEntrySearchButton_Click);
            // 
            // financialEntryDateFilterGroupBox
            // 
            this.financialEntryDateFilterGroupBox.Controls.Add(this.financialEntryDateToLabel);
            this.financialEntryDateFilterGroupBox.Controls.Add(this.financialEntryDateFromLabel);
            this.financialEntryDateFilterGroupBox.Controls.Add(this.financialEntryDateToPicker);
            this.financialEntryDateFilterGroupBox.Controls.Add(this.financialEntryDateFromPicker);
            this.financialEntryDateFilterGroupBox.Location = new System.Drawing.Point(3, 3);
            this.financialEntryDateFilterGroupBox.Name = "financialEntryDateFilterGroupBox";
            this.financialEntryDateFilterGroupBox.Size = new System.Drawing.Size(162, 76);
            this.financialEntryDateFilterGroupBox.TabIndex = 1;
            this.financialEntryDateFilterGroupBox.TabStop = false;
            this.financialEntryDateFilterGroupBox.Text = "Data de Lançamento";
            // 
            // financialEntryDateToLabel
            // 
            this.financialEntryDateToLabel.AutoSize = true;
            this.financialEntryDateToLabel.Location = new System.Drawing.Point(9, 50);
            this.financialEntryDateToLabel.Name = "financialEntryDateToLabel";
            this.financialEntryDateToLabel.Size = new System.Drawing.Size(26, 13);
            this.financialEntryDateToLabel.TabIndex = 3;
            this.financialEntryDateToLabel.Text = "Até:";
            // 
            // financialEntryDateFromLabel
            // 
            this.financialEntryDateFromLabel.AutoSize = true;
            this.financialEntryDateFromLabel.Location = new System.Drawing.Point(9, 25);
            this.financialEntryDateFromLabel.Name = "financialEntryDateFromLabel";
            this.financialEntryDateFromLabel.Size = new System.Drawing.Size(24, 13);
            this.financialEntryDateFromLabel.TabIndex = 3;
            this.financialEntryDateFromLabel.Text = "De:";
            // 
            // financialEntryDateToPicker
            // 
            this.financialEntryDateToPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.financialEntryDateToPicker.Location = new System.Drawing.Point(41, 48);
            this.financialEntryDateToPicker.Name = "financialEntryDateToPicker";
            this.financialEntryDateToPicker.Size = new System.Drawing.Size(95, 20);
            this.financialEntryDateToPicker.TabIndex = 4;
            // 
            // financialEntryDateFromPicker
            // 
            this.financialEntryDateFromPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.financialEntryDateFromPicker.Location = new System.Drawing.Point(41, 21);
            this.financialEntryDateFromPicker.Name = "financialEntryDateFromPicker";
            this.financialEntryDateFromPicker.Size = new System.Drawing.Size(95, 20);
            this.financialEntryDateFromPicker.TabIndex = 2;
            // 
            // financialEntryContentPanel
            // 
            this.financialEntryContentPanel.Controls.Add(this.dataGridView);
            this.financialEntryContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.financialEntryContentPanel.Location = new System.Drawing.Point(0, 102);
            this.financialEntryContentPanel.Name = "financialEntryContentPanel";
            this.financialEntryContentPanel.Size = new System.Drawing.Size(828, 472);
            this.financialEntryContentPanel.TabIndex = 6;
            // 
            // exportToExcelSaveFileDialog
            // 
            this.exportToExcelSaveFileDialog.Filter = "Excel files|*.xlsx";
            // 
            // financialEntryDateColumn
            // 
            this.financialEntryDateColumn.DataPropertyName = "Date";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.financialEntryDateColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.financialEntryDateColumn.HeaderText = "Data";
            this.financialEntryDateColumn.Name = "financialEntryDateColumn";
            this.financialEntryDateColumn.ReadOnly = true;
            this.financialEntryDateColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.financialEntryDateColumn.Width = 21;
            // 
            // financialEntryTargetColumn
            // 
            this.financialEntryTargetColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.financialEntryTargetColumn.DataPropertyName = "TargetDescription";
            this.financialEntryTargetColumn.HeaderText = "Origem";
            this.financialEntryTargetColumn.Name = "financialEntryTargetColumn";
            this.financialEntryTargetColumn.ReadOnly = true;
            this.financialEntryTargetColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // financialReferenceTypeColumn
            // 
            this.financialReferenceTypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.financialReferenceTypeColumn.DataPropertyName = "TypeReferenceName";
            this.financialReferenceTypeColumn.HeaderText = "Tipo de Lançamento";
            this.financialReferenceTypeColumn.Name = "financialReferenceTypeColumn";
            this.financialReferenceTypeColumn.ReadOnly = true;
            this.financialReferenceTypeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // financialEntryObservationColumn
            // 
            this.financialEntryObservationColumn.DataPropertyName = "AdditionalText";
            this.financialEntryObservationColumn.HeaderText = "Observações";
            this.financialEntryObservationColumn.Name = "financialEntryObservationColumn";
            this.financialEntryObservationColumn.ReadOnly = true;
            // 
            // financialEntryBalanceColumn
            // 
            this.financialEntryBalanceColumn.DataPropertyName = "Value";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.financialEntryBalanceColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.financialEntryBalanceColumn.HeaderText = "Valor";
            this.financialEntryBalanceColumn.Name = "financialEntryBalanceColumn";
            this.financialEntryBalanceColumn.ReadOnly = true;
            // 
            // financialEntryBalanceTypeColumn
            // 
            this.financialEntryBalanceTypeColumn.DataPropertyName = "Category";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.financialEntryBalanceTypeColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.financialEntryBalanceTypeColumn.HeaderText = "D/C";
            this.financialEntryBalanceTypeColumn.Name = "financialEntryBalanceTypeColumn";
            this.financialEntryBalanceTypeColumn.ReadOnly = true;
            // 
            // financialEntryTotalBalanceColumn
            // 
            this.financialEntryTotalBalanceColumn.DataPropertyName = "Balance";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.financialEntryTotalBalanceColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.financialEntryTotalBalanceColumn.HeaderText = "Saldo";
            this.financialEntryTotalBalanceColumn.Name = "financialEntryTotalBalanceColumn";
            this.financialEntryTotalBalanceColumn.ReadOnly = true;
            this.financialEntryTotalBalanceColumn.Width = 120;
            // 
            // financialReceiptActionColumn
            // 
            this.financialReceiptActionColumn.HeaderText = "#";
            this.financialReceiptActionColumn.Name = "financialReceiptActionColumn";
            this.financialReceiptActionColumn.ReadOnly = true;
            this.financialReceiptActionColumn.Width = 20;
            // 
            // FinancialEntryListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.financialEntryContentPanel);
            this.Controls.Add(this.financialEntryFilterPanel);
            this.Controls.Add(this.buttonPanel);
            this.Name = "FinancialEntryListUserControl";
            this.Size = new System.Drawing.Size(828, 617);
            this.Load += new System.EventHandler(this.FinancialEntryListUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.financialEntryFilterPanel.ResumeLayout(false);
            this.targetTypeFilterGroupBox.ResumeLayout(false);
            this.totalBalanceGroupBox.ResumeLayout(false);
            this.totalBalanceGroupBox.PerformLayout();
            this.financialEntryDateFilterGroupBox.ResumeLayout(false);
            this.financialEntryDateFilterGroupBox.PerformLayout();
            this.financialEntryContentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button openAddFinancialEntryViewButton;
        private System.Windows.Forms.Panel financialEntryFilterPanel;
        private System.Windows.Forms.GroupBox financialEntryDateFilterGroupBox;
        private System.Windows.Forms.Panel financialEntryContentPanel;
        private System.Windows.Forms.DateTimePicker financialEntryDateFromPicker;
        private System.Windows.Forms.Label financialEntryDateFromLabel;
        private System.Windows.Forms.DateTimePicker financialEntryDateToPicker;
        private System.Windows.Forms.Button financialEntrySearchButton;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.GroupBox totalBalanceGroupBox;
        private System.Windows.Forms.Label currentBalanceLabel;
        private System.Windows.Forms.GroupBox targetTypeFilterGroupBox;
        private System.Windows.Forms.ComboBox targetTypeFilterComboBox;
        private System.Windows.Forms.ComboBox financialReferenceFilterComboBox;
        private System.Windows.Forms.Button closeFinancialEntryBalanceButton;
        private System.Windows.Forms.Button removeOpenedFinancialEntryButton;
        private System.Windows.Forms.Button exportToExcelButton;
        private System.Windows.Forms.SaveFileDialog exportToExcelSaveFileDialog;
        private System.Windows.Forms.Label financialEntryDateToLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn financialEntryDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn financialEntryTargetColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn financialReferenceTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn financialEntryObservationColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn financialEntryBalanceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn financialEntryBalanceTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn financialEntryTotalBalanceColumn;
        private System.Windows.Forms.DataGridViewButtonColumn financialReceiptActionColumn;
    }
}
