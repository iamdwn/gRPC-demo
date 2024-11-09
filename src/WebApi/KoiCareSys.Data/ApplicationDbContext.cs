using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiCareSys.Data.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DevelopmentStage> DevelopmentStages { get; set; }

    public virtual DbSet<FeedingSchedule> FeedingSchedules { get; set; }

    public virtual DbSet<Koi> Kois { get; set; }

    public virtual DbSet<KoiRecord> KoiRecords { get; set; }

    public virtual DbSet<MeasureDatum> MeasureData { get; set; }

    public virtual DbSet<Measurement> Measurements { get; set; }

    public virtual DbSet<Pond> Ponds { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local); Database=KoiCareDb; Uid=sa; Pwd=12345;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DevelopmentStage>(entity =>
        {
            entity.ToTable("development_stage", "koicare");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.RequiredFoodAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("required_food_amount");
            entity.Property(e => e.StageName).HasColumnName("stage_name");
        });

        modelBuilder.Entity<FeedingSchedule>(entity =>
        {
            entity.ToTable("feeding_schedule", "koicare");

            entity.HasIndex(e => e.KoiId, "IX_feeding_schedule_koi_id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FeedAt).HasColumnName("feed_at");
            entity.Property(e => e.FoodAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("food_amount");
            entity.Property(e => e.FoodType).HasColumnName("food_type");
            entity.Property(e => e.KoiId).HasColumnName("koi_id");
            entity.Property(e => e.Note).HasColumnName("note");

            entity.HasOne(d => d.Koi).WithMany(p => p.FeedingSchedules).HasForeignKey(d => d.KoiId);
        });

        modelBuilder.Entity<Koi>(entity =>
        {
            entity.ToTable("koi", "koicare");

            entity.HasIndex(e => e.PondId, "IX_koi_pond_id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Breed).HasColumnName("breed");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.ImgUrl).HasColumnName("img_url");
            entity.Property(e => e.InPondSince).HasColumnName("in_pond_since");
            entity.Property(e => e.Length)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("length");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Origin).HasColumnName("origin");
            entity.Property(e => e.Physique).HasColumnName("physique");
            entity.Property(e => e.PondId).HasColumnName("pond_id");
            entity.Property(e => e.PurchasePrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("purchase_price");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Pond).WithMany(p => p.Kois).HasForeignKey(d => d.PondId);
        });

        modelBuilder.Entity<KoiRecord>(entity =>
        {
            entity.ToTable("koi_record", "koicare");

            entity.HasIndex(e => e.DevelopmentStageId, "IX_koi_record_development_stage_id");

            entity.HasIndex(e => e.KoiId, "IX_koi_record_koi_id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DevelopmentStageId).HasColumnName("development_stage_id");
            entity.Property(e => e.KoiId).HasColumnName("koi_id");
            entity.Property(e => e.Length)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("length");
            entity.Property(e => e.Physique).HasColumnName("physique");
            entity.Property(e => e.RecordAt).HasColumnName("record_at");
            entity.Property(e => e.Weight)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("weight");

            entity.HasOne(d => d.DevelopmentStage).WithMany(p => p.KoiRecords).HasForeignKey(d => d.DevelopmentStageId);

            entity.HasOne(d => d.Koi).WithMany(p => p.KoiRecords).HasForeignKey(d => d.KoiId);
        });

        modelBuilder.Entity<MeasureDatum>(entity =>
        {
            entity.ToTable("measure_data", "koicare");

            entity.HasIndex(e => e.MeasurementId, "IX_measure_data_measurement_id");

            entity.HasIndex(e => e.UnitId, "IX_measure_data_unit_id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.MeasurementId).HasColumnName("measurement_id");
            entity.Property(e => e.UnitId).HasColumnName("unit_id");
            entity.Property(e => e.Volume)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("volume");

            entity.HasOne(d => d.Measurement).WithMany(p => p.MeasureData).HasForeignKey(d => d.MeasurementId);

            entity.HasOne(d => d.Unit).WithMany(p => p.MeasureData).HasForeignKey(d => d.UnitId);
        });

        modelBuilder.Entity<Measurement>(entity =>
        {
            entity.ToTable("measurement", "koicare");

            entity.HasIndex(e => e.PondId, "IX_measurement_pond_id");

            entity.Property(e => e.MeasurementId)
                .ValueGeneratedNever()
                .HasColumnName("measurement_id");
            entity.Property(e => e.DateRecord).HasColumnName("date_record");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.PondId).HasColumnName("pond_id");

            entity.HasOne(d => d.Pond).WithMany(p => p.Measurements).HasForeignKey(d => d.PondId);
        });

        modelBuilder.Entity<Pond>(entity =>
        {
            entity.ToTable("pond", "koicare");

            entity.HasIndex(e => e.UserId, "IX_pond_user_id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Depth)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("depth");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DrainCount).HasColumnName("drain_count");
            entity.Property(e => e.ImgUrl).HasColumnName("img_url");
            entity.Property(e => e.IsQualified).HasColumnName("is_qualified");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.PondName).HasColumnName("pond_name");
            entity.Property(e => e.PumpCapacity)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("pump_capacity");
            entity.Property(e => e.SkimmerCount).HasColumnName("skimmer_count");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Volume)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("volume");

            entity.HasOne(d => d.User).WithMany(p => p.Ponds).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.ToTable("unit", "koicare");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FullName).HasColumnName("full_name");
            entity.Property(e => e.Information).HasColumnName("information");
            entity.Property(e => e.MaxValue)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("max_value");
            entity.Property(e => e.MinValue)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("min_value");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UnitOfMeasure).HasColumnName("unit_of_measure");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user", "koicare");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("full_name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
