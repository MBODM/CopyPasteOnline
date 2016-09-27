using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBODM.CopyPasteApi.Models;

namespace MBODM.CopyPasteApi.Data
{
    public static class DataBase
    {
        private static Random random = new Random();
        private static List<DataBaseEntry> entries = new List<DataBaseEntry>();

        static DataBase()
        {
            entries.Add(new DataBaseEntry(0, "DefaultEntry", DateTime.Now));
        }

        public static DataBaseEntry GetEntryByID(int id)
        {
            return entries.Where(e => e.ID == id).FirstOrDefault();
        }

        public static IEnumerable<DataBaseEntry> GetAllEntries()
        {
            return entries;
        }

        public static DataBaseEntry CreateEntry(string text)
        {
            var entry = new DataBaseEntry(CreateID(), text, DateTime.Now);

            entries.Add(entry);

            return entry;
        }

        public static bool DeleteEntry(int id)
        {
            if (id == 0)
            {
                return false;
            }

            var entry = GetEntryByID(id);

            if (entry != null)
            {
                entries.Remove(entry);

                return true;
            }
            else
            {
                return false;
            }
        }

        private static int CreateID()
        {
            var created = 0;

            var existing = entries.Select(e => e.ID);

            while (true)
            {
                created = random.Next(1, 999);

                if (!existing.Contains(created))
                {
                    break;
                }
            }

            return created;
        }
    }
}
