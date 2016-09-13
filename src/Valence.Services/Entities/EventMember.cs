using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Valence.Entities
{
    [Table("EventMember", Schema = "dbo")]
    public class EventMember : EntityBase
    {
        [Key]
        public int EventMemberId { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        public int MemberId { get; set; }
        public virtual Member Member { get; set; }

        public int EventRoleId { get; set; }
        public virtual EventRole EventRole { get; set; }

        public DateTime EffectiveTimestamp { get; set; }
        public DateTime AssignmentTimestamp { get; set; }

    }
}
