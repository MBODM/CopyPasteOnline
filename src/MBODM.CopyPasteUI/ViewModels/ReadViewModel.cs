using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MBODM.CopyPasteUI.ViewModels
{
    public sealed class ReadViewModel : BaseViewModel
    {
        private const string ErrorText = "Sie müssen eine Zahl zwischen 1 und 999 eingeben.";

        public override bool HasBackButton
        {
            get { return true; }
        }

        [Required(ErrorMessage = ErrorText)]
        [Range(0, 999, ErrorMessage = ErrorText)]
        public string ID
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public int Error
        {
            get;
            set;
        }

        public bool HasText
        {
            get { return !string.IsNullOrEmpty(Text); }
        }

        public bool HasError
        {
            get { return Error != 0; }
        }
    }
}
