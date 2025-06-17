using AutoMapper;

namespace ProductManagement_CleanArchitecture_2025.Configuration
{
    public static class AutoMapper
    {
        /// <summary>
        /// Configure auto mapper by scanning all profiles through assemblies.
        /// </summary>
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
            {
                mc.ConstructServicesUsing(serviceProvider.GetService);
                mc.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            });

            IMapper mapper = mappingConfig.CreateMapper(type => serviceProvider.GetService(type));
            services.AddSingleton(typeof(IMapper), sp => mapper);
        }
    }
}
