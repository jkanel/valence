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
        ReadPublic = 0,
        Read = 1,        
        Update = 2,
        Delete = 3,
    }


    public class OrganizationActions:List<OrganizationActionEnum>, IAction<OrganizationActionEnum>
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

        #region Static Methods

        private static PrivilegeTuple[] Privileges =
        {

            new PrivilegeTuple(OrganizationRoleEnum.Admin, OrganizationActionEnum.ReadPublic),
            new PrivilegeTuple(OrganizationRoleEnum.Admin, OrganizationActionEnum.Read),
            new PrivilegeTuple(OrganizationRoleEnum.Admin, OrganizationActionEnum.Update),
            new PrivilegeTuple(OrganizationRoleEnum.Admin, OrganizationActionEnum.Delete),

            new PrivilegeTuple(OrganizationRoleEnum.Manager, OrganizationActionEnum.ReadPublic),
            new PrivilegeTuple(OrganizationRoleEnum.Manager, OrganizationActionEnum.Read),
            new PrivilegeTuple(OrganizationRoleEnum.Manager, OrganizationActionEnum.Update),

            new PrivilegeTuple(OrganizationRoleEnum.Associate, OrganizationActionEnum.ReadPublic),
            new PrivilegeTuple(OrganizationRoleEnum.Associate, OrganizationActionEnum.Read),

            // automatically available to anyone (public)
            new PrivilegeTuple(OrganizationRoleEnum.None, OrganizationActionEnum.ReadPublic),

        };

        public static IEnumerable<OrganizationActionEnum> GetRoleActions(IEnumerable<OrganizationRoleEnum> roles)
        {
            return Privileges.Where(x => roles.Contains(x.Role)).Select(x => x.Action).Distinct();
        }

        public static bool HasPrivilege(OrganizationRoleEnum role, OrganizationActionEnum action)
        {
            return Privileges.Any(x => (x.Role == role) && x.Action == action);
        }

        public bool HasPrivilege(OrganizationActionEnum action)
        {
            return this.Any(x => x == action);
        }

        #endregion

        #region IAction Methods

        public bool CanRead()
        {
            return this.HasPrivilege(OrganizationActionEnum.Read);
        }

        public bool CanUpdate()
        {
            return this.HasPrivilege(OrganizationActionEnum.Update);
        }

        public bool CanDelete()
        {
            return this.HasPrivilege(OrganizationActionEnum.Delete);
        }


        #endregion
    }
}
