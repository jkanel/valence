using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Valence.Entities;

namespace Valence.Commands
{
    
    class GetOrganizationsCommand : CommandBase
    {
        public GetOrganizationsCommand(DbContext Context) : base(Context){ }

        public IEnumerable<OrganizationBinder> GetMemberOrganizations(int ContextMemberId)
        {
            return ValenceContext.Organizations.Where(o => o.OrganizationMembers.Where(om => om.MemberId == ContextMemberId).Any())
                .Select(org => new OrganizationBinder()
                {
                    Organization = org,
                    Actions = new OrganizationActions(org.OrganizationMembers.Where(om => om.MemberId == ContextMemberId).Select(omx => omx.OrganizationRoleId))
                });
        }

        public OrganizationBinder GetOrganization(int ContextMemberId, int OrganizationId)
        {
            OrganizationBinder binder = new OrganizationBinder();

            binder.Organization = ValenceContext.Organizations.FirstOrDefault(o => o.OrganizationId == OrganizationId &&
                   o.OrganizationMembers.Where(om => om.MemberId == ContextMemberId).Any());

            binder.Actions = new OrganizationActions(binder.Organization.OrganizationMembers
                .Where(om => om.MemberId == ContextMemberId).Select(omx => omx.OrganizationRoleId));

            return binder;
        }
    }
}
