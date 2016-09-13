using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valence.Entities;
using Valence.Repositories;

namespace Valence.Models
{

    public class OrganizationModelList : List<OrganizationModel>
    {
        public OrganizationModelList(IEnumerable<OrganizationRoleBinder> binders )
        {
            foreach (var binder in binders)
            {
                Add(new OrganizationModel(binder.Entity, binder.Role));
            }
        }
    }

    public class OrganizationModel : IModel<Organization>, IContextPrivilegeModel<OrganizationRoleEnum>
    {
        public OrganizationModel() { }
        public OrganizationModel(Organization entity, OrganizationRoleEnum role)
        {
            this.Construct(entity);
            this.ContextRole = role;
        }
        
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string Description { get; set; }
        public string WebPageUrl { get; set; }
        public bool IsServicesVendor { get; set; }
        public bool IsProductVendor { get; set; }
        public bool IsNonProfit { get; set; }
        public bool IsEducational { get; set; }

        #region IContextPrivilegeModel Methods
        public OrganizationRoleEnum ContextRole { get; set; }

        public bool CanEdit()
        {
            return OrganizationRoleModel.RoleCanEdit(this.ContextRole);
        }

        public bool CanDelete()
        {
            return OrganizationRoleModel.RoleCanDelete(this.ContextRole);
        }

        public bool CanView()
        {
            return OrganizationRoleModel.RoleCanView(this.ContextRole);
        }

        public bool CanAdmin()
        {
            return OrganizationRoleModel.RoleCanAdmin(this.ContextRole);
        }

        public bool CanCoordinate()
        {
            return OrganizationRoleModel.RoleCanCoordinate(this.ContextRole);
        }
        #endregion

        #region IModel Methods
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
        #endregion

    }
}
