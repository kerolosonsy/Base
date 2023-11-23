using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.TenantAggregate;

namespace Infrastructure.Services.Tenant
{
    public interface ITenantService
    {
        Domain.TenantAggregate.Tenant GetTenant(string domain);
    }
}
