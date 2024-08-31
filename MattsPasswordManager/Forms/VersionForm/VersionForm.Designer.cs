namespace MattsPasswordManager.Forms
{
    partial class VersionForm
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
            titleLabel = new Label();
            copyLabel = new Label();
            coderMattLink = new LinkLabel();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(46, 9);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(240, 21);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Matt's Password Manager v0.1";
            // 
            // copyLabel
            // 
            copyLabel.AutoSize = true;
            copyLabel.Location = new Point(47, 93);
            copyLabel.Name = "copyLabel";
            copyLabel.Size = new Size(238, 15);
            copyLabel.TabIndex = 1;
            copyLabel.Text = "© 2024 Matthew Dixon. All Rights Reserved.";
            // 
            // coderMattLink
            // 
            coderMattLink.AutoSize = true;
            coderMattLink.LinkArea = new LinkArea(0, 25);
            coderMattLink.LinkBehavior = LinkBehavior.HoverUnderline;
            coderMattLink.Location = new Point(87, 53);
            coderMattLink.Name = "coderMattLink";
            coderMattLink.Size = new Size(159, 15);
            coderMattLink.TabIndex = 2;
            coderMattLink.TabStop = true;
            coderMattLink.Text = "https://www.codermatt.com";
            coderMattLink.LinkClicked += CoderMattLabelClickHandler;
            // 
            // VersionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(332, 123);
            Controls.Add(coderMattLink);
            Controls.Add(copyLabel);
            Controls.Add(titleLabel);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "VersionForm";
            ShowIcon = false;
            Text = "Version";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label copyLabel;
        private LinkLabel coderMattLink;
    }
}