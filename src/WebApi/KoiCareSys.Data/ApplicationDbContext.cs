using KoiCareSys.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KoiCareSys.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public ApplicationDbContext()
        {
        }

        #region DbSet
        public DbSet<DevelopmentStage> DevelopmentStages { get; set; }
        public DbSet<FeedingSchedule> FeedingSchedules { get; set; }
        public DbSet<Pond> Ponds { get; set; }
        public DbSet<Koi> Kois { get; set; }
        public DbSet<KoiRecord> KoiRecords { get; set; }
        public DbSet<MeasureData> MeasureDatas { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users { get; set; }


        #endregion DbSet

        /*        public static string GetConnectionString(string connectionStringName)
                {
                    var config = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("appsettings.json")
                        .Build();

                    string connectionString = config.GetConnectionString(connectionStringName);
                    return connectionString;
                }*/
        public static string GetConnectionString(string connectionStringName)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var directoryInfo = new DirectoryInfo(basePath);

            while (directoryInfo != null && !File.Exists(Path.Combine(directoryInfo.FullName, "KoiCareSys.WebApi", "appsettings.json")))
            {
                directoryInfo = directoryInfo.Parent;
            }

            if (directoryInfo == null)
            {
                throw new FileNotFoundException("The configuration file 'appsettings.json' was not found in the project directory or any parent directories.");
            }

            var configPath = Path.Combine(directoryInfo.FullName, "KoiCareSys.WebApi", "appsettings.json");

            var config = new ConfigurationBuilder()
                .SetBasePath(directoryInfo.FullName)
                .AddJsonFile(configPath, optional: false, reloadOnChange: true)
                .Build();

            string? connectionString = config.GetConnectionString(connectionStringName);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException($"Connection string '{connectionStringName}' is not found in the configuration.");
            }

            return connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.HasDefaultSchema("koicare");

        }

    }
}