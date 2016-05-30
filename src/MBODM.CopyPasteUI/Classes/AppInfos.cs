using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MBODM.CopyPasteUI.Classes
{
    public static class AppInfos
    {
        public static string AppName
        {
            get { return "CopyPasteOnline"; }
        }

        public static string AppVersion
        {
            get { return Assembly.GetEntryAssembly().GetName().Version.ToString(); }
        }

        public static string WebApiUrl
        {
            get { return "http://mbodm.com/CopyPasteApi/api/values"; }
        }
    }
}
