
using Application.Mapping;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.Configure<TokenOptions>(c => configuration.GetSection("TokenOptions"));


            services.AddMediatR(Assembly.GetExecutingAssembly());


            //  services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}
