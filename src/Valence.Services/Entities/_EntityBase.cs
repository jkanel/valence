using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Valence.Entities
{
    public class EntityBase
    {

        public void SetCreateInfo(int MemberId)
        {
            this.CreateMemberId = MemberId;
            this.CreateTimestamp = DateTime.Now;

            this.SetModifyInfo(MemberId);

        }

        public void SetModifyInfo(int MemberId)
        {
            this.ModifyMemberId = MemberId;
            this.ModifyTimestamp = DateTime.Now;
        }

        public int CreateMemberId { get; set; }
        public DateTime CreateTimestamp { get; set; }


        public int ModifyMemberId { get; set; }
        public DateTime ModifyTimestamp { get; set; }

        public static string[] CreateProperties
        {
            get { return new string[] { "CreateMemberId", "CreateTimestamp" }; }
        }
    }
}
