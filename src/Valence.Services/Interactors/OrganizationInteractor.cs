using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Valence.Entities;
using Valence.Models;
using Valence.Repositories;

namespace Valence.Interactors
{
    public class OrganizationInteractor
    {
        private OrganizationRepository Repository { get; set; }

        public OrganizationInteractor() { }
        public OrganizationInteractor(OrganizationRepository Repository)
        {
            this.Repository = Repository;
        }

        public OrganizationInteractor(DbContext Context)
        {
            this.Repository = new OrganizationRepository(Context);
        }

        /// <summary>
        /// Returns all organizations visible for the specified privilege level
        /// </summary>
        /// <param name="ContextMemberId"></param>
        /// <returns></returns>
        public OrganizationModelList GetContextOrganizations(int ContextMemberId)
        {
            OrganizationModelList list = new OrganizationModelList(Repository.AssociatedSelectAll(ContextMemberId));
            return list;
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
