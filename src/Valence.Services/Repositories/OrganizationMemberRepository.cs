using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Design;

using Valence.Entities;

namespace Valence.Repositories
{
    public class OrganizationMemberRepository : GenericRepository<OrganizationMember>
    {
        public OrganizationMemberRepository(DbContext Context) : base(Context)
        {
        }
    }
}
