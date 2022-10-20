using Application.Common.Interface;
using Common;
using IdentityModel;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Infrastruture.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Infrastruture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastruture(this IServiceCollection service, IConfiguration configuration, IWebHostEnvironment environment)
        {
            service.AddScoped<IUserManager, UserManagerService>();
            service.AddTransient<INotificationService, NotificationService>();
            service.AddTransient<IDateTime, MachineDateTime>();

            service.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("NorthwindDatabase")));

            service.AddDefaultIdentity<ApplicationUser>().AddEntityFrameworkStores<ApplicationDbContext>();

            if (environment.IsEnvironment("Test"))
            {
                service.AddIdentityServer()
                    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
                    {
                        options.Clients.Add(new IdentityServer4.Models.Client
                        {
                            ClientId = "Northwind.IntegrationTests",
                            AllowedGrantTypes = { GrantType.ResourceOwnerPassword },
                            ClientSecrets = { new IdentityServer4.Models.Secret("secret".Sha256()) },
                            AllowedScopes = { "Northwind.WebUIAPI", "openid", "profile" }
                        });
                    }).AddTestUsers(new List<TestUser>
                    {
                        new TestUser
                        {
                            SubjectId = "f26da293-02fb-4c90-be75-e4aa51e0bb17",
                            Username = "jason@northwind",
                            Password = "Northwind1!",
                            Claims = new List<Claim>
                            {
                                new Claim(JwtClaimTypes.Email, "jason@northwind")
                            }
                        }
                    });
            }
            else
            {
                service.AddIdentityServer()
                    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();
            }

            service.AddAuthentication()
              .AddIdentityServerJwt();

            return service;
        }
    }
}
