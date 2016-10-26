namespace TadManagementTool
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Aniversariantes");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Colaboradores", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Consagrações");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Calendário", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Post(s)");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Newsletter(s)");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Imagens");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Lançamentos");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Tipos de Lançamentos");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Secretaria", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.menuTreeView = new System.Windows.Forms.TreeView();
            this.mainMenuImageList = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.usuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alterarSenhaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modalWaitingPanel = new TadManagementTool.ModalWaitingPanel(this.components);
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.splitContainer);
            this.mainPanel.Controls.Add(this.statusStrip);
            this.mainPanel.Controls.Add(this.menuStrip);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1008, 730);
            this.mainPanel.TabIndex = 1;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.menuTreeView);
            this.splitContainer.Size = new System.Drawing.Size(1008, 684);
            this.splitContainer.SplitterDistance = 256;
            this.splitContainer.TabIndex = 0;
            // 
            // menuTreeView
            // 
            this.menuTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuTreeView.ImageIndex = 0;
            this.menuTreeView.ImageList = this.mainMenuImageList;
            this.menuTreeView.Location = new System.Drawing.Point(0, 0);
            this.menuTreeView.Name = "menuTreeView";
            treeNode1.ImageKey = "birthdays.png";
            treeNode1.Name = "collaboratorBirthDaysTreeItem";
            treeNode1.SelectedImageKey = "birthdays.png";
            treeNode1.Tag = "TadManagementTool.View.Impl.OpenCollaboratorBirthDaysMenuViewAction";
            treeNode1.Text = "Aniversariantes";
            treeNode2.ImageKey = "colaboradores.png";
            treeNode2.Name = "collaboratorTreeItem";
            treeNode2.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode2.SelectedImageKey = "colaboradores.png";
            treeNode2.Tag = "TadManagementTool.View.Impl.OpenCollaboratorMenuViewAction";
            treeNode2.Text = "Colaboradores";
            treeNode3.ImageKey = "consecration.png";
            treeNode3.Name = "consecrationTreeItem";
            treeNode3.SelectedImageKey = "consecration.png";
            treeNode3.Tag = "TadManagementTool.View.Impl.OpenConsecrationMenuViewAction";
            treeNode3.Text = "Consagrações";
            treeNode4.ImageKey = "calendar.png";
            treeNode4.Name = "calendarTreeItem";
            treeNode4.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            treeNode4.SelectedImageKey = "calendar.png";
            treeNode4.Tag = "TadManagementTool.View.Impl.OpenCalendarMenuViewAction";
            treeNode4.Text = "Calendário";
            treeNode5.ImageKey = "post.png";
            treeNode5.Name = "postTreeItem";
            treeNode5.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            treeNode5.SelectedImageKey = "post.png";
            treeNode5.Tag = "TadManagementTool.View.Impl.OpenPostListMenuViewAction";
            treeNode5.Text = "Post(s)";
            treeNode6.ImageKey = "newsletter.png";
            treeNode6.Name = "newsletterTreeMenuItem";
            treeNode6.SelectedImageKey = "newsletter.png";
            treeNode6.Tag = "TadManagementTool.View.Impl.OpenNewsletterListMenuViewAction";
            treeNode6.Text = "Newsletter(s)";
            treeNode7.ImageKey = "photograph_edit.png";
            treeNode7.Name = "carouselImageTreeItem";
            treeNode7.SelectedImageKey = "photograph_edit.png";
            treeNode7.Tag = "TadManagementTool.View.Impl.OpenImageListMenuViewAction";
            treeNode7.Text = "Imagens";
            treeNode8.ImageKey = "lancamentos.png";
            treeNode8.Name = "financialEntriesTreeMenuItem";
            treeNode8.SelectedImageKey = "lancamentos.png";
            treeNode8.Tag = "TadManagementTool.View.Impl.OpenFinancialEntriesListMenuViewAction";
            treeNode8.Text = "Lançamentos";
            treeNode9.ImageKey = "Accounting Records.png";
            treeNode9.Name = "financialReferenceTreeMenuItem";
            treeNode9.SelectedImageKey = "Accounting Records.png";
            treeNode9.Tag = "TadManagementTool.View.Impl.OpenFinancialReferenceListMenuViewAction";
            treeNode9.Text = "Tipos de Lançamentos";
            treeNode10.ImageKey = "Accounts.png";
            treeNode10.Name = "financialTreeMenuItem";
            treeNode10.SelectedImageKey = "Accounts.png";
            treeNode10.Text = "Secretaria";
            this.menuTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode10});
            this.menuTreeView.SelectedImageIndex = 0;
            this.menuTreeView.Size = new System.Drawing.Size(256, 684);
            this.menuTreeView.TabIndex = 0;
            this.menuTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.menuTreeView_AfterSelect);
            // 
            // mainMenuImageList
            // 
            this.mainMenuImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mainMenuImageList.ImageStream")));
            this.mainMenuImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.mainMenuImageList.Images.SetKeyName(0, "colaboradores.png");
            this.mainMenuImageList.Images.SetKeyName(1, "birthdays.png");
            this.mainMenuImageList.Images.SetKeyName(2, "calendar.png");
            this.mainMenuImageList.Images.SetKeyName(3, "consecration.png");
            this.mainMenuImageList.Images.SetKeyName(4, "post.png");
            this.mainMenuImageList.Images.SetKeyName(5, "newsletter.png");
            this.mainMenuImageList.Images.SetKeyName(6, "photograph_edit.png");
            this.mainMenuImageList.Images.SetKeyName(7, "Accounting Records.png");
            this.mainMenuImageList.Images.SetKeyName(8, "Accounts Payable.png");
            this.mainMenuImageList.Images.SetKeyName(9, "Accounts Receivable.png");
            this.mainMenuImageList.Images.SetKeyName(10, "Accounts.png");
            this.mainMenuImageList.Images.SetKeyName(11, "lancamentos.png");
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 708);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuárioToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // usuárioToolStripMenuItem
            // 
            this.usuárioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alterarSenhaToolStripMenuItem});
            this.usuárioToolStripMenuItem.Name = "usuárioToolStripMenuItem";
            this.usuárioToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.usuárioToolStripMenuItem.Text = "Usuário";
            // 
            // alterarSenhaToolStripMenuItem
            // 
            this.alterarSenhaToolStripMenuItem.Name = "alterarSenhaToolStripMenuItem";
            this.alterarSenhaToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.alterarSenhaToolStripMenuItem.Text = "Alterar Senha";
            this.alterarSenhaToolStripMenuItem.Click += new System.EventHandler(this.alterarSenhaToolStripMenuItem_Click);
            // 
            // modalWaitingPanel
            // 
            this.modalWaitingPanel.DisplayText = null;
            this.modalWaitingPanel.RelatedControl = this.splitContainer.Panel2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TAD";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView menuTreeView;
        private ModalWaitingPanel modalWaitingPanel;
        private System.Windows.Forms.ImageList mainMenuImageList;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem usuárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alterarSenhaToolStripMenuItem;
    }
}

