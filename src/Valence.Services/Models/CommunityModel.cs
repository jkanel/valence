using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valence.Entities;

namespace Valence.Models
{

    public class CommunityModelList : List<CommunityModel>
    {
        public CommunityModelList(IEnumerable<Community> entities)
        {
            foreach (var entity in entities)
            {
                Add(new CommunityModel(entity));
            }
        }
    }

    public class CommunityModel : IModel<Community>
    {
        public CommunityModel() { }
        public CommunityModel(Community entity)
        {
            this.Construct(entity);
        }
        
        public int CommunityId { get; set; }
        public string CommunityName { get; set; }

        public void Construct(Community entity)
        {

            this.CommunityId = entity.CommunityId;
            this.CommunityName = entity.CommunityName;
        }

        public Community ToEntity()
        {
            Community entity = new Entities.Community();

            entity.CommunityId = this.CommunityId;
            entity.CommunityName = this.CommunityName;

            return entity;

        }
    }
}
