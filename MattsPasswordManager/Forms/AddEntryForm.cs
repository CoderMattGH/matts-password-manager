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
    internal partial class AddEntryForm : Form
    {
        private readonly Entry entry;

        public AddEntryForm(Entry entry)
        {
            this.entry = entry;
            InitializeComponent();
        }

        private void OKButtonClickHandler(object sender, EventArgs e)
        {
            // Validate description
            ValidationObj descValidObj = EntryValidator.ValidateDescription(
                descriptionTextBox.Text
            );
            if (!descValidObj.IsValid)
            {
                MessageBox.Show(
                    this,
                    descValidObj.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            // Validate username
            ValidationObj userValidObj = EntryValidator.ValidateUsername(usernameTextBox.Text);
            if (!userValidObj.IsValid)
            {
                MessageBox.Show(
                    this,
                    userValidObj.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            // Validate password
            ValidationObj passValidObj = EntryValidator.ValidatePassword(passwordTextBox.Text);
            if (!passValidObj.IsValid)
            {
                MessageBox.Show(
                    this,
                    passValidObj.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            // Validation OK
            this.DialogResult = DialogResult.OK;
            this.Close();

            entry.Description = descriptionTextBox.Text.Trim();
            entry.Username = usernameTextBox.Text.Trim();
            entry.Password = passwordTextBox.Text.Trim();
        }

        private void CancelButtonClickHandler(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
