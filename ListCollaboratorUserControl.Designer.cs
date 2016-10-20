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
            this.CollaboratorNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollaboratorEmailColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollaboratorStartDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollaboratorGenderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollaboratorTelephoneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contributorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollaboratorActiveColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.collaboratorDetailButton = new System.Windows.Forms.Button();
            this.removeCollaboratorButton = new System.Windows.Forms.Button();
            this.newCollaboratorButton = new System.Windows.Forms.Button();
            this.activeCollaboratorCountLabel = new System.Windows.Forms.Label();
            this.activeCollaboratorCountValueLabel = new System.Windows.Forms.Label();
            this.exportToExcelButton = new System.Windows.Forms.Button();
            this.exportToExcelSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.filterGroupBox = new System.Windows.Forms.GroupBox();
            this.filterActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.collaboratorSearchButton = new System.Windows.Forms.Button();
            this.nonCollaboratorFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.modalWaitingPanel = new TadManagementTool.ModalWaitingPanel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.filterGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CollaboratorNameColumn,
            this.CollaboratorEmailColumn,
            this.BirthDateColumn,
            this.CollaboratorStartDateColumn,
            this.CollaboratorGenderColumn,
            this.CollaboratorTelephoneColumn,
            this.contributorColumn,
            this.CollaboratorActiveColumn});
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.Location = new System.Drawing.Point(0, 73);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(875, 364);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            this.dataGridView.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView_ColumnDisplayIndexChanged);
            this.dataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_ColumnHeaderMouseClick);
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
            // BirthDateColumn
            // 
            this.BirthDateColumn.DataPropertyName = "BirthDate";
            this.BirthDateColumn.HeaderText = "Data de Nascimento";
            this.BirthDateColumn.Name = "BirthDateColumn";
            this.BirthDateColumn.ReadOnly = true;
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
            // contributorColumn
            // 
            this.contributorColumn.DataPropertyName = "IsContributor";
            this.contributorColumn.HeaderText = "Contribuinte?";
            this.contributorColumn.Name = "contributorColumn";
            this.contributorColumn.ReadOnly = true;
            // 
            // CollaboratorActiveColumn
            // 
            this.CollaboratorActiveColumn.DataPropertyName = "Active";
            this.CollaboratorActiveColumn.HeaderText = "Ativo?";
            this.CollaboratorActiveColumn.Name = "CollaboratorActiveColumn";
            this.CollaboratorActiveColumn.ReadOnly = true;
            this.CollaboratorActiveColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // bindingSource
            // 
            this.bindingSource.Sort = "";
            // 
            // collaboratorDetailButton
            // 
            this.collaboratorDetailButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.collaboratorDetailButton.Location = new System.Drawing.Point(759, 443);
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
            this.removeCollaboratorButton.Location = new System.Drawing.Point(3, 443);
            this.removeCollaboratorButton.Name = "removeCollaboratorButton";
            this.removeCollaboratorButton.Size = new System.Drawing.Size(85, 28);
            this.removeCollaboratorButton.TabIndex = 1;
            this.removeCollaboratorButton.Text = "Apagar";
            this.removeCollaboratorButton.UseVisualStyleBackColor = true;
            this.removeCollaboratorButton.Click += new System.EventHandler(this.removeCollaboratorButton_Click);
            // 
            // newCollaboratorButton
            // 
            this.newCollaboratorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newCollaboratorButton.Location = new System.Drawing.Point(641, 443);
            this.newCollaboratorButton.Name = "newCollaboratorButton";
            this.newCollaboratorButton.Size = new System.Drawing.Size(112, 28);
            this.newCollaboratorButton.TabIndex = 1;
            this.newCollaboratorButton.Text = "Novo Colaborador";
            this.newCollaboratorButton.UseVisualStyleBackColor = true;
            this.newCollaboratorButton.Click += new System.EventHandler(this.newCollaboratorButton_Click);
            // 
            // activeCollaboratorCountLabel
            // 
            this.activeCollaboratorCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.activeCollaboratorCountLabel.AutoSize = true;
            this.activeCollaboratorCountLabel.Location = new System.Drawing.Point(24, 39);
            this.activeCollaboratorCountLabel.Name = "activeCollaboratorCountLabel";
            this.activeCollaboratorCountLabel.Size = new System.Drawing.Size(39, 13);
            this.activeCollaboratorCountLabel.TabIndex = 2;
            this.activeCollaboratorCountLabel.Text = "Ativos:";
            // 
            // activeCollaboratorCountValueLabel
            // 
            this.activeCollaboratorCountValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.activeCollaboratorCountValueLabel.AutoSize = true;
            this.activeCollaboratorCountValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeCollaboratorCountValueLabel.Location = new System.Drawing.Point(65, 38);
            this.activeCollaboratorCountValueLabel.Name = "activeCollaboratorCountValueLabel";
            this.activeCollaboratorCountValueLabel.Size = new System.Drawing.Size(34, 16);
            this.activeCollaboratorCountValueLabel.TabIndex = 3;
            this.activeCollaboratorCountValueLabel.Text = "N/A";
            // 
            // exportToExcelButton
            // 
            this.exportToExcelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exportToExcelButton.Location = new System.Drawing.Point(94, 443);
            this.exportToExcelButton.Name = "exportToExcelButton";
            this.exportToExcelButton.Size = new System.Drawing.Size(101, 28);
            this.exportToExcelButton.TabIndex = 1;
            this.exportToExcelButton.Text = "Export p/ Excel";
            this.exportToExcelButton.UseVisualStyleBackColor = true;
            this.exportToExcelButton.Click += new System.EventHandler(this.exportToExcelButton_Click);
            // 
            // exportToExcelSaveFileDialog
            // 
            this.exportToExcelSaveFileDialog.Filter = "Excel files|*.xlsx";
            // 
            // filterGroupBox
            // 
            this.filterGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterGroupBox.Controls.Add(this.nonCollaboratorFilterCheckBox);
            this.filterGroupBox.Controls.Add(this.filterActiveCheckBox);
            this.filterGroupBox.Controls.Add(this.activeCollaboratorCountLabel);
            this.filterGroupBox.Controls.Add(this.activeCollaboratorCountValueLabel);
            this.filterGroupBox.Location = new System.Drawing.Point(10, 6);
            this.filterGroupBox.Name = "filterGroupBox";
            this.filterGroupBox.Size = new System.Drawing.Size(857, 61);
            this.filterGroupBox.TabIndex = 4;
            this.filterGroupBox.TabStop = false;
            this.filterGroupBox.Text = "Filtros";
            // 
            // filterActiveCheckBox
            // 
            this.filterActiveCheckBox.AutoSize = true;
            this.filterActiveCheckBox.Checked = true;
            this.filterActiveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.filterActiveCheckBox.Location = new System.Drawing.Point(27, 19);
            this.filterActiveCheckBox.Name = "filterActiveCheckBox";
            this.filterActiveCheckBox.Size = new System.Drawing.Size(99, 17);
            this.filterActiveCheckBox.TabIndex = 4;
            this.filterActiveCheckBox.Text = "Apenas ativos?";
            this.filterActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // collaboratorSearchButton
            // 
            this.collaboratorSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.collaboratorSearchButton.Location = new System.Drawing.Point(759, 22);
            this.collaboratorSearchButton.Name = "collaboratorSearchButton";
            this.collaboratorSearchButton.Size = new System.Drawing.Size(102, 36);
            this.collaboratorSearchButton.TabIndex = 5;
            this.collaboratorSearchButton.Text = "Buscar";
            this.collaboratorSearchButton.UseVisualStyleBackColor = true;
            this.collaboratorSearchButton.Click += new System.EventHandler(this.collaboratorSearchButton_Click);
            // 
            // nonCollaboratorFilterCheckBox
            // 
            this.nonCollaboratorFilterCheckBox.AutoSize = true;
            this.nonCollaboratorFilterCheckBox.Checked = true;
            this.nonCollaboratorFilterCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nonCollaboratorFilterCheckBox.Location = new System.Drawing.Point(148, 19);
            this.nonCollaboratorFilterCheckBox.Name = "nonCollaboratorFilterCheckBox";
            this.nonCollaboratorFilterCheckBox.Size = new System.Drawing.Size(123, 17);
            this.nonCollaboratorFilterCheckBox.TabIndex = 5;
            this.nonCollaboratorFilterCheckBox.Text = "Não Colaboradores?";
            this.nonCollaboratorFilterCheckBox.UseVisualStyleBackColor = true;
            // 
            // modalWaitingPanel
            // 
            this.modalWaitingPanel.DisplayText = null;
            this.modalWaitingPanel.RelatedControl = this;
            // 
            // ListCollaboratorUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.collaboratorSearchButton);
            this.Controls.Add(this.filterGroupBox);
            this.Controls.Add(this.exportToExcelButton);
            this.Controls.Add(this.removeCollaboratorButton);
            this.Controls.Add(this.newCollaboratorButton);
            this.Controls.Add(this.collaboratorDetailButton);
            this.Controls.Add(this.dataGridView);
            this.DoubleBuffered = true;
            this.Name = "ListCollaboratorUserControl";
            this.Size = new System.Drawing.Size(874, 479);
            this.Load += new System.EventHandler(this.ListCollaboratorUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.filterGroupBox.ResumeLayout(false);
            this.filterGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button collaboratorDetailButton;
        private System.Windows.Forms.Button removeCollaboratorButton;
        private System.Windows.Forms.Button newCollaboratorButton;
        private ModalWaitingPanel modalWaitingPanel;
        private System.Windows.Forms.Label activeCollaboratorCountValueLabel;
        private System.Windows.Forms.Label activeCollaboratorCountLabel;
        private System.Windows.Forms.Button exportToExcelButton;
        private System.Windows.Forms.SaveFileDialog exportToExcelSaveFileDialog;
        private System.Windows.Forms.GroupBox filterGroupBox;
        private System.Windows.Forms.CheckBox filterActiveCheckBox;
        private System.Windows.Forms.Button collaboratorSearchButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollaboratorNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollaboratorEmailColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollaboratorStartDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollaboratorGenderColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollaboratorTelephoneColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contributorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollaboratorActiveColumn;
        private System.Windows.Forms.CheckBox nonCollaboratorFilterCheckBox;
    }
}
