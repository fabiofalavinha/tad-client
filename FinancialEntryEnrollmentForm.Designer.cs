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
            this.openHistoryButton = new System.Windows.Forms.Button();
            this.categoryTypeLabel = new System.Windows.Forms.Label();
            this.entryValueTextBox = new System.Windows.Forms.TextBox();
            this.targetRadionButtonGroupPanel = new System.Windows.Forms.Panel();
            this.targetNonCollaboratorTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.targetComboBox = new System.Windows.Forms.ComboBox();
            this.targetCollaboratorTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.targetOtherCollaboratorTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.balanceSeparatorPanel = new System.Windows.Forms.Panel();
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
            this.buttonPanel.Location = new System.Drawing.Point(0, 341);
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
            this.contentPanel.Controls.Add(this.openHistoryButton);
            this.contentPanel.Controls.Add(this.categoryTypeLabel);
            this.contentPanel.Controls.Add(this.entryValueTextBox);
            this.contentPanel.Controls.Add(this.targetRadionButtonGroupPanel);
            this.contentPanel.Controls.Add(this.balanceSeparatorPanel);
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
            this.contentPanel.Size = new System.Drawing.Size(443, 341);
            this.contentPanel.TabIndex = 0;
            // 
            // openHistoryButton
            // 
            this.openHistoryButton.Image = global::TadManagementTool.Properties.Resources.financial_entry_history;
            this.openHistoryButton.Location = new System.Drawing.Point(378, 122);
            this.openHistoryButton.Name = "openHistoryButton";
            this.openHistoryButton.Size = new System.Drawing.Size(28, 23);
            this.openHistoryButton.TabIndex = 24;
            this.openHistoryButton.UseVisualStyleBackColor = true;
            this.openHistoryButton.Visible = false;
            this.openHistoryButton.Click += new System.EventHandler(this.openHistoryButton_Click);
            // 
            // categoryTypeLabel
            // 
            this.categoryTypeLabel.AutoSize = true;
            this.categoryTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryTypeLabel.Location = new System.Drawing.Point(192, 273);
            this.categoryTypeLabel.Name = "categoryTypeLabel";
            this.categoryTypeLabel.Size = new System.Drawing.Size(0, 13);
            this.categoryTypeLabel.TabIndex = 23;
            // 
            // entryValueTextBox
            // 
            this.entryValueTextBox.Location = new System.Drawing.Point(209, 270);
            this.entryValueTextBox.Name = "entryValueTextBox";
            this.entryValueTextBox.Size = new System.Drawing.Size(86, 20);
            this.entryValueTextBox.TabIndex = 22;
            this.entryValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.entryValueTextBox.TextChanged += new System.EventHandler(this.entryValueTextBox_TextChanged);
            // 
            // targetRadionButtonGroupPanel
            // 
            this.targetRadionButtonGroupPanel.Controls.Add(this.targetNonCollaboratorTypeRadioButton);
            this.targetRadionButtonGroupPanel.Controls.Add(this.targetComboBox);
            this.targetRadionButtonGroupPanel.Controls.Add(this.targetCollaboratorTypeRadioButton);
            this.targetRadionButtonGroupPanel.Controls.Add(this.targetOtherCollaboratorTypeRadioButton);
            this.targetRadionButtonGroupPanel.Location = new System.Drawing.Point(191, 45);
            this.targetRadionButtonGroupPanel.Name = "targetRadionButtonGroupPanel";
            this.targetRadionButtonGroupPanel.Size = new System.Drawing.Size(198, 71);
            this.targetRadionButtonGroupPanel.TabIndex = 3;
            // 
            // targetNonCollaboratorTypeRadioButton
            // 
            this.targetNonCollaboratorTypeRadioButton.AutoSize = true;
            this.targetNonCollaboratorTypeRadioButton.Location = new System.Drawing.Point(92, 3);
            this.targetNonCollaboratorTypeRadioButton.Name = "targetNonCollaboratorTypeRadioButton";
            this.targetNonCollaboratorTypeRadioButton.Size = new System.Drawing.Size(105, 17);
            this.targetNonCollaboratorTypeRadioButton.TabIndex = 6;
            this.targetNonCollaboratorTypeRadioButton.TabStop = true;
            this.targetNonCollaboratorTypeRadioButton.Text = "Não Colaborador";
            this.targetNonCollaboratorTypeRadioButton.UseVisualStyleBackColor = true;
            this.targetNonCollaboratorTypeRadioButton.CheckedChanged += new System.EventHandler(this.targetTypeRadioButton_CheckedChanged);
            // 
            // targetComboBox
            // 
            this.targetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetComboBox.Enabled = false;
            this.targetComboBox.FormattingEnabled = true;
            this.targetComboBox.Location = new System.Drawing.Point(3, 47);
            this.targetComboBox.Name = "targetComboBox";
            this.targetComboBox.Size = new System.Drawing.Size(177, 21);
            this.targetComboBox.TabIndex = 5;
            this.targetComboBox.SelectedIndexChanged += new System.EventHandler(this.targetComboBox_SelectedIndexChanged);
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
            this.targetCollaboratorTypeRadioButton.CheckedChanged += new System.EventHandler(this.targetTypeRadioButton_CheckedChanged);
            // 
            // targetOtherCollaboratorTypeRadioButton
            // 
            this.targetOtherCollaboratorTypeRadioButton.AutoSize = true;
            this.targetOtherCollaboratorTypeRadioButton.Location = new System.Drawing.Point(4, 24);
            this.targetOtherCollaboratorTypeRadioButton.Name = "targetOtherCollaboratorTypeRadioButton";
            this.targetOtherCollaboratorTypeRadioButton.Size = new System.Drawing.Size(56, 17);
            this.targetOtherCollaboratorTypeRadioButton.TabIndex = 4;
            this.targetOtherCollaboratorTypeRadioButton.TabStop = true;
            this.targetOtherCollaboratorTypeRadioButton.Text = "Outros";
            this.targetOtherCollaboratorTypeRadioButton.UseVisualStyleBackColor = true;
            this.targetOtherCollaboratorTypeRadioButton.CheckedChanged += new System.EventHandler(this.targetTypeRadioButton_CheckedChanged);
            // 
            // balanceSeparatorPanel
            // 
            this.balanceSeparatorPanel.BackColor = System.Drawing.Color.Black;
            this.balanceSeparatorPanel.Location = new System.Drawing.Point(195, 296);
            this.balanceSeparatorPanel.Name = "balanceSeparatorPanel";
            this.balanceSeparatorPanel.Size = new System.Drawing.Size(100, 1);
            this.balanceSeparatorPanel.TabIndex = 20;
            // 
            // additionalTextTextBox
            // 
            this.additionalTextTextBox.Location = new System.Drawing.Point(195, 149);
            this.additionalTextTextBox.Multiline = true;
            this.additionalTextTextBox.Name = "additionalTextTextBox";
            this.additionalTextTextBox.Size = new System.Drawing.Size(177, 94);
            this.additionalTextTextBox.TabIndex = 9;
            // 
            // financialTypeComboBox
            // 
            this.financialTypeComboBox.DisplayMember = "Description";
            this.financialTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.financialTypeComboBox.Enabled = false;
            this.financialTypeComboBox.FormattingEnabled = true;
            this.financialTypeComboBox.ItemHeight = 13;
            this.financialTypeComboBox.Location = new System.Drawing.Point(195, 122);
            this.financialTypeComboBox.Name = "financialTypeComboBox";
            this.financialTypeComboBox.Size = new System.Drawing.Size(177, 21);
            this.financialTypeComboBox.TabIndex = 4;
            this.financialTypeComboBox.ValueMember = "Id";
            this.financialTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.financialTypeComboBox_SelectedIndexChanged);
            // 
            // balancePreviewValueLabel
            // 
            this.balancePreviewValueLabel.Location = new System.Drawing.Point(196, 302);
            this.balancePreviewValueLabel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.balancePreviewValueLabel.Name = "balancePreviewValueLabel";
            this.balancePreviewValueLabel.Size = new System.Drawing.Size(100, 13);
            this.balancePreviewValueLabel.TabIndex = 18;
            this.balancePreviewValueLabel.Text = "N/A";
            this.balancePreviewValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // currentBalanceValueLabel
            // 
            this.currentBalanceValueLabel.Location = new System.Drawing.Point(196, 251);
            this.currentBalanceValueLabel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.currentBalanceValueLabel.Name = "currentBalanceValueLabel";
            this.currentBalanceValueLabel.Size = new System.Drawing.Size(100, 13);
            this.currentBalanceValueLabel.TabIndex = 13;
            this.currentBalanceValueLabel.Text = "N/A";
            this.currentBalanceValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // entryValueLabel
            // 
            this.entryValueLabel.AutoSize = true;
            this.entryValueLabel.Location = new System.Drawing.Point(75, 273);
            this.entryValueLabel.Name = "entryValueLabel";
            this.entryValueLabel.Size = new System.Drawing.Size(111, 13);
            this.entryValueLabel.TabIndex = 14;
            this.entryValueLabel.Text = "Valor do Lançamento:";
            // 
            // balancePreviewLabel
            // 
            this.balancePreviewLabel.AutoSize = true;
            this.balancePreviewLabel.Location = new System.Drawing.Point(108, 303);
            this.balancePreviewLabel.Name = "balancePreviewLabel";
            this.balancePreviewLabel.Size = new System.Drawing.Size(78, 13);
            this.balancePreviewLabel.TabIndex = 17;
            this.balancePreviewLabel.Text = "Saldo Previsto:";
            // 
            // currentBalanceLabel
            // 
            this.currentBalanceLabel.AutoSize = true;
            this.currentBalanceLabel.Location = new System.Drawing.Point(122, 251);
            this.currentBalanceLabel.Name = "currentBalanceLabel";
            this.currentBalanceLabel.Size = new System.Drawing.Size(64, 13);
            this.currentBalanceLabel.TabIndex = 12;
            this.currentBalanceLabel.Text = "Saldo Atual:";
            // 
            // additionalTextLabel
            // 
            this.additionalTextLabel.AutoSize = true;
            this.additionalTextLabel.Location = new System.Drawing.Point(116, 151);
            this.additionalTextLabel.Name = "additionalTextLabel";
            this.additionalTextLabel.Size = new System.Drawing.Size(73, 13);
            this.additionalTextLabel.TabIndex = 8;
            this.additionalTextLabel.Text = "Observações:";
            // 
            // financialTypeLabel
            // 
            this.financialTypeLabel.AutoSize = true;
            this.financialTypeLabel.Location = new System.Drawing.Point(81, 125);
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
            this.entryDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.entryDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.entryDateTimePicker.Location = new System.Drawing.Point(195, 22);
            this.entryDateTimePicker.Name = "entryDateTimePicker";
            this.entryDateTimePicker.Size = new System.Drawing.Size(101, 20);
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
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 392);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FinancialEntryEnrollmentForm_FormClosing);
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
        private System.Windows.Forms.RadioButton targetOtherCollaboratorTypeRadioButton;
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
        private System.Windows.Forms.Panel balanceSeparatorPanel;
        private System.Windows.Forms.Panel buttonSeparatorPanel;
        private System.Windows.Forms.Panel targetRadionButtonGroupPanel;
        private System.Windows.Forms.ComboBox targetComboBox;
        private System.Windows.Forms.TextBox entryValueTextBox;
        private System.Windows.Forms.Label categoryTypeLabel;
        private System.Windows.Forms.RadioButton targetNonCollaboratorTypeRadioButton;
        private System.Windows.Forms.Button openHistoryButton;
    }
}