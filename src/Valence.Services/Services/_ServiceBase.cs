using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valence.Services
{
    public class InsufficientMemberPrivilegesException : Exception
    {
    }

    public interface IService
    {
    }

    public class ServiceBase : IService
    {
    }

}
