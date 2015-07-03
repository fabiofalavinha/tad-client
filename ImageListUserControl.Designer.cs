namespace TadManagementTool
{
    partial class ImageListUserControl
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
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.removeImageButton = new System.Windows.Forms.Button();
            this.uploadImageButton = new System.Windows.Forms.Button();
            this.imageFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.modalWaitingPanel = new TadManagementTool.ModalWaitingPanel(this.components);
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonPanel.Controls.Add(this.removeImageButton);
            this.buttonPanel.Controls.Add(this.uploadImageButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 433);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(696, 49);
            this.buttonPanel.TabIndex = 0;
            // 
            // removeImageButton
            // 
            this.removeImageButton.Location = new System.Drawing.Point(14, 13);
            this.removeImageButton.Name = "removeImageButton";
            this.removeImageButton.Size = new System.Drawing.Size(75, 23);
            this.removeImageButton.TabIndex = 0;
            this.removeImageButton.Text = "Apagar";
            this.removeImageButton.UseVisualStyleBackColor = true;
            this.removeImageButton.Click += new System.EventHandler(this.removeImageButton_Click);
            // 
            // uploadImageButton
            // 
            this.uploadImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uploadImageButton.Location = new System.Drawing.Point(606, 13);
            this.uploadImageButton.Name = "uploadImageButton";
            this.uploadImageButton.Size = new System.Drawing.Size(75, 23);
            this.uploadImageButton.TabIndex = 0;
            this.uploadImageButton.Text = "Upload";
            this.uploadImageButton.UseVisualStyleBackColor = true;
            this.uploadImageButton.Click += new System.EventHandler(this.uploadImageButton_Click);
            // 
            // imageFlowLayoutPanel
            // 
            this.imageFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageFlowLayoutPanel.AutoScroll = true;
            this.imageFlowLayoutPanel.BackColor = System.Drawing.Color.White;
            this.imageFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.imageFlowLayoutPanel.Name = "imageFlowLayoutPanel";
            this.imageFlowLayoutPanel.Size = new System.Drawing.Size(690, 424);
            this.imageFlowLayoutPanel.TabIndex = 1;
            // 
            // modalWaitingPanel
            // 
            this.modalWaitingPanel.DisplayText = null;
            this.modalWaitingPanel.RelatedControl = this;
            // 
            // ImageListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imageFlowLayoutPanel);
            this.Controls.Add(this.buttonPanel);
            this.DoubleBuffered = true;
            this.Name = "ImageListUserControl";
            this.Size = new System.Drawing.Size(696, 482);
            this.Load += new System.EventHandler(this.ImageListUserControl_Load);
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button removeImageButton;
        private System.Windows.Forms.Button uploadImageButton;
        private System.Windows.Forms.FlowLayoutPanel imageFlowLayoutPanel;
        private ModalWaitingPanel modalWaitingPanel;
    }
}
