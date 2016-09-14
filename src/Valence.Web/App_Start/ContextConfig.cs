using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Valence.Entities;
using Valence.Commands;

namespace Valence.Web
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole,int, CustomUserLogin, CustomUserRole, CustomUserClaim>, IValenceContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection") { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        #region IValenceContext Methods

        public System.Data.Entity.DbSet<Organization> Organizations { get; set; }
        public System.Data.Entity.DbSet<OrganizationMember> OrganizationMembers { get; set; }
        public System.Data.Entity.DbSet<OrganizationRole> OrganizationRoles { get; set; }

        public System.Data.Entity.DbSet<Community> Communities { get; set; }
        public System.Data.Entity.DbSet<CommunityMember> CommunityMembers { get; set; }
        
        #endregion


        /*
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().ToTable("user");
            modelBuilder.Entity<ApplicationUser>().ToTable("user");

            modelBuilder.Entity<IdentityRole>().ToTable("role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("userrole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("userclaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("userlogin");

        https://www.captechconsulting.com/blogs/customizing-the-aspnet-identity-data-model-with-the-entity-framework-fluent-api--part-1
        http://www.codeproject.com/Articles/727054/ASP-NET-MVC-Identity-Extending-and-Modifying-R
        http://www.asp.net/identity/overview/extensibility/change-primary-key-for-users-in-aspnet-identity#webformsupdate2

        https://msdn.microsoft.com/en-us/magazine/dn818488.aspx?f=255&MSPPError=-2147217396
        http://tech.opentable.co.uk/blog/2013/09/25/resolving-domains-to-areas-in-asp-dot-net-mvc/


        }
        */

    }
}