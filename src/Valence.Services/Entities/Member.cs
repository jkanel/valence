using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Valence.Entities
{
    [Table("Member", Schema = "dbo")]
    public class Member : EntityBase
    {
        [Key]
        public int MemberId { get; set; }

        public string UserGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsValidatedEmail { get; set; }

        public virtual IEnumerable<OrganizationRole> OrganizationRoles { get; set; }




    }
}
