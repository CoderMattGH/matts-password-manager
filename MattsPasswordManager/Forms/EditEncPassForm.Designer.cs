namespace MattsPasswordManager.Forms
{
    partial class EditEncPassForm
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
            passwordLabel = new Label();
            confPasswordLabel = new Label();
            passwordTextBox = new TextBox();
            confPasswordTextBox = new TextBox();
            okButton = new Button();
            cancelButton = new Button();
            titleLabel = new Label();
            warningLabel = new Label();
            SuspendLayout();
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(14, 83);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(60, 15);
            passwordLabel.TabIndex = 0;
            passwordLabel.Text = "Password:";
            // 
            // confPasswordLabel
            // 
            confPasswordLabel.AutoSize = true;
            confPasswordLabel.Location = new Point(14, 122);
            confPasswordLabel.Name = "confPasswordLabel";
            confPasswordLabel.Size = new Size(107, 15);
            confPasswordLabel.TabIndex = 1;
            confPasswordLabel.Text = "Confirm Password:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.BorderStyle = BorderStyle.FixedSingle;
            passwordTextBox.Location = new Point(127, 80);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(312, 23);
            passwordTextBox.TabIndex = 3;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // confPasswordTextBox
            // 
            confPasswordTextBox.BorderStyle = BorderStyle.FixedSingle;
            confPasswordTextBox.Location = new Point(127, 119);
            confPasswordTextBox.Name = "confPasswordTextBox";
            confPasswordTextBox.Size = new Size(312, 23);
            confPasswordTextBox.TabIndex = 4;
            confPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // okButton
            // 
            okButton.Location = new Point(14, 161);
            okButton.Name = "okButton";
            okButton.Size = new Size(200, 53);
            okButton.TabIndex = 6;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += OKButtonHandler;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(239, 161);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(200, 53);
            cancelButton.TabIndex = 7;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButtonHandler;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(14, 18);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(279, 15);
            titleLabel.TabIndex = 8;
            titleLabel.Text = "Set a new password for the password repository file.";
            // 
            // warningLabel
            // 
            warningLabel.AutoSize = true;
            warningLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            warningLabel.Location = new Point(14, 48);
            warningLabel.Name = "warningLabel";
            warningLabel.Size = new Size(264, 15);
            warningLabel.TabIndex = 9;
            warningLabel.Text = "Warning: Please make a note of this password!";
            // 
            // EditEncPassForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(460, 227);
            Controls.Add(warningLabel);
            Controls.Add(titleLabel);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(confPasswordTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(confPasswordLabel);
            Controls.Add(passwordLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "EditEncPassForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Replace File Password";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label confPasswordLabel;
        private Label passwordLabel;
        private TextBox passwordTextBox;
        private TextBox confPasswordTextBox;
        private Button okButton;
        private Button cancelButton;
        private Label titleLabel;
        private Label warningLabel;
    }
}