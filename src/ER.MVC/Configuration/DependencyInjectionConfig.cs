using ER.Application.Services;
using ER.Data.Context;
using ER.Data.Repository;
using ER.Domain.Interfaces;
using ER.Domain.Interfaces.Repositories;
using ER.Domain.Interfaces.Services;
using ER.Domain.Notifications;
using ER.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
namespace ER.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ERDbContext>();

            services.AddScoped<INotifier, Notifier>();

            services.AddScoped<IRecordAppService, RecordAppService>();
            services.AddScoped<IRecordService, RecordService>();
            services.AddScoped<IRecordRepository, RecordRepository>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
