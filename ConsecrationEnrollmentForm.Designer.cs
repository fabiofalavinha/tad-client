namespace TadManagementTool
{
    partial class ConsecrationEnrollmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsecrationEnrollmentForm));
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.itemsTabPage = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.emailTabPage = new System.Windows.Forms.TabPage();
            this.mailContentTextBox = new System.Windows.Forms.TextBox();
            this.modalWaitingPanel = new TadManagementTool.ModalWaitingPanel(this.components);
            this.ElementNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ElementQuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ElementUnitColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PrimaryCollaboratorColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SecondaryCollaboratorColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.itemsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.emailTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.saveButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 479);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(755, 52);
            this.buttonPanel.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(658, 7);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(85, 37);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Salvar";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.tabControl);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(755, 479);
            this.contentPanel.TabIndex = 2;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.itemsTabPage);
            this.tabControl.Controls.Add(this.emailTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(755, 479);
            this.tabControl.TabIndex = 1;
            // 
            // itemsTabPage
            // 
            this.itemsTabPage.Controls.Add(this.dataGridView);
            this.itemsTabPage.Location = new System.Drawing.Point(4, 22);
            this.itemsTabPage.Name = "itemsTabPage";
            this.itemsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.itemsTabPage.Size = new System.Drawing.Size(747, 453);
            this.itemsTabPage.TabIndex = 0;
            this.itemsTabPage.Text = "Itens";
            this.itemsTabPage.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ElementNameColumn,
            this.ElementQuantityColumn,
            this.ElementUnitColumn,
            this.PrimaryCollaboratorColumn,
            this.SecondaryCollaboratorColumn});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(741, 447);
            this.dataGridView.TabIndex = 0;
            // 
            // emailTabPage
            // 
            this.emailTabPage.Controls.Add(this.mailContentTextBox);
            this.emailTabPage.Location = new System.Drawing.Point(4, 22);
            this.emailTabPage.Name = "emailTabPage";
            this.emailTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.emailTabPage.Size = new System.Drawing.Size(747, 453);
            this.emailTabPage.TabIndex = 1;
            this.emailTabPage.Text = "e-Mail";
            this.emailTabPage.UseVisualStyleBackColor = true;
            // 
            // mailContentTextBox
            // 
            this.mailContentTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mailContentTextBox.Location = new System.Drawing.Point(3, 3);
            this.mailContentTextBox.Multiline = true;
            this.mailContentTextBox.Name = "mailContentTextBox";
            this.mailContentTextBox.Size = new System.Drawing.Size(741, 447);
            this.mailContentTextBox.TabIndex = 0;
            // 
            // modalWaitingPanel
            // 
            this.modalWaitingPanel.DisplayText = null;
            this.modalWaitingPanel.RelatedControl = null;
            // 
            // ElementNameColumn
            // 
            this.ElementNameColumn.DataPropertyName = "Name";
            this.ElementNameColumn.HeaderText = "Nome";
            this.ElementNameColumn.Name = "ElementNameColumn";
            // 
            // ElementQuantityColumn
            // 
            this.ElementQuantityColumn.DataPropertyName = "Quantity";
            this.ElementQuantityColumn.HeaderText = "Quantidade";
            this.ElementQuantityColumn.Name = "ElementQuantityColumn";
            // 
            // ElementUnitColumn
            // 
            this.ElementUnitColumn.DataPropertyName = "Unit";
            this.ElementUnitColumn.HeaderText = "Unidade";
            this.ElementUnitColumn.Name = "ElementUnitColumn";
            this.ElementUnitColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ElementUnitColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // PrimaryCollaboratorColumn
            // 
            this.PrimaryCollaboratorColumn.DataPropertyName = "PrimaryCollaboratorId";
            this.PrimaryCollaboratorColumn.HeaderText = "Colaborador 1";
            this.PrimaryCollaboratorColumn.Name = "PrimaryCollaboratorColumn";
            // 
            // SecondaryCollaboratorColumn
            // 
            this.SecondaryCollaboratorColumn.DataPropertyName = "SecondaryCollaboratorId";
            this.SecondaryCollaboratorColumn.HeaderText = "Colaborador 2";
            this.SecondaryCollaboratorColumn.Name = "SecondaryCollaboratorColumn";
            // 
            // ConsecrationEnrollmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 531);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.buttonPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConsecrationEnrollmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "{0} - Detalhes da Consagração";
            this.Load += new System.EventHandler(this.ConsecrationEnrollmentForm_Load);
            this.buttonPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.itemsTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.emailTabPage.ResumeLayout(false);
            this.emailTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage emailTabPage;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox mailContentTextBox;
        private System.Windows.Forms.TabPage itemsTabPage;
        private ModalWaitingPanel modalWaitingPanel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementQuantityColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn ElementUnitColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn PrimaryCollaboratorColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn SecondaryCollaboratorColumn;
        private System.Windows.Forms.BindingSource bindingSource;
    }
}
