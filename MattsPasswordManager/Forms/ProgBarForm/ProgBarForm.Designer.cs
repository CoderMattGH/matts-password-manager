namespace MattsPasswordManager.Forms;

partial class ProgBarForm
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
        progressBar1 = new ProgressBar();
        percentLabel = new Label();
        SuspendLayout();
        // 
        // progressBar1
        // 
        progressBar1.Location = new Point(10, 10);
        progressBar1.Name = "progressBar1";
        progressBar1.Size = new Size(436, 61);
        progressBar1.TabIndex = 0;
        progressBar1.UseWaitCursor = true;
        // 
        // percentLabel
        // 
        percentLabel.AutoSize = true;
        percentLabel.BackColor = SystemColors.Window;
        percentLabel.BorderStyle = BorderStyle.FixedSingle;
        percentLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        percentLabel.Location = new Point(178, 25);
        percentLabel.Margin = new Padding(3);
        percentLabel.MinimumSize = new Size(100, 0);
        percentLabel.Name = "percentLabel";
        percentLabel.Padding = new Padding(4, 4, 4, 5);
        percentLabel.Size = new Size(100, 32);
        percentLabel.TabIndex = 1;
        percentLabel.Text = "0%";
        percentLabel.TextAlign = ContentAlignment.MiddleCenter;
        percentLabel.UseWaitCursor = true;
        // 
        // ProgBarForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Window;
        ClientSize = new Size(456, 80);
        ControlBox = false;
        Controls.Add(percentLabel);
        Controls.Add(progressBar1);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MdiChildrenMinimizedAnchorBottom = false;
        MinimizeBox = false;
        Name = "ProgBarForm";
        ShowIcon = false;
        Text = "Loading";
        TopMost = true;
        UseWaitCursor = true;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ProgressBar progressBar1;
    private Label percentLabel;
}