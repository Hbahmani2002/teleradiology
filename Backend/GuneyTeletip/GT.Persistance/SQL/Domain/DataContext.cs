namespace GT.PERSISTANCE.DOMAIN.Models
{
    using Gt.PERSISTANCE;
    using GT.Core.Settings;
    using GT.Core.Settings.Global;
    using GT.Persistance.Domain.Models;
    using GT.PERSISTANCE.Data.SQL;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Console;
    using Microsoft.Extensions.Logging.Debug;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GTDataContext : CommonDbContext
    {
        //https://docs.microsoft.com/en-us/ef/core/miscellaneous/logging?tabs=v3
        public static readonly ILoggerFactory consoleLoggerFactory
            = LoggerFactory.Create(builder =>
            {
                builder.AddDebug();
            });
        public bool IsLogging { get; set; }
        public GTDataContext()
            : base("name=DataContext")
        {
        }
        public GTDataContext(bool autoDetectChangesEnabled, bool proxyCreationEnabled = true, bool lazyLoadingEnabled = true, bool validateOnSaveEnabled = true, bool logging = false)
           : base($"name={LocalSettings.AppName}")
        {
            IsLogging = logging;
            //Database.SetInitializer<DataContext>(null);
            //Configuration.ProxyCreationEnabled = proxyCreationEnabled;
            //Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;
            //Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
            //Configuration.ValidateOnSaveEnabled = validateOnSaveEnabled;

        }
        public virtual DbSet<AppFilePath> AppFilePath { get; set; }
        public virtual DbSet<AppLog> AppLog { get; set; }
        public virtual DbSet<AppParameter> AppParameter { get; set; }
        public virtual DbSet<AppPermissionName> AppPermissionName { get; set; }
        public virtual DbSet<AppRolePermission> AppRolePermission { get; set; }
        public virtual DbSet<ConstModality> ConstModality { get; set; }
        public virtual DbSet<ConstSkrs> ConstSkrs { get; set; }
        public virtual DbSet<JobEnumtype> JobEnumtype { get; set; }
        public virtual DbSet<KosBatch> KosBatch { get; set; }
        public virtual DbSet<KosEnumtype> KosEnumtype { get; set; }
        public virtual DbSet<KosInstance> KosInstance { get; set; }
        public virtual DbSet<KosOperationEnumType> KosOperationEnumType { get; set; }
        public virtual DbSet<KosPaht> KosPaht { get; set; }
        public virtual DbSet<KosStudy> KosStudy { get; set; }
        public virtual DbSet<KosStudyHistory> KosStudyHistory { get; set; }
        public virtual DbSet<KosStudyJob> KosStudyJob { get; set; }
        public virtual DbSet<KosStudyParameter> KosStudyParameter { get; set; }
        public virtual DbSet<KosStudyYedek> KosStudyYedek { get; set; }
        public virtual DbSet<Oracle> Oracle { get; set; }
        public virtual DbSet<StmGetorderStatusforAccessionnumberlist> StmGetorderStatusforAccessionnumberlist { get; set; }
        public virtual DbSet<StmTeletipStatus> StmTeletipStatus { get; set; }
        public virtual DbSet<StudyOperationCount> StudyOperationCount { get; set; }
        public virtual DbSet<UsrRole> UsrRole { get; set; }
        public virtual DbSet<UsrTenant> UsrTenant { get; set; }
        public virtual DbSet<UsrTenantSkrs> UsrTenantSkrs { get; set; }
        public virtual DbSet<UsrUserLogin> UsrUserLogin { get; set; }
        public virtual DbSet<UsrUserRole> UsrUserRole { get; set; }
        public virtual DbSet<UsrUserTenant> UsrUserTenant { get; set; }
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
                if (IsLogging)
                    optionsBuilder.UseLoggerFactory(consoleLoggerFactory);
                var connectionString = AppSettings.GetCurrent().DatabaseSetting.StudyPostgre;
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppFilePath>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("file_path_pkey");

                entity.ToTable("app_file_path");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Filename)
                    .HasColumnName("filename")
                    .HasColumnType("character varying");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeDeleted).HasColumnName("time_deleted");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");
            });

            modelBuilder.Entity<AppLog>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("app_log_pkey");

                entity.ToTable("app_log");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Desc1)
                    .HasColumnName("desc1")
                    .HasMaxLength(4000);

                entity.Property(e => e.Desc2)
                    .HasColumnName("desc2")
                    .HasMaxLength(4000);

                entity.Property(e => e.Desc3)
                    .HasColumnName("desc3")
                    .HasMaxLength(4000);

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.LogType).HasColumnName("log_type");

                entity.Property(e => e.TestPkFk).HasColumnName("test_pk_fk");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");
            });

            modelBuilder.Entity<AppParameter>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("app_permatt_pkey");

                entity.ToTable("app_parameter");

                entity.HasIndex(e => e.Key)
                    .HasName("key_uni")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .HasDefaultValueSql("nextval('app_permatt_pk_seq'::regclass)");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.Key)
                    .HasColumnName("key")
                    .HasMaxLength(128);

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(1024);
            });

            modelBuilder.Entity<AppPermissionName>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("app_user_permissions_pkey");

                entity.ToTable("app_permission_name");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .HasDefaultValueSql("nextval('app_user_permissions_pk_seq'::regclass)");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(128);

                entity.Property(e => e.RecordStatus).HasColumnName("record_status");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModifiel).HasColumnName("time_modifiel");
            });

            modelBuilder.Entity<AppRolePermission>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("app_user_permissions_authority_pkey");

                entity.ToTable("app_role_permission");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .HasDefaultValueSql("nextval('app_user_permissions_authority_pk_seq'::regclass)");

                entity.Property(e => e.FkPermissionId).HasColumnName("fk_permission_id");

                entity.Property(e => e.FkRoleId).HasColumnName("fk_role_id");
            });

            modelBuilder.Entity<ConstModality>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("modality_pkey");

                entity.ToTable("const_modality");

                entity.HasIndex(e => e.Name)
                    .HasName("name_uni")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .HasDefaultValueSql("nextval('modality_pk_seq'::regclass)");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(8);

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");
            });

            modelBuilder.Entity<ConstSkrs>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("skrs_pkey");

                entity.ToTable("const_skrs");

                entity.HasIndex(e => e.KurumSkrsKodu)
                    .HasName("kurum_skrs_kodu_uni")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .HasDefaultValueSql("nextval('skrs_pk_seq'::regclass)");

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

            modelBuilder.Entity<JobEnumtype>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("enum_type_pkey");

                entity.ToTable("job_enumtype");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");
            });

            modelBuilder.Entity<KosBatch>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("inf_batch_pkey");

                entity.ToTable("kos_batch");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .HasDefaultValueSql("nextval('inf_batch_pk_seq'::regclass)");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");
            });

            modelBuilder.Entity<KosEnumtype>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("kosresultenmtype_pkey");

                entity.ToTable("kos_enumtype");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .HasDefaultValueSql("nextval('kosresultenmtype_pk_seq'::regclass)");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(64);

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");
            });

            modelBuilder.Entity<KosInstance>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("kos_instance_pkey");

                entity.ToTable("kos_instance");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.AccessionNo)
                    .HasColumnName("accession_no")
                    .HasMaxLength(16);

                entity.Property(e => e.InstitutionFilename)
                    .HasColumnName("institution_filename")
                    .HasMaxLength(512);

                entity.Property(e => e.InstitutionPathname)
                    .HasColumnName("institution_pathname")
                    .HasMaxLength(512);

                entity.Property(e => e.Modality)
                    .HasColumnName("modality")
                    .HasMaxLength(6);

                entity.Property(e => e.OracleStudyKey).HasColumnName("oracle_study_key");

                entity.Property(e => e.PatientId)
                    .HasColumnName("patient_id")
                    .HasMaxLength(11);

                entity.Property(e => e.PatinetName)
                    .HasColumnName("patinet_name")
                    .HasMaxLength(80);

                entity.Property(e => e.SeriInfo)
                    .HasColumnName("seri_info")
                    .HasMaxLength(1024);

                entity.Property(e => e.SeriInstanceuid)
                    .HasColumnName("seri_instanceuid")
                    .HasMaxLength(128);

                entity.Property(e => e.SopInstanceuid)
                    .HasColumnName("sop_instanceuid")
                    .HasMaxLength(128);

                entity.Property(e => e.StudyInstanceuid)
                    .HasColumnName("study_instanceuid")
                    .HasMaxLength(128);

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeDelete).HasColumnName("time_delete");

                entity.Property(e => e.UserFk).HasColumnName("user_fk");

                entity.Property(e => e.UserFkLastModfiead).HasColumnName("user_fk_last_modfiead");

                entity.Property(e => e.VolumePath)
                    .HasColumnName("volume_path")
                    .HasMaxLength(512);
            });

            modelBuilder.Entity<KosOperationEnumType>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("kos_operation_enum_type_pkey");

                entity.ToTable("kos_operation_enum_type");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");
            });

            modelBuilder.Entity<KosPaht>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("kos_paht_pkey");

                entity.ToTable("kos_paht");

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

                entity.Property(e => e.ReplacePath).HasColumnName("replace_path");

                entity.Property(e => e.Sharename)
                    .IsRequired()
                    .HasColumnName("sharename");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username");
            });

            modelBuilder.Entity<KosStudy>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("kos_study_pkey");

                entity.ToTable("kos_study");

                entity.HasIndex(e => e.OracleStudyKey)
                    .HasName("ix_kos_study_oracle_study_key")
                    .IsUnique();

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

                entity.Property(e => e.DicomDirPath)
                    .HasColumnName("dicom_dir_path")
                    .HasMaxLength(2048);

                entity.Property(e => e.DicomKosPath)
                    .HasColumnName("dicom_kos_path")
                    .HasColumnType("character varying");

                entity.Property(e => e.FailtMakeKosCount).HasColumnName("failt_make_kos_count");

                entity.Property(e => e.FailtSentKosCount).HasColumnName("failt_sent_kos_count");

                entity.Property(e => e.FileName)
                    .HasColumnName("file_name")
                    .HasMaxLength(256);

                entity.Property(e => e.FkInfBatch).HasColumnName("fk_inf_batch");

                entity.Property(e => e.FkKosEnumType).HasColumnName("fk_kos_enum_type");

                entity.Property(e => e.FkTenant).HasColumnName("fk_tenant");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(8);

                entity.Property(e => e.InfMergeKey).HasColumnName("inf_merge_key");

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

                entity.Property(e => e.OracleStudyKey).HasColumnName("oracle_study_key");

                entity.Property(e => e.PatientId)
                    .HasColumnName("patient_id")
                    .HasMaxLength(15);

                entity.Property(e => e.PatinetNameSurname)
                    .HasColumnName("patinet_name_surname")
                    .HasMaxLength(80);

                entity.Property(e => e.SeriesCount).HasColumnName("series_count");

                entity.Property(e => e.SeriesInfo)
                    .HasColumnName("series_info")
                    .HasMaxLength(128);

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

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");

                entity.Property(e => e.VolumeCode)
                    .HasColumnName("volume_code")
                    .HasMaxLength(4);

                entity.Property(e => e.VolumePathname)
                    .HasColumnName("volume_pathname")
                    .HasMaxLength(64);

                entity.Property(e => e.VolumeStat)
                    .HasColumnName("volume_stat")
                    .HasMaxLength(2);

                entity.Property(e => e.VolumeType)
                    .HasColumnName("volume_type")
                    .HasMaxLength(2);

                entity.Property(e => e.ZeroImg).HasColumnName("zero_img");

                entity.HasOne(d => d.FkTenantNavigation)
                    .WithMany(p => p.KosStudy)
                    .HasForeignKey(d => d.FkTenant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tenat");
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

            modelBuilder.Entity<KosStudyJob>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("kos_study_job_pkey");

                entity.ToTable("kos_study_job");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ErrorCount).HasColumnName("error_count");

                entity.Property(e => e.FkJobEnumType).HasColumnName("fk_job_enum_type");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.Log)
                    .HasColumnName("log")
                    .HasColumnType("character varying");

                entity.Property(e => e.RecordStatus).HasColumnName("record_status");

                entity.Property(e => e.SuccessfulCount).HasColumnName("successful_count");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");

                entity.Property(e => e.TimeStart).HasColumnName("time_start");

                entity.Property(e => e.TimeStop).HasColumnName("time_stop");
            });

            modelBuilder.Entity<KosStudyParameter>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("kos_study_parameter_pkey");

                entity.ToTable("kos_study_parameter");

                entity.HasIndex(e => e.FkTenant)
                    .HasName("fk_tenant_uni")
                    .IsUnique();

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.FkTenant).HasColumnName("fk_tenant");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.IntervalMinute).HasColumnName("interval_minute");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(32);

                entity.Property(e => e.OracleStudyKeyLast).HasColumnName("oracle_study_key_last");

                entity.Property(e => e.RecordStatus).HasColumnName("record_status");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");

                entity.Property(e => e.TimeStart).HasColumnName("time_start");

                entity.Property(e => e.TimeStop).HasColumnName("time_stop");
            });

            modelBuilder.Entity<KosStudyYedek>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("kos_study_yedek");

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

                entity.Property(e => e.DicomDirPath)
                    .HasColumnName("dicom_dir_path")
                    .HasMaxLength(2048);

                entity.Property(e => e.DicomKosPath)
                    .HasColumnName("dicom_kos_path")
                    .HasColumnType("character varying");

                entity.Property(e => e.FailtMakeKosCount).HasColumnName("failt_make_kos_count");

                entity.Property(e => e.FailtSentKosCount).HasColumnName("failt_sent_kos_count");

                entity.Property(e => e.FileName)
                    .HasColumnName("file_name")
                    .HasMaxLength(256);

                entity.Property(e => e.FkInfBatch).HasColumnName("fk_inf_batch");

                entity.Property(e => e.FkKosEnumType).HasColumnName("fk_kos_enum_type");

                entity.Property(e => e.FkTenant).HasColumnName("fk_tenant");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(8);

                entity.Property(e => e.InfMergeKey).HasColumnName("inf_merge_key");

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

                entity.Property(e => e.OracleStudyKey).HasColumnName("oracle_study_key");

                entity.Property(e => e.PatientId)
                    .HasColumnName("patient_id")
                    .HasMaxLength(11);

                entity.Property(e => e.PatinetNameSurname)
                    .HasColumnName("patinet_name_surname")
                    .HasMaxLength(80);

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.SeriesCount).HasColumnName("series_count");

                entity.Property(e => e.SeriesInfo)
                    .HasColumnName("series_info")
                    .HasMaxLength(128);

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

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");

                entity.Property(e => e.VolumeCode)
                    .HasColumnName("volume_code")
                    .HasMaxLength(4);

                entity.Property(e => e.VolumePathname)
                    .HasColumnName("volume_pathname")
                    .HasMaxLength(64);

                entity.Property(e => e.VolumeStat)
                    .HasColumnName("volume_stat")
                    .HasMaxLength(2);

                entity.Property(e => e.VolumeType)
                    .HasColumnName("volume_type")
                    .HasMaxLength(2);

                entity.Property(e => e.ZeroImg).HasColumnName("zero_img");
            });

            modelBuilder.Entity<Oracle>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("oracle");

                entity.Property(e => e.Acce)
                    .HasColumnName("ACCE")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<StmGetorderStatusforAccessionnumberlist>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("stm_getorder_statusfor_accessionnumberlist_pkey");

                entity.ToTable("stm_getorder_statusfor_accessionnumberlist");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.Accessionnumber)
                    .HasColumnName("accessionnumber")
                    .HasMaxLength(32);

                entity.Property(e => e.Citizenid)
                    .HasColumnName("citizenid")
                    .HasMaxLength(16);

                entity.Property(e => e.Dosestatus)
                    .HasColumnName("dosestatus")
                    .HasMaxLength(32);

                entity.Property(e => e.Dosestatusid).HasColumnName("dosestatusid");

                entity.Property(e => e.Error)
                    .HasColumnName("error")
                    .HasMaxLength(512);

                entity.Property(e => e.FkInfBatch).HasColumnName("fk_inf_batch");

                entity.Property(e => e.FkKosStudy).HasColumnName("fk_kos_study");

                entity.Property(e => e.FkTenant).HasColumnName("fk_tenant");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.Lastmedulasenddate).HasColumnName("lastmedulasenddate");

                entity.Property(e => e.Medulainstitutionid)
                    .HasColumnName("medulainstitutionid")
                    .HasMaxLength(32);

                entity.Property(e => e.Medularesponsecode)
                    .HasColumnName("medularesponsecode")
                    .HasMaxLength(16);

                entity.Property(e => e.Medularesponsemessage)
                    .HasColumnName("medularesponsemessage")
                    .HasMaxLength(256);

                entity.Property(e => e.Medulastatus)
                    .HasColumnName("medulastatus")
                    .HasMaxLength(64);

                entity.Property(e => e.Medulastatusid).HasColumnName("medulastatusid");

                entity.Property(e => e.Patienthistorysearchstatus)
                    .HasColumnName("patienthistorysearchstatus")
                    .HasMaxLength(256);

                entity.Property(e => e.Patienthistorysearchstatusid).HasColumnName("patienthistorysearchstatusid");

                entity.Property(e => e.Performeddate).HasColumnName("performeddate");

                entity.Property(e => e.Reportstatus)
                    .HasColumnName("reportstatus")
                    .HasMaxLength(64);

                entity.Property(e => e.Reportstatusid).HasColumnName("reportstatusid");

                entity.Property(e => e.Scheduledate).HasColumnName("scheduledate");

                entity.Property(e => e.Sutcode)
                    .HasColumnName("sutcode")
                    .HasMaxLength(16);

                entity.Property(e => e.Teletipstatus)
                    .HasColumnName("teletipstatus")
                    .HasMaxLength(64);

                entity.Property(e => e.Teletipstatusid).HasColumnName("teletipstatusid");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");

                entity.Property(e => e.Wadostatus)
                    .HasColumnName("wadostatus")
                    .HasMaxLength(64);

                entity.Property(e => e.Wadostatusid).HasColumnName("wadostatusid");
            });

            modelBuilder.Entity<StmTeletipStatus>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("stm_teletip_status_pkey");

                entity.ToTable("stm_teletip_status");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<StudyOperationCount>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("study_operation_count _pkey");

                entity.ToTable("study_operation_count ");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.FkOperationEnumType).HasColumnName("fk_operation_enum_type");

                entity.Property(e => e.FkStudy).HasColumnName("fk_study");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.MakekosErrorTryCount).HasColumnName("makekos_error_try_count");

                entity.Property(e => e.SentkosErrorTryCount).HasColumnName("sentkos_error_try_count");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");
            });

            modelBuilder.Entity<UsrRole>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("usr_role_pkey");

                entity.ToTable("usr_role");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("character varying");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(64);

                entity.Property(e => e.RecordStatus).HasColumnName("record_status");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");
            });

            modelBuilder.Entity<UsrTenant>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("usr_tenant_pkey");

                entity.ToTable("usr_tenant");

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(128);

                entity.Property(e => e.RecordStatus).HasColumnName("record_status");

                entity.Property(e => e.TenantShortName)
                    .HasColumnName("tenant_short_name")
                    .HasMaxLength(64);

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");

                entity.Property(e => e.TimeModified).HasColumnName("time_modified");
            });

            modelBuilder.Entity<UsrTenantSkrs>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("tenat_skrs_pkey");

                entity.ToTable("usr_tenant_skrs");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .HasDefaultValueSql("nextval('tenat_skrs_pk_seq'::regclass)");

                entity.Property(e => e.AccessionNoPrefix)
                    .HasColumnName("accession_no_prefix")
                    .HasMaxLength(10);

                entity.Property(e => e.CallingAe)
                    .HasColumnName("calling_ae")
                    .HasMaxLength(64);

                entity.Property(e => e.FkSkrs).HasColumnName("fk_skrs");

                entity.Property(e => e.FkTenant).HasColumnName("fk_tenant");

                entity.Property(e => e.FkUserCreated).HasColumnName("fk_user_created");

                entity.Property(e => e.FkUserModified).HasColumnName("fk_user_modified");

                entity.Property(e => e.RecordStatus).HasColumnName("record_status");

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
                    .WithMany(p => p.UsrTenantSkrs)
                    .HasForeignKey(d => d.FkSkrs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_skrs");

                entity.HasOne(d => d.FkTenantNavigation)
                    .WithMany(p => p.UsrTenantSkrs)
                    .HasForeignKey(d => d.FkTenant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tenant");
            });

            modelBuilder.Entity<UsrUserLogin>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("usr_user_login_pkey");

                entity.ToTable("usr_user_login");

                entity.HasIndex(e => e.EmailAdress)
                    .HasName("email_uni")
                    .IsUnique();

                entity.HasIndex(e => e.UserName)
                    .HasName("username_uni")
                    .IsUnique();

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

                entity.Property(e => e.RecordStatus).HasColumnName("record_status");

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

                entity.HasIndex(e => new { e.FkUser, e.FkRole })
                    .HasName("usr_user_role_fk_role_key")
                    .IsUnique();

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

            modelBuilder.Entity<UsrUserTenant>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("usr_user_tenat_pkey");

                entity.ToTable("usr_user_tenant");

                entity.HasIndex(e => new { e.FkUser, e.FkTenant })
                    .HasName("user_tenant_uni")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .HasDefaultValueSql("nextval('usr_user_tenat_pk_seq'::regclass)");

                entity.Property(e => e.FkTenant).HasColumnName("fk_tenant");

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
