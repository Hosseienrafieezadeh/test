using Apps.Entitis.ApplicationUsers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.persistence.EF
{
    public class EFDataContext:IdentityDbContext<ApplicationUser>
    {
        public EFDataContext(DbContextOptions<EFDataContext> options) : base(options)
        {
        }
        public DbSet<ApplicationUser> applicationUsers;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly
                (typeof(EFDataContext).Assembly);
        }
    }
}
