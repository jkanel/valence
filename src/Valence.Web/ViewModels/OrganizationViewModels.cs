using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Valence.Web.ViewModels;

namespace Valence.Web.ViewModels
{
    public class OrganizationViewModel : ContextPrivilegeViewModelBase
    {
        [Key]
        public int OrganizationId { get; set; }

        [Display(Name = "Organization")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(200)]
        public string OrganizationName { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Enter a description of your organization.")]
        [StringLength(2000)]
        public string Description { get; set; }

        [Display(Name = "Website URL")]
        [Required]
        [Url(ErrorMessage = "Must be a fully qualified URL with protocol, e.g. http://www.google.com")]  
        [StringLength(1000)]
        public string WebPageUrl { get; set; }

        [Display(Name = "Services Vendor")]
        [Required]
        public bool IsServicesVendor { get; set; }

        [Display(Name = "Product Vendor")]
        [Required]
        public bool IsProductVendor { get; set; }

        [Display(Name = "Non-Profit Organization")]
        [Required]
        public bool IsNonProfit { get; set; }

        [Display(Name = "Educational Mission")]
        [Required]
        public bool IsEducational { get; set; }

    }
}


