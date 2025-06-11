using ApiLearning.Core.Interfaces;
using ApiLearning.Core.Models;
using ApiLearning.Core.Services;
using ApiLearning.Infrastructure;
using ApiLearning.Infrastructure.Data;
using ApiLearning.Infrastructure.Email;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace ApiLearning.Web.Configurations;

public static class ServiceConfigs
{
    public static IServiceCollection AddServiceConfigs(this IServiceCollection services, Microsoft.Extensions.Logging.ILogger logger, WebApplicationBuilder builder)
    {
        services.AddInfrastructureServices(builder.Configuration, logger)
                .AddMediatrConfigs();

        if (builder.Environment.IsDevelopment())
        {
            services.AddScoped<IEmailSender, MimeKitEmailSender>();
      services.AddScoped<ITokenService, TokenService>();
      services.AddScoped<IAccountService, AccountService>();
      services.AddIdentity<AppUser, IdentityRole>(option =>
            {
                option.Password.RequireLowercase = true;
                option.Password.RequireUppercase = true;
                option.Password.RequireDigit = true;
                option.Password.RequiredLength = 8;
                option.Password.RequireNonAlphanumeric = true;
            }).AddEntityFrameworkStores<AppDbContext>();

            _ = services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.RequireHttpsMetadata = false;
                option.SaveToken = true;

                // Fix: Ensure the configuration value is not null or empty before using it
                var jwtKey = builder.Configuration["Jwt:Key"];
                if (string.IsNullOrEmpty(jwtKey))
                {
                    throw new InvalidOperationException("JWT Key is not configured in the application settings.");
                }

                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtKey)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"]
                };
            });

          
    }
        else
        {
            services.AddScoped<IEmailSender, MimeKitEmailSender>();
      services.AddScoped<ITokenService, TokenService>();
      services.AddScoped<IAccountService, AccountService>();
      services.AddIdentity<AppUser, IdentityRole>(option =>
            {
                option.Password.RequireLowercase = true;
                option.Password.RequireUppercase = true;
                option.Password.RequireDigit = true;
                option.Password.RequiredLength = 8;
                option.Password.RequireNonAlphanumeric = true;
            }).AddEntityFrameworkStores<AppDbContext>();
        }

        logger.LogInformation("{Project} services registered", "Mediatr and Email Sender");

        return services;
    }
}
