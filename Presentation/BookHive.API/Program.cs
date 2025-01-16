using System.Text;
using BookHive.API.Extensions;
using BookHive.Application.CustomAttributes;
using BookHive.Application.Registration;
using BookHive.Domain.Identity;
using BookHive.Infrastructure.Registration;
using BookHive.Persistence.Context;
using BookHive.Persistence.Registration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Core;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
{
    //opt.Filters.Add<MaintenanceModeAttribute>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices();

builder.Services.AddHealthChecks();

builder.Services.AddCors(
    options => options.AddDefaultPolicy
    (policy => policy.WithOrigins("https://localhost:7239/", "https://localhost:7239/").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));

builder.Services.AddIdentity<AppUser, AppRole>(Identityoptions =>
{
    Identityoptions.User.RequireUniqueEmail = true;
    Identityoptions.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";
    Identityoptions.Password.RequiredLength = 8;
    Identityoptions.Password.RequireNonAlphanumeric = false;
    Identityoptions.Lockout.AllowedForNewUsers = true;
    Identityoptions.Lockout.MaxFailedAccessAttempts = 5;
    Identityoptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

Logger log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt")
    .WriteTo.MSSqlServer(connectionString: AppDbContext.SqlConnection, tableName: "Logs", autoCreateSqlTable: true)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog(log);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.ResponseHeaders.Add("MyResponseHeader");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
    logging.CombineLogs = true;
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin", options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateAudience = true, // Yarad?lacaq token d?y?rl?rini hans? saytlar?n istifad? ed?c?yi d?y?rdir
            ValidateIssuer = true, // Yarad?lacaq token d?y?rini kimin da??tt?d??n? ifad? edil??ck d?y?rdir
            ValidateLifetime = true, //Yarad?lacaq token d?y?rini vaxt?n? kontrol ed?c?k
            ValidateIssuerSigningKey = true, //Yarad?lacaq token d?y?rinin proqrama aid bir d?y?r oldu?unu ifad? ed?n suciry key verisinin do?rulanmas?d?r

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpLogging();

app.MapHealthChecks("/health");
app.UseCors();
app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
