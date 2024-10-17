using Autofac;
using Microsoft.EntityFrameworkCore;
using KoiCareSys.Data;
using Microsoft.Identity.Client;
using KoiCareSys.Common;


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
