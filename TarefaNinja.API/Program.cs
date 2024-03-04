using Joonasw.AspNetCore.SecurityHeaders;

using Microsoft.EntityFrameworkCore;

using OwaspHeaders.Core.Extensions;

using TarefaNinja.DAL;
using TarefaNinja.Domain;
using TarefaNinja.Repositories;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddControllers();

services.AddDbContext<DefaultContext>(options =>
{
    options.EnableSensitiveDataLogging();
    options.LogTo(Console.WriteLine);

    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

    var connectionString = "Data Source=C:\\TarefaNinja\\TarefaNinja.db";
    options.UseSqlite(connectionString, o =>
    {
        o.MigrationsAssembly("TarefaNinja.API");
    });
});

services.AddTransient<IUserDomain, UserDomain>();
services.AddTransient<IUserRepository, UserRepository>();
services.AddTransient<ICompanyRepository, CompanyRepository>();
services.AddTransient<IUserCompanyRepository, UserCompanyRepository>();

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

app.UseStrictTransportSecurity(new HstsOptions(TimeSpan.FromDays(30), includeSubDomains: false, preload: false));

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
