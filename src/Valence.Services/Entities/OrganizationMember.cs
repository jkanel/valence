using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Valence.Entities
{
    [Table("OrganizationMember", Schema = "dbo")]
    public class OrganizationMember : EntityBase
    {

        [Key]
        public int OrganizationMemberId { get; set; }

        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }

        public int MemberId { get; set; }
        public virtual Member Member { get; set; }

        public int OrganizationRoleId { get; set; }
        public virtual OrganizationRole OrganizationRole { get; set; }

    }
}
