namespace TadManagementTool
{
    partial class ConsecrationHistoryListUserControl
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
            this.consecrationDataGridView = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modalWaitingPanel = new TadManagementTool.ModalWaitingPanel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.consecrationDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // consecrationDataGridView
            // 
            this.consecrationDataGridView.AllowUserToAddRows = false;
            this.consecrationDataGridView.AllowUserToDeleteRows = false;
            this.consecrationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.consecrationDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.DateColumn});
            this.consecrationDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consecrationDataGridView.Location = new System.Drawing.Point(0, 0);
            this.consecrationDataGridView.Name = "consecrationDataGridView";
            this.consecrationDataGridView.ReadOnly = true;
            this.consecrationDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.consecrationDataGridView.Size = new System.Drawing.Size(763, 468);
            this.consecrationDataGridView.TabIndex = 0;
            // 
            // NameColumn
            // 
            this.NameColumn.DataPropertyName = "Name";
            this.NameColumn.HeaderText = "Nome";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // DateColumn
            // 
            this.DateColumn.DataPropertyName = "Date";
            this.DateColumn.HeaderText = "Data do Evento";
            this.DateColumn.Name = "DateColumn";
            this.DateColumn.ReadOnly = true;
            // 
            // modalWaitingPanel
            // 
            this.modalWaitingPanel.DisplayText = null;
            this.modalWaitingPanel.RelatedControl = this;
            // 
            // ConsecrationHistoryListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.consecrationDataGridView);
            this.DoubleBuffered = true;
            this.Name = "ConsecrationHistoryListUserControl";
            this.Size = new System.Drawing.Size(763, 468);
            this.Load += new System.EventHandler(this.ConsecrationHistoryListUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.consecrationDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView consecrationDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn;
        private ModalWaitingPanel modalWaitingPanel;
        private System.Windows.Forms.BindingSource bindingSource;
    }
}
