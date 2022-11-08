using ShuInkWeb.Core.Contracts;
using ShuInkWeb.Core.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ShuInkWebServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();

            services.AddScoped<IAppointmentService, AppointmentService>();

            services.AddScoped<IArtistService, ArtistService>();

            services.AddScoped<IHappeningService, HappeningService>();

            return services;
        }
    }
}
