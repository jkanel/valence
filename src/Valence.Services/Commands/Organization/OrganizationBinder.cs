using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valence.Entities;

namespace Valence.Commands
{
    public class OrganizationBinder
    {
        public Organization Organization { get; set; }
        public OrganizationActions Actions { get; set; }
    }
}
