namespace TadManagementTool
{
    partial class ListCollaboratorUserControl
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.collaboratorDetailButton = new System.Windows.Forms.Button();
            this.removeCollaboratorButton = new System.Windows.Forms.Button();
            this.newCollaboratorButton = new System.Windows.Forms.Button();
            this.modalWaitingPanel = new TadManagementTool.ModalWaitingPanel(this.components);
            this.CollaboratorNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollaboratorEmailColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollaboratorStartDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollaboratorGenderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollaboratorTelephoneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollaboratorActiveColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.CollaboratorNameColumn,
            this.CollaboratorEmailColumn,
            this.CollaboratorStartDateColumn,
            this.CollaboratorGenderColumn,
            this.CollaboratorTelephoneColumn,
            this.CollaboratorActiveColumn});
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(648, 337);
            this.dataGridView.TabIndex = 0;
            // 
            // collaboratorDetailButton
            // 
            this.collaboratorDetailButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.collaboratorDetailButton.Location = new System.Drawing.Point(533, 343);
            this.collaboratorDetailButton.Name = "collaboratorDetailButton";
            this.collaboratorDetailButton.Size = new System.Drawing.Size(112, 28);
            this.collaboratorDetailButton.TabIndex = 1;
            this.collaboratorDetailButton.Text = "Ver Detalhes...";
            this.collaboratorDetailButton.UseVisualStyleBackColor = true;
            this.collaboratorDetailButton.Click += new System.EventHandler(this.collaboratorDetailButton_Click);
            // 
            // removeCollaboratorButton
            // 
            this.removeCollaboratorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeCollaboratorButton.Location = new System.Drawing.Point(3, 343);
            this.removeCollaboratorButton.Name = "removeCollaboratorButton";
            this.removeCollaboratorButton.Size = new System.Drawing.Size(112, 28);
            this.removeCollaboratorButton.TabIndex = 1;
            this.removeCollaboratorButton.Text = "Apagar";
            this.removeCollaboratorButton.UseVisualStyleBackColor = true;
            this.removeCollaboratorButton.Click += new System.EventHandler(this.removeCollaboratorButton_Click);
            // 
            // newCollaboratorButton
            // 
            this.newCollaboratorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newCollaboratorButton.Location = new System.Drawing.Point(415, 343);
            this.newCollaboratorButton.Name = "newCollaboratorButton";
            this.newCollaboratorButton.Size = new System.Drawing.Size(112, 28);
            this.newCollaboratorButton.TabIndex = 1;
            this.newCollaboratorButton.Text = "Novo Colaborador";
            this.newCollaboratorButton.UseVisualStyleBackColor = true;
            this.newCollaboratorButton.Click += new System.EventHandler(this.newCollaboratorButton_Click);
            // 
            // modalWaitingPanel
            // 
            this.modalWaitingPanel.DisplayText = null;
            this.modalWaitingPanel.RelatedControl = this;
            // 
            // CollaboratorNameColumn
            // 
            this.CollaboratorNameColumn.DataPropertyName = "Name";
            this.CollaboratorNameColumn.HeaderText = "Nome";
            this.CollaboratorNameColumn.Name = "CollaboratorNameColumn";
            this.CollaboratorNameColumn.ReadOnly = true;
            // 
            // CollaboratorEmailColumn
            // 
            this.CollaboratorEmailColumn.DataPropertyName = "Email";
            this.CollaboratorEmailColumn.HeaderText = "e-Mail";
            this.CollaboratorEmailColumn.Name = "CollaboratorEmailColumn";
            this.CollaboratorEmailColumn.ReadOnly = true;
            // 
            // CollaboratorStartDateColumn
            // 
            this.CollaboratorStartDateColumn.DataPropertyName = "StartDate";
            this.CollaboratorStartDateColumn.HeaderText = "Data de Início";
            this.CollaboratorStartDateColumn.Name = "CollaboratorStartDateColumn";
            this.CollaboratorStartDateColumn.ReadOnly = true;
            // 
            // CollaboratorGenderColumn
            // 
            this.CollaboratorGenderColumn.DataPropertyName = "GenderType";
            this.CollaboratorGenderColumn.HeaderText = "Sexo";
            this.CollaboratorGenderColumn.Name = "CollaboratorGenderColumn";
            this.CollaboratorGenderColumn.ReadOnly = true;
            // 
            // CollaboratorTelephoneColumn
            // 
            this.CollaboratorTelephoneColumn.DataPropertyName = "Telephones";
            this.CollaboratorTelephoneColumn.HeaderText = "Telefone(s)";
            this.CollaboratorTelephoneColumn.Name = "CollaboratorTelephoneColumn";
            this.CollaboratorTelephoneColumn.ReadOnly = true;
            // 
            // CollaboratorActiveColumn
            // 
            this.CollaboratorActiveColumn.DataPropertyName = "Active";
            this.CollaboratorActiveColumn.HeaderText = "Ativo?";
            this.CollaboratorActiveColumn.Name = "CollaboratorActiveColumn";
            this.CollaboratorActiveColumn.ReadOnly = true;
            this.CollaboratorActiveColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ListCollaboratorUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.removeCollaboratorButton);
            this.Controls.Add(this.newCollaboratorButton);
            this.Controls.Add(this.collaboratorDetailButton);
            this.Controls.Add(this.dataGridView);
            this.DoubleBuffered = true;
            this.Name = "ListCollaboratorUserControl";
            this.Size = new System.Drawing.Size(648, 379);
            this.Load += new System.EventHandler(this.ListCollaboratorUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button collaboratorDetailButton;
        private System.Windows.Forms.Button removeCollaboratorButton;
        private System.Windows.Forms.Button newCollaboratorButton;
        private ModalWaitingPanel modalWaitingPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollaboratorNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollaboratorEmailColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollaboratorStartDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollaboratorGenderColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollaboratorTelephoneColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollaboratorActiveColumn;
    }
}
