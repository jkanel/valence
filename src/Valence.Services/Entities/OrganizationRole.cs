using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Valence.Entities
{
    [Table("OrganizationRole", Schema = "dbo")]
    public class OrganizationRole : EntityBase
    {

        [Key]
        public int OrganizationRoleId { get; set; }

        public string OrganizationRoleName { get; set; }

        public string Description { get; set; }
        

    }
}
