using Domain.Week;
using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace WebApi.DependencyInjection
{
    [ExcludeFromCodeCoverage]
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWeekRepository, WeekRepository>();

            return services;
        }
    }
}
