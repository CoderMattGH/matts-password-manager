using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MattsPasswordManager.DTOs;

namespace MattsPasswordManager.Validators
{
    internal class EntryValidator
    {
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

            return new ValidationObj() { Message = "", IsValid = true };
        }
    }
}
