using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Valence.Entities;

namespace Valence.Commands
{ 
    public interface IValenceContext
    {
        DbSet<Organization> Organizations { get; set; }
        DbSet<OrganizationMember> OrganizationMembers { get; set; }
        DbSet<OrganizationRole> OrganizationRoles { get; set; }
    
    }

    public class ValenceContext : IValenceContext
    {
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<OrganizationMember> OrganizationMembers { get; set; }
        public virtual DbSet<OrganizationRole> OrganizationRoles { get; set; }
    }
}
