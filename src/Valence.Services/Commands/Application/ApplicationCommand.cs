using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Valence.Entities;

namespace Valence.Commands
{
    
    public class ApplicationCommand : CommandBase
    {
        public ApplicationCommand(DbContext Context) : base(Context){ }


        public ApplicationActions GetApplicationActions(int ContextMemberId)
        {

            IEnumerable<int> roles = ValenceContext.ApplicationMember
                .Where(am => am.MemberId == ContextMemberId).Select(amx => amx.ApplicationRoleId);

            if(roles == null)
            {
                return new ApplicationActions();
            } else
            {
                return new ApplicationActions(roles);
            }
          
        }
    }
}
