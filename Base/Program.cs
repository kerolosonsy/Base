using Base.Middleware;
using Domain.ApplicationUserAggregate;
using Infrastructure.DataBase.Context;
using Infrastructure.Services.Tenant;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
        .AddEntityFrameworkStores<BaseContext>()
        .AddDefaultTokenProviders();


builder.Services.AddDbContext<BaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BaseConnection")));


builder.Services.AddSingleton<ITenantService, TenantService>();
builder.Services.AddHttpContextAccessor();

//builder.Services.AddDbContext<BaseContext>(options =>
//    options.UseSqlServer(
//        builder.Configuration.GetConnectionString("BaseConnection"),
//        x => x.MigrationsAssembly("Base")
//    )
//);


//builder.Services.AddSingleton<LogFileService>();
//builder.Services.AddScoped<BeeDegreeUOW>();
//builder.Services.AddScoped<IAttachmentService, AttachmentService>();

var app = builder.Build();

//var logger = app.Services.GetRequiredService<LogFileService>();
//app.ConfigureExceptionHandler(logger);

app.UseMiddleware<TenantMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<BaseContext>();
    dbContext.Database.Migrate();
}

app.Run();
