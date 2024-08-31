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
using MattsPasswordManager.Models;
using MattsPasswordManager.Validators;

namespace MattsPasswordManager.Forms
{
    internal partial class AddEntryForm : Form
    {
        private readonly Entry _entry;
        private readonly List<Entry> _entries;

        public AddEntryForm(Entry entry, List<Entry> entries)
        {
            this._entry = entry;
            this._entries = entries;

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

            // Check that entry does not already exist
            foreach (Entry entry in _entries)
            {
                if (
                    String.Equals(
                        entry.Description,
                        descriptionTextBox.Text.Trim(),
                        StringComparison.OrdinalIgnoreCase
                    )
                    && String.Equals(
                        entry.Username,
                        usernameTextBox.Text.ToLower(),
                        StringComparison.OrdinalIgnoreCase
                    )
                )
                {
                    MessageBox.Show(
                        this,
                        "A similar entry already exists!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }
            }

            // Validation OK
            this.DialogResult = DialogResult.OK;
            this.Close();

            _entry.Description = descriptionTextBox.Text.Trim();
            _entry.Username = usernameTextBox.Text.Trim();
            _entry.Password = passwordTextBox.Text.Trim();
        }

        private void CancelButtonClickHandler(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
