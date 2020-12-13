using Microsoft.Extensions.DependencyInjection;
using JPSD.ChallengeKSP.Transversal.Common;
using JPSD.ChallengeKSP.Infrastructure.Data;
using JPSD.ChallengeKSP.Infrastructure.Repository;
using JPSD.ChallengeKSP.Application.Interface;
using JPSD.ChallengeKSP.Application.Main;
using JPSD.ChallengeKSP.Domain.Interface;
using JPSD.ChallengeKSP.Domain.Core;
using JPSD.ChallengeKSP.Infrastructure.Interface;
using JPSD.ChallengeKSP.Transversal.Logging;
using Microsoft.Extensions.Configuration;

namespace JPSD.ChallengeKSP.Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<IEmployeesApplication, EmployeesApplication>();
            services.AddScoped<IEmployeesDomain, EmployeesDomain>();
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<IBeneficiariesApplication, BeneficiariesApplication>();
            services.AddScoped<IBeneficiariesDomain, BeneficiariesDomain>();
            services.AddScoped<IBeneficiariesRepository, BeneficiariesRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            return services;
        }
    }
}
