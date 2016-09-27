using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MBODM.CopyPasteApi.Models
{
    public sealed class DataBaseEntry
    {
        public DataBaseEntry(int id, string text, DateTime time)
        {
            ID = id;
            Text = text;
            Time = time;
        }

        public int ID { get; }
        public string Text { get; }
        public DateTime Time { get; }
    }
}
