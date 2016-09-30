namespace TadManagementTool
{
    partial class NewsletterListUserControl
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
            this.newsletterDataGridView = new System.Windows.Forms.DataGridView();
            this.NewsletterUserNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewsletterUserEmailColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelButton = new System.Windows.Forms.Panel();
            this.addNewsletterUserButton = new System.Windows.Forms.Button();
            this.exportToExcelButton = new System.Windows.Forms.Button();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.exportToExcelSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.modalWaitingPanel = new TadManagementTool.ModalWaitingPanel(this.components);
            this.removeNewsletterUserButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.newsletterDataGridView)).BeginInit();
            this.panelContent.SuspendLayout();
            this.panelButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // newsletterDataGridView
            // 
            this.newsletterDataGridView.AllowUserToAddRows = false;
            this.newsletterDataGridView.AllowUserToDeleteRows = false;
            this.newsletterDataGridView.AllowUserToOrderColumns = true;
            this.newsletterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.newsletterDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NewsletterUserNameColumn,
            this.NewsletterUserEmailColumn});
            this.newsletterDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newsletterDataGridView.Location = new System.Drawing.Point(0, 0);
            this.newsletterDataGridView.MultiSelect = false;
            this.newsletterDataGridView.Name = "newsletterDataGridView";
            this.newsletterDataGridView.ReadOnly = true;
            this.newsletterDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.newsletterDataGridView.Size = new System.Drawing.Size(740, 453);
            this.newsletterDataGridView.TabIndex = 0;
            // 
            // NewsletterUserNameColumn
            // 
            this.NewsletterUserNameColumn.DataPropertyName = "Name";
            this.NewsletterUserNameColumn.HeaderText = "Nome";
            this.NewsletterUserNameColumn.Name = "NewsletterUserNameColumn";
            this.NewsletterUserNameColumn.ReadOnly = true;
            // 
            // NewsletterUserEmailColumn
            // 
            this.NewsletterUserEmailColumn.DataPropertyName = "Email";
            this.NewsletterUserEmailColumn.HeaderText = "Email";
            this.NewsletterUserEmailColumn.Name = "NewsletterUserEmailColumn";
            this.NewsletterUserEmailColumn.ReadOnly = true;
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.Controls.Add(this.newsletterDataGridView);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(740, 453);
            this.panelContent.TabIndex = 1;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.removeNewsletterUserButton);
            this.panelButton.Controls.Add(this.addNewsletterUserButton);
            this.panelButton.Controls.Add(this.exportToExcelButton);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.Location = new System.Drawing.Point(0, 452);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(740, 58);
            this.panelButton.TabIndex = 2;
            // 
            // addNewsletterUserButton
            // 
            this.addNewsletterUserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addNewsletterUserButton.Location = new System.Drawing.Point(596, 18);
            this.addNewsletterUserButton.Name = "addNewsletterUserButton";
            this.addNewsletterUserButton.Size = new System.Drawing.Size(129, 28);
            this.addNewsletterUserButton.TabIndex = 3;
            this.addNewsletterUserButton.Text = "Registrar Usuário...";
            this.addNewsletterUserButton.UseVisualStyleBackColor = true;
            this.addNewsletterUserButton.Click += new System.EventHandler(this.addNewsletterUserButton_Click);
            // 
            // exportToExcelButton
            // 
            this.exportToExcelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exportToExcelButton.Location = new System.Drawing.Point(13, 18);
            this.exportToExcelButton.Name = "exportToExcelButton";
            this.exportToExcelButton.Size = new System.Drawing.Size(101, 28);
            this.exportToExcelButton.TabIndex = 2;
            this.exportToExcelButton.Text = "Export p/ Excel";
            this.exportToExcelButton.UseVisualStyleBackColor = true;
            this.exportToExcelButton.Click += new System.EventHandler(this.exportToExcelButton_Click);
            // 
            // exportToExcelSaveFileDialog
            // 
            this.exportToExcelSaveFileDialog.Filter = "Excel files|*.xlsx";
            // 
            // modalWaitingPanel
            // 
            this.modalWaitingPanel.DisplayText = null;
            this.modalWaitingPanel.RelatedControl = this;
            // 
            // removeNewsletterUserButton
            // 
            this.removeNewsletterUserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeNewsletterUserButton.Location = new System.Drawing.Point(448, 18);
            this.removeNewsletterUserButton.Name = "removeNewsletterUserButton";
            this.removeNewsletterUserButton.Size = new System.Drawing.Size(129, 28);
            this.removeNewsletterUserButton.TabIndex = 4;
            this.removeNewsletterUserButton.Text = "Remover Usuário";
            this.removeNewsletterUserButton.UseVisualStyleBackColor = true;
            this.removeNewsletterUserButton.Click += new System.EventHandler(this.removeNewsletterUserButton_Click);
            // 
            // NewsletterListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.panelContent);
            this.DoubleBuffered = true;
            this.Name = "NewsletterListUserControl";
            this.Size = new System.Drawing.Size(740, 510);
            this.Load += new System.EventHandler(this.NewsletterListUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.newsletterDataGridView)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView newsletterDataGridView;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button exportToExcelButton;
        private System.Windows.Forms.Button addNewsletterUserButton;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.SaveFileDialog exportToExcelSaveFileDialog;
        private ModalWaitingPanel modalWaitingPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewsletterUserNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewsletterUserEmailColumn;
        private System.Windows.Forms.Button removeNewsletterUserButton;
    }
}
