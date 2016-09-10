using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Valence.Entities
{
    [Table("ApplicationMember",Schema = "dbo")]
    public class ApplicationMember : EntityBase
    {

        [Key]
        public int ApplicationMemberId { get; set; }

        public int MemberId { get; set; }
        public virtual Member Member { get; set; }
       
        public int ApplicationRoleId { get; set; }
        public virtual ApplicationRole ApplicationRole { get; set; }

        public DateTime AssignmentDate { get; set; }

    }
}
