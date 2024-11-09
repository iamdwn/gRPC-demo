using Autofac;
using KoiCareSys.Common;
using KoiCareSys.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace KoiCareSys.WebAPI.Configuration
{
    public static class ConfigureDbContext
    {
        public static IServiceCollection ConfigAddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(AppConfig.ConnectionStrings.DefaultConnection));
            return services;
        }

        public static ContainerBuilder AddDbContext(this ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerLifetimeScope();
            return builder;
        }

    }
}
