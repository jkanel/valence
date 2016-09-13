using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valence.Entities;
using System.Data.Entity;
using System.Data.Entity.Design;

namespace Valence.Repositories
{
    public class OrganizationRoleRepository : GenericRepository<Organization>
    {
        public OrganizationRoleRepository(DbContext Context) : base(Context)
        {
        }
    }
}
