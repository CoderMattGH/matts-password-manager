namespace MattsPasswordManager.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            passwordTable = new DataGridView();
            Description = new DataGridViewTextBoxColumn();
            Username = new DataGridViewTextBoxColumn();
            Password = new DataGridViewTextBoxColumn();
            addButton = new Button();
            removeButton = new Button();
            editButton = new Button();
            mainMenuStrip = new MenuStrip();
            fileMenuStripItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            actionsToolStripMenuItem = new ToolStripMenuItem();
            changeRepoPassToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            versionToolStripMenuItem = new ToolStripMenuItem();
            searchBox = new TextBox();
            searchLabel = new Label();
            menuBorderPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)passwordTable).BeginInit();
            mainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // passwordTable
            // 
            passwordTable.AllowUserToAddRows = false;
            passwordTable.AllowUserToDeleteRows = false;
            passwordTable.AllowUserToResizeColumns = false;
            passwordTable.AllowUserToResizeRows = false;
            passwordTable.BorderStyle = BorderStyle.None;
            passwordTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            passwordTable.Columns.AddRange(new DataGridViewColumn[] { Description, Username, Password });
            passwordTable.Location = new Point(0, 65);
            passwordTable.MultiSelect = false;
            passwordTable.Name = "passwordTable";
            passwordTable.ReadOnly = true;
            passwordTable.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            passwordTable.ScrollBars = ScrollBars.Vertical;
            passwordTable.SelectionMode = DataGridViewSelectionMode.CellSelect;
            passwordTable.Size = new Size(946, 598);
            passwordTable.TabIndex = 0;
            // 
            // Description
            // 
            Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Description.HeaderText = "Description";
            Description.MinimumWidth = 250;
            Description.Name = "Description";
            Description.ReadOnly = true;
            Description.Resizable = DataGridViewTriState.False;
            // 
            // Username
            // 
            Username.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Username.HeaderText = "Username";
            Username.MinimumWidth = 250;
            Username.Name = "Username";
            Username.ReadOnly = true;
            Username.Resizable = DataGridViewTriState.False;
            // 
            // Password
            // 
            Password.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Password.HeaderText = "Password";
            Password.MinimumWidth = 250;
            Password.Name = "Password";
            Password.ReadOnly = true;
            Password.Resizable = DataGridViewTriState.False;
            // 
            // addButton
            // 
            addButton.Location = new Point(4, 669);
            addButton.Name = "addButton";
            addButton.Size = new Size(308, 60);
            addButton.TabIndex = 1;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += AddEntryClickHandler;
            // 
            // removeButton
            // 
            removeButton.Location = new Point(634, 669);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(308, 60);
            removeButton.TabIndex = 2;
            removeButton.Text = "Remove";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += RemoveEntryClickHandler;
            // 
            // editButton
            // 
            editButton.Location = new Point(320, 669);
            editButton.Name = "editButton";
            editButton.Size = new Size(308, 60);
            editButton.TabIndex = 3;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += EditEntryClickhandler;
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.BackColor = SystemColors.MenuBar;
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileMenuStripItem, actionsToolStripMenuItem, aboutToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new Size(946, 24);
            mainMenuStrip.TabIndex = 4;
            mainMenuStrip.Text = "mainMenuStrip";
            // 
            // fileMenuStripItem
            // 
            fileMenuStripItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, loadToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, exitToolStripMenuItem });
            fileMenuStripItem.Name = "fileMenuStripItem";
            fileMenuStripItem.Size = new Size(37, 20);
            fileMenuStripItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(141, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += FileNewClickHandler;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.L;
            loadToolStripMenuItem.Size = new Size(141, 22);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += FileLoadClickHandler;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(141, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += FileSaveClickHandler;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(141, 22);
            saveAsToolStripMenuItem.Text = "Save As";
            saveAsToolStripMenuItem.Click += FileSaveAsClickHandler;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(141, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += FileExitClickHandler;
            // 
            // actionsToolStripMenuItem
            // 
            actionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { changeRepoPassToolStripMenuItem });
            actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            actionsToolStripMenuItem.Size = new Size(59, 20);
            actionsToolStripMenuItem.Text = "&Actions";
            // 
            // changeRepoPassToolStripMenuItem
            // 
            changeRepoPassToolStripMenuItem.Name = "changeRepoPassToolStripMenuItem";
            changeRepoPassToolStripMenuItem.Size = new Size(198, 22);
            changeRepoPassToolStripMenuItem.Text = "Change Repo Password";
            changeRepoPassToolStripMenuItem.Click += ActionChangeRepoPasswordClickHandler;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { versionToolStripMenuItem });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "A&bout";
            // 
            // versionToolStripMenuItem
            // 
            versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            versionToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F1;
            versionToolStripMenuItem.Size = new Size(158, 22);
            versionToolStripMenuItem.Text = "Version";
            versionToolStripMenuItem.Click += AboutVersionClickHandler;
            // 
            // searchBox
            // 
            searchBox.BorderStyle = BorderStyle.FixedSingle;
            searchBox.Location = new Point(59, 34);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(877, 23);
            searchBox.TabIndex = 5;
            searchBox.TextChanged += SearchBoxTypeHandler;
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.Location = new Point(8, 38);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(45, 15);
            searchLabel.TabIndex = 6;
            searchLabel.Text = "Search:";
            // 
            // menuBorderPanel
            // 
            menuBorderPanel.BorderStyle = BorderStyle.FixedSingle;
            menuBorderPanel.ForeColor = SystemColors.ControlDark;
            menuBorderPanel.Location = new Point(-10, 24);
            menuBorderPanel.Margin = new Padding(1);
            menuBorderPanel.Name = "menuBorderPanel";
            menuBorderPanel.Size = new Size(958, 1);
            menuBorderPanel.TabIndex = 7;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(946, 733);
            Controls.Add(menuBorderPanel);
            Controls.Add(editButton);
            Controls.Add(addButton);
            Controls.Add(searchLabel);
            Controls.Add(removeButton);
            Controls.Add(passwordTable);
            Controls.Add(searchBox);
            Controls.Add(mainMenuStrip);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = mainMenuStrip;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Matt's Password Manager";
            FormClosing += CloseButtonHandler;
            ((System.ComponentModel.ISupportInitialize)passwordTable).EndInit();
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView passwordTable;
        private Button addButton;
        private Button removeButton;
        private Button editButton;
        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem fileMenuStripItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem actionsToolStripMenuItem;
        private ToolStripMenuItem changeRepoPassToolStripMenuItem;
        private ToolStripMenuItem versionToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Username;
        private DataGridViewTextBoxColumn Password;
        private TextBox searchBox;
        private Label searchLabel;
        private Panel menuBorderPanel;
    }
}
