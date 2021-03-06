﻿namespace TadManagementTool
{
    partial class CollaboratorView
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.birthDateLabel = new System.Windows.Forms.Label();
            this.genderLabel = new System.Windows.Forms.Label();
            this.maleRadioButton = new System.Windows.Forms.RadioButton();
            this.femaleRadioButton = new System.Windows.Forms.RadioButton();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.releaseDateLabel = new System.Windows.Forms.Label();
            this.releaseDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.releaseDateCheckBox = new System.Windows.Forms.CheckBox();
            this.telephoneLabel = new System.Windows.Forms.Label();
            this.telephoneListBox = new System.Windows.Forms.ListBox();
            this.phoneTypeComboBox = new System.Windows.Forms.ComboBox();
            this.phoneAreaCodeTextBox = new System.Windows.Forms.TextBox();
            this.phoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.addTelephoneButton = new System.Windows.Forms.Button();
            this.removeTelephoneButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.backToListCollaboratorButton = new System.Windows.Forms.Button();
            this.birthDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.idLabel = new System.Windows.Forms.Label();
            this.userRoleLabel = new System.Windows.Forms.Label();
            this.userRoleComboBox = new System.Windows.Forms.ComboBox();
            this.startDateCheckBox = new System.Windows.Forms.CheckBox();
            this.observationLabel = new System.Windows.Forms.Label();
            this.observationTextBox = new System.Windows.Forms.TextBox();
            this.observationLimitLabel = new System.Windows.Forms.Label();
            this.contributorCheckBox = new System.Windows.Forms.CheckBox();
            this.contributorLabel = new System.Windows.Forms.Label();
            this.modalWaitingPanel = new TadManagementTool.ModalWaitingPanel(this.components);
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(90, 54);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Nome:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(134, 49);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(330, 22);
            this.nameTextBox.TabIndex = 5;
            // 
            // birthDateLabel
            // 
            this.birthDateLabel.AutoSize = true;
            this.birthDateLabel.Location = new System.Drawing.Point(22, 110);
            this.birthDateLabel.Name = "birthDateLabel";
            this.birthDateLabel.Size = new System.Drawing.Size(107, 13);
            this.birthDateLabel.TabIndex = 8;
            this.birthDateLabel.Text = "Data de Nascimento:";
            // 
            // genderLabel
            // 
            this.genderLabel.AutoSize = true;
            this.genderLabel.Location = new System.Drawing.Point(95, 135);
            this.genderLabel.Name = "genderLabel";
            this.genderLabel.Size = new System.Drawing.Size(34, 13);
            this.genderLabel.TabIndex = 10;
            this.genderLabel.Text = "Sexo:";
            // 
            // maleRadioButton
            // 
            this.maleRadioButton.AutoSize = true;
            this.maleRadioButton.Location = new System.Drawing.Point(135, 133);
            this.maleRadioButton.Name = "maleRadioButton";
            this.maleRadioButton.Size = new System.Drawing.Size(73, 17);
            this.maleRadioButton.TabIndex = 11;
            this.maleRadioButton.TabStop = true;
            this.maleRadioButton.Text = "Masculino";
            this.maleRadioButton.UseVisualStyleBackColor = true;
            // 
            // femaleRadioButton
            // 
            this.femaleRadioButton.AutoSize = true;
            this.femaleRadioButton.Location = new System.Drawing.Point(214, 133);
            this.femaleRadioButton.Name = "femaleRadioButton";
            this.femaleRadioButton.Size = new System.Drawing.Size(67, 17);
            this.femaleRadioButton.TabIndex = 12;
            this.femaleRadioButton.TabStop = true;
            this.femaleRadioButton.Text = "Feminino";
            this.femaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(90, 82);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(38, 13);
            this.emailLabel.TabIndex = 6;
            this.emailLabel.Text = "e-Mail:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTextBox.Location = new System.Drawing.Point(135, 77);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(329, 22);
            this.emailTextBox.TabIndex = 7;
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Location = new System.Drawing.Point(51, 178);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(78, 13);
            this.startDateLabel.TabIndex = 13;
            this.startDateLabel.Text = "Data de Início:";
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Enabled = false;
            this.startDateTimePicker.Location = new System.Drawing.Point(156, 176);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(234, 20);
            this.startDateTimePicker.TabIndex = 14;
            // 
            // releaseDateLabel
            // 
            this.releaseDateLabel.AutoSize = true;
            this.releaseDateLabel.Location = new System.Drawing.Point(50, 204);
            this.releaseDateLabel.Name = "releaseDateLabel";
            this.releaseDateLabel.Size = new System.Drawing.Size(80, 13);
            this.releaseDateLabel.TabIndex = 15;
            this.releaseDateLabel.Text = "Data da Saída:";
            // 
            // releaseDateTimePicker
            // 
            this.releaseDateTimePicker.Enabled = false;
            this.releaseDateTimePicker.Location = new System.Drawing.Point(156, 202);
            this.releaseDateTimePicker.Name = "releaseDateTimePicker";
            this.releaseDateTimePicker.Size = new System.Drawing.Size(234, 20);
            this.releaseDateTimePicker.TabIndex = 17;
            // 
            // releaseDateCheckBox
            // 
            this.releaseDateCheckBox.AutoSize = true;
            this.releaseDateCheckBox.Location = new System.Drawing.Point(135, 205);
            this.releaseDateCheckBox.Name = "releaseDateCheckBox";
            this.releaseDateCheckBox.Size = new System.Drawing.Size(15, 14);
            this.releaseDateCheckBox.TabIndex = 16;
            this.releaseDateCheckBox.UseVisualStyleBackColor = true;
            this.releaseDateCheckBox.CheckedChanged += new System.EventHandler(this.releaseDateCheckBox_CheckedChanged);
            // 
            // telephoneLabel
            // 
            this.telephoneLabel.AutoSize = true;
            this.telephoneLabel.Location = new System.Drawing.Point(73, 228);
            this.telephoneLabel.Name = "telephoneLabel";
            this.telephoneLabel.Size = new System.Drawing.Size(57, 13);
            this.telephoneLabel.TabIndex = 18;
            this.telephoneLabel.Text = "Telefones:";
            // 
            // telephoneListBox
            // 
            this.telephoneListBox.FormattingEnabled = true;
            this.telephoneListBox.Location = new System.Drawing.Point(134, 255);
            this.telephoneListBox.Name = "telephoneListBox";
            this.telephoneListBox.Size = new System.Drawing.Size(177, 147);
            this.telephoneListBox.TabIndex = 23;
            // 
            // phoneTypeComboBox
            // 
            this.phoneTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phoneTypeComboBox.FormattingEnabled = true;
            this.phoneTypeComboBox.ItemHeight = 13;
            this.phoneTypeComboBox.Location = new System.Drawing.Point(134, 228);
            this.phoneTypeComboBox.Name = "phoneTypeComboBox";
            this.phoneTypeComboBox.Size = new System.Drawing.Size(90, 21);
            this.phoneTypeComboBox.TabIndex = 19;
            // 
            // phoneAreaCodeTextBox
            // 
            this.phoneAreaCodeTextBox.Location = new System.Drawing.Point(231, 229);
            this.phoneAreaCodeTextBox.Name = "phoneAreaCodeTextBox";
            this.phoneAreaCodeTextBox.Size = new System.Drawing.Size(50, 20);
            this.phoneAreaCodeTextBox.TabIndex = 20;
            this.phoneAreaCodeTextBox.Text = "11";
            this.phoneAreaCodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // phoneNumberTextBox
            // 
            this.phoneNumberTextBox.Location = new System.Drawing.Point(287, 229);
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.Size = new System.Drawing.Size(103, 20);
            this.phoneNumberTextBox.TabIndex = 21;
            this.phoneNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // addTelephoneButton
            // 
            this.addTelephoneButton.Image = global::TadManagementTool.Properties.Resources.phone_add;
            this.addTelephoneButton.Location = new System.Drawing.Point(396, 225);
            this.addTelephoneButton.Name = "addTelephoneButton";
            this.addTelephoneButton.Size = new System.Drawing.Size(32, 28);
            this.addTelephoneButton.TabIndex = 22;
            this.addTelephoneButton.UseVisualStyleBackColor = true;
            this.addTelephoneButton.Click += new System.EventHandler(this.addTelephoneButton_Click);
            // 
            // removeTelephoneButton
            // 
            this.removeTelephoneButton.Image = global::TadManagementTool.Properties.Resources.phone_delete;
            this.removeTelephoneButton.Location = new System.Drawing.Point(317, 255);
            this.removeTelephoneButton.Name = "removeTelephoneButton";
            this.removeTelephoneButton.Size = new System.Drawing.Size(32, 28);
            this.removeTelephoneButton.TabIndex = 24;
            this.removeTelephoneButton.UseVisualStyleBackColor = true;
            this.removeTelephoneButton.Click += new System.EventHandler(this.removeTelephoneButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(468, 603);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 30);
            this.saveButton.TabIndex = 25;
            this.saveButton.Text = "Salvar";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // backToListCollaboratorButton
            // 
            this.backToListCollaboratorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backToListCollaboratorButton.Location = new System.Drawing.Point(3, 603);
            this.backToListCollaboratorButton.Name = "backToListCollaboratorButton";
            this.backToListCollaboratorButton.Size = new System.Drawing.Size(92, 30);
            this.backToListCollaboratorButton.TabIndex = 26;
            this.backToListCollaboratorButton.Text = "Voltar p/ Lista";
            this.backToListCollaboratorButton.UseVisualStyleBackColor = true;
            this.backToListCollaboratorButton.Click += new System.EventHandler(this.backToListCollaboratorButton_Click);
            // 
            // birthDateTimePicker
            // 
            this.birthDateTimePicker.Location = new System.Drawing.Point(135, 107);
            this.birthDateTimePicker.Name = "birthDateTimePicker";
            this.birthDateTimePicker.Size = new System.Drawing.Size(255, 20);
            this.birthDateTimePicker.TabIndex = 9;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(12, 11);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(0, 13);
            this.idLabel.TabIndex = 1;
            this.idLabel.Visible = false;
            // 
            // userRoleLabel
            // 
            this.userRoleLabel.AutoSize = true;
            this.userRoleLabel.Location = new System.Drawing.Point(45, 25);
            this.userRoleLabel.Name = "userRoleLabel";
            this.userRoleLabel.Size = new System.Drawing.Size(85, 13);
            this.userRoleLabel.TabIndex = 2;
            this.userRoleLabel.Text = "Tipo de Usuário:";
            // 
            // userRoleComboBox
            // 
            this.userRoleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userRoleComboBox.FormattingEnabled = true;
            this.userRoleComboBox.ItemHeight = 13;
            this.userRoleComboBox.Location = new System.Drawing.Point(134, 22);
            this.userRoleComboBox.Name = "userRoleComboBox";
            this.userRoleComboBox.Size = new System.Drawing.Size(147, 21);
            this.userRoleComboBox.TabIndex = 3;
            this.userRoleComboBox.SelectedIndexChanged += new System.EventHandler(this.userRoleComboBox_SelectedIndexChanged);
            // 
            // startDateCheckBox
            // 
            this.startDateCheckBox.AutoSize = true;
            this.startDateCheckBox.Location = new System.Drawing.Point(135, 178);
            this.startDateCheckBox.Name = "startDateCheckBox";
            this.startDateCheckBox.Size = new System.Drawing.Size(15, 14);
            this.startDateCheckBox.TabIndex = 16;
            this.startDateCheckBox.UseVisualStyleBackColor = true;
            this.startDateCheckBox.CheckedChanged += new System.EventHandler(this.startDateCheckBox_CheckedChanged);
            // 
            // observationLabel
            // 
            this.observationLabel.AutoSize = true;
            this.observationLabel.Location = new System.Drawing.Point(55, 417);
            this.observationLabel.Name = "observationLabel";
            this.observationLabel.Size = new System.Drawing.Size(73, 13);
            this.observationLabel.TabIndex = 28;
            this.observationLabel.Text = "Observações:";
            // 
            // observationTextBox
            // 
            this.observationTextBox.Location = new System.Drawing.Point(135, 414);
            this.observationTextBox.MaxLength = 2000;
            this.observationTextBox.Multiline = true;
            this.observationTextBox.Name = "observationTextBox";
            this.observationTextBox.Size = new System.Drawing.Size(176, 151);
            this.observationTextBox.TabIndex = 29;
            this.observationTextBox.TextChanged += new System.EventHandler(this.observationTextBox_TextChanged);
            // 
            // observationLimitLabel
            // 
            this.observationLimitLabel.AutoSize = true;
            this.observationLimitLabel.Location = new System.Drawing.Point(132, 568);
            this.observationLimitLabel.Name = "observationLimitLabel";
            this.observationLimitLabel.Size = new System.Drawing.Size(139, 13);
            this.observationLimitLabel.TabIndex = 30;
            this.observationLimitLabel.Text = "(Limite de Caracteres: 2000)";
            this.observationLimitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contributorCheckBox
            // 
            this.contributorCheckBox.AutoSize = true;
            this.contributorCheckBox.Location = new System.Drawing.Point(135, 156);
            this.contributorCheckBox.Name = "contributorCheckBox";
            this.contributorCheckBox.Size = new System.Drawing.Size(15, 14);
            this.contributorCheckBox.TabIndex = 31;
            this.contributorCheckBox.UseVisualStyleBackColor = true;
            // 
            // contributorLabel
            // 
            this.contributorLabel.AutoSize = true;
            this.contributorLabel.Location = new System.Drawing.Point(64, 156);
            this.contributorLabel.Name = "contributorLabel";
            this.contributorLabel.Size = new System.Drawing.Size(66, 13);
            this.contributorLabel.TabIndex = 32;
            this.contributorLabel.Text = "Contribuinte:";
            // 
            // modalWaitingPanel
            // 
            this.modalWaitingPanel.DisplayText = null;
            this.modalWaitingPanel.RelatedControl = this;
            // 
            // CollaboratorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.contributorLabel);
            this.Controls.Add(this.contributorCheckBox);
            this.Controls.Add(this.observationLimitLabel);
            this.Controls.Add(this.observationTextBox);
            this.Controls.Add(this.observationLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.backToListCollaboratorButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.phoneNumberTextBox);
            this.Controls.Add(this.phoneAreaCodeTextBox);
            this.Controls.Add(this.userRoleComboBox);
            this.Controls.Add(this.phoneTypeComboBox);
            this.Controls.Add(this.addTelephoneButton);
            this.Controls.Add(this.removeTelephoneButton);
            this.Controls.Add(this.telephoneListBox);
            this.Controls.Add(this.startDateCheckBox);
            this.Controls.Add(this.releaseDateCheckBox);
            this.Controls.Add(this.releaseDateTimePicker);
            this.Controls.Add(this.birthDateTimePicker);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.femaleRadioButton);
            this.Controls.Add(this.maleRadioButton);
            this.Controls.Add(this.genderLabel);
            this.Controls.Add(this.birthDateLabel);
            this.Controls.Add(this.telephoneLabel);
            this.Controls.Add(this.releaseDateLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.startDateLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.userRoleLabel);
            this.Controls.Add(this.nameLabel);
            this.DoubleBuffered = true;
            this.Name = "CollaboratorView";
            this.Size = new System.Drawing.Size(546, 636);
            this.Load += new System.EventHandler(this.CollaboratorView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label birthDateLabel;
        private System.Windows.Forms.Label genderLabel;
        private System.Windows.Forms.RadioButton maleRadioButton;
        private System.Windows.Forms.RadioButton femaleRadioButton;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.Label releaseDateLabel;
        private System.Windows.Forms.DateTimePicker releaseDateTimePicker;
        private System.Windows.Forms.CheckBox releaseDateCheckBox;
        private System.Windows.Forms.Label telephoneLabel;
        private System.Windows.Forms.ListBox telephoneListBox;
        private System.Windows.Forms.Button removeTelephoneButton;
        private System.Windows.Forms.ComboBox phoneTypeComboBox;
        private System.Windows.Forms.TextBox phoneAreaCodeTextBox;
        private System.Windows.Forms.TextBox phoneNumberTextBox;
        private System.Windows.Forms.Button addTelephoneButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button backToListCollaboratorButton;
        private System.Windows.Forms.DateTimePicker birthDateTimePicker;
        private ModalWaitingPanel modalWaitingPanel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.ComboBox userRoleComboBox;
        private System.Windows.Forms.Label userRoleLabel;
        private System.Windows.Forms.CheckBox startDateCheckBox;
        private System.Windows.Forms.Label observationLimitLabel;
        private System.Windows.Forms.TextBox observationTextBox;
        private System.Windows.Forms.Label observationLabel;
        private System.Windows.Forms.Label contributorLabel;
        private System.Windows.Forms.CheckBox contributorCheckBox;
    }
}
