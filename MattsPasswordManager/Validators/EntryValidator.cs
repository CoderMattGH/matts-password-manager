using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MattsPasswordManager.DTOs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MattsPasswordManager.Validators
{
    internal class EntryValidator
    {
        private EntryValidator() { }

        public static ValidationObj ValidateDescription(string description)
        {
            if (description == null || description.Trim().Length == 0)
            {
                return new ValidationObj()
                {
                    Message = "Description cannot be empty!",
                    IsValid = false
                };
            }

            if (description.Length > 200)
            {
                return new ValidationObj()
                {
                    Message = "Description cannot exceed 200 characters!",
                    IsValid = false
                };
            }

            return new ValidationObj() { Message = "", IsValid = true };
        }

        public static ValidationObj ValidateUsername(string username)
        {
            if (username == null || username.Trim().Length == 0)
            {
                return new ValidationObj()
                {
                    Message = "Username cannot be empty!",
                    IsValid = false
                };
            }

            if (username.Length > 100)
            {
                return new ValidationObj()
                {
                    Message = "Username cannot exceed 100 characters!",
                    IsValid = false
                };
            }

            if (Regex.IsMatch(username, @"\s"))
            {
                return new ValidationObj()
                {
                    IsValid = false,
                    Message = "Username cannot contain spaces!"
                };
            }

            return new ValidationObj() { Message = "", IsValid = true };
        }

        public static ValidationObj ValidatePassword(string password)
        {
            if (password == null || password.Trim().Length == 0)
            {
                return new ValidationObj()
                {
                    Message = "Password cannot be empty!",
                    IsValid = false
                };
            }

            if (password.Length > 100)
            {
                return new ValidationObj()
                {
                    Message = "Password cannot exceed 100 characters!",
                    IsValid = false
                };
            }

            if (Regex.IsMatch(password, @"\s"))
            {
                return new ValidationObj()
                {
                    Message = "Password cannot contain spaces!",
                    IsValid = false,
                };
            }

            return new ValidationObj() { Message = "", IsValid = true };
        }
    }
}
