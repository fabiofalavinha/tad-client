namespace TadManagementTool
{
    partial class UploadImageForm
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
            this.fileListBox = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.startUploadButton = new System.Windows.Forms.Button();
            this.modalWaitingPanel = new TadManagementTool.ModalWaitingPanel(this.components);
            this.imageOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // fileListBox
            // 
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.Location = new System.Drawing.Point(13, 13);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.Size = new System.Drawing.Size(315, 95);
            this.fileListBox.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Image = global::TadManagementTool.Properties.Resources.add;
            this.addButton.Location = new System.Drawing.Point(334, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(26, 26);
            this.addButton.TabIndex = 1;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Image = global::TadManagementTool.Properties.Resources.delete;
            this.removeButton.Location = new System.Drawing.Point(334, 44);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(26, 26);
            this.removeButton.TabIndex = 1;
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // startUploadButton
            // 
            this.startUploadButton.Location = new System.Drawing.Point(285, 122);
            this.startUploadButton.Name = "startUploadButton";
            this.startUploadButton.Size = new System.Drawing.Size(75, 23);
            this.startUploadButton.TabIndex = 2;
            this.startUploadButton.Text = "Upload";
            this.startUploadButton.UseVisualStyleBackColor = true;
            this.startUploadButton.Click += new System.EventHandler(this.startUploadButton_Click);
            // 
            // modalWaitingPanel
            // 
            this.modalWaitingPanel.DisplayText = null;
            this.modalWaitingPanel.RelatedControl = this;
            // 
            // imageOpenFileDialog
            // 
            this.imageOpenFileDialog.Filter = "PNG|*.png|JPEG|*.jpeg|JPG|*.jpg";
            this.imageOpenFileDialog.Multiselect = true;
            // 
            // UploadImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 157);
            this.ControlBox = false;
            this.Controls.Add(this.startUploadButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.fileListBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UploadImageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Upload";
            this.Load += new System.EventHandler(this.UploadImageForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox fileListBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button startUploadButton;
        private ModalWaitingPanel modalWaitingPanel;
        private System.Windows.Forms.OpenFileDialog imageOpenFileDialog;
    }
}