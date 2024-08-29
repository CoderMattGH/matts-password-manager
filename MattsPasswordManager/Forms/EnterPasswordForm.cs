using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MattsPasswordManager.DTOs;
using MattsPasswordManager.Validators;

namespace MattsPasswordManager.Forms
{
    internal partial class EnterPasswordForm : Form
    {
        private readonly EncPassword _encPassword;

        public EnterPasswordForm(EncPassword encPassword)
        {
            InitializeComponent();
            this._encPassword = encPassword;
        }

        private void OKButtonClickHandler(object sender, EventArgs e)
        {
            string password = passwordTextBox.Text;

            if (passwordTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show(
                    this,
                    "Password cannot be empty!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            this._encPassword.Password = password;
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void CancelButtonClickHandler(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
