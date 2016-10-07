namespace TadManagementTool
{
    partial class CollaboratorBirthDayItemUserControl
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
            this.personNameLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // personNameLabel
            // 
            this.personNameLabel.BackColor = System.Drawing.Color.LightGray;
            this.personNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.personNameLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.personNameLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personNameLabel.ForeColor = System.Drawing.Color.Black;
            this.personNameLabel.Location = new System.Drawing.Point(0, 23);
            this.personNameLabel.Name = "personNameLabel";
            this.personNameLabel.Padding = new System.Windows.Forms.Padding(5);
            this.personNameLabel.Size = new System.Drawing.Size(419, 273);
            this.personNameLabel.TabIndex = 0;
            // 
            // dateLabel
            // 
            this.dateLabel.BackColor = System.Drawing.Color.LightBlue;
            this.dateLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(0, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(419, 23);
            this.dateLabel.TabIndex = 1;
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CollaboratorBirthDayItemUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.personNameLabel);
            this.DoubleBuffered = true;
            this.Name = "CollaboratorBirthDayItemUserControl";
            this.Size = new System.Drawing.Size(419, 296);
            this.Load += new System.EventHandler(this.CollaboratorBirthDayItemUserControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label personNameLabel;
        private System.Windows.Forms.Label dateLabel;
    }
}
