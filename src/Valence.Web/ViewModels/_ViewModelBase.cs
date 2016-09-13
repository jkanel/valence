using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Valence.Web.ViewModels
{
    public class ContextPrivilegeViewModelBase
    {
        [HiddenInput(DisplayValue = false)]
        public bool CanEdit { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool CanDelete { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool CanAdmin { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool CanCoordinate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool CanView { get; set; }

    }

    
}