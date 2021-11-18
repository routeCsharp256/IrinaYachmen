using MerchandiseService.Infrastructure.Handlers.RequestMerchAggregate;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using MerchandiseService.Domain.AggregatesModel;
using MerchandiseService.Infrastructure.Queries;
using MerchandiseService.Infrastructure.Stubs;


namespace MerchandiseService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Добавление в DI контейнер инфраструктурных сервисов
        /// </summary>
        /// <param name="services">Объект IServiceCollection</param>
        /// <returns>Объект <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            
          //  services.AddMediatR(typeof(CreateRequestMerchCommandHandler).Assembly);
          //  services.AddMediatR(typeof(GetInfoAboutRequestMerchQueryHandler).Assembly);
            
            return services;
        }
        
        
        /// <summary>
        /// Добавление в DI контейнер инфраструктурных репозиториев
        /// </summary>
        /// <param name="services">Объект IServiceCollection</param>
        /// <returns>Объект <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
        {
            
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            services.AddScoped<IRequestMerchRepository, RequestMerchRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            return services;
        }
    }
}