using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valence.Entities;

namespace Valence.Models
{

    public class OrganizationMemberModelList : List<OrganizationMemberModel>
    {
        public OrganizationMemberModelList(IEnumerable<OrganizationMember> entities)
        {
            foreach (var entity in entities)
            {
                Add(new OrganizationMemberModel(entity));
            }
        }
    }

    public class OrganizationMemberModel : IModel<OrganizationMember>
    {
        public OrganizationMemberModel() { }
        public OrganizationMemberModel(OrganizationMember entity)
        {
            this.Construct(entity);
        }
        
        public int OrganizationMemberId { get; set; }
        public int OrganizationId { get; set; }
        public int MemberId { get; set; }
        public int OrganizationRoleId { get; set; }

        public void Construct(OrganizationMember entity)
        {

            this.OrganizationMemberId = entity.OrganizationMemberId;
            this.MemberId = entity.MemberId;
            this.OrganizationId = entity.OrganizationId;
            this.OrganizationRoleId = entity.OrganizationRoleId;
            
        }

        public OrganizationMember ToEntity()
        {
            OrganizationMember entity = new Entities.OrganizationMember();

            entity.OrganizationMemberId = this.OrganizationMemberId;
            entity.MemberId = this.MemberId;
            entity.OrganizationId = this.OrganizationId;
            entity.OrganizationRoleId = this.OrganizationRoleId;

            return entity;

        }
    }
}
