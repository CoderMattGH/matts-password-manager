namespace MattsPasswordManager.Forms
{
    partial class EditEntryForm
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
            descriptionLabel = new Label();
            usernameLabel = new Label();
            passwordLabel = new Label();
            descriptionTextBox = new TextBox();
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            okButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(14, 15);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(70, 15);
            descriptionLabel.TabIndex = 0;
            descriptionLabel.Text = "Description:";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(14, 54);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(63, 15);
            usernameLabel.TabIndex = 1;
            usernameLabel.Text = "Username:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(14, 96);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(60, 15);
            passwordLabel.TabIndex = 2;
            passwordLabel.Text = "Password:";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new Point(99, 12);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(340, 23);
            descriptionTextBox.TabIndex = 3;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(99, 51);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(340, 23);
            usernameTextBox.TabIndex = 4;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(99, 93);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(340, 23);
            passwordTextBox.TabIndex = 5;
            // 
            // okButton
            // 
            okButton.Location = new Point(14, 132);
            okButton.Name = "okButton";
            okButton.Size = new Size(200, 53);
            okButton.TabIndex = 6;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += OKButtonClickHandler;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(239, 132);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(200, 53);
            cancelButton.TabIndex = 7;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButtonClickHandler;
            // 
            // AddEntryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 195);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(descriptionTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(descriptionLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "AddEntryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Entry";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label descriptionLabel;
        private Label usernameLabel;
        private Label passwordLabel;
        private TextBox descriptionTextBox;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button okButton;
        private Button cancelButton;
    }
}