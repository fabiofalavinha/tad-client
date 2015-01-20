namespace TadManagementTool
{
    partial class ModalWaitingPanel
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
            this.waitingPanel = new TadManagementTool.ModalWaitingPanelUserControl();
            // 
            // waitingPanel
            // 
            this.waitingPanel.BackColor = System.Drawing.Color.Transparent;
            this.waitingPanel.Location = new System.Drawing.Point(0, 0);
            this.waitingPanel.Name = "waitingPanel";
            this.waitingPanel.Size = new System.Drawing.Size(100, 50);
            this.waitingPanel.TabIndex = 0;
            this.waitingPanel.Visible = false;

        }

        #endregion

        private TadManagementTool.ModalWaitingPanelUserControl waitingPanel;
    }
}
