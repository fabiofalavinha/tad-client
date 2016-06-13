namespace TadManagementTool
{
    partial class FinancialEntryEnrollmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinancialEntryEnrollmentForm));
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.buttonSeparatorPanel = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.targetRadionButtonGroupPanel = new System.Windows.Forms.Panel();
            this.targetComboBox = new System.Windows.Forms.ComboBox();
            this.targetCollaboratorTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.targetNonCollaboratorTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.categoryPayableRadionButton = new System.Windows.Forms.RadioButton();
            this.categoryReceivableRadionButton = new System.Windows.Forms.RadioButton();
            this.balanceSeparatorPanel = new System.Windows.Forms.Panel();
            this.entryValueTextBox = new System.Windows.Forms.TextBox();
            this.additionalTextTextBox = new System.Windows.Forms.TextBox();
            this.financialTypeComboBox = new System.Windows.Forms.ComboBox();
            this.balancePreviewValueLabel = new System.Windows.Forms.Label();
            this.currentBalanceValueLabel = new System.Windows.Forms.Label();
            this.entryValueLabel = new System.Windows.Forms.Label();
            this.balancePreviewLabel = new System.Windows.Forms.Label();
            this.currentBalanceLabel = new System.Windows.Forms.Label();
            this.additionalTextLabel = new System.Windows.Forms.Label();
            this.financialTypeLabel = new System.Windows.Forms.Label();
            this.targetLabel = new System.Windows.Forms.Label();
            this.entryDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.entryDateLabel = new System.Windows.Forms.Label();
            this.modalWaitingPanel = new TadManagementTool.ModalWaitingPanel(this.components);
            this.buttonPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.targetRadionButtonGroupPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.buttonSeparatorPanel);
            this.buttonPanel.Controls.Add(this.saveButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 337);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(443, 51);
            this.buttonPanel.TabIndex = 19;
            // 
            // buttonSeparatorPanel
            // 
            this.buttonSeparatorPanel.BackColor = System.Drawing.Color.Black;
            this.buttonSeparatorPanel.Location = new System.Drawing.Point(1, 2);
            this.buttonSeparatorPanel.Name = "buttonSeparatorPanel";
            this.buttonSeparatorPanel.Size = new System.Drawing.Size(443, 1);
            this.buttonSeparatorPanel.TabIndex = 8;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(356, 11);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 30);
            this.saveButton.TabIndex = 21;
            this.saveButton.Text = "Salvar";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.targetRadionButtonGroupPanel);
            this.contentPanel.Controls.Add(this.categoryPayableRadionButton);
            this.contentPanel.Controls.Add(this.categoryReceivableRadionButton);
            this.contentPanel.Controls.Add(this.balanceSeparatorPanel);
            this.contentPanel.Controls.Add(this.entryValueTextBox);
            this.contentPanel.Controls.Add(this.additionalTextTextBox);
            this.contentPanel.Controls.Add(this.financialTypeComboBox);
            this.contentPanel.Controls.Add(this.balancePreviewValueLabel);
            this.contentPanel.Controls.Add(this.currentBalanceValueLabel);
            this.contentPanel.Controls.Add(this.entryValueLabel);
            this.contentPanel.Controls.Add(this.balancePreviewLabel);
            this.contentPanel.Controls.Add(this.currentBalanceLabel);
            this.contentPanel.Controls.Add(this.additionalTextLabel);
            this.contentPanel.Controls.Add(this.financialTypeLabel);
            this.contentPanel.Controls.Add(this.targetLabel);
            this.contentPanel.Controls.Add(this.entryDateTimePicker);
            this.contentPanel.Controls.Add(this.entryDateLabel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(443, 337);
            this.contentPanel.TabIndex = 0;
            // 
            // targetRadionButtonGroupPanel
            // 
            this.targetRadionButtonGroupPanel.Controls.Add(this.targetComboBox);
            this.targetRadionButtonGroupPanel.Controls.Add(this.targetCollaboratorTypeRadioButton);
            this.targetRadionButtonGroupPanel.Controls.Add(this.targetNonCollaboratorTypeRadioButton);
            this.targetRadionButtonGroupPanel.Location = new System.Drawing.Point(191, 45);
            this.targetRadionButtonGroupPanel.Name = "targetRadionButtonGroupPanel";
            this.targetRadionButtonGroupPanel.Size = new System.Drawing.Size(184, 46);
            this.targetRadionButtonGroupPanel.TabIndex = 3;
            // 
            // targetComboBox
            // 
            this.targetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetComboBox.Enabled = false;
            this.targetComboBox.FormattingEnabled = true;
            this.targetComboBox.Location = new System.Drawing.Point(4, 22);
            this.targetComboBox.Name = "targetComboBox";
            this.targetComboBox.Size = new System.Drawing.Size(177, 21);
            this.targetComboBox.TabIndex = 5;
            // 
            // targetCollaboratorTypeRadioButton
            // 
            this.targetCollaboratorTypeRadioButton.AutoSize = true;
            this.targetCollaboratorTypeRadioButton.Location = new System.Drawing.Point(4, 3);
            this.targetCollaboratorTypeRadioButton.Name = "targetCollaboratorTypeRadioButton";
            this.targetCollaboratorTypeRadioButton.Size = new System.Drawing.Size(82, 17);
            this.targetCollaboratorTypeRadioButton.TabIndex = 3;
            this.targetCollaboratorTypeRadioButton.TabStop = true;
            this.targetCollaboratorTypeRadioButton.Text = "Colaborador";
            this.targetCollaboratorTypeRadioButton.UseVisualStyleBackColor = true;
            this.targetCollaboratorTypeRadioButton.CheckedChanged += new System.EventHandler(this.targetCollaboratorTypeRadioButton_CheckedChanged);
            // 
            // targetNonCollaboratorTypeRadioButton
            // 
            this.targetNonCollaboratorTypeRadioButton.AutoSize = true;
            this.targetNonCollaboratorTypeRadioButton.Location = new System.Drawing.Point(92, 3);
            this.targetNonCollaboratorTypeRadioButton.Name = "targetNonCollaboratorTypeRadioButton";
            this.targetNonCollaboratorTypeRadioButton.Size = new System.Drawing.Size(56, 17);
            this.targetNonCollaboratorTypeRadioButton.TabIndex = 4;
            this.targetNonCollaboratorTypeRadioButton.TabStop = true;
            this.targetNonCollaboratorTypeRadioButton.Text = "Outros";
            this.targetNonCollaboratorTypeRadioButton.UseVisualStyleBackColor = true;
            this.targetNonCollaboratorTypeRadioButton.CheckedChanged += new System.EventHandler(this.targetNonCollaboratorTypeRadioButton_CheckedChanged);
            // 
            // categoryPayableRadionButton
            // 
            this.categoryPayableRadionButton.AutoSize = true;
            this.categoryPayableRadionButton.Location = new System.Drawing.Point(259, 225);
            this.categoryPayableRadionButton.Name = "categoryPayableRadionButton";
            this.categoryPayableRadionButton.Size = new System.Drawing.Size(56, 17);
            this.categoryPayableRadionButton.TabIndex = 11;
            this.categoryPayableRadionButton.TabStop = true;
            this.categoryPayableRadionButton.Text = "Débito";
            this.categoryPayableRadionButton.UseVisualStyleBackColor = true;
            // 
            // categoryReceivableRadionButton
            // 
            this.categoryReceivableRadionButton.AutoSize = true;
            this.categoryReceivableRadionButton.Location = new System.Drawing.Point(195, 225);
            this.categoryReceivableRadionButton.Name = "categoryReceivableRadionButton";
            this.categoryReceivableRadionButton.Size = new System.Drawing.Size(58, 17);
            this.categoryReceivableRadionButton.TabIndex = 10;
            this.categoryReceivableRadionButton.TabStop = true;
            this.categoryReceivableRadionButton.Text = "Crédito";
            this.categoryReceivableRadionButton.UseVisualStyleBackColor = true;
            // 
            // balanceSeparatorPanel
            // 
            this.balanceSeparatorPanel.BackColor = System.Drawing.Color.Black;
            this.balanceSeparatorPanel.Location = new System.Drawing.Point(195, 292);
            this.balanceSeparatorPanel.Name = "balanceSeparatorPanel";
            this.balanceSeparatorPanel.Size = new System.Drawing.Size(150, 1);
            this.balanceSeparatorPanel.TabIndex = 20;
            // 
            // entryValueTextBox
            // 
            this.entryValueTextBox.Location = new System.Drawing.Point(195, 265);
            this.entryValueTextBox.Name = "entryValueTextBox";
            this.entryValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.entryValueTextBox.TabIndex = 15;
            this.entryValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // additionalTextTextBox
            // 
            this.additionalTextTextBox.Location = new System.Drawing.Point(195, 124);
            this.additionalTextTextBox.Multiline = true;
            this.additionalTextTextBox.Name = "additionalTextTextBox";
            this.additionalTextTextBox.Size = new System.Drawing.Size(177, 94);
            this.additionalTextTextBox.TabIndex = 9;
            // 
            // financialTypeComboBox
            // 
            this.financialTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.financialTypeComboBox.FormattingEnabled = true;
            this.financialTypeComboBox.ItemHeight = 13;
            this.financialTypeComboBox.Location = new System.Drawing.Point(195, 97);
            this.financialTypeComboBox.Name = "financialTypeComboBox";
            this.financialTypeComboBox.Size = new System.Drawing.Size(177, 21);
            this.financialTypeComboBox.TabIndex = 4;
            // 
            // balancePreviewValueLabel
            // 
            this.balancePreviewValueLabel.AutoSize = true;
            this.balancePreviewValueLabel.Location = new System.Drawing.Point(192, 299);
            this.balancePreviewValueLabel.Name = "balancePreviewValueLabel";
            this.balancePreviewValueLabel.Size = new System.Drawing.Size(27, 13);
            this.balancePreviewValueLabel.TabIndex = 18;
            this.balancePreviewValueLabel.Text = "N/A";
            // 
            // currentBalanceValueLabel
            // 
            this.currentBalanceValueLabel.AutoSize = true;
            this.currentBalanceValueLabel.Location = new System.Drawing.Point(192, 247);
            this.currentBalanceValueLabel.Name = "currentBalanceValueLabel";
            this.currentBalanceValueLabel.Size = new System.Drawing.Size(27, 13);
            this.currentBalanceValueLabel.TabIndex = 13;
            this.currentBalanceValueLabel.Text = "N/A";
            // 
            // entryValueLabel
            // 
            this.entryValueLabel.AutoSize = true;
            this.entryValueLabel.Location = new System.Drawing.Point(75, 269);
            this.entryValueLabel.Name = "entryValueLabel";
            this.entryValueLabel.Size = new System.Drawing.Size(111, 13);
            this.entryValueLabel.TabIndex = 14;
            this.entryValueLabel.Text = "Valor do Lançamento:";
            // 
            // balancePreviewLabel
            // 
            this.balancePreviewLabel.AutoSize = true;
            this.balancePreviewLabel.Location = new System.Drawing.Point(108, 299);
            this.balancePreviewLabel.Name = "balancePreviewLabel";
            this.balancePreviewLabel.Size = new System.Drawing.Size(78, 13);
            this.balancePreviewLabel.TabIndex = 17;
            this.balancePreviewLabel.Text = "Saldo Previsto:";
            // 
            // currentBalanceLabel
            // 
            this.currentBalanceLabel.AutoSize = true;
            this.currentBalanceLabel.Location = new System.Drawing.Point(122, 247);
            this.currentBalanceLabel.Name = "currentBalanceLabel";
            this.currentBalanceLabel.Size = new System.Drawing.Size(64, 13);
            this.currentBalanceLabel.TabIndex = 12;
            this.currentBalanceLabel.Text = "Saldo Atual:";
            // 
            // additionalTextLabel
            // 
            this.additionalTextLabel.AutoSize = true;
            this.additionalTextLabel.Location = new System.Drawing.Point(116, 126);
            this.additionalTextLabel.Name = "additionalTextLabel";
            this.additionalTextLabel.Size = new System.Drawing.Size(73, 13);
            this.additionalTextLabel.TabIndex = 8;
            this.additionalTextLabel.Text = "Observações:";
            // 
            // financialTypeLabel
            // 
            this.financialTypeLabel.AutoSize = true;
            this.financialTypeLabel.Location = new System.Drawing.Point(81, 100);
            this.financialTypeLabel.Name = "financialTypeLabel";
            this.financialTypeLabel.Size = new System.Drawing.Size(108, 13);
            this.financialTypeLabel.TabIndex = 6;
            this.financialTypeLabel.Text = "Tipo de Lançamento:";
            // 
            // targetLabel
            // 
            this.targetLabel.AutoSize = true;
            this.targetLabel.Location = new System.Drawing.Point(146, 52);
            this.targetLabel.Name = "targetLabel";
            this.targetLabel.Size = new System.Drawing.Size(43, 13);
            this.targetLabel.TabIndex = 2;
            this.targetLabel.Text = "Origem:";
            // 
            // entryDateTimePicker
            // 
            this.entryDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.entryDateTimePicker.Location = new System.Drawing.Point(195, 22);
            this.entryDateTimePicker.Name = "entryDateTimePicker";
            this.entryDateTimePicker.Size = new System.Drawing.Size(91, 20);
            this.entryDateTimePicker.TabIndex = 2;
            // 
            // entryDateLabel
            // 
            this.entryDateLabel.AutoSize = true;
            this.entryDateLabel.Location = new System.Drawing.Point(79, 26);
            this.entryDateLabel.Name = "entryDateLabel";
            this.entryDateLabel.Size = new System.Drawing.Size(110, 13);
            this.entryDateLabel.TabIndex = 1;
            this.entryDateLabel.Text = "Data do Lançamento:";
            // 
            // modalWaitingPanel
            // 
            this.modalWaitingPanel.DisplayText = null;
            this.modalWaitingPanel.RelatedControl = this;
            // 
            // FinancialEntryEnrollmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 388);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.buttonPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FinancialEntryEnrollmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dados do Lançamento Financeiro";
            this.Load += new System.EventHandler(this.FinancialEntryEnrollmentForm_Load);
            this.buttonPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.targetRadionButtonGroupPanel.ResumeLayout(false);
            this.targetRadionButtonGroupPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.RadioButton targetNonCollaboratorTypeRadioButton;
        private System.Windows.Forms.RadioButton targetCollaboratorTypeRadioButton;
        private System.Windows.Forms.Label targetLabel;
        private System.Windows.Forms.DateTimePicker entryDateTimePicker;
        private System.Windows.Forms.Label entryDateLabel;
        private ModalWaitingPanel modalWaitingPanel;
        private System.Windows.Forms.ComboBox financialTypeComboBox;
        private System.Windows.Forms.Label financialTypeLabel;
        private System.Windows.Forms.TextBox additionalTextTextBox;
        private System.Windows.Forms.Label additionalTextLabel;
        private System.Windows.Forms.Label currentBalanceValueLabel;
        private System.Windows.Forms.Label currentBalanceLabel;
        private System.Windows.Forms.Label balancePreviewValueLabel;
        private System.Windows.Forms.Label entryValueLabel;
        private System.Windows.Forms.Label balancePreviewLabel;
        private System.Windows.Forms.TextBox entryValueTextBox;
        private System.Windows.Forms.Panel balanceSeparatorPanel;
        private System.Windows.Forms.RadioButton categoryReceivableRadionButton;
        private System.Windows.Forms.RadioButton categoryPayableRadionButton;
        private System.Windows.Forms.Panel buttonSeparatorPanel;
        private System.Windows.Forms.Panel targetRadionButtonGroupPanel;
        private System.Windows.Forms.ComboBox targetComboBox;
    }
}