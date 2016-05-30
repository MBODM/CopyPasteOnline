using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MBODM.CopyPasteUI.ViewModels
{
    public sealed class WriteViewModel : BaseViewModel
    {
        public override bool HasBackButton
        {
            get { return true; }
        }

        [Required]
        public string Text
        {
            get;
            set;
        }

        public int ID
        {
            get;
            set;
        }

        public int Error
        {
            get;
            set;
        }

        public bool HasID
        {
            get { return ID != 0; }
        }

        public bool HasError
        {
            get { return Error != 0; }
        }
    }
}
