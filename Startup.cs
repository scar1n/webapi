using CarServiceApi.Services;
using CarServiceApi.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarServiceApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwaggerGen();

            services.AddDbContext<ApplicationContext>();

            services.AddTransient<ICarBrandsService, CarBrandsService>();
            services.AddTransient<ICarModelsService, CarModelsService>();
            services.AddTransient<ICarQueuesService, CarQueuesService>();
            services.AddTransient<IClientCarsService, ClientCarsService>();
            services.AddTransient<IClientsService, ClientsService>();
            services.AddTransient<ICompaniesService, CompaniesService>();
            services.AddTransient<ICompletedServicesService, CompletedServicesService>();
            services.AddTransient<IEmployeesService, EmployeesService>();
            services.AddTransient<IInstrumentsService, InstrumentsService>();
            services.AddTransient<IModelGenerationsService, ModelGenerationsService>();
            services.AddTransient<IPlacesService, PlacesService>();
            services.AddTransient<IPositionsService, PositionsService>();
            services.AddTransient<IServicesService, ServicesService>();
            services.AddTransient<ISparesService, SparesService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<JsonConverterMiddleware>();

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
