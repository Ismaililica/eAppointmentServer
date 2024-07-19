using eAppointmentServer.Application.Services;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Infrastructure.Context;
using eAppointmentServer.Infrastructure.Repositories;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace eAppointmentServer.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            });
            services.AddIdentity<AppUser, AppRole>(action =>
            {
                action.Password.RequiredLength = 12;
                action.Password.RequireUppercase = false;
                action.Password.RequireDigit = false;
                action.Password.RequireLowercase = false;
                action.Password.RequireNonAlphanumeric = false;
            });
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.Scan(action
                =>
            {
                action
                .FromAssemblies(typeof(DependencyInjection).Assembly)
                .AddClasses(publicOnly: false)
                .UsingRegistrationStrategy(registrationStrategy: RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime();



            });
            return services;
        }
    }
}
