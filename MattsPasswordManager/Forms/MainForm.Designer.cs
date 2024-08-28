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
            changeGlobalPasswordToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            versionToolStripMenuItem = new ToolStripMenuItem();
            Description = new DataGridViewTextBoxColumn();
            Username = new DataGridViewTextBoxColumn();
            Password = new DataGridViewTextBoxColumn();
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
            passwordTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            passwordTable.Columns.AddRange(new DataGridViewColumn[] { Description, Username, Password });
            passwordTable.Location = new Point(0, 27);
            passwordTable.MultiSelect = false;
            passwordTable.Name = "passwordTable";
            passwordTable.ReadOnly = true;
            passwordTable.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            passwordTable.ScrollBars = ScrollBars.Vertical;
            passwordTable.SelectionMode = DataGridViewSelectionMode.CellSelect;
            passwordTable.Size = new Size(943, 625);
            passwordTable.TabIndex = 0;
            // 
            // addButton
            // 
            addButton.Location = new Point(12, 658);
            addButton.Name = "addButton";
            addButton.Size = new Size(300, 60);
            addButton.TabIndex = 1;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += AddEntryClickHandler;
            // 
            // removeButton
            // 
            removeButton.Location = new Point(631, 658);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(300, 60);
            removeButton.TabIndex = 2;
            removeButton.Text = "Remove";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += RemoveEntryClickHandler;
            // 
            // editButton
            // 
            editButton.Location = new Point(322, 658);
            editButton.Name = "editButton";
            editButton.Size = new Size(300, 60);
            editButton.TabIndex = 3;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += EditEntryClickhandler;
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileMenuStripItem, actionsToolStripMenuItem, aboutToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new Size(943, 24);
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
            newToolStripMenuItem.Size = new Size(114, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += FileNewClickHandler;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(114, 22);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += FileLoadClickHandler;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(114, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += FileSaveClickHandler;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(114, 22);
            saveAsToolStripMenuItem.Text = "Save As";
            saveAsToolStripMenuItem.Click += FileSaveAsClickHandler;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(114, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += FileExitClickHandler;
            // 
            // actionsToolStripMenuItem
            // 
            actionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { changeGlobalPasswordToolStripMenuItem });
            actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            actionsToolStripMenuItem.Size = new Size(59, 20);
            actionsToolStripMenuItem.Text = "Actions";
            // 
            // changeGlobalPasswordToolStripMenuItem
            // 
            changeGlobalPasswordToolStripMenuItem.Name = "changeGlobalPasswordToolStripMenuItem";
            changeGlobalPasswordToolStripMenuItem.Size = new Size(189, 22);
            changeGlobalPasswordToolStripMenuItem.Text = "Change File Password";
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
            versionToolStripMenuItem.Size = new Size(112, 22);
            versionToolStripMenuItem.Text = "Version";
            versionToolStripMenuItem.Click += AboutVersionClickHandler;
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 723);
            Controls.Add(editButton);
            Controls.Add(removeButton);
            Controls.Add(addButton);
            Controls.Add(passwordTable);
            Controls.Add(mainMenuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
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
        private ToolStripMenuItem changeGlobalPasswordToolStripMenuItem;
        private ToolStripMenuItem versionToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Username;
        private DataGridViewTextBoxColumn Password;
    }
}
