using Domain.ApplicationUserAggregate;
using Infrastructure.DataBase.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DBMigrationWebApi.Extenstions;

public static class ServicesExtenstions
{

    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<BaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("BeeDegreeConnection"),
            sqlServerOptionsAction: sqloption =>
            {
                sqloption.MigrationsAssembly("DBMigration");
                //sqloption.EnableRetryOnFailure();
            });
        });


    public static void ConfigureIdentityDbContext(this IServiceCollection services) =>
        services.AddIdentity<ApplicationUser, IdentityRole<string>>(options =>
        {
            options.User.RequireUniqueEmail = false;
            options.Password.RequireNonAlphanumeric = false;
        })
                .AddEntityFrameworkStores<BaseContext>()
                .AddDefaultTokenProviders();







}
