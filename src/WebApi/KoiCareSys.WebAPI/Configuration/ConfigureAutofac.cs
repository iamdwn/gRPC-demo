using Autofac;
using Autofac.Extensions.DependencyInjection;
using KoiCareSys.WebAPI.Configuration;

namespace KoiCareSys.WebAPI.Configuration
{
    public static class ConfigureAutofac
    {
        public static void ConfigureAutofacContainer(this WebApplicationBuilder builder)
        {
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofaceModule());
            });
        }

        public class AutofaceModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.AddDbContext();
                base.Load(builder);
            }
        }
    }
}
