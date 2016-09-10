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
    public class CommunityRepository : GenericRepository<Community>
    {
        public CommunityRepository(DbContext Context) : base(Context)
        {
        }
    }
}
