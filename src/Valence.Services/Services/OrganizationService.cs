using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valence.Repositories;
using Valence.Entities;
using Valence.Models;
using Valence.Interactors;

namespace Valence.Services
{

    public interface IOrganizationService
    {
        void CreateOrganization(OrganizationInteractor oi, OrganizationModel model, int ContextMemberId);
        void DeleteOrganization(int OrganizationId, int ContextMemberId);
        bool CanAdminOrganization(int OrganizationId, int ContextMemberId);

    }

    public class OrganizationService
    {

        public OrganizationService() { }

        public void CreateOrganization(OrganizationModel model, int ContextMemberId, OrganizationInteractor oi)
        {
            //Organization entity = model.ToEntity();
            //entity.SetCreateInfo(ContextMemberId);
            //Repository.Insert(entity);

            //OrganizationMember om = new OrganizationMember();
            //om.MemberId = ContextMemberId;
            //om.OrganizationId = model.OrganizationId;
            //om.OrganizationRoleId = 
            //om.SetCreateInfo(ContextMemberId);
            
        }

        //public bool CanAdminOrganization(OrganizationInteractor oi, int OrganizationId, int ContextMemberId)
        //{

        //}

        //public void DeleteOrganization(int OrganizationId)
        //{
        //    Repository.DeleteSingle(OrganizationId);
        //}

    }
}
