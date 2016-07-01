using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MBODM.CopyPasteApi.Interfaces
{
    public interface IRepository
    {
        string Find(int id);
        int Add(string text);
        bool Remove(int id);
    }
}
