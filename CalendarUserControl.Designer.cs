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
            this.calendarControl = new Calendar.NET.Calendar();
            this.calendarControlButtonPanel = new System.Windows.Forms.Panel();
            this.addEventButton = new System.Windows.Forms.Button();
            this.modalWaitingPanel = new TadManagementTool.ModalWaitingPanel(this.components);
            this.calendarControlButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // calendarControl
            // 
            this.calendarControl.AllowEditingEvents = true;
            this.calendarControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calendarControl.CalendarDate = new System.DateTime(2015, 6, 12, 12, 3, 0, 0);
            this.calendarControl.CalendarView = Calendar.NET.CalendarViews.Month;
            this.calendarControl.DateHeaderFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.calendarControl.DayOfWeekFont = new System.Drawing.Font("Arial", 10F);
            this.calendarControl.DaysFont = new System.Drawing.Font("Arial", 10F);
            this.calendarControl.DayViewTimeFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.calendarControl.DimDisabledEvents = true;
            this.calendarControl.EventDetailsCallback = null;
            this.calendarControl.HighlightCurrentDay = true;
            this.calendarControl.LoadPresetHolidays = false;
            this.calendarControl.Location = new System.Drawing.Point(0, 0);
            this.calendarControl.Name = "calendarControl";
            this.calendarControl.ShowArrowControls = true;
            this.calendarControl.ShowDashedBorderOnDisabledEvents = true;
            this.calendarControl.ShowDateInHeader = true;
            this.calendarControl.ShowDisabledEvents = false;
            this.calendarControl.ShowEventTooltips = true;
            this.calendarControl.ShowTodayButton = true;
            this.calendarControl.Size = new System.Drawing.Size(588, 363);
            this.calendarControl.TabIndex = 1;
            this.calendarControl.TodayFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            // 
            // calendarControlButtonPanel
            // 
            this.calendarControlButtonPanel.Controls.Add(this.addEventButton);
            this.calendarControlButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.calendarControlButtonPanel.Location = new System.Drawing.Point(0, 362);
            this.calendarControlButtonPanel.Name = "calendarControlButtonPanel";
            this.calendarControlButtonPanel.Size = new System.Drawing.Size(588, 45);
            this.calendarControlButtonPanel.TabIndex = 2;
            // 
            // addEventButton
            // 
            this.addEventButton.Location = new System.Drawing.Point(14, 10);
            this.addEventButton.Name = "addEventButton";
            this.addEventButton.Size = new System.Drawing.Size(92, 23);
            this.addEventButton.TabIndex = 0;
            this.addEventButton.Text = "Novo Evento";
            this.addEventButton.UseVisualStyleBackColor = true;
            this.addEventButton.Click += new System.EventHandler(this.addEventButton_Click);
            // 
            // modalWaitingPanel
            // 
            this.modalWaitingPanel.DisplayText = null;
            this.modalWaitingPanel.RelatedControl = this;
            // 
            // CalendarUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.calendarControlButtonPanel);
            this.Controls.Add(this.calendarControl);
            this.DoubleBuffered = true;
            this.Name = "CalendarUserControl";
            this.Size = new System.Drawing.Size(588, 407);
            this.Load += new System.EventHandler(this.CalendarUserControl_Load);
            this.calendarControlButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ModalWaitingPanel modalWaitingPanel;
        private Calendar.NET.Calendar calendarControl;
        private System.Windows.Forms.Panel calendarControlButtonPanel;
        private System.Windows.Forms.Button addEventButton;


    }
}
