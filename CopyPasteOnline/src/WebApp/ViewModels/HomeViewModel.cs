using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MBODM.CopyPasteUI.ViewModels
{
    public sealed class HomeViewModel : BaseViewModel
    {
        public override bool HasBackButton
        {
            get { return false; }
        }
    }
}
