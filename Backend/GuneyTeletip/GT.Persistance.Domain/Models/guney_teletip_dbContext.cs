using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GT.Persistance.Domain.Models
{
    public partial class guney_teletip_dbContext : DbContext
    {
        public guney_teletip_dbContext()
        {
        }

        public guney_teletip_dbContext(DbContextOptions<guney_teletip_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppPermatt> AppPermatt { get; set; }
        public virtual DbSet<InfBatch> InfBatch { get; set; }
        public virtual DbSet<InfStudy> InfStudy { get; set; }
        public virtual DbSet<Kosresultenmtype> Kosresultenmtype { get; set; }
        public virtual DbSet<Modality> Modality { get; set; }
        public virtual DbSet<Skrs> Skrs { get; set; }
        public virtual DbSet<Tenat> Tenat { get; set; }
        public virtual DbSet<TenatSkrs> TenatSkrs { get; set; }
        public virtual DbSet<UsrRole> UsrRole { get; set; }
        public virtual DbSet<UsrUserLogin> UsrUserLogin { get; set; }
        public virtual DbSet<UsrUserRole> UsrUserRole { get; set; }
        public virtual DbSet<UsrUserTenat> UsrUserTenat { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=85.95.241.63;Database=guney_teletip_db;Username=test_user;Password=test123;Port=54321");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppPermatt>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("app_permatt_pkey");

                entity.ToTable("app_permatt");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.AppLog)
                    .HasColumnName("app_log")
                    .HasMaxLength(2000);

                entity.Property(e => e.Desc1)
                    .HasColumnName("desc1")
                    .HasMaxLength(64);

                entity.Property(e => e.Desc2)
                    .HasColumnName("desc2")
                    .HasMaxLength(64);

                entity.Property(e => e.Desc3)
                    .HasColumnName("desc3")
                    .HasMaxLength(64);

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeDelete).HasColumnName("time_delete");

                entity.Property(e => e.UserFkCreated).HasColumnName("user_fk_created");

                entity.Property(e => e.UserFkLastModfiead).HasColumnName("user_fk_last_modfiead");

                entity.Property(e => e.Valuse).HasColumnName("valuse");
            });

            modelBuilder.Entity<InfBatch>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("inf_batch_pkey");

                entity.ToTable("inf_batch");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.Tarih).HasColumnName("tarih");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeDelete).HasColumnName("time_delete");

                entity.Property(e => e.UserFkCreated).HasColumnName("user_fk_created");

                entity.Property(e => e.UserFkLastModfiead).HasColumnName("user_fk_last_modfiead");
            });

            modelBuilder.Entity<InfStudy>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("inf_study_pkey");

                entity.ToTable("inf_study");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.AccessionNo)
                    .HasColumnName("accession_no")
                    .HasMaxLength(16);

                entity.Property(e => e.CihazDeviceSerialNumber)
                    .HasColumnName("cihaz_device_serial_number")
                    .HasMaxLength(64);

                entity.Property(e => e.DateBirth)
                    .HasColumnName("date_birth")
                    .HasColumnType("date");

                entity.Property(e => e.Desc1)
                    .HasColumnName("desc1")
                    .HasMaxLength(64);

                entity.Property(e => e.Desc2)
                    .HasColumnName("desc2")
                    .HasMaxLength(64);

                entity.Property(e => e.Desc3)
                    .HasColumnName("desc3")
                    .HasMaxLength(64);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(8);

                entity.Property(e => e.InfFkBatch)
                    .HasColumnName("inf_fk_batch")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.InfFkStudy)
                    .HasColumnName("inf_fk_study")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.InstanceNumber).HasColumnName("instance_number");

                entity.Property(e => e.InstitutionName)
                    .HasColumnName("institution_name")
                    .HasMaxLength(256);

                entity.Property(e => e.Modality)
                    .HasColumnName("modality")
                    .HasMaxLength(6);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(40);

                entity.Property(e => e.PatientId)
                    .HasColumnName("patient_id")
                    .HasMaxLength(11);

                entity.Property(e => e.PatinetNameSurname)
                    .HasColumnName("patinet_name_surname")
                    .HasMaxLength(80);

                entity.Property(e => e.StoragePath)
                    .HasColumnName("storage_path")
                    .HasMaxLength(512);

                entity.Property(e => e.StudyDate).HasColumnName("study_date");

                entity.Property(e => e.StudyDescription)
                    .HasColumnName("study_description")
                    .HasMaxLength(256);

                entity.Property(e => e.StudyInstanceuid)
                    .HasColumnName("study_instanceuid")
                    .HasMaxLength(128);

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasMaxLength(40);

                entity.Property(e => e.TenantFk)
                    .HasColumnName("tenant_fk")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeDelete).HasColumnName("time_delete");

                entity.Property(e => e.UserFk)
                    .HasColumnName("user_fk")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserFkLastModfiead)
                    .HasColumnName("user_fk_last_modfiead")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.InfFkBatchNavigation)
                    .WithMany(p => p.InfStudy)
                    .HasForeignKey(d => d.InfFkBatch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_batch");
            });

            modelBuilder.Entity<Kosresultenmtype>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("kosresultenmtype_pkey");

                entity.ToTable("kosresultenmtype");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.EnmAd)
                    .HasColumnName("enm_ad")
                    .HasMaxLength(64);

                entity.Property(e => e.EnmId).HasColumnName("enm_id");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeDelete).HasColumnName("time_delete");

                entity.Property(e => e.UserFkCreated).HasColumnName("user_fk_created");

                entity.Property(e => e.UserFkLastModfiead).HasColumnName("user_fk_last_modfiead");
            });

            modelBuilder.Entity<Modality>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("modality_pkey");

                entity.ToTable("modality");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.Modality1)
                    .HasColumnName("modality")
                    .HasMaxLength(8);

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeDelete).HasColumnName("time_delete");

                entity.Property(e => e.UserFkCreated).HasColumnName("user_fk_created");

                entity.Property(e => e.UserFkLastModfiead).HasColumnName("user_fk_last_modfiead");
            });

            modelBuilder.Entity<Skrs>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("skrs_pkey");

                entity.ToTable("skrs");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.KurumAd)
                    .HasColumnName("kurum_ad")
                    .HasMaxLength(64);

                entity.Property(e => e.KurumMedulaTesisKodu)
                    .HasColumnName("kurum_medula_tesis_kodu")
                    .HasMaxLength(32);

                entity.Property(e => e.KurumSettingId)
                    .HasColumnName("kurum_setting_id")
                    .HasMaxLength(128);

                entity.Property(e => e.KurumSkrsAdı)
                    .HasColumnName("kurum_skrs_adı")
                    .HasMaxLength(64);

                entity.Property(e => e.KurumSkrsKodu)
                    .HasColumnName("kurum_skrs_kodu")
                    .HasMaxLength(32);

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeDelete).HasColumnName("time_delete");

                entity.Property(e => e.UserFk).HasColumnName("user_fk");

                entity.Property(e => e.UserFkLastModfiead).HasColumnName("user_fk_last_modfiead");
            });

            modelBuilder.Entity<Tenat>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("tenat_pkey");

                entity.ToTable("tenat");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.AccessionNoOnek)
                    .HasColumnName("accession_no_onek")
                    .HasMaxLength(10);

                entity.Property(e => e.CallingAetitle)
                    .HasColumnName("calling_aetitle")
                    .HasMaxLength(16);

                entity.Property(e => e.DaySequence)
                    .HasColumnName("day_sequence")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RecordType)
                    .HasColumnName("record_type")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ServerAetitle)
                    .HasColumnName("server_aetitle")
                    .HasMaxLength(64);

                entity.Property(e => e.ServerHost)
                    .HasColumnName("server_host")
                    .HasMaxLength(64);

                entity.Property(e => e.ServerName)
                    .HasColumnName("server_name")
                    .HasMaxLength(32);

                entity.Property(e => e.ServerPort)
                    .HasColumnName("server_port")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TenatAd)
                    .HasColumnName("tenat_ad")
                    .HasMaxLength(64);

                entity.Property(e => e.TenatKisaAd)
                    .HasColumnName("tenat_kisa_ad")
                    .HasMaxLength(32);

                entity.Property(e => e.TenatRecordType).HasColumnName("tenat_record_type");

                entity.Property(e => e.TenatWado)
                    .HasColumnName("tenat_wado")
                    .HasMaxLength(128);

                entity.Property(e => e.TenatWadoRs)
                    .HasColumnName("tenat_wado_rs")
                    .HasMaxLength(128);

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeDelete).HasColumnName("time_delete");

                entity.Property(e => e.UserFk).HasColumnName("user_fk");

                entity.Property(e => e.UserFkLastModfiead).HasColumnName("user_fk_last_modfiead");
            });

            modelBuilder.Entity<TenatSkrs>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("tenat_skrs_pkey");

                entity.ToTable("tenat_skrs");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.SkrsFk).HasColumnName("skrs_fk");

                entity.Property(e => e.TenatFk).HasColumnName("tenat_fk");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeDelete).HasColumnName("time_delete");

                entity.Property(e => e.UserFk).HasColumnName("user_fk");

                entity.Property(e => e.UserFkLastModfiead).HasColumnName("user_fk_last_modfiead");

                entity.HasOne(d => d.SkrsFkNavigation)
                    .WithMany(p => p.TenatSkrs)
                    .HasForeignKey(d => d.SkrsFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("skrs_fk");

                entity.HasOne(d => d.TenatFkNavigation)
                    .WithMany(p => p.TenatSkrs)
                    .HasForeignKey(d => d.TenatFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tenat_fk");
            });

            modelBuilder.Entity<UsrRole>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("usr_role_pkey");

                entity.ToTable("usr_role");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.UsrRoleAd)
                    .HasColumnName("usr_role_ad")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<UsrUserLogin>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("usr_user_login_pk");

                entity.ToTable("usr_user_login");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.EmailAdress)
                    .HasColumnName("email_adress")
                    .HasMaxLength(64);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(64);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(128);

                entity.Property(e => e.RecordType).HasColumnName("	record_type");

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasMaxLength(64);

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeDelete).HasColumnName("time_delete");

                entity.Property(e => e.UserFk)
                    .HasColumnName("user_fk")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserFkLastModfiead)
                    .HasColumnName("user_fk_last_modfiead")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserName)
                    .HasColumnName("user_name")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<UsrUserRole>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("usr_user_role_pkey");

                entity.ToTable("usr_user_role");

                entity.HasIndex(e => e.RoleFk)
                    .HasName("fki_fk_usr_role");

                entity.HasIndex(e => e.UserFk)
                    .HasName("fki_fk_usr_user_login");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.RoleFk)
                    .HasColumnName("role_fk")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Test)
                    .HasColumnName("test")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserFk)
                    .HasColumnName("user_fk")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.RoleFkNavigation)
                    .WithMany(p => p.UsrUserRole)
                    .HasForeignKey(d => d.RoleFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usr_role");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.UsrUserRole)
                    .HasForeignKey(d => d.UserFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usr_user_login");
            });

            modelBuilder.Entity<UsrUserTenat>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("usr_user_tenat_pkey");

                entity.ToTable("usr_user_tenat");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeDelete).HasColumnName("time_delete");

                entity.Property(e => e.UserFk).HasColumnName("user_fk");

                entity.Property(e => e.UserFkCreated).HasColumnName("user_fk_created");

                entity.Property(e => e.UserFkLastModfiead).HasColumnName("user_fk_last_modfiead");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
