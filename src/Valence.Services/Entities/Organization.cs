using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Valence.Entities
{


    [Table("Organization", Schema = "dbo")]
    public class Organization : EntityBase
    {

		[Key]
        public int OrganizationId { get; set; }
		public string OrganizationName { get; set;}
		public string Description { get; set; }
		public string WebPageUrl { get; set; }
		public bool IsServicesVendor { get; set; }
		public bool IsProductVendor { get; set; }
		public bool IsNonProfit { get; set; }
		public bool IsEducational { get; set; }

        public virtual IEnumerable<OrganizationMember> OrganizationMembers { get; set; }

        public virtual IEnumerable<EventMember> EventMembers { get; set; }


    }
}
