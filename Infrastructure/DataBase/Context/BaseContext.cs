using Domain.ApplicationUserAggregate;
using Domain.TenantAggregate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataBase.Context
{
    public class BaseContext : IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        private readonly Tenant _tenant;

        public BaseContext(DbContextOptions<BaseContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _tenant = httpContextAccessor.HttpContext?.Items["Tenant"] as Tenant;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (_tenant != null)
            {
                modelBuilder.HasDefaultSchema(_tenant.Schema);
            }

            base.OnModelCreating(modelBuilder);
        }
        #region Tenant
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<Tenant> Tenant1 { get; set; }
        #endregion

    }
}
