using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Valence.Commands
{
    public class CommandBase
    {
        
        public DbContext Context { get; set; }

        public CommandBase() { }

        public CommandBase(DbContext Context)
        {
            this.Context = Context;
        }

        public IValenceContext ValenceContext
        {
            get { return (IValenceContext)this.Context; }
        }

    }
}
