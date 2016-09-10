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
    public class OrganizationMemberInteractor
    {
        private OrganizationMemberRepository Repository { get; set; }

        public OrganizationMemberInteractor() { }
        public OrganizationMemberInteractor(OrganizationMemberRepository Repository)
        {
            this.Repository = Repository;
        }

        public void CreateOrganizationMember(OrganizationMemberModel model, int WorkerMemberId)
        {
            OrganizationMember entity = model.ToEntity();
            entity.SetCreateInfo(WorkerMemberId);
            Repository.Insert(entity);
        }

        public void DeleteOrganizationMember(int OrganizationMemberId, int WorkerMemberId)
        {
            Repository.DeleteSingle(OrganizationMemberId);
        }

        public void UpdateOrganizationMember(OrganizationMemberModel model, int WorkerMemberId)
        {
            OrganizationMember entity = model.ToEntity();
            entity.SetModifyInfo(WorkerMemberId);

            Repository.UpdateExcept(entity, OrganizationMember.CreateProperties);
        }

        public void UpdateOrganizationMemberApproval(int OrganizationMemberId, bool IsApproved, int WorkerMemberId)
        {
            throw new NotImplementedException();
        }       
    }
}
