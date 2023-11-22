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
    public class BaseContext : IdentityDbContext<ApplicationUser,ApplicatoinRole,string>
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }
        #region Tenant
        public DbSet<Tenant> Tenant { get; set; }
        #endregion

    }
}
