namespace GT.PERSISTANCE.DOMAIN.Models
{
    using GT.Persistance.Domain.infinity.Models;
    using GT.Persistance.infinity.Util;
    using GT.PERSISTANCE.Data.SQL;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class InfDataContext : CommonDbContext
    {
        //https://docs.microsoft.com/en-us/ef/core/miscellaneous/logging?tabs=v3
        public static readonly ILoggerFactory consoleLoggerFactory
            = LoggerFactory.Create(builder =>
            {
                builder.AddDebug();
            });
        public InfDataContext()
            : base("name=DataContext")
        {
        }
        public InfDataContext(bool autoDetectChangesEnabled, bool proxyCreationEnabled = true, bool lazyLoadingEnabled = true, bool validateOnSaveEnabled = true, Action<string> logAction = null)
           : base($"name={LocalSettings.AppName}")
        {
            //Database.SetInitializer<DataContext>(null);
            //Configuration.ProxyCreationEnabled = proxyCreationEnabled;
            //Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;
            //Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
            //Configuration.ValidateOnSaveEnabled = validateOnSaveEnabled;
            //if (logAction != null)
            //{
            //    Database.Log = logAction;
            //}
        }
        public virtual DbSet<TestSql> TestSql { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Instance> Instance { get; set; }
        public virtual DbSet<Instanceloc> Instanceloc { get; set; }
        public virtual DbSet<Modality> Modality { get; set; }
        public virtual DbSet<Series> Series { get; set; }
        public virtual DbSet<Study> Study { get; set; }
        public virtual DbSet<Volume> Volume { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //test deneme               
                optionsBuilder.UseLoggerFactory(consoleLoggerFactory);
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseOracle("User Id=test_user;Password=protek_oracle_2020;Data Source=85.95.238.211:9003/xe;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "TEST_USER");

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.InstanceKey)
                    .HasName("IMAGE_INSTANCE_KEY_PK");

                entity.ToTable("IMAGE");

                entity.HasIndex(e => e.InstanceKey)
                    .HasName("IMAGE_INSTANCE_KEY_PK")
                    .IsUnique();

                entity.Property(e => e.InstanceKey)
                    .HasColumnName("INSTANCE_KEY")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.AcqDttm)
                    .HasColumnName("ACQ_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.AcqNo)
                    .HasColumnName("ACQ_NO")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.AnnotationLob)
                    .HasColumnName("ANNOTATION_LOB")
                    .HasColumnType("CLOB");

                entity.Property(e => e.BitsAllocated)
                    .HasColumnName("BITS_ALLOCATED")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.BitsStored)
                    .HasColumnName("BITS_STORED")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.CassetteSize)
                    .HasColumnName("CASSETTE_SIZE")
                    .HasColumnType("VARCHAR2(16)");

                entity.Property(e => e.Curvature)
                    .HasColumnName("CURVATURE")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.FrameHeight)
                    .HasColumnName("FRAME_HEIGHT")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.FrameWidth)
                    .HasColumnName("FRAME_WIDTH")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.HeaderPostProcessing)
                    .HasColumnName("HEADER_POST_PROCESSING")
                    .HasColumnType("VARCHAR2(1)");

                entity.Property(e => e.ImageDttm)
                    .HasColumnName("IMAGE_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.ImageInfo)
                    .HasColumnName("IMAGE_INFO")
                    .HasColumnType("VARCHAR2(256)");

                entity.Property(e => e.ImageInfoEx)
                    .HasColumnName("IMAGE_INFO_EX")
                    .HasColumnType("VARCHAR2(1024)");

                entity.Property(e => e.ImageNo)
                    .HasColumnName("IMAGE_NO")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.ImageType)
                    .HasColumnName("IMAGE_TYPE")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.PhotometricInterpretation)
                    .HasColumnName("PHOTOMETRIC_INTERPRETATION")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.PixelAspectRatio)
                    .HasColumnName("PIXEL_ASPECT_RATIO")
                    .HasColumnType("VARCHAR2(32)");

                entity.Property(e => e.PixelRepresentation)
                    .HasColumnName("PIXEL_REPRESENTATION")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.PixelsizeX)
                    .HasColumnName("PIXELSIZE_X")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.PixelsizeY)
                    .HasColumnName("PIXELSIZE_Y")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.PlanarConfiguration)
                    .HasColumnName("PLANAR_CONFIGURATION")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.PlateId)
                    .HasColumnName("PLATE_ID")
                    .HasColumnType("VARCHAR2(128)");

                entity.Property(e => e.PresentationStat)
                    .HasColumnName("PRESENTATION_STAT")
                    .HasColumnType("CLOB");

                entity.Property(e => e.RegionCalibration)
                    .HasColumnName("REGION_CALIBRATION")
                    .HasColumnType("VARCHAR2(4000)");

                entity.Property(e => e.Rotation)
                    .HasColumnName("ROTATION")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.SamplesPerPixel)
                    .HasColumnName("SAMPLES_PER_PIXEL")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.State)
                    .HasColumnName("STATE")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.VideoInfo)
                    .HasColumnName("VIDEO_INFO")
                    .HasColumnType("VARCHAR2(1024)");

                entity.Property(e => e.WindowCenter)
                    .HasColumnName("WINDOW_CENTER")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.WindowType)
                    .HasColumnName("WINDOW_TYPE")
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.WindowWidth)
                    .HasColumnName("WINDOW_WIDTH")
                    .HasColumnType("NUMBER");
            });

            modelBuilder.Entity<Instance>(entity =>
            {
                entity.HasKey(e => e.InstanceKey)
                    .HasName("INSTANCE_KEY_PK");

                entity.ToTable("INSTANCE");

                entity.HasIndex(e => e.InstanceKey)
                    .HasName("INSTANCE_KEY_PK")
                    .IsUnique();

                entity.HasIndex(e => e.SopInstanceUid)
                    .HasName("INSTANCE_UID_UK")
                    .IsUnique();

                entity.HasIndex(e => new { e.InstanceStat, e.InstanceKey })
                    .HasName("INSTANCE_INSTANCE_STAT_IDX");

                entity.HasIndex(e => new { e.SeriesKey, e.InstanceKey })
                    .HasName("INSTANCE_SERIES_KEY_IDX");

                entity.HasIndex(e => new { e.StudyKey, e.InstanceKey })
                    .HasName("INSTANCE_STUDY_KEY_IDX");

                entity.Property(e => e.InstanceKey)
                    .HasColumnName("INSTANCE_KEY")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.ConcateKey)
                    .HasColumnName("CONCATE_KEY")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.ContentDttm)
                    .HasColumnName("CONTENT_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.InstanceNo)
                    .HasColumnName("INSTANCE_NO")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.InstanceStat)
                    .IsRequired()
                    .HasColumnName("INSTANCE_STAT")
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.InstanceframeCount)
                    .HasColumnName("INSTANCEFRAME_COUNT")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Ordinal)
                    .HasColumnName("ORDINAL")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.SeriesKey)
                    .HasColumnName("SERIES_KEY")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.SopClassKey)
                    .HasColumnName("SOP_CLASS_KEY")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.SopInstanceUid)
                    .IsRequired()
                    .HasColumnName("SOP_INSTANCE_UID")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.StudyKey)
                    .HasColumnName("STUDY_KEY")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.TransferSyntaxKey)
                    .HasColumnName("TRANSFER_SYNTAX_KEY")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.TransferSyntaxKeyB0)
                    .HasColumnName("TRANSFER_SYNTAX_KEY_B0")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.TransferSyntaxKeyB1)
                    .HasColumnName("TRANSFER_SYNTAX_KEY_B1")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.TransferSyntaxKeyB2)
                    .HasColumnName("TRANSFER_SYNTAX_KEY_B2")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.TransferSyntaxKeyB3)
                    .HasColumnName("TRANSFER_SYNTAX_KEY_B3")
                    .HasColumnType("NUMBER");

                entity.HasOne(d => d.SeriesKeyNavigation)
                    .WithMany(p => p.Instance)
                    .HasForeignKey(d => d.SeriesKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("INSTANCE_SERIES_KEY_FK");

                entity.HasOne(d => d.StudyKeyNavigation)
                    .WithMany(p => p.Instance)
                    .HasForeignKey(d => d.StudyKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("INSTANCE_STUDY_KEY_FK");
            });

            modelBuilder.Entity<Instanceloc>(entity =>
            {
                entity.HasKey(e => e.InstanceKey)
                    .HasName("INSTANCELOC_INSTANCE_KEY_PK");

                entity.ToTable("INSTANCELOC");

                entity.HasIndex(e => e.InstanceKey)
                    .HasName("INSTANCELOC_INSTANCE_KEY_PK")
                    .IsUnique();

                entity.HasIndex(e => new { e.B1BakStat, e.InstanceKey })
                    .HasName("INSTANCELOC_B1_BAK_STAT_IDX");

                entity.HasIndex(e => new { e.B2BakStat, e.InstanceKey })
                    .HasName("INSTANCELOC_B2_BAK_STAT_IDX");

                entity.HasIndex(e => new { e.B3BakStat, e.InstanceKey })
                    .HasName("INSTANCELOC_B3_BAK_STAT_IDX");

                entity.HasIndex(e => new { e.VolumeCode, e.InstanceKey })
                    .HasName("INSTANCELOC_VOLUME_CODE");

                entity.HasIndex(e => new { e.VolumeCode, e.B1BakStat, e.InstanceKey })
                    .HasName("INSTANCELOC_VOLUME_CODE_B1_IDX");

                entity.HasIndex(e => new { e.VolumeCode, e.B2BakStat, e.InstanceKey })
                    .HasName("INSTANCELOC_VOLUME_CODE_B2_IDX");

                entity.HasIndex(e => new { e.VolumeCode, e.B3BakStat, e.InstanceKey })
                    .HasName("INSTANCELOC_VOLUME_CODE_B3_IDX");

                entity.Property(e => e.InstanceKey)
                    .HasColumnName("INSTANCE_KEY")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.B0Filepath)
                    .HasColumnName("B0_FILEPATH")
                    .HasColumnType("VARCHAR2(512)");

                entity.Property(e => e.B0VolCode)
                    .HasColumnName("B0_VOL_CODE")
                    .HasColumnType("VARCHAR2(2)");

                entity.Property(e => e.B0VolStat)
                    .HasColumnName("B0_VOL_STAT")
                    .HasColumnType("VARCHAR2(1)");

                entity.Property(e => e.B1BakStat)
                    .IsRequired()
                    .HasColumnName("B1_BAK_STAT")
                    .HasColumnType("VARCHAR2(1)")
                    .HasDefaultValueSql("'N' ");

                entity.Property(e => e.B1Filepath)
                    .HasColumnName("B1_FILEPATH")
                    .HasColumnType("VARCHAR2(512)");

                entity.Property(e => e.B1VolCode)
                    .HasColumnName("B1_VOL_CODE")
                    .HasColumnType("VARCHAR2(2)");

                entity.Property(e => e.B1VolStat)
                    .HasColumnName("B1_VOL_STAT")
                    .HasColumnType("VARCHAR2(1)");

                entity.Property(e => e.B2BakStat)
                    .IsRequired()
                    .HasColumnName("B2_BAK_STAT")
                    .HasColumnType("VARCHAR2(1)")
                    .HasDefaultValueSql("'N' ");

                entity.Property(e => e.B2Filepath)
                    .HasColumnName("B2_FILEPATH")
                    .HasColumnType("VARCHAR2(512)");

                entity.Property(e => e.B2VolCode)
                    .HasColumnName("B2_VOL_CODE")
                    .HasColumnType("VARCHAR2(2)");

                entity.Property(e => e.B2VolStat)
                    .HasColumnName("B2_VOL_STAT")
                    .HasColumnType("VARCHAR2(1)");

                entity.Property(e => e.B3BakStat)
                    .IsRequired()
                    .HasColumnName("B3_BAK_STAT")
                    .HasColumnType("VARCHAR2(1)")
                    .HasDefaultValueSql("'N' ");

                entity.Property(e => e.B3Filepath)
                    .HasColumnName("B3_FILEPATH")
                    .HasColumnType("VARCHAR2(512)");

                entity.Property(e => e.B3VolCode)
                    .HasColumnName("B3_VOL_CODE")
                    .HasColumnType("VARCHAR2(2)");

                entity.Property(e => e.B3VolStat)
                    .HasColumnName("B3_VOL_STAT")
                    .HasColumnType("VARCHAR2(1)");

                entity.Property(e => e.CompressSize)
                    .HasColumnName("COMPRESS_SIZE")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasColumnName("FILENAME")
                    .HasColumnType("VARCHAR2(256)");

                entity.Property(e => e.InstanceSize)
                    .HasColumnName("INSTANCE_SIZE")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.InstanceType)
                    .IsRequired()
                    .HasColumnName("INSTANCE_TYPE")
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.Pathext)
                    .HasColumnName("PATHEXT")
                    .HasColumnType("VARCHAR2(8)");

                entity.Property(e => e.Pathname)
                    .IsRequired()
                    .HasColumnName("PATHNAME")
                    .HasColumnType("VARCHAR2(256)");

                entity.Property(e => e.VolumeCode)
                    .HasColumnName("VOLUME_CODE")
                    .HasColumnType("VARCHAR2(2)");
            });

            modelBuilder.Entity<Modality>(entity =>
            {
                entity.HasKey(e => e.ModalityCode)
                    .HasName("MODALITY_CODE_PK");

                entity.ToTable("MODALITY");

                entity.HasIndex(e => e.ModalityCode)
                    .HasName("MODALITY_CODE_PK")
                    .IsUnique();

                entity.Property(e => e.ModalityCode)
                    .HasColumnName("MODALITY_CODE")
                    .HasColumnType("VARCHAR2(8)");

                entity.Property(e => e.LastPerformed)
                    .HasColumnName("LAST_PERFORMED")
                    .HasColumnType("DATE");

                entity.Property(e => e.ModalityDesc)
                    .HasColumnName("MODALITY_DESC")
                    .HasColumnType("VARCHAR2(128)");

                entity.Property(e => e.ModalityStat)
                    .HasColumnName("MODALITY_STAT")
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.PerformedCount)
                    .HasColumnName("PERFORMED_COUNT")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Rvu)
                    .HasColumnName("RVU")
                    .HasColumnType("NUMBER");
            });

            modelBuilder.Entity<Series>(entity =>
            {
                entity.HasKey(e => e.SeriesKey)
                    .HasName("SERIES_KEY_PK");

                entity.ToTable("SERIES");

                entity.HasIndex(e => e.SeriesInstanceUid)
                    .HasName("SERIES_INSTANCE_UID_UK")
                    .IsUnique();

                entity.HasIndex(e => e.SeriesKey)
                    .HasName("SERIES_KEY_PK")
                    .IsUnique();

                entity.HasIndex(e => new { e.Modality, e.StudyKey })
                    .HasName("IDX_SERIES_MODALITY_STUDY");

                entity.HasIndex(e => new { e.StudyKey, e.SeriesKey })
                    .HasName("SERIES_STUDY_KEY_IDX");

                entity.HasIndex(e => new { e.Temporary, e.StudyKey })
                    .HasName("IDX_SERIES_TEMPORARY_STUDY");

                entity.HasIndex(e => new { e.StudyKey, e.Temporary, e.SeriesKey })
                    .HasName("IDX_SERIES_STUDY_TEMP_SERIES");

                entity.Property(e => e.SeriesKey)
                    .HasColumnName("SERIES_KEY")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Bodypart)
                    .HasColumnName("BODYPART")
                    .HasColumnType("VARCHAR2(32)");

                entity.Property(e => e.FilterInfo)
                    .HasColumnName("FILTER_INFO")
                    .HasColumnType("CHAR(3)");

                entity.Property(e => e.InstanceCount)
                    .HasColumnName("INSTANCE_COUNT")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Modality)
                    .IsRequired()
                    .HasColumnName("MODALITY")
                    .HasColumnType("VARCHAR2(12)");

                entity.Property(e => e.Operator)
                    .HasColumnName("OPERATOR")
                    .HasColumnType("VARCHAR2(32)");

                entity.Property(e => e.Ordinal)
                    .HasColumnName("ORDINAL")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.PerformDoctor)
                    .HasColumnName("PERFORM_DOCTOR")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.PerformedProcStartDttm)
                    .HasColumnName("PERFORMED_PROC_START_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.PpsDesc)
                    .HasColumnName("PPS_DESC")
                    .HasColumnType("VARCHAR2(256)");

                entity.Property(e => e.PpsId)
                    .HasColumnName("PPS_ID")
                    .HasColumnType("VARCHAR2(32)");

                entity.Property(e => e.PpsStartDttm)
                    .HasColumnName("PPS_START_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.RequestAttrs)
                    .HasColumnName("REQUEST_ATTRS")
                    .HasColumnType("VARCHAR2(1024)");

                entity.Property(e => e.SeriesDesc)
                    .HasColumnName("SERIES_DESC")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.SeriesDttm)
                    .HasColumnName("SERIES_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.SeriesInfo)
                    .HasColumnName("SERIES_INFO")
                    .HasColumnType("VARCHAR2(256)");

                entity.Property(e => e.SeriesInstanceUid)
                    .IsRequired()
                    .HasColumnName("SERIES_INSTANCE_UID")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.SeriesNo)
                    .HasColumnName("SERIES_NO")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.SeriesSize)
                    .HasColumnName("SERIES_SIZE")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.SeriesStat)
                    .IsRequired()
                    .HasColumnName("SERIES_STAT")
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.StudyKey)
                    .HasColumnName("STUDY_KEY")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Temporary)
                    .HasColumnName("TEMPORARY")
                    .HasColumnType("CHAR(1)");

                entity.HasOne(d => d.StudyKeyNavigation)
                    .WithMany(p => p.Series)
                    .HasForeignKey(d => d.StudyKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SERIES_STUDY_KEY_FK");
            });

            modelBuilder.Entity<Study>(entity =>
            {
                entity.HasKey(e => e.StudyKey)
                    .HasName("STUDY_KEY_PK");

                entity.ToTable("STUDY");

                entity.HasIndex(e => e.AccessDttm)
                    .HasName("STUDY_ACCESS_DTTM_IDX");

                entity.HasIndex(e => e.CreationDttm)
                    .HasName("STUDY_CREATION_DTTM_IDX");

                entity.HasIndex(e => e.Department)
                    .HasName("STUDY_DEPARTMENT_IDX");

                entity.HasIndex(e => e.MergeKey)
                    .HasName("STUDY_MERGE_KEY_IDX");

                entity.HasIndex(e => e.OtherPatientName)
                    .HasName("IDX_STDTMDESC_OTHPATNAM");

                entity.HasIndex(e => e.PatientIdIssuer)
                    .HasName("STUDY_ID_ISSUER_IDX");

                entity.HasIndex(e => e.PatientName)
                    .HasName("IDX_STUDY_STDDTM_DESC_PATNAM");

                entity.HasIndex(e => e.Specialty)
                    .HasName("IDX_STUDY_STDDTM_DESC_SPECT");

                entity.HasIndex(e => e.StudyDesc)
                    .HasName("IDX_STUDY_STDDTM_DESC_DESCR");

                entity.HasIndex(e => e.StudyInstanceUid)
                    .HasName("STUDY_INSTANCE_UID_UK")
                    .IsUnique();

                entity.HasIndex(e => e.StudyKey)
                    .HasName("STUDY_KEY_PK")
                    .IsUnique();

                entity.HasIndex(e => e.StudySsn)
                    .HasName("IDX_STUDY_SSN");

                entity.HasIndex(e => new { e.OrderKey, e.StudyKey })
                    .HasName("STUDY_ORDER_KEY_IDX");

                entity.HasIndex(e => new { e.PatientId, e.StudyKey })
                    .HasName("STUDY_PATIENT_ID_IDX2");

                entity.HasIndex(e => new { e.AccessNo, e.Modalities, e.PatientId })
                    .HasName("STUDY_ACCESS_NO_IDX2");

                entity.HasIndex(e => new { e.Modalities, e.Department, e.Bodyparts })
                    .HasName("IDX_STDTMDESC_MODAL_DEPT_BDPT");

                entity.HasIndex(e => new { e.PatientBirthDttm, e.PatientAgeInDays, e.PatientAge })
                    .HasName("IDX_STDTMDESC_BIRTH_DAYS_AGE");

                entity.HasIndex(e => new { e.PatientId, e.StudyDttm, e.StudyKey })
                    .HasName("STUDY_PATIENT_ID_IDX");

                entity.HasIndex(e => new { e.PatientName, e.StudyDttm, e.StudyKey })
                    .HasName("STUDY_PATIENT_NAME_IDX");

                entity.HasIndex(e => new { e.StudyId, e.StudyDttm, e.StudyKey })
                    .HasName("STUDY_STUDY_ID_IDX");

                entity.HasIndex(e => new { e.StudyStat, e.PatientLocation, e.Passcode })
                    .HasName("IDX_STDTMDESC_STAT_PLOC_PASCD");

                entity.HasIndex(e => new { e.AccessNo, e.StudyDttm, e.Modalities, e.PatientId })
                    .HasName("STUDY_ACCESS_NO_IDX");

                entity.HasIndex(e => new { e.RequestName, e.RequestDoctor, e.ConsultDoctor, e.ReferDoctor })
                    .HasName("IDX_STDTMDESC_REQNAM_DOCTORS");

                entity.HasIndex(e => new { e.StudyDttm, e.PatientId, e.AccessNo, e.Specialty, e.StudyStat, e.SourceAetitle, e.Modalities })
                    .HasName("STUDY_STUDY_DTTM_IDX");

                entity.Property(e => e.StudyKey)
                    .HasColumnName("STUDY_KEY")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.AccessDttm)
                    .HasColumnName("ACCESS_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.AccessNo)
                    .HasColumnName("ACCESS_NO")
                    .HasColumnType("VARCHAR2(32)");

                entity.Property(e => e.AddendumStat)
                    .HasColumnName("ADDENDUM_STAT")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.AdmitDttm)
                    .HasColumnName("ADMIT_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.AssignedDttm)
                    .HasColumnName("ASSIGNED_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.AttendDoctor)
                    .HasColumnName("ATTEND_DOCTOR")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.BillingStat)
                    .HasColumnName("BILLING_STAT")
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.Bodyparts)
                    .HasColumnName("BODYPARTS")
                    .HasColumnType("VARCHAR2(128)");

                entity.Property(e => e.CompletedDttm)
                    .HasColumnName("COMPLETED_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.ConfirmStat)
                    .HasColumnName("CONFIRM_STAT")
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.ConsultDoctor)
                    .HasColumnName("CONSULT_DOCTOR")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.CreationDttm)
                    .HasColumnName("CREATION_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.Department)
                    .HasColumnName("DEPARTMENT")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.Diagnosis)
                    .HasColumnName("DIAGNOSIS")
                    .HasColumnType("VARCHAR2(2048)");

                entity.Property(e => e.DreadDttm)
                    .HasColumnName("DREAD_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.DreaderKey)
                    .HasColumnName("DREADER_KEY")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.EdStat)
                    .HasColumnName("ED_STAT")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.EnglishPatientName)
                    .HasColumnName("ENGLISH_PATIENT_NAME")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.HideCode)
                    .HasColumnName("HIDE_CODE")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.InstanceCount)
                    .HasColumnName("INSTANCE_COUNT")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Institution)
                    .HasColumnName("INSTITUTION")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.JobUid)
                    .HasColumnName("JOB_UID")
                    .HasColumnType("VARCHAR2(128)");

                entity.Property(e => e.LastPrintDttm)
                    .HasColumnName("LAST_PRINT_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.LastPrintUserKey)
                    .HasColumnName("LAST_PRINT_USER_KEY")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.LtaCount)
                    .HasColumnName("LTA_COUNT")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.MergeKey)
                    .HasColumnName("MERGE_KEY")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Modalities)
                    .HasColumnName("MODALITIES")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.ModifyDttm)
                    .HasColumnName("MODIFY_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.MspsCount)
                    .HasColumnName("MSPS_COUNT")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Operators)
                    .HasColumnName("OPERATORS")
                    .HasColumnType("VARCHAR2(128)");

                entity.Property(e => e.OrderDttm)
                    .HasColumnName("ORDER_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.OrderKey)
                    .HasColumnName("ORDER_KEY")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.OtherPatientId)
                    .HasColumnName("OTHER_PATIENT_ID")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.OtherPatientIdIssuer)
                    .HasColumnName("OTHER_PATIENT_ID_ISSUER")
                    .HasColumnType("VARCHAR2(32)");

                entity.Property(e => e.OtherPatientName)
                    .HasColumnName("OTHER_PATIENT_NAME")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.Passcode)
                    .HasColumnName("PASSCODE")
                    .HasColumnType("VARCHAR2(16)");

                entity.Property(e => e.PatientAccountNo)
                    .HasColumnName("PATIENT_ACCOUNT_NO")
                    .HasColumnType("VARCHAR2(32)");

                entity.Property(e => e.PatientAge)
                    .HasColumnName("PATIENT_AGE")
                    .HasColumnType("VARCHAR2(16)");

                entity.Property(e => e.PatientAgeInDays)
                    .HasColumnName("PATIENT_AGE_IN_DAYS")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.PatientArrange)
                    .HasColumnName("PATIENT_ARRANGE")
                    .HasColumnType("VARCHAR2(32)");

                entity.Property(e => e.PatientBirthDttm)
                    .HasColumnName("PATIENT_BIRTH_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.PatientId)
                    .HasColumnName("PATIENT_ID")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.PatientIdIssuer)
                    .HasColumnName("PATIENT_ID_ISSUER")
                    .HasColumnType("VARCHAR2(32)");

                entity.Property(e => e.PatientLocation)
                    .HasColumnName("PATIENT_LOCATION")
                    .HasColumnType("VARCHAR2(32)");

                entity.Property(e => e.PatientName)
                    .HasColumnName("PATIENT_NAME")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.PatientResidency)
                    .HasColumnName("PATIENT_RESIDENCY")
                    .HasColumnType("VARCHAR2(80)");

                entity.Property(e => e.PatientSex)
                    .HasColumnName("PATIENT_SEX")
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.PatientSize)
                    .HasColumnName("PATIENT_SIZE")
                    .HasColumnType("VARCHAR2(16)");

                entity.Property(e => e.PatientWeight)
                    .HasColumnName("PATIENT_WEIGHT")
                    .HasColumnType("VARCHAR2(16)");

                entity.Property(e => e.PerformDoctor)
                    .HasColumnName("PERFORM_DOCTOR")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.PrintStat)
                    .HasColumnName("PRINT_STAT")
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.ProcplanKey)
                    .HasColumnName("PROCPLAN_KEY")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Protected)
                    .HasColumnName("PROTECTED")
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.ReadDoctor)
                    .HasColumnName("READ_DOCTOR")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.ReferDoctor)
                    .HasColumnName("REFER_DOCTOR")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.RegisterDttm)
                    .HasColumnName("REGISTER_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.RequestCode)
                    .HasColumnName("REQUEST_CODE")
                    .HasColumnType("VARCHAR2(32)");

                entity.Property(e => e.RequestDepartment)
                    .HasColumnName("REQUEST_DEPARTMENT")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.RequestDoctor)
                    .HasColumnName("REQUEST_DOCTOR")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.RequestDttm)
                    .HasColumnName("REQUEST_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.RequestName)
                    .HasColumnName("REQUEST_NAME")
                    .HasColumnType("VARCHAR2(128)");

                entity.Property(e => e.RequestStat)
                    .HasColumnName("REQUEST_STAT")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Requestexam)
                    .HasColumnName("REQUESTEXAM")
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.ScheduledDttm)
                    .HasColumnName("SCHEDULED_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.SeriesCount)
                    .HasColumnName("SERIES_COUNT")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.SourceAetitle)
                    .HasColumnName("SOURCE_AETITLE")
                    .HasColumnType("VARCHAR2(16)");

                entity.Property(e => e.SpecialNeeds)
                    .HasColumnName("SPECIAL_NEEDS")
                    .HasColumnType("VARCHAR2(4000)");

                entity.Property(e => e.Specialty)
                    .HasColumnName("SPECIALTY")
                    .HasColumnType("VARCHAR2(32)");

                entity.Property(e => e.StayinStat)
                    .HasColumnName("STAYIN_STAT")
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.StsStat)
                    .HasColumnName("STS_STAT")
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.StudyComments)
                    .HasColumnName("STUDY_COMMENTS")
                    .HasColumnType("VARCHAR2(4000)");

                entity.Property(e => e.StudyDesc)
                    .HasColumnName("STUDY_DESC")
                    .HasColumnType("VARCHAR2(128)");

                entity.Property(e => e.StudyDttm)
                    .HasColumnName("STUDY_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.StudyId)
                    .HasColumnName("STUDY_ID")
                    .HasColumnType("VARCHAR2(32)");

                entity.Property(e => e.StudyInstanceUid)
                    .IsRequired()
                    .HasColumnName("STUDY_INSTANCE_UID")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.StudyPriority)
                    .HasColumnName("STUDY_PRIORITY")
                    .HasColumnType("VARCHAR2(32)");

                entity.Property(e => e.StudyReason)
                    .HasColumnName("STUDY_REASON")
                    .HasColumnType("VARCHAR2(512)");

                entity.Property(e => e.StudySize)
                    .HasColumnName("STUDY_SIZE")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.StudySsn)
                    .HasColumnName("STUDY_SSN")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.StudyStat)
                    .HasColumnName("STUDY_STAT")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.TreadDttm)
                    .HasColumnName("TREAD_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.TreaderKey)
                    .HasColumnName("TREADER_KEY")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.ValidateDttm)
                    .HasColumnName("VALIDATE_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.VerifierKey)
                    .HasColumnName("VERIFIER_KEY")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.VerifyDttm)
                    .HasColumnName("VERIFY_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.WetReading)
                    .HasColumnName("WET_READING")
                    .HasColumnType("CHAR(1)");
            });

            modelBuilder.Entity<Volume>(entity =>
            {
                entity.HasKey(e => e.VolumeCode)
                    .HasName("SYS_C007301");

                entity.ToTable("VOLUME");

                entity.HasIndex(e => e.InstitutionCode)
                    .HasName("IDX_VOLUME_INSTCODE");

                entity.HasIndex(e => e.VolumeCode)
                    .HasName("SYS_C007301")
                    .IsUnique();

                entity.Property(e => e.VolumeCode)
                    .HasColumnName("VOLUME_CODE")
                    .HasColumnType("VARCHAR2(2)");

                entity.Property(e => e.Aetitle)
                    .HasColumnName("AETITLE")
                    .HasColumnType("VARCHAR2(16)");

                entity.Property(e => e.Capacity)
                    .HasColumnName("CAPACITY")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Hostname)
                    .IsRequired()
                    .HasColumnName("HOSTNAME")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.Iishost)
                    .HasColumnName("IISHOST")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.InstitutionCode)
                    .HasColumnName("INSTITUTION_CODE")
                    .HasColumnType("VARCHAR2(32)");

                entity.Property(e => e.Modality)
                    .HasColumnName("MODALITY")
                    .HasColumnType("VARCHAR2(8)");

                entity.Property(e => e.Ordinal)
                    .HasColumnName("ORDINAL")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasColumnType("VARCHAR2(16)");

                entity.Property(e => e.Pathname)
                    .IsRequired()
                    .HasColumnName("PATHNAME")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.Protocol)
                    .HasColumnName("PROTOCOL")
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.Rhostname)
                    .HasColumnName("RHOSTNAME")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.Rpassword)
                    .HasColumnName("RPASSWORD")
                    .HasColumnType("VARCHAR2(16)");

                entity.Property(e => e.Rusername)
                    .HasColumnName("RUSERNAME")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.Sharename)
                    .IsRequired()
                    .HasColumnName("SHARENAME")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.Threshold)
                    .HasColumnName("THRESHOLD")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.UsedSpace)
                    .HasColumnName("USED_SPACE")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.UsedSpaceUpdateDttm)
                    .HasColumnName("USED_SPACE_UPDATE_DTTM")
                    .HasColumnType("DATE");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("USERNAME")
                    .HasColumnType("VARCHAR2(64)");

                entity.Property(e => e.VolumeStat)
                    .IsRequired()
                    .HasColumnName("VOLUME_STAT")
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.VolumeType)
                    .IsRequired()
                    .HasColumnName("VOLUME_TYPE")
                    .HasColumnType("CHAR(1)");
            });

            //  OnModelCreatingPartial(modelBuilder);
        }
    }
}
