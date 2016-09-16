using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valence.Commands
{
    interface IAction<TActionEnum> where TActionEnum : struct, IConvertible 
    {
        bool HasPrivilege(TActionEnum action);

        bool CanRead();
        bool CanUpdate();
        bool CanDelete();

    }
}
