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

        public virtual DbSet<AppLog> AppLog { get; set; }
        public virtual DbSet<AppParameter> AppParameter { get; set; }
        public virtual DbSet<InfBatch> InfBatch { get; set; }
        public virtual DbSet<InfPaht> InfPaht { get; set; }
        public virtual DbSet<InfStudy> InfStudy { get; set; }
        public virtual DbSet<InfStudyParameter> InfStudyParameter { get; set; }
        public virtual DbSet<KosResultEnmtype> KosResultEnmtype { get; set; }
        public virtual DbSet<KosStudy> KosStudy { get; set; }
        public virtual DbSet<KosStudyHistory> KosStudyHistory { get; set; }
        public virtual DbSet<Modality> Modality { get; set; }
        public virtual DbSet<Skrs> Skrs { get; set; }
        public virtual DbSet<Tenant> Tenant { get; set; }
        public virtual DbSet<TenantSkrs> TenantSkrs { get; set; }
        public virtual DbSet<UsrRole> UsrRole { get; set; }
        public virtual DbSet<UsrUserLogin> UsrUserLogin { get; set; }
        public virtual DbSet<UsrUserRole> UsrUserRole { get; set; }
        public virtual DbSet<UsrUserTenat> UsrUserTenat { get; set; }
        public virtual DbSet<XinfImage> XinfImage { get; set; }
        public virtual DbSet<XinfInstance> XinfInstance { get; set; }
        public virtual DbSet<XinfInstanceloc> XinfInstanceloc { get; set; }
        public virtual DbSet<XinfSeries> XinfSeries { get; set; }
        public virtual DbSet<XinfStudy> XinfStudy { get; set; }
        public virtual DbSet<XinfValume> XinfValume { get; set; }
        public virtual DbSet<XxxAbpTenants> XxxAbpTenants { get; set; }
        public virtual DbSet<XxxDicomData> XxxDicomData { get; set; }
        public virtual DbSet<XxxQueryRetrieveSettings> XxxQueryRetrieveSettings { get; set; }
        public virtual DbSet<XxxSkrsKurumKodlari> XxxSkrsKurumKodlari { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=85.95.238.211;Database=guney_teletip_db;Username=test_protek;Password=test123;Port=9002");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppLog>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("app_log_pkey");

                entity.ToTable("app_log");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.Desc1)
                    .HasColumnName("desc1")
                    .HasMaxLength(2048);

                entity.Property(e => e.Desc2)
                    .HasColumnName("desc2")
                    .HasMaxLength(2048);

                entity.Property(e => e.Desc3)
                    .HasColumnName("desc3")
                    .HasMaxLength(2048);

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.LogType).HasColumnName("log_type");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");
            });

            modelBuilder.Entity<AppParameter>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("app_permatt_pkey");

                entity.ToTable("app_parameter");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .HasDefaultValueSql("nextval('app_permatt_pk_seq'::regclass)");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnName("key")
                    .HasMaxLength(128);

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeDelete).HasColumnName("time_delete");

                entity.Property(e => e.UserFkCreated).HasColumnName("user_fk_created");

                entity.Property(e => e.UserFkLastModfiead).HasColumnName("user_fk_last_modfiead");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(1024);
            });

            modelBuilder.Entity<InfBatch>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("inf_batch_pkey");

                entity.ToTable("inf_batch");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.Tarih).HasColumnName("tarih");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");
            });

            modelBuilder.Entity<InfPaht>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("inf_paht_pkey");

                entity.ToTable("inf_paht");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.FilePath).HasColumnName("file_path");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.Hostname)
                    .IsRequired()
                    .HasColumnName("hostname");

                entity.Property(e => e.KurumKodu).HasColumnName("kurum_kodu");

                entity.Property(e => e.Modality).HasColumnName("modality");

                entity.Property(e => e.PahtCode)
                    .IsRequired()
                    .HasColumnName("paht_code");

                entity.Property(e => e.PahtStat).HasColumnName("paht_stat");

                entity.Property(e => e.PahtType).HasColumnName("paht_type");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.Pathname)
                    .IsRequired()
                    .HasColumnName("pathname");

                entity.Property(e => e.RecordType).HasColumnName("record_type");

                entity.Property(e => e.Sharename)
                    .IsRequired()
                    .HasColumnName("sharename");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username");
            });

            modelBuilder.Entity<InfStudy>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("inf_study_pkey");

                entity.ToTable("inf_study");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.AccessionNo)
                    .HasColumnName("accession_no")
                    .HasMaxLength(32);

                entity.Property(e => e.CihazDeviceSerialNumber)
                    .HasColumnName("cihaz_device_serial_number")
                    .HasMaxLength(64);

                entity.Property(e => e.CreationDttm).HasColumnName("creation_dttm");

                entity.Property(e => e.DateBirth).HasColumnName("date_birth");

                entity.Property(e => e.Desc1)
                    .HasColumnName("desc1")
                    .HasMaxLength(64);

                entity.Property(e => e.Desc2)
                    .HasColumnName("desc2")
                    .HasMaxLength(64);

                entity.Property(e => e.Desc3)
                    .HasColumnName("desc3")
                    .HasMaxLength(64);

                entity.Property(e => e.FileName)
                    .HasColumnName("file_name")
                    .HasMaxLength(256);

                entity.Property(e => e.FkUserCreated)
                    .HasColumnName("fk_user_created")
                    .HasDefaultValueSql("nextval('inf_study_user_fk_seq'::regclass)");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(8);

                entity.Property(e => e.InfFkBatch)
                    .HasColumnName("inf_fk_batch")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.InfFkStudy)
                    .HasColumnName("inf_fk_study")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.InstanceCount).HasColumnName("instance_count");

                entity.Property(e => e.InstanceKey).HasColumnName("instance_key");

                entity.Property(e => e.Institution)
                    .HasColumnName("institution")
                    .HasMaxLength(64);

                entity.Property(e => e.InstitutionName)
                    .HasColumnName("institution_name")
                    .HasMaxLength(256);

                entity.Property(e => e.Modality)
                    .HasColumnName("modality")
                    .HasMaxLength(6);

                entity.Property(e => e.PatientId)
                    .HasColumnName("patient_id")
                    .HasMaxLength(11);

                entity.Property(e => e.PatinetNameSurname)
                    .HasColumnName("patinet_name_surname")
                    .HasMaxLength(80);

                entity.Property(e => e.SeriesCount).HasColumnName("series_count");

                entity.Property(e => e.SeriesKey).HasColumnName("series_key");

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

                entity.Property(e => e.StudyKey).HasColumnName("study_key");

                entity.Property(e => e.TenantFk)
                    .HasColumnName("tenant_fk")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");

                entity.Property(e => e.UserFkModfiead)
                    .HasColumnName("user_fk_modfiead")
                    .HasDefaultValueSql("nextval('inf_study_user_fk_last_modfiead_seq'::regclass)");

                entity.Property(e => e.ValumeCode)
                    .HasColumnName("valume_code")
                    .HasMaxLength(4);

                entity.Property(e => e.ValumePathname)
                    .HasColumnName("valume_pathname")
                    .HasMaxLength(64);

                entity.Property(e => e.ValumeStat)
                    .HasColumnName("valume_stat")
                    .HasMaxLength(2);

                entity.Property(e => e.ValumeType)
                    .HasColumnName("valume_type")
                    .HasMaxLength(2);

                entity.HasOne(d => d.InfFkBatchNavigation)
                    .WithMany(p => p.InfStudy)
                    .HasForeignKey(d => d.InfFkBatch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("	inf_fk_study_fk_inf_batch");
            });

            modelBuilder.Entity<InfStudyParameter>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("inf_study_parameters_pkey");

                entity.ToTable("inf_study_parameter");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .HasDefaultValueSql("nextval('inf_study_parameters_pk_seq'::regclass)");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.InfCreationStartDate)
                    .HasColumnName("inf_creation_start_date")
                    .HasColumnType("date");

                entity.Property(e => e.InfCreationStopDate)
                    .HasColumnName("inf_creation_stop_date")
                    .HasColumnType("date");

                entity.Property(e => e.InfStudyPkLast).HasColumnName("inf_study_pk_last");

                entity.Property(e => e.IntervalMinut).HasColumnName("interval_minut");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(32);

                entity.Property(e => e.RecordType).HasColumnName("record_type");

                entity.Property(e => e.TenatFk).HasColumnName("tenat_fk");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");
            });

            modelBuilder.Entity<KosResultEnmtype>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("kosresultenmtype_pkey");

                entity.ToTable("kos_result_enmtype");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .HasDefaultValueSql("nextval('kosresultenmtype_pk_seq'::regclass)");

                entity.Property(e => e.EnmAd)
                    .HasColumnName("enm_ad")
                    .HasMaxLength(64);

                entity.Property(e => e.EnmId).HasColumnName("enm_id");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");
            });

            modelBuilder.Entity<KosStudy>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("kos_study_pkey");

                entity.ToTable("kos_study");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.FkInfStudy).HasColumnName("fk_inf_study");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.KosEnumType).HasColumnName("kos_enum_type");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");
            });

            modelBuilder.Entity<KosStudyHistory>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("kos_study_history_pkey");

                entity.ToTable("kos_study_history");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.EnumType).HasColumnName("enum_type");

                entity.Property(e => e.FkKosStudy).HasColumnName("fk_kos_study");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified)
                    .HasColumnName("fk_user_modified")
                    .HasColumnType("oid");

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasMaxLength(2048);

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");
            });

            modelBuilder.Entity<Modality>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("modality_pkey");

                entity.ToTable("modality");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.Modality1)
                    .HasColumnName("modality")
                    .HasMaxLength(8);

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");
            });

            modelBuilder.Entity<Skrs>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("skrs_pkey");

                entity.ToTable("skrs");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.InstitutionName)
                    .HasColumnName("institution_name")
                    .HasMaxLength(128);

                entity.Property(e => e.KurumAd)
                    .HasColumnName("kurum_ad")
                    .HasMaxLength(64);

                entity.Property(e => e.KurumMedulaTesisKodu)
                    .HasColumnName("kurum_medula_tesis_kodu")
                    .HasMaxLength(32);

                entity.Property(e => e.KurumSkrsAdi)
                    .HasColumnName("kurum_skrs_adi")
                    .HasMaxLength(64);

                entity.Property(e => e.KurumSkrsKodu)
                    .HasColumnName("kurum_skrs_kodu")
                    .HasMaxLength(32);

                entity.Property(e => e.QrSettingId).HasColumnName("qr_setting_id");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("tenat_pkey");

                entity.ToTable("tenant");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .HasDefaultValueSql("nextval('tenat_pk_seq'::regclass)");

                entity.Property(e => e.DaySequence)
                    .HasColumnName("day_sequence")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.TenantAd)
                    .HasColumnName("tenant_ad")
                    .HasMaxLength(128);

                entity.Property(e => e.TenantKisaAd)
                    .HasColumnName("tenant_kisa_ad")
                    .HasMaxLength(64);

                entity.Property(e => e.TenantRecordType).HasColumnName("tenant_record_type");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");
            });

            modelBuilder.Entity<TenantSkrs>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("tenat_skrs_pkey");

                entity.ToTable("tenant_skrs");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .HasDefaultValueSql("nextval('tenat_skrs_pk_seq'::regclass)");

                entity.Property(e => e.AccessionNoOnek)
                    .HasColumnName("accession_no_onek")
                    .HasMaxLength(10);

                entity.Property(e => e.CallingAe)
                    .HasColumnName("calling_ae")
                    .HasMaxLength(64);

                entity.Property(e => e.FkSkrs).HasColumnName("fk_skrs");

                entity.Property(e => e.FkTenat).HasColumnName("fk_tenat");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.RecordState).HasColumnName("record_state");

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

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");

                entity.HasOne(d => d.FkSkrsNavigation)
                    .WithMany(p => p.TenantSkrs)
                    .HasForeignKey(d => d.FkSkrs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_skrs");

                entity.HasOne(d => d.FkTenatNavigation)
                    .WithMany(p => p.TenantSkrs)
                    .HasForeignKey(d => d.FkTenat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tenat");
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
                    .HasName("usr_user_login_pkey");

                entity.ToTable("usr_user_login");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.EmailAdress)
                    .HasColumnName("email_adress")
                    .HasMaxLength(64);

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(64);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(128);

                entity.Property(e => e.RecordState).HasColumnName("record_state");

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasMaxLength(64);

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<UsrUserRole>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("usr_user_role_pkey");

                entity.ToTable("usr_user_role");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.FkRole).HasColumnName("fk_role");

                entity.Property(e => e.FkUser).HasColumnName("fk_user");

                entity.HasOne(d => d.FkRoleNavigation)
                    .WithMany(p => p.UsrUserRole)
                    .HasForeignKey(d => d.FkRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usr_role");

                entity.HasOne(d => d.FkUserNavigation)
                    .WithMany(p => p.UsrUserRole)
                    .HasForeignKey(d => d.FkUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usr_user_login");
            });

            modelBuilder.Entity<UsrUserTenat>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("usr_user_tenat_pkey");

                entity.ToTable("usr_user_tenat");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.FkUser).HasColumnName("fk_user");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModifiel).HasColumnName("time_modifiel");
            });

            modelBuilder.Entity<XinfImage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("xinf_image");

                entity.Property(e => e.AcqDttm).HasColumnName("acq_dttm");

                entity.Property(e => e.AcqNo).HasColumnName("acq_no");

                entity.Property(e => e.BitsAllocated).HasColumnName("bits_allocated");

                entity.Property(e => e.BitsStored).HasColumnName("bits_stored");

                entity.Property(e => e.CassetteSize).HasColumnName("cassette_size");

                entity.Property(e => e.Curvature).HasColumnName("curvature");

                entity.Property(e => e.FrameHeight).HasColumnName("frame_height");

                entity.Property(e => e.FrameWidth).HasColumnName("frame_width");

                entity.Property(e => e.HeaderPostProcessing).HasColumnName("header_post_processing");

                entity.Property(e => e.ImageDttm).HasColumnName("image_dttm");

                entity.Property(e => e.ImageInfo).HasColumnName("image_info");

                entity.Property(e => e.ImageInfoEx).HasColumnName("image_info_ex");

                entity.Property(e => e.ImageNo).HasColumnName("image_no");

                entity.Property(e => e.ImageType).HasColumnName("image_type");

                entity.Property(e => e.InstanceKey).HasColumnName("instance_key");

                entity.Property(e => e.PhotometricInterpretation).HasColumnName("photometric_interpretation");

                entity.Property(e => e.PixelAspectRatio).HasColumnName("pixel_aspect_ratio");

                entity.Property(e => e.PixelRepresentation).HasColumnName("pixel_representation");

                entity.Property(e => e.PixelsizeX).HasColumnName("pixelsize_x");

                entity.Property(e => e.PixelsizeY).HasColumnName("pixelsize_y");

                entity.Property(e => e.PlanarConfiguration).HasColumnName("planar_configuration");

                entity.Property(e => e.PlateId).HasColumnName("plate_id");

                entity.Property(e => e.RegionCalibration).HasColumnName("region_calibration");

                entity.Property(e => e.Rotation).HasColumnName("rotation");

                entity.Property(e => e.SamplesPerPixel).HasColumnName("samples_per_pixel");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.VideoInfo).HasColumnName("video_info");

                entity.Property(e => e.WindowCenter).HasColumnName("window_center");

                entity.Property(e => e.WindowType).HasColumnName("window_type");

                entity.Property(e => e.WindowWidth).HasColumnName("window_width");
            });

            modelBuilder.Entity<XinfInstance>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("xinf_instance");

                entity.Property(e => e.ConcateKey).HasColumnName("concate_key");

                entity.Property(e => e.ContentDttm).HasColumnName("content_dttm");

                entity.Property(e => e.InstanceKey).HasColumnName("instance_key");

                entity.Property(e => e.InstanceNo).HasColumnName("instance_no");

                entity.Property(e => e.InstanceStat).HasColumnName("instance_stat");

                entity.Property(e => e.InstanceframeCount).HasColumnName("instanceframe_count");

                entity.Property(e => e.Ordinal).HasColumnName("ordinal");

                entity.Property(e => e.SeriesKey).HasColumnName("series_key");

                entity.Property(e => e.SopClassKey).HasColumnName("sop_class_key");

                entity.Property(e => e.SopInstanceUid)
                    .IsRequired()
                    .HasColumnName("sop_instance_uid");

                entity.Property(e => e.StudyKey).HasColumnName("study_key");

                entity.Property(e => e.TransferSyntaxKey).HasColumnName("transfer_syntax_key");

                entity.Property(e => e.TransferSyntaxKeyB0).HasColumnName("transfer_syntax_key_b0");

                entity.Property(e => e.TransferSyntaxKeyB1).HasColumnName("transfer_syntax_key_b1");

                entity.Property(e => e.TransferSyntaxKeyB2).HasColumnName("transfer_syntax_key_b2");

                entity.Property(e => e.TransferSyntaxKeyB3).HasColumnName("transfer_syntax_key_b3");
            });

            modelBuilder.Entity<XinfInstanceloc>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("xinf_instanceloc");

                entity.Property(e => e.B0Filepath).HasColumnName("b0_filepath");

                entity.Property(e => e.B0VolCode).HasColumnName("b0_vol_code");

                entity.Property(e => e.B0VolStat).HasColumnName("b0_vol_stat");

                entity.Property(e => e.B1BakStat)
                    .IsRequired()
                    .HasColumnName("b1_bak_stat");

                entity.Property(e => e.B1Filepath).HasColumnName("b1_filepath");

                entity.Property(e => e.B1VolCode).HasColumnName("b1_vol_code");

                entity.Property(e => e.B1VolStat).HasColumnName("b1_vol_stat");

                entity.Property(e => e.B2BakStat)
                    .IsRequired()
                    .HasColumnName("b2_bak_stat");

                entity.Property(e => e.B2Filepath).HasColumnName("b2_filepath");

                entity.Property(e => e.B2VolCode).HasColumnName("b2_vol_code");

                entity.Property(e => e.B2VolStat).HasColumnName("b2_vol_stat");

                entity.Property(e => e.B3BakStat)
                    .IsRequired()
                    .HasColumnName("b3_bak_stat");

                entity.Property(e => e.B3Filepath).HasColumnName("b3_filepath");

                entity.Property(e => e.B3VolCode).HasColumnName("b3_vol_code");

                entity.Property(e => e.B3VolStat).HasColumnName("b3_vol_stat");

                entity.Property(e => e.CompressSize).HasColumnName("compress_size");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasColumnName("filename");

                entity.Property(e => e.InstanceKey).HasColumnName("instance_key");

                entity.Property(e => e.InstanceSize).HasColumnName("instance_size");

                entity.Property(e => e.InstanceType).HasColumnName("instance_type");

                entity.Property(e => e.Pathext).HasColumnName("pathext");

                entity.Property(e => e.Pathname)
                    .IsRequired()
                    .HasColumnName("pathname");

                entity.Property(e => e.VolumeCode).HasColumnName("volume_code");
            });

            modelBuilder.Entity<XinfSeries>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("xinf_series");

                entity.Property(e => e.Bodypart).HasColumnName("bodypart");

                entity.Property(e => e.FilterInfo)
                    .HasColumnName("filter_info")
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.InstanceCount).HasColumnName("instance_count");

                entity.Property(e => e.Modality)
                    .IsRequired()
                    .HasColumnName("modality");

                entity.Property(e => e.Operator).HasColumnName("operator");

                entity.Property(e => e.Ordinal).HasColumnName("ordinal");

                entity.Property(e => e.PerformDoctor).HasColumnName("perform_doctor");

                entity.Property(e => e.PerformedProcStartDttm).HasColumnName("performed_proc_start_dttm");

                entity.Property(e => e.PpsDesc).HasColumnName("pps_desc");

                entity.Property(e => e.PpsId).HasColumnName("pps_id");

                entity.Property(e => e.PpsStartDttm).HasColumnName("pps_start_dttm");

                entity.Property(e => e.RequestAttrs).HasColumnName("request_attrs");

                entity.Property(e => e.SeriesDesc).HasColumnName("series_desc");

                entity.Property(e => e.SeriesDttm).HasColumnName("series_dttm");

                entity.Property(e => e.SeriesInfo).HasColumnName("series_info");

                entity.Property(e => e.SeriesInstanceUid)
                    .IsRequired()
                    .HasColumnName("series_instance_uid");

                entity.Property(e => e.SeriesKey).HasColumnName("series_key");

                entity.Property(e => e.SeriesNo).HasColumnName("series_no");

                entity.Property(e => e.SeriesSize).HasColumnName("series_size");

                entity.Property(e => e.SeriesStat).HasColumnName("series_stat");

                entity.Property(e => e.StudyKey).HasColumnName("study_key");

                entity.Property(e => e.Temporary).HasColumnName("temporary");
            });

            modelBuilder.Entity<XinfStudy>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("xinf_study");

                entity.Property(e => e.AccessDttm).HasColumnName("access_dttm");

                entity.Property(e => e.AccessNo).HasColumnName("access_no");

                entity.Property(e => e.AddendumStat).HasColumnName("addendum_stat");

                entity.Property(e => e.AdmitDttm).HasColumnName("admit_dttm");

                entity.Property(e => e.AssignedDttm).HasColumnName("assigned_dttm");

                entity.Property(e => e.AttendDoctor).HasColumnName("attend_doctor");

                entity.Property(e => e.BillingStat).HasColumnName("billing_stat");

                entity.Property(e => e.Bodyparts).HasColumnName("bodyparts");

                entity.Property(e => e.CompletedDttm).HasColumnName("completed_dttm");

                entity.Property(e => e.ConfirmStat).HasColumnName("confirm_stat");

                entity.Property(e => e.ConsultDoctor).HasColumnName("consult_doctor");

                entity.Property(e => e.CreationDttm).HasColumnName("creation_dttm");

                entity.Property(e => e.Department).HasColumnName("department");

                entity.Property(e => e.Diagnosis).HasColumnName("diagnosis");

                entity.Property(e => e.DreadDttm).HasColumnName("dread_dttm");

                entity.Property(e => e.DreaderKey).HasColumnName("dreader_key");

                entity.Property(e => e.EdStat).HasColumnName("ed_stat");

                entity.Property(e => e.EnglishPatientName).HasColumnName("english_patient_name");

                entity.Property(e => e.HideCode).HasColumnName("hide_code");

                entity.Property(e => e.InstanceCount).HasColumnName("instance_count");

                entity.Property(e => e.Institution).HasColumnName("institution");

                entity.Property(e => e.JobUid).HasColumnName("job_uid");

                entity.Property(e => e.LastPrintDttm).HasColumnName("last_print_dttm");

                entity.Property(e => e.LastPrintUserKey).HasColumnName("last_print_user_key");

                entity.Property(e => e.LtaCount).HasColumnName("lta_count");

                entity.Property(e => e.MergeKey).HasColumnName("merge_key");

                entity.Property(e => e.Modalities).HasColumnName("modalities");

                entity.Property(e => e.ModifyDttm).HasColumnName("modify_dttm");

                entity.Property(e => e.MspsCount).HasColumnName("msps_count");

                entity.Property(e => e.Operators).HasColumnName("operators");

                entity.Property(e => e.OrderDttm).HasColumnName("order_dttm");

                entity.Property(e => e.OrderKey).HasColumnName("order_key");

                entity.Property(e => e.OtherPatientId).HasColumnName("other_patient_id");

                entity.Property(e => e.OtherPatientIdIssuer).HasColumnName("other_patient_id_issuer");

                entity.Property(e => e.OtherPatientName).HasColumnName("other_patient_name");

                entity.Property(e => e.Passcode).HasColumnName("passcode");

                entity.Property(e => e.PatientAccountNo).HasColumnName("patient_account_no");

                entity.Property(e => e.PatientAge).HasColumnName("patient_age");

                entity.Property(e => e.PatientAgeInDays).HasColumnName("patient_age_in_days");

                entity.Property(e => e.PatientArrange).HasColumnName("patient_arrange");

                entity.Property(e => e.PatientBirthDttm).HasColumnName("patient_birth_dttm");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.PatientIdIssuer).HasColumnName("patient_id_issuer");

                entity.Property(e => e.PatientLocation).HasColumnName("patient_location");

                entity.Property(e => e.PatientName).HasColumnName("patient_name");

                entity.Property(e => e.PatientResidency).HasColumnName("patient_residency");

                entity.Property(e => e.PatientSex).HasColumnName("patient_sex");

                entity.Property(e => e.PatientSize).HasColumnName("patient_size");

                entity.Property(e => e.PatientWeight).HasColumnName("patient_weight");

                entity.Property(e => e.PerformDoctor).HasColumnName("perform_doctor");

                entity.Property(e => e.PrintStat).HasColumnName("print_stat");

                entity.Property(e => e.ProcplanKey).HasColumnName("procplan_key");

                entity.Property(e => e.Protected).HasColumnName("protected");

                entity.Property(e => e.ReadDoctor).HasColumnName("read_doctor");

                entity.Property(e => e.ReferDoctor).HasColumnName("refer_doctor");

                entity.Property(e => e.RegisterDttm).HasColumnName("register_dttm");

                entity.Property(e => e.RequestCode).HasColumnName("request_code");

                entity.Property(e => e.RequestDepartment).HasColumnName("request_department");

                entity.Property(e => e.RequestDoctor).HasColumnName("request_doctor");

                entity.Property(e => e.RequestDttm).HasColumnName("request_dttm");

                entity.Property(e => e.RequestName).HasColumnName("request_name");

                entity.Property(e => e.RequestStat).HasColumnName("request_stat");

                entity.Property(e => e.Requestexam).HasColumnName("requestexam");

                entity.Property(e => e.ScheduledDttm).HasColumnName("scheduled_dttm");

                entity.Property(e => e.SeriesCount).HasColumnName("series_count");

                entity.Property(e => e.SourceAetitle).HasColumnName("source_aetitle");

                entity.Property(e => e.SpecialNeeds).HasColumnName("special_needs");

                entity.Property(e => e.Specialty).HasColumnName("specialty");

                entity.Property(e => e.StayinStat).HasColumnName("stayin_stat");

                entity.Property(e => e.StsStat).HasColumnName("sts_stat");

                entity.Property(e => e.StudyComments).HasColumnName("study_comments");

                entity.Property(e => e.StudyDesc).HasColumnName("study_desc");

                entity.Property(e => e.StudyDttm).HasColumnName("study_dttm");

                entity.Property(e => e.StudyId).HasColumnName("study_id");

                entity.Property(e => e.StudyInstanceUid)
                    .IsRequired()
                    .HasColumnName("study_instance_uid");

                entity.Property(e => e.StudyKey).HasColumnName("study_key");

                entity.Property(e => e.StudyPriority).HasColumnName("study_priority");

                entity.Property(e => e.StudyReason).HasColumnName("study_reason");

                entity.Property(e => e.StudySize).HasColumnName("study_size");

                entity.Property(e => e.StudySsn).HasColumnName("study_ssn");

                entity.Property(e => e.StudyStat).HasColumnName("study_stat");

                entity.Property(e => e.TreadDttm).HasColumnName("tread_dttm");

                entity.Property(e => e.TreaderKey).HasColumnName("treader_key");

                entity.Property(e => e.ValidateDttm).HasColumnName("validate_dttm");

                entity.Property(e => e.VerifierKey).HasColumnName("verifier_key");

                entity.Property(e => e.VerifyDttm).HasColumnName("verify_dttm");

                entity.Property(e => e.WetReading).HasColumnName("wet_reading");
            });

            modelBuilder.Entity<XinfValume>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("xinf_valume");

                entity.Property(e => e.Aetitle).HasColumnName("aetitle");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Hostname)
                    .IsRequired()
                    .HasColumnName("hostname");

                entity.Property(e => e.Iishost).HasColumnName("iishost");

                entity.Property(e => e.InstitutionCode).HasColumnName("institution_code");

                entity.Property(e => e.Modality).HasColumnName("modality");

                entity.Property(e => e.Ordinal).HasColumnName("ordinal");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.Pathname)
                    .IsRequired()
                    .HasColumnName("pathname");

                entity.Property(e => e.Protocol).HasColumnName("protocol");

                entity.Property(e => e.Rhostname).HasColumnName("rhostname");

                entity.Property(e => e.Rpassword).HasColumnName("rpassword");

                entity.Property(e => e.Rusername).HasColumnName("rusername");

                entity.Property(e => e.Sharename)
                    .IsRequired()
                    .HasColumnName("sharename");

                entity.Property(e => e.Threshold).HasColumnName("threshold");

                entity.Property(e => e.UsedSpace).HasColumnName("used_space");

                entity.Property(e => e.UsedSpaceUpdateDttm).HasColumnName("used_space_update_dttm");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username");

                entity.Property(e => e.VolumeCode)
                    .IsRequired()
                    .HasColumnName("volume_code");

                entity.Property(e => e.VolumeStat).HasColumnName("volume_stat");

                entity.Property(e => e.VolumeType).HasColumnName("volume_type");
            });

            modelBuilder.Entity<XxxAbpTenants>(entity =>
            {
                entity.ToTable("xxxAbpTenants");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ConnectionString).HasMaxLength(1024);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.TenancyName)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<XxxDicomData>(entity =>
            {
                entity.ToTable("xxxDicom_Data");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccNoDegisimSayi).HasColumnName("Acc_No_Degisim_Sayi");

                entity.Property(e => e.AccessionNo)
                    .HasColumnName("Accession_No")
                    .HasMaxLength(16);

                entity.Property(e => e.DeviceSerialNumber)
                    .HasColumnName("Device_Serial_Number")
                    .HasMaxLength(64);

                entity.Property(e => e.Gender).HasMaxLength(6);

                entity.Property(e => e.InstanceAvailability)
                    .HasColumnName("Instance_Availability")
                    .HasMaxLength(10);

                entity.Property(e => e.InstanceNumber).HasColumnName("Instance_Number");

                entity.Property(e => e.InstitutionName)
                    .HasColumnName("Institution_Name")
                    .HasMaxLength(200);

                entity.Property(e => e.KosState).HasColumnName("Kos_State");

                entity.Property(e => e.Modality).HasMaxLength(4);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.NumberOfStudyRelatedInstances).HasColumnName("Number_Of_Study_Related_Instances");

                entity.Property(e => e.NumberOfStudyRelatedSeries).HasColumnName("Number_of_Study_Related_Series");

                entity.Property(e => e.PatientBirthDate).HasColumnName("Patient_Birth_Date");

                entity.Property(e => e.PatientId)
                    .HasColumnName("Patient_Id")
                    .HasMaxLength(11);

                entity.Property(e => e.PatientName)
                    .HasColumnName("Patient_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.RandevuId).HasColumnName("Randevu_Id");

                entity.Property(e => e.SendHl7ForAccession)
                    .HasColumnName("Send_HL7_For_Accession")
                    .HasMaxLength(1);

                entity.Property(e => e.StoragePath)
                    .HasColumnName("Storage_Path")
                    .HasMaxLength(300);

                entity.Property(e => e.StudyDate)
                    .HasColumnName("Study_Date")
                    .HasDefaultValueSql("'0001-01-01 00:00:00'::timestamp without time zone");

                entity.Property(e => e.StudyDescription)
                    .HasColumnName("Study_Description")
                    .HasMaxLength(200);

                entity.Property(e => e.StudyId)
                    .HasColumnName("Study_Id")
                    .HasMaxLength(20);

                entity.Property(e => e.StudyInstanceUid)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Surname).HasMaxLength(30);

                entity.Property(e => e.TarihtenSonraSil).HasColumnName("Tarihten_Sonra_Sil");

                entity.Property(e => e.TetkikIstekId).HasColumnName("Tetkik_Istek_Id");

                entity.Property(e => e.Title).HasMaxLength(10);
            });

            modelBuilder.Entity<XxxQueryRetrieveSettings>(entity =>
            {
                entity.ToTable("xxxQuery_Retrieve_Settings");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccessionNoOnek)
                    .HasColumnName("Accession_No_Onek")
                    .HasMaxLength(10);

                entity.Property(e => e.Aktif).HasMaxLength(1);

                entity.Property(e => e.CallingAetitle).HasColumnName("Calling_AETitle");

                entity.Property(e => e.DaySequence).HasColumnName("Day_Sequence");

                entity.Property(e => e.EndDate).HasColumnName("End_Date");

                entity.Property(e => e.ServerAetitle)
                    .HasColumnName("Server_AETitle")
                    .HasMaxLength(64);

                entity.Property(e => e.ServerHost)
                    .HasColumnName("Server_Host")
                    .HasMaxLength(64);

                entity.Property(e => e.ServerName)
                    .HasColumnName("Server_Name")
                    .HasMaxLength(30);

                entity.Property(e => e.ServerPort).HasColumnName("Server_Port");

                entity.Property(e => e.StartDate).HasColumnName("Start_Date");

                entity.Property(e => e.TenantId).HasColumnName("Tenant_Id");
            });

            modelBuilder.Entity<XxxSkrsKurumKodlari>(entity =>
            {
                entity.ToTable("xxxSKRS_Kurum_Kodlari");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.InstitutionName)
                    .HasColumnName("Institution_Name")
                    .HasMaxLength(64);

                entity.Property(e => e.KurumIsmi)
                    .HasColumnName("Kurum_Ismi")
                    .HasMaxLength(64);

                entity.Property(e => e.MedulaTesisKodu).HasColumnName("Medula_Tesis_Kodu");

                entity.Property(e => e.QrSettingId).HasColumnName("QR_Setting_Id");

                entity.Property(e => e.SkrsKodu)
                    .HasColumnName("SKRS_Kodu")
                    .HasMaxLength(12);

                entity.Property(e => e.TenantId).HasColumnName("Tenant_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
