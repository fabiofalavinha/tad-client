namespace TadManagementTool
{
    partial class ImageItemUserControl
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
            this.imageContainerPanel = new System.Windows.Forms.Panel();
            this.imageProgressBar = new System.Windows.Forms.ProgressBar();
            this.modalWaitingPanel = new TadManagementTool.ModalWaitingPanel(this.components);
            this.imageContainerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageContainerPanel
            // 
            this.imageContainerPanel.Controls.Add(this.imageProgressBar);
            this.imageContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.imageContainerPanel.Name = "imageContainerPanel";
            this.imageContainerPanel.Size = new System.Drawing.Size(180, 136);
            this.imageContainerPanel.TabIndex = 0;
            // 
            // imageProgressBar
            // 
            this.imageProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.imageProgressBar.Location = new System.Drawing.Point(0, 126);
            this.imageProgressBar.Name = "imageProgressBar";
            this.imageProgressBar.Size = new System.Drawing.Size(180, 10);
            this.imageProgressBar.TabIndex = 0;
            // 
            // modalWaitingPanel
            // 
            this.modalWaitingPanel.DisplayText = null;
            this.modalWaitingPanel.RelatedControl = this.imageContainerPanel;
            // 
            // ImageItemUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imageContainerPanel);
            this.Name = "ImageItemUserControl";
            this.Size = new System.Drawing.Size(180, 136);
            this.Load += new System.EventHandler(this.ImageItemUserControl_Load);
            this.imageContainerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel imageContainerPanel;
        private System.Windows.Forms.ProgressBar imageProgressBar;
        private ModalWaitingPanel modalWaitingPanel;
    }
}
