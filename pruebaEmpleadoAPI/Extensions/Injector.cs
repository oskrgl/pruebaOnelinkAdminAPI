using pruebaEmpleadoAPI.Application.Interfaces;
using pruebaEmpleadoAPI.Application.Services;
using pruebaEmpleadoAPI.DataAccess;
using pruebaEmpleadoAPI.DataAccess.Repositories;
using pruebaEmpleadoAPI.Domain.Helpers;
using pruebaEmpleadoAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace pruebaEmpleadoAPI.Extensions
{
    /// <summary>
    /// Represents dependency injection
    /// </summary>
    public static class Injector
    {
        /// <summary>
        /// Inject the dependencies
        /// </summary>
        /// <param name="services">Represents an instance of <see cref="IServiceCollection"/></param>
        /// <param name="configuration">Represents an instance of <see cref="IConfiguration"/></param>
        public static void Register(this IServiceCollection services, IConfiguration configuration)
        {

            #region Application
            services.AddSingleton<AppSettingGlobal>();
            services.AddTransient<ISaveEmpleadoApp, SaveEmpleadoApp>();
            #endregion

            #region Domain
            services.AddScoped<ISaveEmpleadoRepository, SaveEmpleadoRepository>();
            #endregion

            #region DbContext
            services.AddDbContext<EmpleadoDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
            #endregion
        }
    }
}
