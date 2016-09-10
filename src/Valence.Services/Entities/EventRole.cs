using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Valence.Entities
{
    [Table("EventRole", Schema = "dbo")]
    public class EventRole : EntityBase
    {

        [Key]
        public int EventRoleId { get; set; }

        public string EventRoleName { get; set; }

        public string Description { get; set; }



    }
}
