using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MBODM.CopyPasteUI.ViewModels
{
    public abstract class BaseViewModel
    {
        public abstract bool HasBackButton
        {
            get;
        }
    }
}
