using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valence.Entities
{

    public class EntityRoleEnumBinder<TEntity, TRoleEnum> where TEntity : class where TRoleEnum : struct, IConvertible
    {
        public EntityRoleEnumBinder(TEntity Entity, TRoleEnum Role)
        {
            this.Entity = Entity;
            this.Role = Role;
        }

        public TEntity Entity { get; set; }
        public TRoleEnum Role { get; set; }
    }


    public class OrganizationRoleBinder: EntityRoleEnumBinder<Organization, OrganizationRoleEnum>
    {
        public OrganizationRoleBinder(Organization Entity, OrganizationRoleEnum Role)
            :base(Entity, Role) { }
    }
    

}
