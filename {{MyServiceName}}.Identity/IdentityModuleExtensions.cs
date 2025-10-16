using __MyServiceName__.Identity.Domain.Entities;
using __MyServiceName__.Identity.Middlewares;
using __MyServiceName__.Identity.Models;
using __MyServiceName__.Identity.Services;
using __MyServiceName__.Identity.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace __MyServiceName__.Identity;

public static class IdentityModuleExtensions
{
    public static IServiceCollection AddIdentityModule(this IServiceCollection services, IConfiguration configuration)
    {
        var builder = new ConfigurationBuilder()
        .SetBasePath(AppContext.BaseDirectory)
        .AddJsonFile("secret.json", optional: false, reloadOnChange: true);

        var identityConfig = builder.Build();

        services.AddOptions<JwtOptions>()
            .Bind(identityConfig.GetSection("Jwt"))
            .ValidateDataAnnotations()   
            .ValidateOnStart();          


        services.AddScoped<ITokenService, TokenService>();

        services.AddDbContext<IdentityContext>(options =>
            options.UseSqlServer(identityConfig.GetConnectionString("IdentityConnection")));

        services.AddIdentityCore<ApplicationUser>()
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<IdentityContext>()
            .AddDefaultTokenProviders();

        return services;

    }

    public static IApplicationBuilder UseIdentityModule(this IApplicationBuilder app)
    {
        app.UseMiddleware<IdentityMiddleware>();
        return app;
    }
}
