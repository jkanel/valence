using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Valence.Entities;

namespace Valence.Commands
{
    public enum OrganizationActionEnum
    {
        ViewPublic = 0,
        View = 1,        
        Edit = 2,
        Delete = 3,
        Create = 4
    }


    public class OrganizationActions:List<OrganizationActionEnum>
    {
        public OrganizationActions() { }

        private class PrivilegeTuple
        {
            public PrivilegeTuple(OrganizationRoleEnum role, OrganizationActionEnum action)
            {
                this.Role = role;
                this.Action = action;
            }

            public OrganizationRoleEnum Role { get; set; }
            public OrganizationActionEnum Action { get; set; }
        }

        public OrganizationActions(IEnumerable<int> roles) : this(roles.Cast<OrganizationRoleEnum>()) { }

        public OrganizationActions(IEnumerable<OrganizationRoleEnum> roles)
        {
            base.AddRange(OrganizationActions.GetRoleActions(roles));
        }
        

        private static PrivilegeTuple[] Privileges =
        {

            new PrivilegeTuple(OrganizationRoleEnum.Admin, OrganizationActionEnum.ViewPublic),
            new PrivilegeTuple(OrganizationRoleEnum.Admin, OrganizationActionEnum.View),
            new PrivilegeTuple(OrganizationRoleEnum.Admin, OrganizationActionEnum.Edit),
            new PrivilegeTuple(OrganizationRoleEnum.Admin, OrganizationActionEnum.Delete),

            new PrivilegeTuple(OrganizationRoleEnum.Manager, OrganizationActionEnum.ViewPublic),
            new PrivilegeTuple(OrganizationRoleEnum.Manager, OrganizationActionEnum.View),
            new PrivilegeTuple(OrganizationRoleEnum.Manager, OrganizationActionEnum.Edit),

            new PrivilegeTuple(OrganizationRoleEnum.Associate, OrganizationActionEnum.ViewPublic),
            new PrivilegeTuple(OrganizationRoleEnum.Associate, OrganizationActionEnum.View),

            // automatically available to anyone (public)
            new PrivilegeTuple(OrganizationRoleEnum.None, OrganizationActionEnum.ViewPublic),

        };

        public static IEnumerable<OrganizationActionEnum> GetRoleActions(IEnumerable<OrganizationRoleEnum> roles)
        {
            return Privileges.Where(x => roles.Contains(x.Role)).Select(x => x.Action).Distinct();
        }

        public static bool HasPrivilege(OrganizationRoleEnum role, OrganizationActionEnum action)
        {
            return Privileges.Any(x => (x.Role == role) && x.Action == action);
        }    
    }
}
