using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Valence.Entities
{

    [Table("Community", Schema = "dbo")]
    public class Community : EntityBase
    {
        [Key]
        public int CommunityId { get; set; }

        public string CommunityName { get; set; }

        public virtual IEnumerable<Organization> Organizations { get; set; }
        public virtual IEnumerable<OrganizationRole> OrganizationRoles { get; set; }
        public virtual IEnumerable<Event> Events { get; set; }

    }
}
