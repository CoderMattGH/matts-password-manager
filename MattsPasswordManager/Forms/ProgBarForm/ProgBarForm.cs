using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MattsPasswordManager.Forms
{
    public partial class ProgBarForm : Form
    {
        public ProgBarForm()
        {
            InitializeComponent();

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
        }

        public void SetProgressPercentage(int percentage)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new Action<int>(SetProgressPercentage), percentage);
            }
            else
            {
                if (percentage < 0)
                {
                    this.progressBar1.Value = 0;
                }
                else if (percentage > 100)
                {
                    this.progressBar1.Value = 100;
                }
                else
                {
                    this.progressBar1.Value = percentage;
                }

                this.percentLabel.Text = $"{this.progressBar1.Value}%";
            }
        }

        public void CloseForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(CloseForm));
            }
            else
            {
                this.Close();
            }
        }
    }
}
