using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattsPasswordManager.DTOs
{
    internal class ValidationObj
    {
        public required string Message { get; set; }
        public required Boolean IsValid { get; set; }
    }
}
