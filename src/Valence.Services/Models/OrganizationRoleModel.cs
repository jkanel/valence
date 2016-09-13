using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valence.Entities;

namespace Valence.Models
{


    public class OrganizationRoleModelList : List<OrganizationRoleModel>
    {
        public OrganizationRoleModelList(IEnumerable<OrganizationRole> entities)
        {
            foreach (var entity in entities)
            {
                Add(new OrganizationRoleModel(entity));
            }
        }
    }

    public class OrganizationRoleModel : IModel<OrganizationRole>
    {
        #region Constructors
        public OrganizationRoleModel() { }
        public OrganizationRoleModel(OrganizationRole entity)
        {
            this.Construct(entity);
        }
        #endregion

        #region Attributes
        public int OrganizationRoleId { get; set; }
        public string OrganizationRoleName { get; set; }
        public string Description { get; set; }
        #endregion


        #region Static Role Definitions

        private static OrganizationRoleEnum[] EditRoles = new OrganizationRoleEnum[]
        {
            OrganizationRoleEnum.Admin,
            OrganizationRoleEnum.Manager
        };

        private static OrganizationRoleEnum[] DeleteRoles = new OrganizationRoleEnum[]
        {
            OrganizationRoleEnum.Admin,
            OrganizationRoleEnum.Manager
        };

        private static OrganizationRoleEnum[] AdminRoles = new OrganizationRoleEnum[]
        {
            OrganizationRoleEnum.Admin
        };

        private static OrganizationRoleEnum[] ViewRoles = new OrganizationRoleEnum[]
        {
            OrganizationRoleEnum.Admin,
            OrganizationRoleEnum.Manager,
            OrganizationRoleEnum.Coordinator,
            OrganizationRoleEnum.Associate
        };

        private static OrganizationRoleEnum[] CoordinateRoles = new OrganizationRoleEnum[]
        {
            OrganizationRoleEnum.Admin,
            OrganizationRoleEnum.Manager,
            OrganizationRoleEnum.Coordinator
        };

        public static bool RoleCanEdit(OrganizationRoleEnum role)
        {
            return OrganizationRoleModel.EditRoles.Contains(role);
        }
        
        public static bool RoleCanDelete(OrganizationRoleEnum role)
        {
            return OrganizationRoleModel.DeleteRoles.Contains(role);
        }

        public static bool RoleCanAdmin(OrganizationRoleEnum role)
        {
            return OrganizationRoleModel.AdminRoles.Contains(role);
        }

        public static bool RoleCanView(OrganizationRoleEnum role)
        {
            return OrganizationRoleModel.ViewRoles.Contains(role);
        }

        public static bool RoleCanCoordinate(OrganizationRoleEnum role)
        {
            return OrganizationRoleModel.CoordinateRoles.Contains(role);
        }

        #endregion

        #region Mappers
        public void Construct(OrganizationRole entity)
        {

            this.OrganizationRoleId = entity.OrganizationRoleId;
            this.OrganizationRoleName = entity.OrganizationRoleName;
            this.Description = entity.Description;
            
        }

        public OrganizationRole ToEntity()
        {
            OrganizationRole entity = new Entities.OrganizationRole();

            entity.OrganizationRoleId = this.OrganizationRoleId;
            entity.OrganizationRoleName = this.OrganizationRoleName;
            entity.Description = this.Description;

            return entity;

        }
        #endregion
    }
}
