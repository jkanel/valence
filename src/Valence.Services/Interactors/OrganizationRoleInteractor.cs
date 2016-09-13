using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valence.Entities;
using Valence.Models;
using Valence.Repositories;

namespace Valence.Interactors
{
    public class OrganizationRoleInteractor
    {
        private OrganizationRoleRepository Repository { get; set; }

        public OrganizationRoleInteractor() { }
        public OrganizationRoleInteractor(OrganizationRoleRepository Repository)
        {
            this.Repository = Repository;
        }

        
        public void CreateOrganization(int ContextMemberId, OrganizationModel model)
        {
            Organization entity = model.ToEntity();
            entity.SetCreateInfo(ContextMemberId);
            Repository.Insert(entity);
        }

        public void DeleteOrganization(int ContextMemberId, int OrganizationId)
        {
            Repository.DeleteSingle(OrganizationId);
        }

        public void UpdateOrganization(int ContextMemberId, OrganizationModel model)
        {
            Organization entity = model.ToEntity();
            entity.SetModifyInfo(ContextMemberId);

            Repository.UpdateExcept(entity, Organization.CreateProperties);
        }
    }
}
