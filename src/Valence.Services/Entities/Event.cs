using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Valence.Entities
{

    [Table("Event", Schema = "dbo")]
    public class Event : EntityBase
    {
        [Key]
        public int EventId { get; set; }
        
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        

        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }

        public DateTime EventDate { get; set; }
        public DateTime EventTime { get; set; }
        public string Instruction { get; set; }

        public string EventName { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsInviteRequired { get; set; }

        public enum EventProviders { Internal, Meetup }

        public EventProviders EventProvider { get; set; }
        public string WebPageUrl { get; set; }
        
        public virtual IEnumerable<Member> AttendingMembers { get; set; }

    }
}
