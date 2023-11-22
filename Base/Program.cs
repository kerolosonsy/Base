using Base.Extenstions;
using Domain.ApplicationUserAggregate;
using Infrastructure.Services.Authentication;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwaggerGen();

builder.Services.AddScoped<IUserStore<ApplicationUser>/*, CustomUserStore*/>();
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureIdentityDbContext();
builder.Services.ConfigureCors(builder.Configuration);

var authConfig = builder.Configuration.GetSection("AuthConfig").Get<AuthConfiguration>();

if (authConfig != null)
{
    builder.Services.ConfigureAuthentication(authConfig);
    builder.Services.AddSingleton(authConfig);
}
//builder.Services.AddSingleton<LogFileService>();
//builder.Services.AddScoped<BeeDegreeUOW>();
//builder.Services.AddScoped<IAttachmentService, AttachmentService>();

var app = builder.Build();

//var logger = app.Services.GetRequiredService<LogFileService>();
//app.ConfigureExceptionHandler(logger);

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

app.Run();
