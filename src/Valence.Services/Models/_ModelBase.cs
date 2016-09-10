using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valence.Models
{
    public interface IModel<TEntity> where TEntity : class
    {
        TEntity ToEntity();
        void Construct(TEntity entity);
        
    }  
}
