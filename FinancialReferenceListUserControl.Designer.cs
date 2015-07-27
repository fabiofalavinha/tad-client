namespace TadManagementTool
{
    partial class FinancialReferenceListUserControl
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
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.descriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collaboratorColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.newFinancialReferenceButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // modalWaitingPanel
            // 
            this.modalWaitingPanel.DisplayText = null;
            this.modalWaitingPanel.RelatedControl = this;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descriptionColumn,
            this.categoryColumn,
            this.collaboratorColumn});
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(537, 327);
            this.dataGridView.TabIndex = 1;
            // 
            // descriptionColumn
            // 
            this.descriptionColumn.DataPropertyName = "Description";
            this.descriptionColumn.HeaderText = "Descrição";
            this.descriptionColumn.Name = "descriptionColumn";
            this.descriptionColumn.ReadOnly = true;
            // 
            // categoryColumn
            // 
            this.categoryColumn.DataPropertyName = "Category";
            this.categoryColumn.HeaderText = "Categoria";
            this.categoryColumn.Name = "categoryColumn";
            this.categoryColumn.ReadOnly = true;
            // 
            // collaboratorColumn
            // 
            this.collaboratorColumn.DataPropertyName = "AssociatedWithCollaborator";
            this.collaboratorColumn.HeaderText = "Associado ao Colaborator?";
            this.collaboratorColumn.Name = "collaboratorColumn";
            this.collaboratorColumn.ReadOnly = true;
            // 
            // newFinancialReferenceButton
            // 
            this.newFinancialReferenceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newFinancialReferenceButton.Location = new System.Drawing.Point(449, 341);
            this.newFinancialReferenceButton.Name = "newFinancialReferenceButton";
            this.newFinancialReferenceButton.Size = new System.Drawing.Size(75, 39);
            this.newFinancialReferenceButton.TabIndex = 2;
            this.newFinancialReferenceButton.Text = "Novo";
            this.newFinancialReferenceButton.UseVisualStyleBackColor = true;
            this.newFinancialReferenceButton.Click += new System.EventHandler(this.newFinancialReferenceButton_Click);
            // 
            // FinancialReferenceListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.newFinancialReferenceButton);
            this.Controls.Add(this.dataGridView);
            this.DoubleBuffered = true;
            this.Name = "FinancialReferenceListUserControl";
            this.Size = new System.Drawing.Size(537, 389);
            this.Load += new System.EventHandler(this.FinancialReferenceListUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ModalWaitingPanel modalWaitingPanel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Button newFinancialReferenceButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn collaboratorColumn;
    }
}
