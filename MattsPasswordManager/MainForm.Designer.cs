namespace MattsPasswordManager
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
            loadToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            actionsToolStripMenuItem = new ToolStripMenuItem();
            changeGlobalPasswordToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            creditsToolStripMenuItem = new ToolStripMenuItem();
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
            passwordTable.Name = "passwordTable";
            passwordTable.ReadOnly = true;
            passwordTable.Size = new Size(943, 625);
            passwordTable.TabIndex = 0;
            // 
            // Description
            // 
            Description.HeaderText = "Description";
            Description.MinimumWidth = 300;
            Description.Name = "Description";
            Description.ReadOnly = true;
            Description.Resizable = DataGridViewTriState.False;
            Description.Width = 300;
            // 
            // Username
            // 
            Username.HeaderText = "Username";
            Username.MinimumWidth = 300;
            Username.Name = "Username";
            Username.ReadOnly = true;
            Username.Resizable = DataGridViewTriState.False;
            Username.Width = 300;
            // 
            // Password
            // 
            Password.HeaderText = "Password";
            Password.MinimumWidth = 300;
            Password.Name = "Password";
            Password.ReadOnly = true;
            Password.Resizable = DataGridViewTriState.False;
            Password.Width = 300;
            // 
            // addButton
            // 
            addButton.Location = new Point(12, 658);
            addButton.Name = "addButton";
            addButton.Size = new Size(300, 60);
            addButton.TabIndex = 1;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            removeButton.Location = new Point(631, 658);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(300, 60);
            removeButton.TabIndex = 2;
            removeButton.Text = "Remove";
            removeButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            editButton.Location = new Point(322, 658);
            editButton.Name = "editButton";
            editButton.Size = new Size(300, 60);
            editButton.TabIndex = 3;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
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
            fileMenuStripItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem, saveToolStripMenuItem, exitToolStripMenuItem });
            fileMenuStripItem.Name = "fileMenuStripItem";
            fileMenuStripItem.Size = new Size(37, 20);
            fileMenuStripItem.Text = "&File";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(180, 22);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += FileLoadClickHandler;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += FileSaveClickHandler;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
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
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { creditsToolStripMenuItem });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "A&bout";
            // 
            // creditsToolStripMenuItem
            // 
            creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            creditsToolStripMenuItem.Size = new Size(111, 22);
            creditsToolStripMenuItem.Text = "Credits";
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
            ((System.ComponentModel.ISupportInitialize)passwordTable).EndInit();
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView passwordTable;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Username;
        private DataGridViewTextBoxColumn Password;
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
        private ToolStripMenuItem creditsToolStripMenuItem;
    }
}
