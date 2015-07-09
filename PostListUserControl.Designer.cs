namespace TadManagementTool
{
    partial class PostListUserControl
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
            this.postDataGridView = new System.Windows.Forms.DataGridView();
            this.postTitleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postCreatedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postCreadedByColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postModifiedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postModifiedByColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postVisibilityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.publishedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.postBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.newPostButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.publishedButton = new System.Windows.Forms.Button();
            this.viewDetailsButton = new System.Windows.Forms.Button();
            this.orderPostListCheckBox = new System.Windows.Forms.CheckBox();
            this.modalWaitingPanel = new TadManagementTool.ModalWaitingPanel(this.components);
            this.saveOrderListButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.postDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.postBindingSource)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // postDataGridView
            // 
            this.postDataGridView.AllowUserToAddRows = false;
            this.postDataGridView.AllowUserToDeleteRows = false;
            this.postDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.postDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.postDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.postTitleColumn,
            this.postCreatedColumn,
            this.postCreadedByColumn,
            this.postModifiedColumn,
            this.postModifiedByColumn,
            this.postVisibilityColumn,
            this.publishedColumn});
            this.postDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.postDataGridView.Location = new System.Drawing.Point(0, 36);
            this.postDataGridView.MultiSelect = false;
            this.postDataGridView.Name = "postDataGridView";
            this.postDataGridView.ReadOnly = true;
            this.postDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.postDataGridView.ShowCellErrors = false;
            this.postDataGridView.ShowEditingIcon = false;
            this.postDataGridView.ShowRowErrors = false;
            this.postDataGridView.Size = new System.Drawing.Size(656, 335);
            this.postDataGridView.TabIndex = 0;
            this.postDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.postDataGridView_CellDoubleClick);
            this.postDataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.postDataGridView_DragDrop);
            this.postDataGridView.DragOver += new System.Windows.Forms.DragEventHandler(this.postDataGridView_DragOver);
            this.postDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.postDataGridView_MouseDown);
            this.postDataGridView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.postDataGridView_MouseMove);
            // 
            // postTitleColumn
            // 
            this.postTitleColumn.DataPropertyName = "Title";
            this.postTitleColumn.HeaderText = "Título";
            this.postTitleColumn.Name = "postTitleColumn";
            this.postTitleColumn.ReadOnly = true;
            // 
            // postCreatedColumn
            // 
            this.postCreatedColumn.DataPropertyName = "Created";
            this.postCreatedColumn.HeaderText = "Criado em";
            this.postCreatedColumn.Name = "postCreatedColumn";
            this.postCreatedColumn.ReadOnly = true;
            // 
            // postCreadedByColumn
            // 
            this.postCreadedByColumn.DataPropertyName = "CreatedBy";
            this.postCreadedByColumn.HeaderText = "Criado por";
            this.postCreadedByColumn.Name = "postCreadedByColumn";
            this.postCreadedByColumn.ReadOnly = true;
            // 
            // postModifiedColumn
            // 
            this.postModifiedColumn.DataPropertyName = "Modified";
            this.postModifiedColumn.HeaderText = "Modificado em";
            this.postModifiedColumn.Name = "postModifiedColumn";
            this.postModifiedColumn.ReadOnly = true;
            // 
            // postModifiedByColumn
            // 
            this.postModifiedByColumn.DataPropertyName = "ModifiedBy";
            this.postModifiedByColumn.HeaderText = "Modificado por";
            this.postModifiedByColumn.Name = "postModifiedByColumn";
            this.postModifiedByColumn.ReadOnly = true;
            // 
            // postVisibilityColumn
            // 
            this.postVisibilityColumn.DataPropertyName = "Visibility";
            this.postVisibilityColumn.HeaderText = "Visibilidade";
            this.postVisibilityColumn.Name = "postVisibilityColumn";
            this.postVisibilityColumn.ReadOnly = true;
            // 
            // publishedColumn
            // 
            this.publishedColumn.DataPropertyName = "Published";
            this.publishedColumn.HeaderText = "Publicado?";
            this.publishedColumn.Name = "publishedColumn";
            this.publishedColumn.ReadOnly = true;
            // 
            // buttonPanel
            // 
            this.buttonPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonPanel.Controls.Add(this.newPostButton);
            this.buttonPanel.Controls.Add(this.removeButton);
            this.buttonPanel.Controls.Add(this.publishedButton);
            this.buttonPanel.Controls.Add(this.viewDetailsButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 377);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(656, 54);
            this.buttonPanel.TabIndex = 1;
            // 
            // newPostButton
            // 
            this.newPostButton.Location = new System.Drawing.Point(103, 13);
            this.newPostButton.Name = "newPostButton";
            this.newPostButton.Size = new System.Drawing.Size(75, 23);
            this.newPostButton.TabIndex = 0;
            this.newPostButton.Text = "Novo";
            this.newPostButton.UseVisualStyleBackColor = true;
            this.newPostButton.Click += new System.EventHandler(this.newPostButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(13, 13);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 0;
            this.removeButton.Text = "Apagar";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // publishedButton
            // 
            this.publishedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.publishedButton.Location = new System.Drawing.Point(537, 13);
            this.publishedButton.Name = "publishedButton";
            this.publishedButton.Size = new System.Drawing.Size(103, 23);
            this.publishedButton.TabIndex = 0;
            this.publishedButton.Text = "Publicar";
            this.publishedButton.UseVisualStyleBackColor = true;
            this.publishedButton.Click += new System.EventHandler(this.publishedButton_Click);
            // 
            // viewDetailsButton
            // 
            this.viewDetailsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.viewDetailsButton.Location = new System.Drawing.Point(419, 13);
            this.viewDetailsButton.Name = "viewDetailsButton";
            this.viewDetailsButton.Size = new System.Drawing.Size(103, 23);
            this.viewDetailsButton.TabIndex = 0;
            this.viewDetailsButton.Text = "Ver Detalhes...";
            this.viewDetailsButton.UseVisualStyleBackColor = true;
            this.viewDetailsButton.Click += new System.EventHandler(this.viewDetailsButton_Click);
            // 
            // orderPostListCheckBox
            // 
            this.orderPostListCheckBox.AutoSize = true;
            this.orderPostListCheckBox.Location = new System.Drawing.Point(15, 10);
            this.orderPostListCheckBox.Name = "orderPostListCheckBox";
            this.orderPostListCheckBox.Size = new System.Drawing.Size(88, 17);
            this.orderPostListCheckBox.TabIndex = 2;
            this.orderPostListCheckBox.Text = "Ordernar lista";
            this.orderPostListCheckBox.UseVisualStyleBackColor = true;
            this.orderPostListCheckBox.CheckedChanged += new System.EventHandler(this.orderPostListCheckBox_CheckedChanged);
            // 
            // modalWaitingPanel
            // 
            this.modalWaitingPanel.DisplayText = null;
            this.modalWaitingPanel.RelatedControl = this;
            // 
            // saveOrderListButton
            // 
            this.saveOrderListButton.Location = new System.Drawing.Point(110, 7);
            this.saveOrderListButton.Name = "saveOrderListButton";
            this.saveOrderListButton.Size = new System.Drawing.Size(75, 23);
            this.saveOrderListButton.TabIndex = 3;
            this.saveOrderListButton.Text = "Salvar";
            this.saveOrderListButton.UseVisualStyleBackColor = true;
            this.saveOrderListButton.Visible = false;
            this.saveOrderListButton.Click += new System.EventHandler(this.saveOrderListButton_Click);
            // 
            // PostListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.saveOrderListButton);
            this.Controls.Add(this.orderPostListCheckBox);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.postDataGridView);
            this.DoubleBuffered = true;
            this.Name = "PostListUserControl";
            this.Size = new System.Drawing.Size(656, 431);
            this.Load += new System.EventHandler(this.PostListUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.postDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.postBindingSource)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView postDataGridView;
        private System.Windows.Forms.BindingSource postBindingSource;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button viewDetailsButton;
        private ModalWaitingPanel modalWaitingPanel;
        private System.Windows.Forms.Button publishedButton;
        private System.Windows.Forms.Button newPostButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn postTitleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postCreatedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postCreadedByColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postModifiedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postModifiedByColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postVisibilityColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn publishedColumn;
        private System.Windows.Forms.CheckBox orderPostListCheckBox;
        private System.Windows.Forms.Button saveOrderListButton;

    }
}
