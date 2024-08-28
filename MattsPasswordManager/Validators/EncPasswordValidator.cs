using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MattsPasswordManager.DTOs;

namespace MattsPasswordManager.Validators
{
    internal class EncPasswordValidator
    {
        public static ValidationObj ValidateEncPassword(string password)
        {
            if (password == null || password.Trim().Length == 0)
            {
                return new ValidationObj()
                {
                    IsValid = false,
                    Message = "Password cannot be empty!"
                };
            }

            return new ValidationObj() { IsValid = true, Message = "" };
        }

        public static ValidationObj CheckPasswordsMatch(string password, string confPassword)
        {
            if (!password.Equals(confPassword))
            {
                return new ValidationObj() { IsValid = false, Message = "Passwords do not match!" };
            }

            return new ValidationObj() { IsValid = true, Message = "" };
        }
    }
}
