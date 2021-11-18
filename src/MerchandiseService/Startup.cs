using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.Contracts;
using MerchandiseService.GrpcServices;
using MerchandiseService.Infrastructure.Configuration;
using MerchandiseService.Infrastructure.Extensions;
using MerchandiseService.Infrastructure.Filters;
using MerchandiseService.Infrastructure.Interceptors;
using MerchandiseService.Infrastructure.Middlewares;
using MerchandiseService.Infrastructure.Repositories.Infrastructure;
using MerchandiseService.Infrastructure.Repositories.Infrastructure.Interfaces;
using MerchandiseService.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Npgsql;

namespace MerchandiseService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructureRepositories();
            AddDatabaseComponents(services);
            AddMediator(services);
            services.AddSingleton<IMerchandiseService, Services.MerchandiseService>();
            services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<MerchandiseGrpcService>();
                endpoints.MapControllers();
            });
        }
        
        private void AddDatabaseComponents(IServiceCollection services)
        {
            services.Configure<DatabaseConnectionOptions>(Configuration.GetSection(nameof(DatabaseConnectionOptions)));
            services.AddScoped<IDbConnectionFactory<NpgsqlConnection>, NpgsqlConnectionFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IChangeTracker, ChangeTracker>();
        }
        
        private static void AddMediator(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup), typeof(DatabaseConnectionOptions));
        }

    }

    

    
}