using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Valence.Entities
{
    public enum ApplicationRoles
    {
        Public = 0,
        Member = 100,
        Admin = 1000
    }

    [Table("ApplicationRole", Schema = "dbo")]
    public class ApplicationRole : EntityBase
    {

        [Key]
        public int ApplicationRoleId { get; set; }

        public string ApplicationRoleName { get; set; }

        public int PrivilegeLevel { get; set; }

        public string Description { get; set; }


    }
}
