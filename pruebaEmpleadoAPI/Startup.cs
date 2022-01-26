using pruebaEmpleadoAPI.Domain.Helpers;
using pruebaEmpleadoAPI.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text;

namespace pruebaEmpleadoAPI
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
			

			var appSettingsSection = Configuration.GetSection("Configs");
			services.Configure<AppSetting>(appSettingsSection);
			var appSettings = appSettingsSection.Get<AppSetting>();

			services.Register(Configuration);
			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "pruebaEmpleadoAPI", Version = "v1" });
			});
        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "pruebaEmpleadoAPI v1"));
			}
			//Add cors politics 
			app.UseCors(options => {
				options.WithOrigins("http://localhost:4200/");
				options.AllowAnyMethod();
				options.AllowAnyHeader();
				options.AllowAnyOrigin();
			});





			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
