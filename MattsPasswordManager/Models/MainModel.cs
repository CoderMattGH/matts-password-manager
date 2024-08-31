using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MattsPasswordManager.DTOs;
using MattsPasswordManager.Forms;
using MattsPasswordManager.Presenters;

namespace MattsPasswordManager.Models
{
    internal class MainModel
    {
        public string OpenFilePath { get; set; } = "";
        public string EncPassword { get; set; } = "";
        public Boolean IsModified { get; set; } = false;
        public List<Entry> Entries { get; set; } = [];

        public void AddEntry(Entry entry)
        {
            Entries.Add(entry);
        }

        public void RemoveEntry(int index)
        {
            Entries.RemoveAt(index);
        }

        public Entry GetEntry(int index)
        {
            return Entries[index];
        }

        public void ClearEntries()
        {
            Entries.Clear();
        }
    }
}
