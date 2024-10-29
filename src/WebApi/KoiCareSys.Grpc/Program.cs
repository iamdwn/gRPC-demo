using KoiCareSys.Data;
using KoiCareSys.Grpc.Services;
using KoiCareSys.Service.Mappings;
using KoiCareSys.Service.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using PondService = KoiCareSys.Grpc.Protos.PondService;

namespace KoiCareSys.Grpc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

            // Add services to the container.
            builder.Services.AddScoped<UnitOfWork>();
            builder.Services.AddScoped<IPondService, KoiCareSys.Service.Service.PondService>();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

            builder.Services.AddGrpc();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Server=(local);Database=KoiCareDb;uid=sa;pwd=12345;Trusted_Connection=True;TrustServerCertificate=True;"));

            builder.WebHost.UseUrls("http://localhost:5000");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<GreeterService>();
            app.MapGrpcService<PondService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}