using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
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

        public void RemoveEntry(Entry entry)
        {
            Entries.Remove(entry);
        }

        public Entry GetEntry(int index)
        {
            return Entries[index];
        }

        public void ClearEntries()
        {
            Entries.Clear();
        }

        public int GetIndex(Entry entry)
        {
            return Entries.IndexOf(entry);
        }
    }
}
