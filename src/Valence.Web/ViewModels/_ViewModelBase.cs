using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Valence.Commands;
using Valence.Web;

namespace Valence.Web.ViewModels
{

    public interface IEntityViewModel<TEntity> where TEntity : class
    {

        void Construct(TEntity entity);
        TEntity ToEntity();

        bool CanRead { get; set; }               
        bool CanUpdate { get; set; }
        bool CanDelete{ get; set; }
        
    }
    
    public interface IApplicationViewModel
    {
        ApplicationUserInfo ApplicationUserInfo { get; set; }
    }


}