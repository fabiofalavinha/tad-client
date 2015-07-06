namespace TadManagementTool
{
    partial class EventForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.eventTitleLabel = new System.Windows.Forms.Label();
            this.eventTitleTextBox = new System.Windows.Forms.TextBox();
            this.eventNotesLabel = new System.Windows.Forms.Label();
            this.eventNotesTextBox = new System.Windows.Forms.TextBox();
            this.eventDateLabel = new System.Windows.Forms.Label();
            this.eventDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.eventVisibilityLabel = new System.Windows.Forms.Label();
            this.eventPublicVisibilityRadioButton = new System.Windows.Forms.RadioButton();
            this.eventInternalVisibilityRadioButton = new System.Windows.Forms.RadioButton();
            this.removeEventButton = new System.Windows.Forms.Button();
            this.eventBackColorLabel = new System.Windows.Forms.Label();
            this.backColorDialog = new System.Windows.Forms.ColorDialog();
            this.eventColorFontLabel = new System.Windows.Forms.Label();
            this.eventBackColorValueLabel = new System.Windows.Forms.Label();
            this.eventFontColorValueLabel = new System.Windows.Forms.Label();
            this.eventColorGroupBox = new System.Windows.Forms.GroupBox();
            this.fontColorDialog = new System.Windows.Forms.ColorDialog();
            this.modalWaitingPanel = new TadManagementTool.ModalWaitingPanel(this.components);
            this.eventColorGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(393, 299);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(312, 299);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // eventTitleLabel
            // 
            this.eventTitleLabel.AutoSize = true;
            this.eventTitleLabel.Location = new System.Drawing.Point(34, 19);
            this.eventTitleLabel.Name = "eventTitleLabel";
            this.eventTitleLabel.Size = new System.Drawing.Size(38, 13);
            this.eventTitleLabel.TabIndex = 1;
            this.eventTitleLabel.Text = "Título:";
            // 
            // eventTitleTextBox
            // 
            this.eventTitleTextBox.Location = new System.Drawing.Point(78, 16);
            this.eventTitleTextBox.Name = "eventTitleTextBox";
            this.eventTitleTextBox.Size = new System.Drawing.Size(390, 20);
            this.eventTitleTextBox.TabIndex = 2;
            // 
            // eventNotesLabel
            // 
            this.eventNotesLabel.AutoSize = true;
            this.eventNotesLabel.Location = new System.Drawing.Point(16, 77);
            this.eventNotesLabel.Name = "eventNotesLabel";
            this.eventNotesLabel.Size = new System.Drawing.Size(58, 13);
            this.eventNotesLabel.TabIndex = 3;
            this.eventNotesLabel.Text = "Descrição:";
            // 
            // eventNotesTextBox
            // 
            this.eventNotesTextBox.Location = new System.Drawing.Point(78, 77);
            this.eventNotesTextBox.Multiline = true;
            this.eventNotesTextBox.Name = "eventNotesTextBox";
            this.eventNotesTextBox.Size = new System.Drawing.Size(390, 118);
            this.eventNotesTextBox.TabIndex = 4;
            // 
            // eventDateLabel
            // 
            this.eventDateLabel.AutoSize = true;
            this.eventDateLabel.Location = new System.Drawing.Point(39, 47);
            this.eventDateLabel.Name = "eventDateLabel";
            this.eventDateLabel.Size = new System.Drawing.Size(33, 13);
            this.eventDateLabel.TabIndex = 3;
            this.eventDateLabel.Text = "Data:";
            // 
            // eventDateTimePicker
            // 
            this.eventDateTimePicker.Location = new System.Drawing.Point(78, 47);
            this.eventDateTimePicker.Name = "eventDateTimePicker";
            this.eventDateTimePicker.Size = new System.Drawing.Size(225, 20);
            this.eventDateTimePicker.TabIndex = 5;
            // 
            // eventVisibilityLabel
            // 
            this.eventVisibilityLabel.AutoSize = true;
            this.eventVisibilityLabel.Location = new System.Drawing.Point(12, 209);
            this.eventVisibilityLabel.Name = "eventVisibilityLabel";
            this.eventVisibilityLabel.Size = new System.Drawing.Size(62, 13);
            this.eventVisibilityLabel.TabIndex = 3;
            this.eventVisibilityLabel.Text = "Visibilidade:";
            // 
            // eventPublicVisibilityRadioButton
            // 
            this.eventPublicVisibilityRadioButton.AutoSize = true;
            this.eventPublicVisibilityRadioButton.Checked = true;
            this.eventPublicVisibilityRadioButton.Location = new System.Drawing.Point(78, 207);
            this.eventPublicVisibilityRadioButton.Name = "eventPublicVisibilityRadioButton";
            this.eventPublicVisibilityRadioButton.Size = new System.Drawing.Size(60, 17);
            this.eventPublicVisibilityRadioButton.TabIndex = 6;
            this.eventPublicVisibilityRadioButton.TabStop = true;
            this.eventPublicVisibilityRadioButton.Text = "Público";
            this.eventPublicVisibilityRadioButton.UseVisualStyleBackColor = true;
            // 
            // eventInternalVisibilityRadioButton
            // 
            this.eventInternalVisibilityRadioButton.AutoSize = true;
            this.eventInternalVisibilityRadioButton.Location = new System.Drawing.Point(144, 207);
            this.eventInternalVisibilityRadioButton.Name = "eventInternalVisibilityRadioButton";
            this.eventInternalVisibilityRadioButton.Size = new System.Drawing.Size(58, 17);
            this.eventInternalVisibilityRadioButton.TabIndex = 6;
            this.eventInternalVisibilityRadioButton.Text = "Interno";
            this.eventInternalVisibilityRadioButton.UseVisualStyleBackColor = true;
            // 
            // removeEventButton
            // 
            this.removeEventButton.Location = new System.Drawing.Point(15, 299);
            this.removeEventButton.Name = "removeEventButton";
            this.removeEventButton.Size = new System.Drawing.Size(80, 23);
            this.removeEventButton.TabIndex = 0;
            this.removeEventButton.Text = "Apagar";
            this.removeEventButton.UseVisualStyleBackColor = true;
            this.removeEventButton.Click += new System.EventHandler(this.removeEventButton_Click);
            // 
            // eventBackColorLabel
            // 
            this.eventBackColorLabel.AutoSize = true;
            this.eventBackColorLabel.Location = new System.Drawing.Point(54, 19);
            this.eventBackColorLabel.Name = "eventBackColorLabel";
            this.eventBackColorLabel.Size = new System.Drawing.Size(40, 13);
            this.eventBackColorLabel.TabIndex = 7;
            this.eventBackColorLabel.Text = "Fundo:";
            // 
            // eventColorFontLabel
            // 
            this.eventColorFontLabel.AutoSize = true;
            this.eventColorFontLabel.Location = new System.Drawing.Point(164, 19);
            this.eventColorFontLabel.Name = "eventColorFontLabel";
            this.eventColorFontLabel.Size = new System.Drawing.Size(37, 13);
            this.eventColorFontLabel.TabIndex = 8;
            this.eventColorFontLabel.Text = "Fonte:";
            // 
            // eventBackColorValueLabel
            // 
            this.eventBackColorValueLabel.BackColor = System.Drawing.Color.Red;
            this.eventBackColorValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eventBackColorValueLabel.Location = new System.Drawing.Point(95, 19);
            this.eventBackColorValueLabel.Name = "eventBackColorValueLabel";
            this.eventBackColorValueLabel.Size = new System.Drawing.Size(35, 13);
            this.eventBackColorValueLabel.TabIndex = 9;
            this.eventBackColorValueLabel.Click += new System.EventHandler(this.eventBackColorValueLabel_Click);
            // 
            // eventFontColorValueLabel
            // 
            this.eventFontColorValueLabel.BackColor = System.Drawing.Color.White;
            this.eventFontColorValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eventFontColorValueLabel.Location = new System.Drawing.Point(204, 19);
            this.eventFontColorValueLabel.Name = "eventFontColorValueLabel";
            this.eventFontColorValueLabel.Size = new System.Drawing.Size(35, 13);
            this.eventFontColorValueLabel.TabIndex = 9;
            this.eventFontColorValueLabel.Click += new System.EventHandler(this.eventFontColorValueLabel_Click);
            // 
            // eventColorGroupBox
            // 
            this.eventColorGroupBox.Controls.Add(this.eventBackColorLabel);
            this.eventColorGroupBox.Controls.Add(this.eventFontColorValueLabel);
            this.eventColorGroupBox.Controls.Add(this.eventBackColorValueLabel);
            this.eventColorGroupBox.Controls.Add(this.eventColorFontLabel);
            this.eventColorGroupBox.Location = new System.Drawing.Point(19, 235);
            this.eventColorGroupBox.Name = "eventColorGroupBox";
            this.eventColorGroupBox.Size = new System.Drawing.Size(449, 45);
            this.eventColorGroupBox.TabIndex = 10;
            this.eventColorGroupBox.TabStop = false;
            this.eventColorGroupBox.Text = "Cor";
            // 
            // modalWaitingPanel
            // 
            this.modalWaitingPanel.DisplayText = null;
            this.modalWaitingPanel.RelatedControl = this;
            // 
            // EventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 334);
            this.Controls.Add(this.eventColorGroupBox);
            this.Controls.Add(this.eventInternalVisibilityRadioButton);
            this.Controls.Add(this.eventPublicVisibilityRadioButton);
            this.Controls.Add(this.eventDateTimePicker);
            this.Controls.Add(this.eventNotesTextBox);
            this.Controls.Add(this.eventDateLabel);
            this.Controls.Add(this.eventVisibilityLabel);
            this.Controls.Add(this.eventNotesLabel);
            this.Controls.Add(this.eventTitleTextBox);
            this.Controls.Add(this.eventTitleLabel);
            this.Controls.Add(this.removeEventButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EventForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Evento";
            this.Load += new System.EventHandler(this.EventForm_Load);
            this.eventColorGroupBox.ResumeLayout(false);
            this.eventColorGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label eventTitleLabel;
        private System.Windows.Forms.TextBox eventTitleTextBox;
        private System.Windows.Forms.Label eventNotesLabel;
        private System.Windows.Forms.TextBox eventNotesTextBox;
        private System.Windows.Forms.Label eventDateLabel;
        private System.Windows.Forms.DateTimePicker eventDateTimePicker;
        private ModalWaitingPanel modalWaitingPanel;
        private System.Windows.Forms.RadioButton eventInternalVisibilityRadioButton;
        private System.Windows.Forms.RadioButton eventPublicVisibilityRadioButton;
        private System.Windows.Forms.Label eventVisibilityLabel;
        private System.Windows.Forms.Button removeEventButton;
        private System.Windows.Forms.Label eventBackColorValueLabel;
        private System.Windows.Forms.Label eventColorFontLabel;
        private System.Windows.Forms.Label eventBackColorLabel;
        private System.Windows.Forms.ColorDialog backColorDialog;
        private System.Windows.Forms.Label eventFontColorValueLabel;
        private System.Windows.Forms.GroupBox eventColorGroupBox;
        private System.Windows.Forms.ColorDialog fontColorDialog;
    }
}