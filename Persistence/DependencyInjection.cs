using Application.Common.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NortwindDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("NorthwindDatabase")));
            services.AddScoped<INorthwindDbContext>(provider => provider.GetService<NortwindDbContext>());

            return services;
        }
    }
}
