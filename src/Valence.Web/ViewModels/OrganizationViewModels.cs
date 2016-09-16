using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Valence.Web.ViewModels;
using Valence.Entities;
using Valence.Commands;

namespace Valence.Web.ViewModels
{

    public class OrganizationViewModelList:List<OrganizationViewModel>, IApplicationViewModel
    {
        public ApplicationUserInfo ApplicationUserInfo { get; set; }

        public OrganizationViewModelList(IEnumerable<OrganizationBinder> binders)
        {
            binders.ToList().ForEach(b => base.Add(new OrganizationViewModel(b)));
        }
    }

    public class OrganizationViewModel : IApplicationViewModel, IEntityViewModel<Organization>
    {
        public ApplicationUserInfo ApplicationUserInfo { get; set; }

        public OrganizationViewModel(OrganizationBinder binder)
        {
            this.Construct(binder.Organization);
         
            this.CanRead = binder.Actions.CanRead();
            this.CanUpdate = binder.Actions.CanUpdate();
            this.CanDelete = binder.Actions.CanDelete();
        }

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

        #region IViewModel Methods

        [HiddenInput(DisplayValue = false)]
        public bool CanCreate { get; set; }
        [HiddenInput(DisplayValue = false)]
        public bool CanRead { get; set; }
        [HiddenInput(DisplayValue = false)]
        public bool CanUpdate { get; set; }
        [HiddenInput(DisplayValue = false)]
        public bool CanDelete { get; set; }

        public Organization ToEntity()
        {
            Organization entity = new Organization();

            entity.OrganizationId = this.OrganizationId;
            entity.OrganizationName = this.OrganizationName;
            entity.WebPageUrl = this.WebPageUrl;
            entity.Description = this.Description;
            entity.IsEducational = this.IsEducational;
            entity.IsNonProfit = this.IsNonProfit;
            entity.IsProductVendor = this.IsProductVendor;
            entity.IsServicesVendor = this.IsServicesVendor;

            return entity;
            
        }
        
        public void Construct(Organization entity)
        {
            
            this.OrganizationId = entity.OrganizationId;
            this.OrganizationName = entity.OrganizationName;
            this.WebPageUrl = entity.WebPageUrl;
            this.Description = entity.Description;
            this.IsEducational = entity.IsEducational;
            this.IsNonProfit = entity.IsNonProfit;
            this.IsProductVendor = entity.IsProductVendor;
            this.IsServicesVendor = entity.IsServicesVendor;
            
        }

        #endregion

    }
}


