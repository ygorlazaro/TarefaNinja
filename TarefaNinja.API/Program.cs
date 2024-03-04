using Joonasw.AspNetCore.SecurityHeaders;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using System.Text;

using TarefaNinja.DAL;
using TarefaNinja.Domain;
using TarefaNinja.Repositories;
using TarefaNinja.Services;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Tarefa Ninja",
        Description = "Tarefa Ninja API"
    });

    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });

    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                           []
                    }
                });
});
services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["Jwt:Issuer"],
        ValidAudience = configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
    };
});
services.AddControllers()
      .AddJsonOptions(config =>
      {
          config.JsonSerializerOptions.AllowTrailingCommas = false;
          config.JsonSerializerOptions.MaxDepth = 0;
          config.JsonSerializerOptions.IgnoreReadOnlyFields = true;
          config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
      });

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

services.AddDbContext<DefaultContext>(options =>
{
    options.EnableSensitiveDataLogging();
    options.LogTo(Console.WriteLine);

    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

    var connectionString = "Server=localhost;Port=5432;Database=tarefaninja;UID=postgres;PWD=postgres";

    options.UseNpgsql(connectionString, o =>
    {
        o.MigrationsAssembly("TarefaNinja.API");
    }).UseSnakeCaseNamingConvention();
});

services.AddTransient<IUserDomain, UserDomain>();
services.AddTransient<IUserRepository, UserRepository>();
services.AddTransient<ICompanyRepository, CompanyRepository>();
services.AddTransient<IUserCompanyRepository, UserCompanyRepository>();
services.AddTransient<IPasswordHasher, PasswordHasher>();
services.AddSingleton<ITokenService, TokenService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.UseHpkp(hpkp =>
{
    hpkp.UseMaxAgeSeconds(30 * 24 * 60 * 60)
        .AddSha256Pin("nrmpk4ZI3wbRBmUZIT5aKAgP0LlKHRgfA2Snjzeg9iY=")
        .SetReportOnly()
        .ReportViolationsTo("/hpkp-report");
});

app.UseCsp(csp =>
{
    csp.ByDefaultAllow
        .FromSelf();

    csp.AllowScripts
        .FromSelf();

    csp.AllowStyles
        .FromSelf();

    csp.AllowImages
        .FromSelf();

    csp.AllowAudioAndVideo
        .FromNowhere();

    csp.AllowFrames
        .FromNowhere();

    csp.AllowPlugins
        .FromNowhere();

    csp.AllowFraming
        .FromNowhere();

    csp.ReportViolationsTo("/csp-report");
});

app.MapControllers();

app.Run();
