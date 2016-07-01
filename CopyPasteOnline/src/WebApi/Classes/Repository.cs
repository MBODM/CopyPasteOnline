using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBODM.CopyPasteApi.Data;
using MBODM.CopyPasteApi.Interfaces;

namespace MBODM.CopyPasteApi.Classes
{
    public sealed class Repository : IRepository
    {
        public int Add(string text)
        {
            CleanUpExpiredEntries();

            return DataBase.CreateEntry(text).ID;
        }

        public string Find(int id)
        {
            return DataBase.GetEntryByID(id)?.Text;
        }

        public bool Remove(int id)
        {
            return DataBase.DeleteEntry(id);
        }

        private void CleanUpExpiredEntries()
        {
            var entries = DataBase.GetAllEntries().Where(e => e.ID != 0);

            foreach (var entry in entries)
            {
                var elapsedTime = DateTime.Now.Subtract(entry.Time);

                if (elapsedTime.TotalMinutes > 30)
                {
                    DataBase.DeleteEntry(entry.ID);
                }
            }
        }
    }
}
