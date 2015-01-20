namespace TadManagementTool
{
    partial class ModalWaitingPanelUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModalWaitingPanelUserControl));
            this.waitingPanelControl = new System.Windows.Forms.Panel();
            this.textLabelControl = new System.Windows.Forms.Label();
            this.pictureEdit1 = new System.Windows.Forms.PictureBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.waitingPanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // waitingPanelControl
            // 
            resources.ApplyResources(this.waitingPanelControl, "waitingPanelControl");
            this.waitingPanelControl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.waitingPanelControl.Controls.Add(this.textLabelControl);
            this.waitingPanelControl.Controls.Add(this.pictureEdit1);
            this.waitingPanelControl.Name = "waitingPanelControl";
            // 
            // textLabelControl
            // 
            resources.ApplyResources(this.textLabelControl, "textLabelControl");
            this.textLabelControl.Name = "textLabelControl";
            // 
            // pictureEdit1
            // 
            resources.ApplyResources(this.pictureEdit1, "pictureEdit1");
            this.pictureEdit1.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Image = global::TadManagementTool.Properties.Resources.waitProcess;
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.TabStop = false;
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            // 
            // ModalWaitingPanelUserControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.waitingPanelControl);
            this.Controls.Add(this.pictureBox);
            this.Name = "ModalWaitingPanelUserControl";
            this.Load += new System.EventHandler(this.ModalWaitingPanelUserControl_Load);
            this.waitingPanelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel waitingPanelControl;
        private System.Windows.Forms.PictureBox pictureEdit1;
        private System.Windows.Forms.Label textLabelControl;
    }
}
