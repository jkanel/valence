using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Valence.Entities
{
    [Table("CommunityRole", Schema = "dbo")]
    public class CommunityRole : EntityBase
    {

        [Key]
        public int CommunityRoleId { get; set; }

        public string CommunityRoleName { get; set; }

        public string Description { get; set; }



    }
}
