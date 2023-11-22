using Domain.ApplicationUserAggregate;
using Infrastructure.Services.Authentication;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserStore<ApplicationUser>/*, CustomUserStore*/>();
;


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
