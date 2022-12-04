﻿namespace Microsoft.Extensions.DependencyInjection
{
    using ShuInkWeb.Core.Contracts;
    using ShuInkWeb.Core.Services;
    using ShuInkWeb.Data;
    using ShuInkWeb.Data.Common.Repositories;
    using ShuInkWeb.JsonSerializer;

    public static class ShuInkWebServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddScoped<IDbQueryRunner, DbQueryRunner>();


            services.AddScoped<IJsonCalendarListEvents, JsonCalendarListEvents>();


            services.AddScoped<IAppointmentService, AppointmentService>();

            services.AddScoped<IArtistService, ArtistService>();

            services.AddScoped<IBlogService, BlogService>();

            services.AddScoped<IClientService, ClientService>();

            return services;
        }
    }
}
