using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Valence.Entities
{
    [Table("CommunityMember",Schema = "dbo")]
    public class CommunityMember : EntityBase
    {

        [Key]
        public int CommunityMemberId { get; set; }

        public int CommunityId { get; set; }
        public virtual Community Community { get; set; }

        public int MemberId { get; set; }
        public virtual Member Member { get; set; }

        public int CommunityRoleId { get; set; }
        public virtual CommunityRole CommunityRole { get; set; }


        public DateTime EffectiveTimestamp { get; set; }
        public DateTime AssignmentTimestamp { get; set; }

    }
}
