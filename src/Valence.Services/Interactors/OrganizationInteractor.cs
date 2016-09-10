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
    public class OrganizationInteractor
    {
        private OrganizationRepository Repository { get; set; }

        public OrganizationInteractor() { }
        public OrganizationInteractor(OrganizationRepository Repository)
        {
            this.Repository = Repository;
        }

        public void CreateOrganization(OrganizationModel model, int WorkerMemberId)
        {
            Organization entity = model.ToEntity();
            entity.SetCreateInfo(WorkerMemberId);
            Repository.Insert(entity);
        }

        public void DeleteOrganization(int OrganizationId, int WorkerMemberId)
        {
            Repository.DeleteSingle(OrganizationId);
        }

        public void UpdateOrganization(OrganizationModel model, int WorkerMemberId)
        {
            Organization entity = model.ToEntity();
            entity.SetModifyInfo(WorkerMemberId);

            Repository.UpdateExcept(entity, Organization.CreateProperties);
        }

        public void UpdateOrganizationApproval(int OrganizationId, bool IsApproved, int WorkerMemberId)
        {
            throw new NotImplementedException();
        }       
    }
}
