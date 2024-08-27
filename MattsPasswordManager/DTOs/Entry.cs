using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattsPasswordManager.DTOs
{
    internal class Entry
    {
        public string? Description { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
