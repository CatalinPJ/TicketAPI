using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TicketAPI.Persistence.Repositories;
using TicketAPI.Services.Contracts;
using TicketAPI.Services.Implementations;

namespace TicketAPI.Extensions
{
    public static class CustomServices
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<IUserService, UserService>();
        }

        public static void AddCustomCors(this IServiceCollection services, string customOriginName)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: customOriginName,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:4200")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader();
                                  });
            });
        }
        public static void AddCustomAuthorization(this IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes("my top secret key");
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}