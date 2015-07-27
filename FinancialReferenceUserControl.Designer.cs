namespace TadManagementTool
{
    partial class FinancialReferenceUserControl
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
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.associatedWithCollaboratorLabel = new System.Windows.Forms.Label();
            this.associatedWithCollaboratorCheckBox = new System.Windows.Forms.CheckBox();
            this.panelButton = new System.Windows.Forms.Panel();
            this.backToListButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.modalWaitingPanel = new TadManagementTool.ModalWaitingPanel(this.components);
            this.panelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(27, 28);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(58, 13);
            this.descriptionLabel.TabIndex = 0;
            this.descriptionLabel.Text = "Descrição:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTextBox.Location = new System.Drawing.Point(91, 23);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(421, 22);
            this.descriptionTextBox.TabIndex = 1;
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(30, 60);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(55, 13);
            this.categoryLabel.TabIndex = 0;
            this.categoryLabel.Text = "Categoria:";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(91, 57);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(164, 21);
            this.categoryComboBox.TabIndex = 2;
            // 
            // associatedWithCollaboratorLabel
            // 
            this.associatedWithCollaboratorLabel.AutoSize = true;
            this.associatedWithCollaboratorLabel.Location = new System.Drawing.Point(21, 93);
            this.associatedWithCollaboratorLabel.Name = "associatedWithCollaboratorLabel";
            this.associatedWithCollaboratorLabel.Size = new System.Drawing.Size(64, 13);
            this.associatedWithCollaboratorLabel.TabIndex = 0;
            this.associatedWithCollaboratorLabel.Text = "Colaborator:";
            // 
            // associatedWithCollaboratorCheckBox
            // 
            this.associatedWithCollaboratorCheckBox.AutoSize = true;
            this.associatedWithCollaboratorCheckBox.Location = new System.Drawing.Point(91, 92);
            this.associatedWithCollaboratorCheckBox.Name = "associatedWithCollaboratorCheckBox";
            this.associatedWithCollaboratorCheckBox.Size = new System.Drawing.Size(15, 14);
            this.associatedWithCollaboratorCheckBox.TabIndex = 3;
            this.associatedWithCollaboratorCheckBox.UseVisualStyleBackColor = true;
            // 
            // panelButton
            // 
            this.panelButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelButton.Controls.Add(this.saveButton);
            this.panelButton.Controls.Add(this.backToListButton);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.Location = new System.Drawing.Point(0, 397);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(623, 45);
            this.panelButton.TabIndex = 4;
            // 
            // backToListButton
            // 
            this.backToListButton.Location = new System.Drawing.Point(12, 7);
            this.backToListButton.Name = "backToListButton";
            this.backToListButton.Size = new System.Drawing.Size(98, 30);
            this.backToListButton.TabIndex = 0;
            this.backToListButton.Text = "Voltar p/ Lista";
            this.backToListButton.UseVisualStyleBackColor = true;
            this.backToListButton.Click += new System.EventHandler(this.backToListButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(511, 7);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(98, 30);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Salvar";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // modalWaitingPanel
            // 
            this.modalWaitingPanel.DisplayText = null;
            this.modalWaitingPanel.RelatedControl = this;
            // 
            // FinancialReferenceUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.associatedWithCollaboratorCheckBox);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.associatedWithCollaboratorLabel);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.descriptionLabel);
            this.DoubleBuffered = true;
            this.Name = "FinancialReferenceUserControl";
            this.Size = new System.Drawing.Size(623, 442);
            this.Load += new System.EventHandler(this.FinancialReferenceUserControl_Load);
            this.panelButton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label associatedWithCollaboratorLabel;
        private System.Windows.Forms.CheckBox associatedWithCollaboratorCheckBox;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button backToListButton;
        private ModalWaitingPanel modalWaitingPanel;
    }
}
