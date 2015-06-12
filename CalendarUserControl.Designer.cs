namespace TadManagementTool
{
    partial class CalendarUserControl
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
            this.modalWaitingPanel = new TadManagementTool.ModalWaitingPanel(this.components);
            this.calendarControl = new Calendar.NET.Calendar();
            this.SuspendLayout();
            // 
            // modalWaitingPanel
            // 
            this.modalWaitingPanel.DisplayText = null;
            this.modalWaitingPanel.RelatedControl = this;
            // 
            // calendarControl
            // 
            this.calendarControl.AllowEditingEvents = true;
            this.calendarControl.CalendarDate = new System.DateTime(2015, 6, 12, 12, 3, 41, 637);
            this.calendarControl.CalendarView = Calendar.NET.CalendarViews.Month;
            this.calendarControl.DateHeaderFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.calendarControl.DayOfWeekFont = new System.Drawing.Font("Arial", 10F);
            this.calendarControl.DaysFont = new System.Drawing.Font("Arial", 10F);
            this.calendarControl.DayViewTimeFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.calendarControl.DimDisabledEvents = true;
            this.calendarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calendarControl.HighlightCurrentDay = true;
            this.calendarControl.LoadPresetHolidays = true;
            this.calendarControl.Location = new System.Drawing.Point(0, 0);
            this.calendarControl.Name = "calendarControl";
            this.calendarControl.ShowArrowControls = true;
            this.calendarControl.ShowDashedBorderOnDisabledEvents = true;
            this.calendarControl.ShowDateInHeader = true;
            this.calendarControl.ShowDisabledEvents = false;
            this.calendarControl.ShowEventTooltips = true;
            this.calendarControl.ShowTodayButton = true;
            this.calendarControl.Size = new System.Drawing.Size(588, 407);
            this.calendarControl.TabIndex = 1;
            this.calendarControl.TodayFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            // 
            // CalendarUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.calendarControl);
            this.DoubleBuffered = true;
            this.Name = "CalendarUserControl";
            this.Size = new System.Drawing.Size(588, 407);
            this.Load += new System.EventHandler(this.CalendarUserControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ModalWaitingPanel modalWaitingPanel;
        private Calendar.NET.Calendar calendarControl;


    }
}
