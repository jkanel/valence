using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Valence.Entities;

namespace Valence.Commands
{
    public enum ApplicationActionEnum
    {
        CreateOrganization = 1,
        CreateCommunity = 2
    }


    public class ApplicationActions:List<ApplicationActionEnum>, IAction<ApplicationActionEnum>
    {
        public ApplicationActions() { }

        private class PrivilegeTuple
        {
            public PrivilegeTuple(ApplicationRoleEnum role, ApplicationActionEnum action)
            {
                this.Role = role;
                this.Action = action;
            }

            public ApplicationRoleEnum Role { get; set; }
            public ApplicationActionEnum Action { get; set; }
        }

        public ApplicationActions(IEnumerable<int> roles) : this(roles.Cast<ApplicationRoleEnum>()) { }

        public ApplicationActions(IEnumerable<ApplicationRoleEnum> roles)
        {
            base.AddRange(ApplicationActions.GetRoleActions(roles));
        }

        public bool CanCreateOrganization()
        {
            return this.HasPrivilege(ApplicationActionEnum.CreateOrganization);           
        }

        public bool CanCreateCommunity()
        {
            return this.HasPrivilege(ApplicationActionEnum.CreateCommunity);
        }

        #region Static Methods

        private static PrivilegeTuple[] Privileges =
        {

            new PrivilegeTuple(ApplicationRoleEnum.Admin, ApplicationActionEnum.CreateOrganization),
            new PrivilegeTuple(ApplicationRoleEnum.Admin, ApplicationActionEnum.CreateCommunity),

            new PrivilegeTuple(ApplicationRoleEnum.Member, ApplicationActionEnum.CreateOrganization),

            // no actions available to anyone (public)

        };

        public static IEnumerable<ApplicationActionEnum> GetRoleActions(IEnumerable<ApplicationRoleEnum> roles)
        {
            return Privileges.Where(x => roles.Contains(x.Role)).Select(x => x.Action).Distinct();
        }

        public static bool HasPrivilege(ApplicationRoleEnum role, ApplicationActionEnum action)
        {
            return Privileges.Any(x => (x.Role == role) && x.Action == action);
        }

        public bool HasPrivilege(ApplicationActionEnum action)
        {
            return this.Any(x => x == action);
        }

        #endregion

        #region IAction Methods



        public bool CanCreate()
        {
            throw new NotImplementedException();
        }

        public bool CanRead()
        {
            throw new NotImplementedException();
        }

        public bool CanUpdate()
        {
            throw new NotImplementedException();
        }

        public bool CanDelete()
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
