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

        public void CreateOrganizationMember(int ContextMemberId, OrganizationMemberModel model)
        {
            OrganizationMember entity = model.ToEntity();
            entity.SetCreateInfo(ContextMemberId);
            Repository.Insert(entity);
        }

        public void DeleteOrganizationMember(int ContextMemberId, int OrganizationMemberId)
        {
            Repository.DeleteSingle(OrganizationMemberId);
        }

        public void UpdateOrganizationMember(int ContextMemberId, OrganizationMemberModel model)
        {
            OrganizationMember entity = model.ToEntity();
            entity.SetModifyInfo(ContextMemberId);

            Repository.UpdateExcept(entity, OrganizationMember.CreateProperties);
        }
        
    }
}
