namespace TadManagementTool
{
    partial class ConsecrationListUserControl
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
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.itemsTabPage = new System.Windows.Forms.TabPage();
            this.emailTabPage = new System.Windows.Forms.TabPage();
            this.saveButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.mailContentTextBox = new System.Windows.Forms.TextBox();
            this.buttonPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.emailTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.backButton);
            this.buttonPanel.Controls.Add(this.saveButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 485);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(771, 52);
            this.buttonPanel.TabIndex = 1;
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.tabControl);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(771, 479);
            this.contentPanel.TabIndex = 2;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.itemsTabPage);
            this.tabControl.Controls.Add(this.emailTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(771, 479);
            this.tabControl.TabIndex = 1;
            // 
            // itemsTabPage
            // 
            this.itemsTabPage.Location = new System.Drawing.Point(4, 22);
            this.itemsTabPage.Name = "itemsTabPage";
            this.itemsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.itemsTabPage.Size = new System.Drawing.Size(763, 453);
            this.itemsTabPage.TabIndex = 0;
            this.itemsTabPage.Text = "Itens";
            this.itemsTabPage.UseVisualStyleBackColor = true;
            // 
            // emailTabPage
            // 
            this.emailTabPage.Controls.Add(this.mailContentTextBox);
            this.emailTabPage.Location = new System.Drawing.Point(4, 22);
            this.emailTabPage.Name = "emailTabPage";
            this.emailTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.emailTabPage.Size = new System.Drawing.Size(763, 453);
            this.emailTabPage.TabIndex = 1;
            this.emailTabPage.Text = "e-Mail";
            this.emailTabPage.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(682, 7);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(85, 37);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Salvar";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(4, 7);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(85, 37);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Voltar";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // mailContentTextBox
            // 
            this.mailContentTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mailContentTextBox.Location = new System.Drawing.Point(3, 3);
            this.mailContentTextBox.Multiline = true;
            this.mailContentTextBox.Name = "mailContentTextBox";
            this.mailContentTextBox.Size = new System.Drawing.Size(757, 447);
            this.mailContentTextBox.TabIndex = 0;
            // 
            // ConsecrationListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.buttonPanel);
            this.Name = "ConsecrationListUserControl";
            this.Size = new System.Drawing.Size(771, 537);
            this.buttonPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.emailTabPage.ResumeLayout(false);
            this.emailTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage itemsTabPage;
        private System.Windows.Forms.TabPage emailTabPage;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox mailContentTextBox;
    }
}
