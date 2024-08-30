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
    internal partial class EditEntryForm : Form
    {
        private readonly Entry _entry;
        private readonly List<Entry> _entries;
        private readonly int _rowIndex;

        public EditEntryForm(Entry entry, List<Entry> entries, int rowIndex)
        {
            this._entry = entry;
            this._entries = entries;
            this._rowIndex = rowIndex;

            InitializeComponent();

            // Set current values
            descriptionTextBox.Text = entry.Description;
            usernameTextBox.Text = entry.Username;
            passwordTextBox.Text = entry.Password;
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
            for (int i = 0; i < _entries.Count; i++)
            {
                if (
                    this._rowIndex != i
                    && String.Equals(
                        this._entries[i].Description,
                        descriptionTextBox.Text.Trim(),
                        StringComparison.OrdinalIgnoreCase
                    )
                    && String.Equals(
                        this._entries[i].Username,
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
