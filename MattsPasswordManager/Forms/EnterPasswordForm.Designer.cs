namespace MattsPasswordManager.Forms
{
    partial class EnterPasswordForm
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
            enterPasswordLabel = new Label();
            passwordTextBox = new TextBox();
            cancelButton = new Button();
            okButton = new Button();
            SuspendLayout();
            // 
            // enterPasswordLabel
            // 
            enterPasswordLabel.AutoSize = true;
            enterPasswordLabel.Location = new Point(13, 18);
            enterPasswordLabel.Name = "enterPasswordLabel";
            enterPasswordLabel.Size = new Size(90, 15);
            enterPasswordLabel.TabIndex = 0;
            enterPasswordLabel.Text = "Enter Password:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(109, 15);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(329, 23);
            passwordTextBox.TabIndex = 1;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(238, 53);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(200, 53);
            cancelButton.TabIndex = 9;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButtonClickHandler;
            // 
            // okButton
            // 
            okButton.Location = new Point(13, 53);
            okButton.Name = "okButton";
            okButton.Size = new Size(200, 53);
            okButton.TabIndex = 8;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += OKButtonClickHandler;
            // 
            // EnterPasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 119);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(passwordTextBox);
            Controls.Add(enterPasswordLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "EnterPasswordForm";
            Text = "Enter Password";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label enterPasswordLabel;
        private TextBox passwordTextBox;
        private Button cancelButton;
        private Button okButton;
    }
}