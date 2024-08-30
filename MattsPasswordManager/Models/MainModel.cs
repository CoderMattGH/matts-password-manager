using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MattsPasswordManager.Presenters;

namespace MattsPasswordManager.Models
{
    internal class MainModel
    {
        public string OpenFilePath { get; set; } = "";
        public string EncPassword { get; set; } = "";
        public Boolean IsModified { get; set; } = false;
    }
}
