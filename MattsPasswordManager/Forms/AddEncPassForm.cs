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
    internal partial class AddEncPassForm : Form
    {
        private readonly EncPassword encPassword;

        public AddEncPassForm(EncPassword encPassword)
        {
            InitializeComponent();
            this.encPassword = encPassword;
        }

        private void OKButtonHandler(object sender, EventArgs e)
        {
            string password = passwordTextBox.Text.Trim();
            string confPassword = confPasswordTextBox.Text.Trim();

            ValidationObj passValObj = EncPasswordValidator.ValidateEncPassword(password);
            if (!passValObj.IsValid)
            {
                MessageBox.Show(
                    this,
                    passValObj.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            ValidationObj passMatchValObj = EncPasswordValidator.CheckPasswordsMatch(
                password,
                confPassword
            );
            if (!passMatchValObj.IsValid)
            {
                MessageBox.Show(
                    this,
                    passMatchValObj.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            this.encPassword.Password = password;
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void CancelButtonHandler(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
