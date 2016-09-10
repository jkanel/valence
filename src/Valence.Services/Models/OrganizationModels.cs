using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valence.Entities;

namespace Valence.Models
{

    public class OrganizationModelList : List<OrganizationModel>
    {
        public OrganizationModelList(IEnumerable<Organization> entities)
        {
            foreach (var entity in entities)
            {
                Add(new OrganizationModel(entity));
            }
        }
    }

    public class OrganizationModel : IModel<Organization>
    {
        public OrganizationModel() { }
        public OrganizationModel(Organization entity)
        {
            this.Construct(entity);
        }
        
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string Description { get; set; }
        public string WebPageUrl { get; set; }
        public bool IsServicesVendor { get; set; }
        public bool IsProductVendor { get; set; }
        public bool IsNonProfit { get; set; }
        public bool IsEducational { get; set; }

        public void Construct(Organization entity)
        {

            this.OrganizationId = entity.OrganizationId;
            this.OrganizationName = entity.OrganizationName;
            this.Description = entity.Description;
            this.WebPageUrl = entity.WebPageUrl;
            this.IsServicesVendor = entity.IsServicesVendor;
            this.IsProductVendor = entity.IsProductVendor;
            this.IsNonProfit = entity.IsNonProfit;
            this.IsEducational = entity.IsEducational;
        }

        public Organization ToEntity()
        {
            Organization entity = new Entities.Organization();

            entity.OrganizationId = this.OrganizationId;
            entity.OrganizationName = this.OrganizationName;
            entity.Description = this.Description;
            entity.WebPageUrl = this.WebPageUrl;
            entity.IsServicesVendor = this.IsServicesVendor;
            entity.IsProductVendor = this.IsProductVendor;
            entity.IsNonProfit = this.IsNonProfit;
            entity.IsEducational = this.IsEducational;

            return entity;

        }
    }
}
