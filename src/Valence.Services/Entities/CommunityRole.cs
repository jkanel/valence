using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Valence.Entities
{

    public enum ComunityRoles
    {
        Public = 0,
        Coordinator = 200,
        Manager = 900,
        Admin = 1000
    }
    

    [Table("CommunityRole", Schema = "dbo")]
    public class CommunityRole : EntityBase
    {

        [Key]
        public int CommunityRoleId { get; set; }

        public string CommunityRoleName { get; set; }

        public int PrivilegeLevel { get; set; }

        public string Description { get; set; }



    }
}
