namespace GT.PERSISTANCE.DOMAIN.Models
{
    using Dcm4chee.Persistance.Domain.Models;
    using Gt.PERSISTANCE;
    using GT.Core.Settings;
    using GT.Core.Settings.Global;
    using GT.PERSISTANCE.Data.SQL;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Console;
    using Microsoft.Extensions.Logging.Debug;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Dcm4cheeDataContext : CommonDbContext
    {
        //https://docs.microsoft.com/en-us/ef/core/miscellaneous/logging?tabs=v3
        public static readonly ILoggerFactory consoleLoggerFactory
            = LoggerFactory.Create(builder =>
            {
                builder.AddDebug();
            });
        public bool IsLogging { get; set; }
        public Dcm4cheeDataContext()
            : base("name=DataContext")
        {
        }
        public Dcm4cheeDataContext(bool autoDetectChangesEnabled, bool proxyCreationEnabled = true, bool lazyLoadingEnabled = true, bool validateOnSaveEnabled = true, bool logging = false)
           : base($"name={LocalSettings.AppName}")
        {
            IsLogging = logging;
            //Database.SetInitializer<DataContext>(null);
            //Configuration.ProxyCreationEnabled = proxyCreationEnabled;
            //Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;
            //Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
            //Configuration.ValidateOnSaveEnabled = validateOnSaveEnabled;

        }
        public virtual DbSet<Code> Code { get; set; }
        public virtual DbSet<ContentItem> ContentItem { get; set; }
        public virtual DbSet<Dicomattrs> Dicomattrs { get; set; }
        public virtual DbSet<DiffTask> DiffTask { get; set; }
        public virtual DbSet<DiffTaskAttrs> DiffTaskAttrs { get; set; }
        public virtual DbSet<ExportTask> ExportTask { get; set; }
        public virtual DbSet<GlobalSubscription> GlobalSubscription { get; set; }
        public virtual DbSet<Hl7psuTask> Hl7psuTask { get; set; }
        public virtual DbSet<IanTask> IanTask { get; set; }
        public virtual DbSet<IdSequence> IdSequence { get; set; }
        public virtual DbSet<Instance> Instance { get; set; }
        public virtual DbSet<Issuer> Issuer { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Metadata> Metadata { get; set; }
        public virtual DbSet<Mpps> Mpps { get; set; }
        public virtual DbSet<MwlItem> MwlItem { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<PatientId> PatientId { get; set; }
        public virtual DbSet<PersonName> PersonName { get; set; }
        public virtual DbSet<QueueMsg> QueueMsg { get; set; }
        public virtual DbSet<RejectedInstance> RejectedInstance { get; set; }
        public virtual DbSet<RelStudyPcode> RelStudyPcode { get; set; }
        public virtual DbSet<RelUpsPerfCode> RelUpsPerfCode { get; set; }
        public virtual DbSet<RetrieveTask> RetrieveTask { get; set; }
        public virtual DbSet<Rise> Rise { get; set; }
        public virtual DbSet<Series> Series { get; set; }
        public virtual DbSet<SeriesQueryAttrs> SeriesQueryAttrs { get; set; }
        public virtual DbSet<SeriesReq> SeriesReq { get; set; }
        public virtual DbSet<SoundexCode> SoundexCode { get; set; }
        public virtual DbSet<SpsStationAet> SpsStationAet { get; set; }
        public virtual DbSet<StgcmtResult> StgcmtResult { get; set; }
        public virtual DbSet<StgverTask> StgverTask { get; set; }
        public virtual DbSet<Study> Study { get; set; }
        public virtual DbSet<StudyQueryAttrs> StudyQueryAttrs { get; set; }
        public virtual DbSet<Subscription> Subscription { get; set; }
        public virtual DbSet<Uidmap> Uidmap { get; set; }
        public virtual DbSet<Ups> Ups { get; set; }
        public virtual DbSet<UpsReq> UpsReq { get; set; }
        public virtual DbSet<VerifyObserver> VerifyObserver { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (IsLogging)
                    optionsBuilder.UseLoggerFactory(consoleLoggerFactory);
                var connectionString = "Host = 85.95.239.134; Database = pacsdb; Username = pacs; Password = pacs; Port = 5432";
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Code>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("code_pkey");

                entity.ToTable("code");

                entity.HasIndex(e => new { e.CodeValue, e.CodeDesignator, e.CodeVersion })
                    .HasName("uk_sb4oc9lkns36wswku831c33w6")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeDesignator)
                    .IsRequired()
                    .HasColumnName("code_designator")
                    .HasMaxLength(255);

                entity.Property(e => e.CodeMeaning)
                    .IsRequired()
                    .HasColumnName("code_meaning")
                    .HasMaxLength(255);

                entity.Property(e => e.CodeValue)
                    .IsRequired()
                    .HasColumnName("code_value")
                    .HasMaxLength(255);

                entity.Property(e => e.CodeVersion)
                    .IsRequired()
                    .HasColumnName("code_version")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ContentItem>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("content_item_pkey");

                entity.ToTable("content_item");

                entity.HasIndex(e => e.CodeFk)
                    .HasName("fk_gudw6viy7lrf5t5hetw7mbgh5");

                entity.HasIndex(e => e.InstanceFk)
                    .HasName("fk_9kpe6whsov3ur9rph4ih2vi5a");

                entity.HasIndex(e => e.NameFk)
                    .HasName("fk_pyrd1nhijag5ct0ee9xqq4h78");

                entity.HasIndex(e => e.RelType)
                    .HasName("uk_i715nk4mi378f9bxflvfroa5a");

                entity.HasIndex(e => e.TextValue)
                    .HasName("uk_6iism30y000w85v649ju968sv");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeFk).HasColumnName("code_fk");

                entity.Property(e => e.InstanceFk).HasColumnName("instance_fk");

                entity.Property(e => e.NameFk).HasColumnName("name_fk");

                entity.Property(e => e.RelType)
                    .IsRequired()
                    .HasColumnName("rel_type")
                    .HasMaxLength(255);

                entity.Property(e => e.TextValue)
                    .HasColumnName("text_value")
                    .HasMaxLength(255);

                entity.HasOne(d => d.CodeFkNavigation)
                    .WithMany(p => p.ContentItemCodeFkNavigation)
                    .HasForeignKey(d => d.CodeFk)
                    .HasConstraintName("fk_gudw6viy7lrf5t5hetw7mbgh5");

                entity.HasOne(d => d.InstanceFkNavigation)
                    .WithMany(p => p.ContentItem)
                    .HasForeignKey(d => d.InstanceFk)
                    .HasConstraintName("fk_9kpe6whsov3ur9rph4ih2vi5a");

                entity.HasOne(d => d.NameFkNavigation)
                    .WithMany(p => p.ContentItemNameFkNavigation)
                    .HasForeignKey(d => d.NameFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pyrd1nhijag5ct0ee9xqq4h78");
            });

            modelBuilder.Entity<Dicomattrs>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("dicomattrs_pkey");

                entity.ToTable("dicomattrs");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.Attrs)
                    .IsRequired()
                    .HasColumnName("attrs");
            });

            modelBuilder.Entity<DiffTask>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("diff_task_pkey");

                entity.ToTable("diff_task");

                entity.HasIndex(e => e.CheckDifferent)
                    .HasName("uk_ex8bacv78us242731mpyrigpd");

                entity.HasIndex(e => e.CheckMissing)
                    .HasName("uk_1b3rghtxfl0byme5urnxmd4xl");

                entity.HasIndex(e => e.CompareFields)
                    .HasName("uk_d92i2fx5i138fbehp4qfk");

                entity.HasIndex(e => e.CreatedTime)
                    .HasName("uk_swm85lyyxy8sr2oot4dcrjck4");

                entity.HasIndex(e => e.LocalAet)
                    .HasName("uk_ji31t9tjovks2hi8c220kvh2o");

                entity.HasIndex(e => e.PrimaryAet)
                    .HasName("uk_kigvmtftfxwb5ekb5a1d48okh");

                entity.HasIndex(e => e.QueueMsgFk)
                    .HasName("fk_dlrthwe594xvfeta3kyuih3ip");

                entity.HasIndex(e => e.SecondaryAet)
                    .HasName("uk_4esq3qn81u1ww82vsheeiy424");

                entity.HasIndex(e => e.UpdatedTime)
                    .HasName("uk_dyakfsqdbpk1bgme5i9xw20jj");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.CheckDifferent).HasColumnName("check_different");

                entity.Property(e => e.CheckMissing).HasColumnName("check_missing");

                entity.Property(e => e.CompareFields)
                    .HasColumnName("compare_fields")
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.Different).HasColumnName("different");

                entity.Property(e => e.LocalAet)
                    .IsRequired()
                    .HasColumnName("local_aet")
                    .HasMaxLength(255);

                entity.Property(e => e.Matches).HasColumnName("matches");

                entity.Property(e => e.Missing).HasColumnName("missing");

                entity.Property(e => e.PrimaryAet)
                    .IsRequired()
                    .HasColumnName("primary_aet")
                    .HasMaxLength(255);

                entity.Property(e => e.QueryStr)
                    .IsRequired()
                    .HasColumnName("query_str")
                    .HasMaxLength(255);

                entity.Property(e => e.QueueMsgFk).HasColumnName("queue_msg_fk");

                entity.Property(e => e.SecondaryAet)
                    .IsRequired()
                    .HasColumnName("secondary_aet")
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");

                entity.HasOne(d => d.QueueMsgFkNavigation)
                    .WithMany(p => p.DiffTask)
                    .HasForeignKey(d => d.QueueMsgFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dlrthwe594xvfeta3kyuih3ip");
            });

            modelBuilder.Entity<DiffTaskAttrs>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("diff_task_attrs");

                entity.HasIndex(e => e.DicomattrsFk)
                    .HasName("uk_72rsx022j2wu9noi6jldvq95r")
                    .IsUnique();

                entity.HasIndex(e => e.DiffTaskFk)
                    .HasName("fk_1sbjtesix8hkq310i84lfg0xi");

                entity.Property(e => e.DicomattrsFk).HasColumnName("dicomattrs_fk");

                entity.Property(e => e.DiffTaskFk).HasColumnName("diff_task_fk");

                entity.HasOne(d => d.DicomattrsFkNavigation)
                    .WithOne()
                    .HasForeignKey<DiffTaskAttrs>(d => d.DicomattrsFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_72rsx022j2wu9noi6jldvq95r");

                entity.HasOne(d => d.DiffTaskFkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.DiffTaskFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_1sbjtesix8hkq310i84lfg0xi");
            });

            modelBuilder.Entity<ExportTask>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("export_task_pkey");

                entity.ToTable("export_task");

                entity.HasIndex(e => e.BatchId)
                    .HasName("uk_mt8p2iqcmkoxodkjtfcw1635v");

                entity.HasIndex(e => e.CreatedTime)
                    .HasName("uk_7iil4v32vf234i75edsxkdr8f");

                entity.HasIndex(e => e.DeviceName)
                    .HasName("uk_c5cof80jx0oopvovf3p4jv4l8");

                entity.HasIndex(e => e.ExporterId)
                    .HasName("uk_q7gmfr3aog1hateydhfeiu7si");

                entity.HasIndex(e => e.QueueMsgFk)
                    .HasName("fk_g6atpiywpo2100kn6ovix7uet");

                entity.HasIndex(e => e.ScheduledTime)
                    .HasName("uk_j1t0mj3vlmf5xwt4fs5xida1r");

                entity.HasIndex(e => e.UpdatedTime)
                    .HasName("uk_p5jjs08sdp9oecvr93r2g0kyq");

                entity.HasIndex(e => new { e.StudyIuid, e.SeriesIuid, e.SopIuid })
                    .HasName("uk_hb9rftf7opmg56nkg7dkvsdc8");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.BatchId)
                    .HasColumnName("batch_id")
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasColumnName("device_name")
                    .HasMaxLength(255);

                entity.Property(e => e.ExporterId)
                    .IsRequired()
                    .HasColumnName("exporter_id")
                    .HasMaxLength(255);

                entity.Property(e => e.Modalities)
                    .HasColumnName("modalities")
                    .HasMaxLength(255);

                entity.Property(e => e.NumInstances).HasColumnName("num_instances");

                entity.Property(e => e.QueueMsgFk).HasColumnName("queue_msg_fk");

                entity.Property(e => e.ScheduledTime).HasColumnName("scheduled_time");

                entity.Property(e => e.SeriesIuid)
                    .IsRequired()
                    .HasColumnName("series_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.SopIuid)
                    .IsRequired()
                    .HasColumnName("sop_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.StudyIuid)
                    .IsRequired()
                    .HasColumnName("study_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");

                entity.Property(e => e.Version).HasColumnName("version");

                entity.HasOne(d => d.QueueMsgFkNavigation)
                    .WithMany(p => p.ExportTask)
                    .HasForeignKey(d => d.QueueMsgFk)
                    .HasConstraintName("fk_g6atpiywpo2100kn6ovix7uet");
            });

            modelBuilder.Entity<GlobalSubscription>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("global_subscription_pkey");

                entity.ToTable("global_subscription");

                entity.HasIndex(e => e.MatchkeysFk)
                    .HasName("fk_f1l196ykcnh7s2pwo6qnmltw7");

                entity.HasIndex(e => e.SubscriberAet)
                    .HasName("uk_4n26cxir6d3tksb2cd1kd86ch")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeletionLock).HasColumnName("deletion_lock");

                entity.Property(e => e.MatchkeysFk).HasColumnName("matchkeys_fk");

                entity.Property(e => e.SubscriberAet)
                    .IsRequired()
                    .HasColumnName("subscriber_aet")
                    .HasMaxLength(255);

                entity.HasOne(d => d.MatchkeysFkNavigation)
                    .WithMany(p => p.GlobalSubscription)
                    .HasForeignKey(d => d.MatchkeysFk)
                    .HasConstraintName("fk_f1l196ykcnh7s2pwo6qnmltw7");
            });

            modelBuilder.Entity<Hl7psuTask>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("hl7psu_task_pkey");

                entity.ToTable("hl7psu_task");

                entity.HasIndex(e => e.DeviceName)
                    .HasName("uk_t0y05h07d9dagn9a4a9s4a5a4");

                entity.HasIndex(e => e.MppsFk)
                    .HasName("fk_pev4urgkk7id2h1ijhv8domjx");

                entity.HasIndex(e => e.StudyIuid)
                    .HasName("uk_p5fraoqdbaywmlyumaeo16t56")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aet)
                    .IsRequired()
                    .HasColumnName("aet")
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasColumnName("device_name")
                    .HasMaxLength(255);

                entity.Property(e => e.MppsFk).HasColumnName("mpps_fk");

                entity.Property(e => e.ScheduledTime).HasColumnName("scheduled_time");

                entity.Property(e => e.SeriesIuid)
                    .HasColumnName("series_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.StudyIuid)
                    .HasColumnName("study_iuid")
                    .HasMaxLength(255);

                entity.HasOne(d => d.MppsFkNavigation)
                    .WithMany(p => p.Hl7psuTask)
                    .HasForeignKey(d => d.MppsFk)
                    .HasConstraintName("fk_pev4urgkk7id2h1ijhv8domjx");
            });

            modelBuilder.Entity<IanTask>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("ian_task_pkey");

                entity.ToTable("ian_task");

                entity.HasIndex(e => e.DeviceName)
                    .HasName("uk_5shiir23exao1xpy2n5gvasrh");

                entity.HasIndex(e => e.MppsFk)
                    .HasName("fk_1fuh251le2hid2byw90hd1mly");

                entity.HasIndex(e => e.StudyIuid)
                    .HasName("uk_dq88edcjjxh7h92f89y5ueast")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.CallingAet)
                    .IsRequired()
                    .HasColumnName("calling_aet")
                    .HasMaxLength(255);

                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasColumnName("device_name")
                    .HasMaxLength(255);

                entity.Property(e => e.IanDests)
                    .IsRequired()
                    .HasColumnName("ian_dests")
                    .HasMaxLength(255);

                entity.Property(e => e.MppsFk).HasColumnName("mpps_fk");

                entity.Property(e => e.ScheduledTime).HasColumnName("scheduled_time");

                entity.Property(e => e.StudyIuid)
                    .HasColumnName("study_iuid")
                    .HasMaxLength(255);

                entity.HasOne(d => d.MppsFkNavigation)
                    .WithMany(p => p.IanTask)
                    .HasForeignKey(d => d.MppsFk)
                    .HasConstraintName("fk_1fuh251le2hid2byw90hd1mly");
            });

            modelBuilder.Entity<IdSequence>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("id_sequence_pkey");

                entity.ToTable("id_sequence");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.NextValue).HasColumnName("next_value");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<Instance>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("instance_pkey");

                entity.ToTable("instance");

                entity.HasIndex(e => e.ContentDate)
                    .HasName("uk_5ikkfk17vijvsvtyied2xa225");

                entity.HasIndex(e => e.ContentTime)
                    .HasName("uk_pck1ovyd4t96mjkbbw6f8jiam");

                entity.HasIndex(e => e.DicomattrsFk)
                    .HasName("uk_jxfu47kwjk3kkkyrwewjw8a4n")
                    .IsUnique();

                entity.HasIndex(e => e.InstCustom1)
                    .HasName("uk_fncb1s641rrnoek7j47k0j06n");

                entity.HasIndex(e => e.InstCustom2)
                    .HasName("uk_rr1ro1oxv6s4riib9hjkcuvuo");

                entity.HasIndex(e => e.InstCustom3)
                    .HasName("uk_q5i0hxt1iyahxjiroux2h8imm");

                entity.HasIndex(e => e.InstNo)
                    .HasName("uk_ouh6caecancvsa05lknojy30j");

                entity.HasIndex(e => e.SeriesFk)
                    .HasName("fk_s4tgrew4sh4qxoupmk3gihtrk");

                entity.HasIndex(e => e.SopCuid)
                    .HasName("uk_dglm8ndp9y9i0uo6fgaa5rhbb");

                entity.HasIndex(e => e.SopIuid)
                    .HasName("uk_eg0khesxr81gdimwhjiyrylw7");

                entity.HasIndex(e => e.SrComplete)
                    .HasName("uk_gisd09x31lphi4437hwgh7ihg");

                entity.HasIndex(e => e.SrVerified)
                    .HasName("uk_qh8jqpe8ulsb5t7iv24scho00");

                entity.HasIndex(e => e.SrcodeFk)
                    .HasName("fk_7w6f9bi2w91qr2abl6ddxnrwq");

                entity.HasIndex(e => new { e.SeriesFk, e.SopIuid })
                    .HasName("uk_247lgirehl8i2vuanyfjnuyjb")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.Availability).HasColumnName("availability");

                entity.Property(e => e.ContentDate)
                    .IsRequired()
                    .HasColumnName("content_date")
                    .HasMaxLength(255);

                entity.Property(e => e.ContentTime)
                    .IsRequired()
                    .HasColumnName("content_time")
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.DicomattrsFk).HasColumnName("dicomattrs_fk");

                entity.Property(e => e.ExtRetrieveAet)
                    .HasColumnName("ext_retrieve_aet")
                    .HasMaxLength(255);

                entity.Property(e => e.InstCustom1)
                    .IsRequired()
                    .HasColumnName("inst_custom1")
                    .HasMaxLength(255);

                entity.Property(e => e.InstCustom2)
                    .IsRequired()
                    .HasColumnName("inst_custom2")
                    .HasMaxLength(255);

                entity.Property(e => e.InstCustom3)
                    .IsRequired()
                    .HasColumnName("inst_custom3")
                    .HasMaxLength(255);

                entity.Property(e => e.InstNo).HasColumnName("inst_no");

                entity.Property(e => e.NumFrames).HasColumnName("num_frames");

                entity.Property(e => e.RetrieveAets)
                    .HasColumnName("retrieve_aets")
                    .HasMaxLength(255);

                entity.Property(e => e.SeriesFk).HasColumnName("series_fk");

                entity.Property(e => e.SopCuid)
                    .IsRequired()
                    .HasColumnName("sop_cuid")
                    .HasMaxLength(255);

                entity.Property(e => e.SopIuid)
                    .IsRequired()
                    .HasColumnName("sop_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.SrComplete)
                    .IsRequired()
                    .HasColumnName("sr_complete")
                    .HasMaxLength(255);

                entity.Property(e => e.SrVerified)
                    .IsRequired()
                    .HasColumnName("sr_verified")
                    .HasMaxLength(255);

                entity.Property(e => e.SrcodeFk).HasColumnName("srcode_fk");

                entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");

                entity.Property(e => e.Version).HasColumnName("version");

                entity.HasOne(d => d.DicomattrsFkNavigation)
                    .WithOne(p => p.Instance)
                    .HasForeignKey<Instance>(d => d.DicomattrsFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_jxfu47kwjk3kkkyrwewjw8a4n");

                entity.HasOne(d => d.SeriesFkNavigation)
                    .WithMany(p => p.Instance)
                    .HasForeignKey(d => d.SeriesFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_s4tgrew4sh4qxoupmk3gihtrk");

                entity.HasOne(d => d.SrcodeFkNavigation)
                    .WithMany(p => p.Instance)
                    .HasForeignKey(d => d.SrcodeFk)
                    .HasConstraintName("fk_7w6f9bi2w91qr2abl6ddxnrwq");
            });

            modelBuilder.Entity<Issuer>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("issuer_pkey");

                entity.ToTable("issuer");

                entity.HasIndex(e => e.EntityId)
                    .HasName("uk_gknfxd1vh283cmbg8ymia9ms8")
                    .IsUnique();

                entity.HasIndex(e => new { e.EntityUid, e.EntityUidType })
                    .HasName("uk_t1p7jajas0mu12sx8jvtp2y0f")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.EntityId)
                    .HasColumnName("entity_id")
                    .HasMaxLength(255);

                entity.Property(e => e.EntityUid)
                    .HasColumnName("entity_uid")
                    .HasMaxLength(255);

                entity.Property(e => e.EntityUidType)
                    .HasColumnName("entity_uid_type")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("location_pkey");

                entity.ToTable("location");

                entity.HasIndex(e => e.InstanceFk)
                    .HasName("fk_hjtlcwsvwihs4khh961d423e7");

                entity.HasIndex(e => e.MultiRef)
                    .HasName("uk_i1lnahmehau3r3j9pdyxg3p3y");

                entity.HasIndex(e => e.UidmapFk)
                    .HasName("fk_bfk5vl6eoxaf0hhwiu3rbgmkn");

                entity.HasIndex(e => new { e.StorageId, e.Status })
                    .HasName("uk_r3oh859i9osv3aluoc8dcx9wk");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.Digest)
                    .HasColumnName("digest")
                    .HasMaxLength(255);

                entity.Property(e => e.InstanceFk).HasColumnName("instance_fk");

                entity.Property(e => e.MultiRef).HasColumnName("multi_ref");

                entity.Property(e => e.ObjectSize).HasColumnName("object_size");

                entity.Property(e => e.ObjectType).HasColumnName("object_type");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StorageId)
                    .IsRequired()
                    .HasColumnName("storage_id")
                    .HasMaxLength(255);

                entity.Property(e => e.StoragePath)
                    .IsRequired()
                    .HasColumnName("storage_path")
                    .HasMaxLength(255);

                entity.Property(e => e.TeletipMesaj).HasMaxLength(4000);

                entity.Property(e => e.Tsuid)
                    .HasColumnName("tsuid")
                    .HasMaxLength(255);

                entity.Property(e => e.UidmapFk).HasColumnName("uidmap_fk");

                entity.HasOne(d => d.InstanceFkNavigation)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.InstanceFk)
                    .HasConstraintName("fk_hjtlcwsvwihs4khh961d423e7");

                entity.HasOne(d => d.UidmapFkNavigation)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.UidmapFk)
                    .HasConstraintName("fk_bfk5vl6eoxaf0hhwiu3rbgmkn");
            });

            modelBuilder.Entity<Metadata>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("metadata_pkey");

                entity.ToTable("metadata");

                entity.HasIndex(e => new { e.StorageId, e.Status })
                    .HasName("uk_f7c9hmq8pfypohkgkp5vkbhxp");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.Digest)
                    .HasColumnName("digest")
                    .HasMaxLength(255);

                entity.Property(e => e.ObjectSize).HasColumnName("object_size");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StorageId)
                    .IsRequired()
                    .HasColumnName("storage_id")
                    .HasMaxLength(255);

                entity.Property(e => e.StoragePath)
                    .IsRequired()
                    .HasColumnName("storage_path")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Mpps>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("mpps_pkey");

                entity.ToTable("mpps");

                entity.HasIndex(e => e.AccnoIssuerFk)
                    .HasName("fk_grl2idmms10qq4lhmh909jxtj");

                entity.HasIndex(e => e.DicomattrsFk)
                    .HasName("uk_o49fec996jvdo31o7ysmsn9s2")
                    .IsUnique();

                entity.HasIndex(e => e.DiscreasonCodeFk)
                    .HasName("fk_nrigpgue611m33rao03nnfe5l");

                entity.HasIndex(e => e.PatientFk)
                    .HasName("fk_ofg0lvfxad6r5oigw3y6da27u");

                entity.HasIndex(e => e.SopIuid)
                    .HasName("uk_cyqglxijg7kebbj6oj821yx4d")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccessionNo)
                    .IsRequired()
                    .HasColumnName("accession_no")
                    .HasMaxLength(255);

                entity.Property(e => e.AccnoIssuerFk).HasColumnName("accno_issuer_fk");

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.DicomattrsFk).HasColumnName("dicomattrs_fk");

                entity.Property(e => e.DiscreasonCodeFk).HasColumnName("discreason_code_fk");

                entity.Property(e => e.PatientFk).HasColumnName("patient_fk");

                entity.Property(e => e.PpsStartDate)
                    .IsRequired()
                    .HasColumnName("pps_start_date")
                    .HasMaxLength(255);

                entity.Property(e => e.PpsStartTime)
                    .IsRequired()
                    .HasColumnName("pps_start_time")
                    .HasMaxLength(255);

                entity.Property(e => e.PpsStatus).HasColumnName("pps_status");

                entity.Property(e => e.SopIuid)
                    .IsRequired()
                    .HasColumnName("sop_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.StudyIuid)
                    .IsRequired()
                    .HasColumnName("study_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");

                entity.Property(e => e.Version).HasColumnName("version");

                entity.HasOne(d => d.AccnoIssuerFkNavigation)
                    .WithMany(p => p.Mpps)
                    .HasForeignKey(d => d.AccnoIssuerFk)
                    .HasConstraintName("fk_grl2idmms10qq4lhmh909jxtj");

                entity.HasOne(d => d.DicomattrsFkNavigation)
                    .WithOne(p => p.Mpps)
                    .HasForeignKey<Mpps>(d => d.DicomattrsFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_o49fec996jvdo31o7ysmsn9s2");

                entity.HasOne(d => d.DiscreasonCodeFkNavigation)
                    .WithMany(p => p.Mpps)
                    .HasForeignKey(d => d.DiscreasonCodeFk)
                    .HasConstraintName("fk_nrigpgue611m33rao03nnfe5l");

                entity.HasOne(d => d.PatientFkNavigation)
                    .WithMany(p => p.Mpps)
                    .HasForeignKey(d => d.PatientFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ofg0lvfxad6r5oigw3y6da27u");
            });

            modelBuilder.Entity<MwlItem>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("mwl_item_pkey");

                entity.ToTable("mwl_item");

                entity.HasIndex(e => e.AccessionNo)
                    .HasName("uk_pw8h1b4sac2sr9estyqr82pcf");

                entity.HasIndex(e => e.AccnoIssuerFk)
                    .HasName("fk_ot32lpvialton54xqh636c4it");

                entity.HasIndex(e => e.AdmidIssuerFk)
                    .HasName("fk_9k8x73a91nd9q7ux7h5itkyh5");

                entity.HasIndex(e => e.AdmissionId)
                    .HasName("uk_tlkw80b7pbutfj19vh6et2vs7");

                entity.HasIndex(e => e.Department)
                    .HasName("uk_ksy3uy0rvpis1sqqeojlet7lb");

                entity.HasIndex(e => e.DeptCodeFk)
                    .HasName("fk_hqecoo67sflk190dxyc0hnf0c");

                entity.HasIndex(e => e.DicomattrsFk)
                    .HasName("uk_6qj8tkh6ib9w2pjqwvqe23ko")
                    .IsUnique();

                entity.HasIndex(e => e.InstCodeFk)
                    .HasName("fk_t4vpsywvy0axeutmdgc0ye3nk");

                entity.HasIndex(e => e.Institution)
                    .HasName("uk_8qkftk7n30hla3v1frep9vg2q");

                entity.HasIndex(e => e.LocalAet)
                    .HasName("uk_9ockpkbetj7a97for0s1jhasi");

                entity.HasIndex(e => e.Modality)
                    .HasName("uk_q28149iaxebyt3de2h5sm2bgl");

                entity.HasIndex(e => e.PatientFk)
                    .HasName("fk_vkxtls2wr17wgxnxj7b2fe32");

                entity.HasIndex(e => e.PerfPhysNameFk)
                    .HasName("fk_44qwwvs50lgpog2cqmicxgt1f");

                entity.HasIndex(e => e.ReqProcId)
                    .HasName("uk_kedi0qimmvs83af3jxk471uxn");

                entity.HasIndex(e => e.SpsId)
                    .HasName("uk_2odo3oah39o400thy9bf0rgv0");

                entity.HasIndex(e => e.SpsStartDate)
                    .HasName("uk_9oh3yd4prp9sfys4n0p2kd69y");

                entity.HasIndex(e => e.SpsStartTime)
                    .HasName("uk_m20xnkg1iqetifvuegehbhekm");

                entity.HasIndex(e => e.SpsStatus)
                    .HasName("uk_3oigo76r1a7et491bkci96km8");

                entity.HasIndex(e => e.StudyIuid)
                    .HasName("uk_fpfq8q514gsime2dl8oo773d4");

                entity.HasIndex(e => e.UpdatedTime)
                    .HasName("uk_d0v5hjn1crha2nqbws4wj0yoj");

                entity.HasIndex(e => new { e.StudyIuid, e.SpsId })
                    .HasName("uk_lerlqlaghhcs0oaj5irux4qig")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccessionNo)
                    .IsRequired()
                    .HasColumnName("accession_no")
                    .HasMaxLength(255);

                entity.Property(e => e.AccnoIssuerFk).HasColumnName("accno_issuer_fk");

                entity.Property(e => e.AdmidIssuerFk).HasColumnName("admid_issuer_fk");

                entity.Property(e => e.AdmissionId)
                    .IsRequired()
                    .HasColumnName("admission_id")
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasColumnName("department")
                    .HasMaxLength(255);

                entity.Property(e => e.DeptCodeFk).HasColumnName("dept_code_fk");

                entity.Property(e => e.DicomattrsFk).HasColumnName("dicomattrs_fk");

                entity.Property(e => e.InstCodeFk).HasColumnName("inst_code_fk");

                entity.Property(e => e.Institution)
                    .IsRequired()
                    .HasColumnName("institution")
                    .HasMaxLength(255);

                entity.Property(e => e.LocalAet)
                    .IsRequired()
                    .HasColumnName("local_aet")
                    .HasMaxLength(255);

                entity.Property(e => e.Modality)
                    .IsRequired()
                    .HasColumnName("modality")
                    .HasMaxLength(255);

                entity.Property(e => e.PatientFk).HasColumnName("patient_fk");

                entity.Property(e => e.PerfPhysNameFk).HasColumnName("perf_phys_name_fk");

                entity.Property(e => e.ReqProcId)
                    .IsRequired()
                    .HasColumnName("req_proc_id")
                    .HasMaxLength(255);

                entity.Property(e => e.SpsId)
                    .IsRequired()
                    .HasColumnName("sps_id")
                    .HasMaxLength(255);

                entity.Property(e => e.SpsStartDate)
                    .IsRequired()
                    .HasColumnName("sps_start_date")
                    .HasMaxLength(255);

                entity.Property(e => e.SpsStartTime)
                    .IsRequired()
                    .HasColumnName("sps_start_time")
                    .HasMaxLength(255);

                entity.Property(e => e.SpsStatus).HasColumnName("sps_status");

                entity.Property(e => e.StudyIuid)
                    .IsRequired()
                    .HasColumnName("study_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");

                entity.Property(e => e.Version).HasColumnName("version");

                entity.HasOne(d => d.AccnoIssuerFkNavigation)
                    .WithMany(p => p.MwlItemAccnoIssuerFkNavigation)
                    .HasForeignKey(d => d.AccnoIssuerFk)
                    .HasConstraintName("fk_ot32lpvialton54xqh636c4it");

                entity.HasOne(d => d.AdmidIssuerFkNavigation)
                    .WithMany(p => p.MwlItemAdmidIssuerFkNavigation)
                    .HasForeignKey(d => d.AdmidIssuerFk)
                    .HasConstraintName("fk_9k8x73a91nd9q7ux7h5itkyh5");

                entity.HasOne(d => d.DeptCodeFkNavigation)
                    .WithMany(p => p.MwlItemDeptCodeFkNavigation)
                    .HasForeignKey(d => d.DeptCodeFk)
                    .HasConstraintName("fk_hqecoo67sflk190dxyc0hnf0c");

                entity.HasOne(d => d.DicomattrsFkNavigation)
                    .WithOne(p => p.MwlItem)
                    .HasForeignKey<MwlItem>(d => d.DicomattrsFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_6qj8tkh6ib9w2pjqwvqe23ko");

                entity.HasOne(d => d.InstCodeFkNavigation)
                    .WithMany(p => p.MwlItemInstCodeFkNavigation)
                    .HasForeignKey(d => d.InstCodeFk)
                    .HasConstraintName("fk_t4vpsywvy0axeutmdgc0ye3nk");

                entity.HasOne(d => d.PatientFkNavigation)
                    .WithMany(p => p.MwlItem)
                    .HasForeignKey(d => d.PatientFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vkxtls2wr17wgxnxj7b2fe32");

                entity.HasOne(d => d.PerfPhysNameFkNavigation)
                    .WithMany(p => p.MwlItem)
                    .HasForeignKey(d => d.PerfPhysNameFk)
                    .HasConstraintName("fk_44qwwvs50lgpog2cqmicxgt1f");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("patient_pkey");

                entity.ToTable("patient");

                entity.HasIndex(e => e.DicomattrsFk)
                    .HasName("uk_5lgndn3gn7iug3kuewiy9q124")
                    .IsUnique();

                entity.HasIndex(e => e.MergeFk)
                    .HasName("fk_sk77bwjgaoetvy1pbcgqf08g");

                entity.HasIndex(e => e.NumStudies)
                    .HasName("uk_296rccryifu6d8byisl2f4dvq");

                entity.HasIndex(e => e.PatBirthdate)
                    .HasName("uk_1ho1jyofty54ip8aqpuhi4mu1");

                entity.HasIndex(e => e.PatCustom1)
                    .HasName("uk_9f2m2lkijm7wi0hpjsime069n");

                entity.HasIndex(e => e.PatCustom2)
                    .HasName("uk_dwp6no1c4624yii6sbo59fedg");

                entity.HasIndex(e => e.PatCustom3)
                    .HasName("uk_3ioui3yamjf01yny98bliqfgs");

                entity.HasIndex(e => e.PatNameFk)
                    .HasName("fk_rj42ffdtimnrcwmqqlvj24gi2");

                entity.HasIndex(e => e.PatSex)
                    .HasName("uk_545wp9un24fhgcy2lcfu1o04y");

                entity.HasIndex(e => e.PatientIdFk)
                    .HasName("fk_39gahcxyursxfxe2ucextr65s");

                entity.HasIndex(e => e.RespPersonFk)
                    .HasName("fk_56r2g5ggptqgcvb3hl11adke2");

                entity.HasIndex(e => e.VerificationStatus)
                    .HasName("uk_e7rsyrt9n2mccyv1fcd2s6ikv");

                entity.HasIndex(e => e.VerificationTime)
                    .HasName("uk_bay8wkvwegw3pmyeypv2v93k1");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.DicomattrsFk).HasColumnName("dicomattrs_fk");

                entity.Property(e => e.FailedVerifications).HasColumnName("failed_verifications");

                entity.Property(e => e.MergeFk).HasColumnName("merge_fk");

                entity.Property(e => e.NumStudies).HasColumnName("num_studies");

                entity.Property(e => e.PatBirthdate)
                    .IsRequired()
                    .HasColumnName("pat_birthdate")
                    .HasMaxLength(255);

                entity.Property(e => e.PatCustom1)
                    .IsRequired()
                    .HasColumnName("pat_custom1")
                    .HasMaxLength(255);

                entity.Property(e => e.PatCustom2)
                    .IsRequired()
                    .HasColumnName("pat_custom2")
                    .HasMaxLength(255);

                entity.Property(e => e.PatCustom3)
                    .IsRequired()
                    .HasColumnName("pat_custom3")
                    .HasMaxLength(255);

                entity.Property(e => e.PatNameFk).HasColumnName("pat_name_fk");

                entity.Property(e => e.PatSex)
                    .IsRequired()
                    .HasColumnName("pat_sex")
                    .HasMaxLength(255);

                entity.Property(e => e.PatientIdFk).HasColumnName("patient_id_fk");

                entity.Property(e => e.RespPersonFk).HasColumnName("resp_person_fk");

                entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");

                entity.Property(e => e.VerificationStatus).HasColumnName("verification_status");

                entity.Property(e => e.VerificationTime).HasColumnName("verification_time");

                entity.Property(e => e.Version).HasColumnName("version");

                entity.HasOne(d => d.DicomattrsFkNavigation)
                    .WithOne(p => p.Patient)
                    .HasForeignKey<Patient>(d => d.DicomattrsFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_5lgndn3gn7iug3kuewiy9q124");

                entity.HasOne(d => d.MergeFkNavigation)
                    .WithMany(p => p.InverseMergeFkNavigation)
                    .HasForeignKey(d => d.MergeFk)
                    .HasConstraintName("fk_sk77bwjgaoetvy1pbcgqf08g");

                entity.HasOne(d => d.PatNameFkNavigation)
                    .WithMany(p => p.PatientPatNameFkNavigation)
                    .HasForeignKey(d => d.PatNameFk)
                    .HasConstraintName("fk_rj42ffdtimnrcwmqqlvj24gi2");

                entity.HasOne(d => d.PatientIdFkNavigation)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.PatientIdFk)
                    .HasConstraintName("fk_39gahcxyursxfxe2ucextr65s");

                entity.HasOne(d => d.RespPersonFkNavigation)
                    .WithMany(p => p.PatientRespPersonFkNavigation)
                    .HasForeignKey(d => d.RespPersonFk)
                    .HasConstraintName("fk_56r2g5ggptqgcvb3hl11adke2");
            });

            modelBuilder.Entity<PatientId>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("patient_id_pkey");

                entity.ToTable("patient_id");

                entity.HasIndex(e => e.IssuerFk)
                    .HasName("fk_oo232lt89k1b5h8mberi9v152");

                entity.HasIndex(e => new { e.PatId, e.IssuerFk })
                    .HasName("uk_31gvi9falc03xs94m8l3pgoid")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.IssuerFk).HasColumnName("issuer_fk");

                entity.Property(e => e.PatId)
                    .IsRequired()
                    .HasColumnName("pat_id")
                    .HasMaxLength(255);

                entity.Property(e => e.PatIdTypeCode)
                    .HasColumnName("pat_id_type_code")
                    .HasMaxLength(255);

                entity.Property(e => e.Version).HasColumnName("version");

                entity.HasOne(d => d.IssuerFkNavigation)
                    .WithMany(p => p.PatientId)
                    .HasForeignKey(d => d.IssuerFk)
                    .HasConstraintName("fk_oo232lt89k1b5h8mberi9v152");
            });

            modelBuilder.Entity<PersonName>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("person_name_pkey");

                entity.ToTable("person_name");

                entity.HasIndex(e => e.FamilyName)
                    .HasName("uk_mgrwrswyrk02s1kn86cvpix3m");

                entity.HasIndex(e => e.GivenName)
                    .HasName("uk_byvbmsx5w9jop12gdqldogbwm");

                entity.HasIndex(e => e.IFamilyName)
                    .HasName("uk_l3prcvmx90pdclj84s6uvbblm");

                entity.HasIndex(e => e.IGivenName)
                    .HasName("uk_tgh0ek52g7cpioire3qwdweoi");

                entity.HasIndex(e => e.IMiddleName)
                    .HasName("uk_lwnfdvx2cknj9ravec592642d");

                entity.HasIndex(e => e.MiddleName)
                    .HasName("uk_hop27c6p2aiabl0ei6rj7oohi");

                entity.HasIndex(e => e.PFamilyName)
                    .HasName("uk_2189yvio0mae92hjhgbfwqgvc");

                entity.HasIndex(e => e.PGivenName)
                    .HasName("uk_6cn50unrp2u9xf6authiollrr");

                entity.HasIndex(e => e.PMiddleName)
                    .HasName("uk_kungbb1r2qtt9aq0vsb1l68y6");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.FamilyName)
                    .HasColumnName("family_name")
                    .HasMaxLength(255);

                entity.Property(e => e.GivenName)
                    .HasColumnName("given_name")
                    .HasMaxLength(255);

                entity.Property(e => e.IFamilyName)
                    .HasColumnName("i_family_name")
                    .HasMaxLength(255);

                entity.Property(e => e.IGivenName)
                    .HasColumnName("i_given_name")
                    .HasMaxLength(255);

                entity.Property(e => e.IMiddleName)
                    .HasColumnName("i_middle_name")
                    .HasMaxLength(255);

                entity.Property(e => e.INamePrefix)
                    .HasColumnName("i_name_prefix")
                    .HasMaxLength(255);

                entity.Property(e => e.INameSuffix)
                    .HasColumnName("i_name_suffix")
                    .HasMaxLength(255);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middle_name")
                    .HasMaxLength(255);

                entity.Property(e => e.NamePrefix)
                    .HasColumnName("name_prefix")
                    .HasMaxLength(255);

                entity.Property(e => e.NameSuffix)
                    .HasColumnName("name_suffix")
                    .HasMaxLength(255);

                entity.Property(e => e.PFamilyName)
                    .HasColumnName("p_family_name")
                    .HasMaxLength(255);

                entity.Property(e => e.PGivenName)
                    .HasColumnName("p_given_name")
                    .HasMaxLength(255);

                entity.Property(e => e.PMiddleName)
                    .HasColumnName("p_middle_name")
                    .HasMaxLength(255);

                entity.Property(e => e.PNamePrefix)
                    .HasColumnName("p_name_prefix")
                    .HasMaxLength(255);

                entity.Property(e => e.PNameSuffix)
                    .HasColumnName("p_name_suffix")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<QueueMsg>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("queue_msg_pkey");

                entity.ToTable("queue_msg");

                entity.HasIndex(e => e.BatchId)
                    .HasName("uk_ln9rs61la03lhvgiv8c2wehnr");

                entity.HasIndex(e => e.CreatedTime)
                    .HasName("uk_jfyulc3fo7cmn29sbha0l72m3");

                entity.HasIndex(e => e.DeviceName)
                    .HasName("uk_kvtxqtdow67hcr2wv8irtdwqy");

                entity.HasIndex(e => e.MsgId)
                    .HasName("uk_k520j369nwx6rpbkvlp4kn623")
                    .IsUnique();

                entity.HasIndex(e => e.MsgStatus)
                    .HasName("uk_o8pu8axwpcm4chqxy75y09gpo");

                entity.HasIndex(e => e.QueueName)
                    .HasName("uk_b5mbe6jenklf1r5wp5csrvf67");

                entity.HasIndex(e => e.UpdatedTime)
                    .HasName("uk_gsdfgth9kxjat98cmabtj8x1h");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.BatchId)
                    .HasColumnName("batch_id")
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasColumnName("device_name")
                    .HasMaxLength(255);

                entity.Property(e => e.ErrorMsg)
                    .HasColumnName("error_msg")
                    .HasMaxLength(255);

                entity.Property(e => e.MsgBody)
                    .IsRequired()
                    .HasColumnName("msg_body");

                entity.Property(e => e.MsgId)
                    .IsRequired()
                    .HasColumnName("msg_id")
                    .HasMaxLength(255);

                entity.Property(e => e.MsgProps)
                    .IsRequired()
                    .HasColumnName("msg_props")
                    .HasMaxLength(4000);

                entity.Property(e => e.MsgStatus).HasColumnName("msg_status");

                entity.Property(e => e.NumFailures).HasColumnName("num_failures");

                entity.Property(e => e.OutcomeMsg)
                    .HasColumnName("outcome_msg")
                    .HasMaxLength(255);

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.ProcEndTime).HasColumnName("proc_end_time");

                entity.Property(e => e.ProcStartTime).HasColumnName("proc_start_time");

                entity.Property(e => e.QueueName)
                    .IsRequired()
                    .HasColumnName("queue_name")
                    .HasMaxLength(255);

                entity.Property(e => e.ScheduledTime).HasColumnName("scheduled_time");

                entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<RejectedInstance>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("rejected_instance_pkey");

                entity.ToTable("rejected_instance");

                entity.HasIndex(e => e.CreatedTime)
                    .HasName("uk_owm55at56tdjitsncsrhr93xj");

                entity.HasIndex(e => e.RejectCodeFk)
                    .HasName("fk_iafiq2ugv5rd6fonwd0vd7xdx");

                entity.HasIndex(e => new { e.StudyIuid, e.SeriesIuid, e.SopIuid })
                    .HasName("uk_6liqevdmi0spifxf2vrh18wkp")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.RejectCodeFk).HasColumnName("reject_code_fk");

                entity.Property(e => e.SeriesIuid)
                    .IsRequired()
                    .HasColumnName("series_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.SopCuid)
                    .IsRequired()
                    .HasColumnName("sop_cuid")
                    .HasMaxLength(255);

                entity.Property(e => e.SopIuid)
                    .IsRequired()
                    .HasColumnName("sop_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.StudyIuid)
                    .IsRequired()
                    .HasColumnName("study_iuid")
                    .HasMaxLength(255);

                entity.HasOne(d => d.RejectCodeFkNavigation)
                    .WithMany(p => p.RejectedInstance)
                    .HasForeignKey(d => d.RejectCodeFk)
                    .HasConstraintName("fk_iafiq2ugv5rd6fonwd0vd7xdx");
            });

            modelBuilder.Entity<RelStudyPcode>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("rel_study_pcode");

                entity.HasIndex(e => e.PcodeFk)
                    .HasName("fk_fryhnb2ppb6fcop3jrrfwvnfy");

                entity.HasIndex(e => e.StudyFk)
                    .HasName("fk_mnahh8fh77d365m6w2x4x3f4q");

                entity.Property(e => e.PcodeFk).HasColumnName("pcode_fk");

                entity.Property(e => e.StudyFk).HasColumnName("study_fk");

                entity.HasOne(d => d.PcodeFkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PcodeFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_fryhnb2ppb6fcop3jrrfwvnfy");

                entity.HasOne(d => d.StudyFkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.StudyFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mnahh8fh77d365m6w2x4x3f4q");
            });

            modelBuilder.Entity<RelUpsPerfCode>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("rel_ups_perf_code");

                entity.HasIndex(e => e.PerfCodeFk)
                    .HasName("fk_6asj28yy5se9mp443b6ryefd2");

                entity.HasIndex(e => e.UpsFk)
                    .HasName("fk_6m06tt8ku376qxkro94xpteus");

                entity.Property(e => e.PerfCodeFk).HasColumnName("perf_code_fk");

                entity.Property(e => e.UpsFk).HasColumnName("ups_fk");

                entity.HasOne(d => d.PerfCodeFkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PerfCodeFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_6asj28yy5se9mp443b6ryefd2");

                entity.HasOne(d => d.UpsFkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.UpsFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_6m06tt8ku376qxkro94xpteus");
            });

            modelBuilder.Entity<RetrieveTask>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("retrieve_task_pkey");

                entity.ToTable("retrieve_task");

                entity.HasIndex(e => e.BatchId)
                    .HasName("uk_ahkqwir2di2jm44jlhi22iw3e");

                entity.HasIndex(e => e.CreatedTime)
                    .HasName("uk_sf2g7oi8cfx89olwch9095hx7");

                entity.HasIndex(e => e.DestinationAet)
                    .HasName("uk_jgaej0gm9appih04n09qto8yh");

                entity.HasIndex(e => e.DeviceName)
                    .HasName("uk_djkqk3dls3xkru1n0c3p5rm3");

                entity.HasIndex(e => e.LocalAet)
                    .HasName("uk_a26s4yqy4rnpw7nniuyt7tkpo");

                entity.HasIndex(e => e.QueueMsgFk)
                    .HasName("fk_mxokt1gw5g1e7rc3ssotvuqix");

                entity.HasIndex(e => e.QueueName)
                    .HasName("uk_r866eptnxfw7plhxwtm3vks0e");

                entity.HasIndex(e => e.RemoteAet)
                    .HasName("uk_3avjusmul00fc3yi1notyh16j");

                entity.HasIndex(e => e.ScheduledTime)
                    .HasName("uk_rqp93vxrhyg09x3ck7vc1mawp");

                entity.HasIndex(e => e.StudyIuid)
                    .HasName("uk_gafcma0d5wwdjlq8jueqknlq0");

                entity.HasIndex(e => e.UpdatedTime)
                    .HasName("uk_e2lo4ep4t4k07njc09anf6xkm");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.BatchId)
                    .HasColumnName("batch_id")
                    .HasMaxLength(255);

                entity.Property(e => e.Completed).HasColumnName("completed");

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.DestinationAet)
                    .IsRequired()
                    .HasColumnName("destination_aet")
                    .HasMaxLength(255);

                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasColumnName("device_name")
                    .HasMaxLength(255);

                entity.Property(e => e.ErrorComment)
                    .HasColumnName("error_comment")
                    .HasMaxLength(255);

                entity.Property(e => e.Failed).HasColumnName("failed");

                entity.Property(e => e.LocalAet)
                    .IsRequired()
                    .HasColumnName("local_aet")
                    .HasMaxLength(255);

                entity.Property(e => e.QueueMsgFk).HasColumnName("queue_msg_fk");

                entity.Property(e => e.QueueName)
                    .IsRequired()
                    .HasColumnName("queue_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Remaining).HasColumnName("remaining");

                entity.Property(e => e.RemoteAet)
                    .IsRequired()
                    .HasColumnName("remote_aet")
                    .HasMaxLength(255);

                entity.Property(e => e.ScheduledTime).HasColumnName("scheduled_time");

                entity.Property(e => e.SeriesIuid)
                    .HasColumnName("series_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.SopIuid)
                    .HasColumnName("sop_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.StatusCode).HasColumnName("status_code");

                entity.Property(e => e.StudyIuid)
                    .IsRequired()
                    .HasColumnName("study_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");

                entity.Property(e => e.Warning).HasColumnName("warning");

                entity.HasOne(d => d.QueueMsgFkNavigation)
                    .WithMany(p => p.RetrieveTask)
                    .HasForeignKey(d => d.QueueMsgFk)
                    .HasConstraintName("fk_mxokt1gw5g1e7rc3ssotvuqix");
            });

            modelBuilder.Entity<Rise>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("rise", "rise");

                entity.Property(e => e.AeTitle)
                    .HasColumnName("ae_title")
                    .HasMaxLength(255);

                entity.Property(e => e.HospitalStudyInstanceuid)
                    .HasColumnName("hospital_study_instanceuid")
                    .HasMaxLength(1024);

                entity.Property(e => e.HospitaldataAccessionNumber)
                    .HasColumnName("hospitaldata_accession_number")
                    .HasMaxLength(255);

                entity.Property(e => e.HospitaldataCreatedtime).HasColumnName("hospitaldata_createdtime");

                entity.Property(e => e.HospitaldataDescription)
                    .HasColumnName("hospitaldata_description")
                    .HasMaxLength(255);

                entity.Property(e => e.HospitaldataPatientBirthdate)
                    .HasColumnName("hospitaldata_patient_birthdate")
                    .HasMaxLength(255);

                entity.Property(e => e.HospitaldataPatientName)
                    .HasColumnName("hospitaldata_patient_name")
                    .HasMaxLength(1024);

                entity.Property(e => e.HospitaldataPatientSex)
                    .HasColumnName("hospitaldata_patient_sex")
                    .HasMaxLength(255);

                entity.Property(e => e.HospitaldataPatientid)
                    .HasColumnName("hospitaldata_patientid")
                    .HasMaxLength(255);

                entity.Property(e => e.HospitaldataReferringPhysicianName)
                    .HasColumnName("hospitaldata_referring_physician_name")
                    .HasMaxLength(255);

                entity.Property(e => e.HospitaldataStudyid)
                    .HasColumnName("hospitaldata_studyid")
                    .HasMaxLength(255);

                entity.Property(e => e.Hospitalid).HasColumnName("hospitalid");

                entity.Property(e => e.InstanceCount).HasColumnName("instance_count");

                entity.Property(e => e.Modalityid)
                    .HasColumnName("modalityid")
                    .HasMaxLength(255);

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.TimeCreated).HasColumnName("time_created");
            });

            modelBuilder.Entity<Series>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("series_pkey");

                entity.ToTable("series");

                entity.HasIndex(e => e.BodyPart)
                    .HasName("uk_gwp46ofa26am9ohhccq1ohdj");

                entity.HasIndex(e => e.Completeness)
                    .HasName("uk_4lnegvfs65fbkjn7nmg9s8usy");

                entity.HasIndex(e => e.CompressFailures)
                    .HasName("uk_889438ocqfrvybu3k2eo65lpa");

                entity.HasIndex(e => e.CompressTime)
                    .HasName("uk_38mfgfnjhan2yhnwqtcrawe4");

                entity.HasIndex(e => e.Department)
                    .HasName("uk_bqu32v5v76p4qi0etptnrm0pc");

                entity.HasIndex(e => e.DeptCodeFk)
                    .HasName("fk_avp2oeuufo8axv5j184cchrop");

                entity.HasIndex(e => e.DicomattrsFk)
                    .HasName("uk_bdj2kuutidekc2en6dckev7l6")
                    .IsUnique();

                entity.HasIndex(e => e.ExpirationDate)
                    .HasName("uk_ta3pi6exqft5encv389hwjytw");

                entity.HasIndex(e => e.ExpirationState)
                    .HasName("uk_ih49lthl3udoca5opvgsdcerj");

                entity.HasIndex(e => e.FailedRetrieves)
                    .HasName("uk_j6aadbh7u93bpmv18s1inrl1r");

                entity.HasIndex(e => e.InstCodeFk)
                    .HasName("fk_oiq81nulcmtg6p85iu31igtf5");

                entity.HasIndex(e => e.InstPurgeState)
                    .HasName("uk_er4ife08f6eaki91gt3hxt5e");

                entity.HasIndex(e => e.InstPurgeTime)
                    .HasName("uk_a8vyikwd972jomyb3f6brcfh5");

                entity.HasIndex(e => e.Institution)
                    .HasName("uk_82qea56c0kdhod3b1wu8wbrny");

                entity.HasIndex(e => e.Laterality)
                    .HasName("uk_tbdrfrmkmifsqhpf43065jrbs");

                entity.HasIndex(e => e.MetadataFk)
                    .HasName("fk_pu4p7k1o9hleuk9rmxvw2ybj6");

                entity.HasIndex(e => e.MetadataUpdateFailures)
                    .HasName("uk_6xqpk4cvy49wj41p2qwixro8w");

                entity.HasIndex(e => e.MetadataUpdateTime)
                    .HasName("uk_hwkcpd7yv0nca7o918wm4bn69");

                entity.HasIndex(e => e.Modality)
                    .HasName("uk_b126hub0dc1o9dqp6awoispx2");

                entity.HasIndex(e => e.PerfPhysNameFk)
                    .HasName("fk_5n4bxxb2xa7bvvq26ao7wihky");

                entity.HasIndex(e => e.PpsStartDate)
                    .HasName("uk_rvlxc150uexwmr1l9ojp8fgd");

                entity.HasIndex(e => e.PpsStartTime)
                    .HasName("uk_amr00xwlatxewgj1sjp5mnf76");

                entity.HasIndex(e => e.RejectionState)
                    .HasName("uk_jlgy9ifvqak4g2bxkchismw8x");

                entity.HasIndex(e => e.SeriesCustom1)
                    .HasName("uk_hm39592a9n7m54dgso17irlhv");

                entity.HasIndex(e => e.SeriesCustom2)
                    .HasName("uk_q3wayt2ke25fdcghaohhrjiu7");

                entity.HasIndex(e => e.SeriesCustom3)
                    .HasName("uk_d8b8irasiw8eh9tsigmwkbvae");

                entity.HasIndex(e => e.SeriesDesc)
                    .HasName("uk_achxn1rtfm3fbkkswlsyr75t0");

                entity.HasIndex(e => e.SeriesIuid)
                    .HasName("uk_9fi64g5jjycg9dp24jjk5txg1");

                entity.HasIndex(e => e.SeriesNo)
                    .HasName("uk_75oc6w5ootkuwyvmrhe3tbown");

                entity.HasIndex(e => e.SopCuid)
                    .HasName("uk_mrn00m45lkq1xbehmbw5d9jbl");

                entity.HasIndex(e => e.StationName)
                    .HasName("uk_pq1yi70ftxhh391lhcq3e08nf");

                entity.HasIndex(e => e.StgverFailures)
                    .HasName("uk_s1vceb8cu9c45j0q8tbldgol9");

                entity.HasIndex(e => e.StgverTime)
                    .HasName("uk_ftv3ijh2ud6ogoknneyqc6t9i");

                entity.HasIndex(e => e.StudyFk)
                    .HasName("fk_1og1krtgxfh207rtqjg0r7pbd");

                entity.HasIndex(e => e.Tsuid)
                    .HasName("uk_tahx0q1ejidnsam40ans7oecx");

                entity.HasIndex(e => new { e.StudyFk, e.SeriesIuid })
                    .HasName("uk_83y2fx8cou17h3xggxspgikna")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.BodyPart)
                    .IsRequired()
                    .HasColumnName("body_part")
                    .HasMaxLength(255);

                entity.Property(e => e.Completeness).HasColumnName("completeness");

                entity.Property(e => e.CompressFailures).HasColumnName("compress_failures");

                entity.Property(e => e.CompressParams)
                    .HasColumnName("compress_params")
                    .HasMaxLength(255);

                entity.Property(e => e.CompressTime).HasColumnName("compress_time");

                entity.Property(e => e.CompressTsuid)
                    .HasColumnName("compress_tsuid")
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasColumnName("department")
                    .HasMaxLength(255);

                entity.Property(e => e.DeptCodeFk).HasColumnName("dept_code_fk");

                entity.Property(e => e.DicomattrsFk).HasColumnName("dicomattrs_fk");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnName("expiration_date")
                    .HasMaxLength(255);

                entity.Property(e => e.ExpirationExporterId)
                    .HasColumnName("expiration_exporter_id")
                    .HasMaxLength(255);

                entity.Property(e => e.ExpirationState).HasColumnName("expiration_state");

                entity.Property(e => e.ExtRetrieveAet)
                    .HasColumnName("ext_retrieve_aet")
                    .HasMaxLength(255);

                entity.Property(e => e.FailedRetrieves).HasColumnName("failed_retrieves");

                entity.Property(e => e.InstCodeFk).HasColumnName("inst_code_fk");

                entity.Property(e => e.InstPurgeState).HasColumnName("inst_purge_state");

                entity.Property(e => e.InstPurgeTime).HasColumnName("inst_purge_time");

                entity.Property(e => e.Institution)
                    .IsRequired()
                    .HasColumnName("institution")
                    .HasMaxLength(255);

                entity.Property(e => e.Laterality)
                    .IsRequired()
                    .HasColumnName("laterality")
                    .HasMaxLength(255);

                entity.Property(e => e.MetadataFk).HasColumnName("metadata_fk");

                entity.Property(e => e.MetadataUpdateFailures).HasColumnName("metadata_update_failures");

                entity.Property(e => e.MetadataUpdateTime).HasColumnName("metadata_update_time");

                entity.Property(e => e.Modality)
                    .IsRequired()
                    .HasColumnName("modality")
                    .HasMaxLength(255);

                entity.Property(e => e.PerfPhysNameFk).HasColumnName("perf_phys_name_fk");

                entity.Property(e => e.PpsCuid)
                    .IsRequired()
                    .HasColumnName("pps_cuid")
                    .HasMaxLength(255);

                entity.Property(e => e.PpsIuid)
                    .IsRequired()
                    .HasColumnName("pps_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.PpsStartDate)
                    .IsRequired()
                    .HasColumnName("pps_start_date")
                    .HasMaxLength(255);

                entity.Property(e => e.PpsStartTime)
                    .IsRequired()
                    .HasColumnName("pps_start_time")
                    .HasMaxLength(255);

                entity.Property(e => e.RejectionState).HasColumnName("rejection_state");

                entity.Property(e => e.SeriesCustom1)
                    .IsRequired()
                    .HasColumnName("series_custom1")
                    .HasMaxLength(255);

                entity.Property(e => e.SeriesCustom2)
                    .IsRequired()
                    .HasColumnName("series_custom2")
                    .HasMaxLength(255);

                entity.Property(e => e.SeriesCustom3)
                    .IsRequired()
                    .HasColumnName("series_custom3")
                    .HasMaxLength(255);

                entity.Property(e => e.SeriesDesc)
                    .IsRequired()
                    .HasColumnName("series_desc")
                    .HasMaxLength(255);

                entity.Property(e => e.SeriesIuid)
                    .IsRequired()
                    .HasColumnName("series_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.SeriesNo).HasColumnName("series_no");

                entity.Property(e => e.SeriesSize).HasColumnName("series_size");

                entity.Property(e => e.SopCuid)
                    .IsRequired()
                    .HasColumnName("sop_cuid")
                    .HasMaxLength(255);

                entity.Property(e => e.SrcAet)
                    .HasColumnName("src_aet")
                    .HasMaxLength(255);

                entity.Property(e => e.StationName)
                    .IsRequired()
                    .HasColumnName("station_name")
                    .HasMaxLength(255);

                entity.Property(e => e.StgverFailures).HasColumnName("stgver_failures");

                entity.Property(e => e.StgverTime).HasColumnName("stgver_time");

                entity.Property(e => e.StudyFk).HasColumnName("study_fk");

                entity.Property(e => e.Tsuid)
                    .IsRequired()
                    .HasColumnName("tsuid")
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");

                entity.Property(e => e.Version).HasColumnName("version");

                entity.HasOne(d => d.DeptCodeFkNavigation)
                    .WithMany(p => p.SeriesDeptCodeFkNavigation)
                    .HasForeignKey(d => d.DeptCodeFk)
                    .HasConstraintName("fk_avp2oeuufo8axv5j184cchrop");

                entity.HasOne(d => d.DicomattrsFkNavigation)
                    .WithOne(p => p.Series)
                    .HasForeignKey<Series>(d => d.DicomattrsFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_bdj2kuutidekc2en6dckev7l6");

                entity.HasOne(d => d.InstCodeFkNavigation)
                    .WithMany(p => p.SeriesInstCodeFkNavigation)
                    .HasForeignKey(d => d.InstCodeFk)
                    .HasConstraintName("fk_oiq81nulcmtg6p85iu31igtf5");

                entity.HasOne(d => d.MetadataFkNavigation)
                    .WithMany(p => p.Series)
                    .HasForeignKey(d => d.MetadataFk)
                    .HasConstraintName("fk_pu4p7k1o9hleuk9rmxvw2ybj6");

                entity.HasOne(d => d.PerfPhysNameFkNavigation)
                    .WithMany(p => p.Series)
                    .HasForeignKey(d => d.PerfPhysNameFk)
                    .HasConstraintName("fk_5n4bxxb2xa7bvvq26ao7wihky");

                entity.HasOne(d => d.StudyFkNavigation)
                    .WithMany(p => p.Series)
                    .HasForeignKey(d => d.StudyFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_1og1krtgxfh207rtqjg0r7pbd");
            });

            modelBuilder.Entity<SeriesQueryAttrs>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("series_query_attrs_pkey");

                entity.ToTable("series_query_attrs");

                entity.HasIndex(e => e.SeriesFk)
                    .HasName("fk_eiwosf6pcc97n6y282cv1n54k");

                entity.HasIndex(e => new { e.ViewId, e.SeriesFk })
                    .HasName("uk_t1uhb1suiiqffhsv9eaopeevs")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.Availability).HasColumnName("availability");

                entity.Property(e => e.CuidsInSeries)
                    .HasColumnName("cuids_in_series")
                    .HasMaxLength(255);

                entity.Property(e => e.NumInstances).HasColumnName("num_instances");

                entity.Property(e => e.RetrieveAets)
                    .HasColumnName("retrieve_aets")
                    .HasMaxLength(255);

                entity.Property(e => e.SeriesFk).HasColumnName("series_fk");

                entity.Property(e => e.ViewId)
                    .HasColumnName("view_id")
                    .HasMaxLength(255);

                entity.HasOne(d => d.SeriesFkNavigation)
                    .WithMany(p => p.SeriesQueryAttrs)
                    .HasForeignKey(d => d.SeriesFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_eiwosf6pcc97n6y282cv1n54k");
            });

            modelBuilder.Entity<SeriesReq>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("series_req_pkey");

                entity.ToTable("series_req");

                entity.HasIndex(e => e.AccessionNo)
                    .HasName("uk_m4wanupyq3yldxgh3pbo7t68h");

                entity.HasIndex(e => e.AccnoIssuerFk)
                    .HasName("fk_se4n39as61wwf92ggbfc9yglo");

                entity.HasIndex(e => e.ReqPhysNameFk)
                    .HasName("fk_bcn0jtvurqutw865pwp34pejb");

                entity.HasIndex(e => e.ReqProcId)
                    .HasName("uk_p9w1wg4031w6y66w4xhx1ffay");

                entity.HasIndex(e => e.ReqService)
                    .HasName("uk_l1fg3crmk6pjeu1x36e25h6p4");

                entity.HasIndex(e => e.SeriesFk)
                    .HasName("fk_bdkjk6ww0ulrb0nhf41c7liwt");

                entity.HasIndex(e => e.SpsId)
                    .HasName("uk_4uq79j30ind90jjs68gb24j6e");

                entity.HasIndex(e => e.StudyIuid)
                    .HasName("uk_crnpneoalwq25p795xtrhbx2");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccessionNo)
                    .IsRequired()
                    .HasColumnName("accession_no")
                    .HasMaxLength(255);

                entity.Property(e => e.AccnoIssuerFk).HasColumnName("accno_issuer_fk");

                entity.Property(e => e.ReqPhysNameFk).HasColumnName("req_phys_name_fk");

                entity.Property(e => e.ReqProcId)
                    .IsRequired()
                    .HasColumnName("req_proc_id")
                    .HasMaxLength(255);

                entity.Property(e => e.ReqService)
                    .IsRequired()
                    .HasColumnName("req_service")
                    .HasMaxLength(255);

                entity.Property(e => e.SeriesFk).HasColumnName("series_fk");

                entity.Property(e => e.SpsId)
                    .IsRequired()
                    .HasColumnName("sps_id")
                    .HasMaxLength(255);

                entity.Property(e => e.StudyIuid)
                    .IsRequired()
                    .HasColumnName("study_iuid")
                    .HasMaxLength(255);

                entity.HasOne(d => d.AccnoIssuerFkNavigation)
                    .WithMany(p => p.SeriesReq)
                    .HasForeignKey(d => d.AccnoIssuerFk)
                    .HasConstraintName("fk_se4n39as61wwf92ggbfc9yglo");

                entity.HasOne(d => d.ReqPhysNameFkNavigation)
                    .WithMany(p => p.SeriesReq)
                    .HasForeignKey(d => d.ReqPhysNameFk)
                    .HasConstraintName("fk_bcn0jtvurqutw865pwp34pejb");

                entity.HasOne(d => d.SeriesFkNavigation)
                    .WithMany(p => p.SeriesReq)
                    .HasForeignKey(d => d.SeriesFk)
                    .HasConstraintName("fk_bdkjk6ww0ulrb0nhf41c7liwt");
            });

            modelBuilder.Entity<SoundexCode>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("soundex_code_pkey");

                entity.ToTable("soundex_code");

                entity.HasIndex(e => e.PersonNameFk)
                    .HasName("fk_dh7lahwi99hk6bttrk75x4ckc");

                entity.HasIndex(e => e.SxCodeValue)
                    .HasName("uk_3dxkqfajcytiwjjb5rgh4nu1l");

                entity.HasIndex(e => e.SxPnComp)
                    .HasName("uk_fjwlo6vk0gxp78eh2i7j04a5t");

                entity.HasIndex(e => e.SxPnCompPart)
                    .HasName("uk_nlv8hnjxmb7pobdfl094ud14u");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.PersonNameFk).HasColumnName("person_name_fk");

                entity.Property(e => e.SxCodeValue)
                    .IsRequired()
                    .HasColumnName("sx_code_value")
                    .HasMaxLength(255);

                entity.Property(e => e.SxPnComp).HasColumnName("sx_pn_comp");

                entity.Property(e => e.SxPnCompPart).HasColumnName("sx_pn_comp_part");

                entity.HasOne(d => d.PersonNameFkNavigation)
                    .WithMany(p => p.SoundexCode)
                    .HasForeignKey(d => d.PersonNameFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dh7lahwi99hk6bttrk75x4ckc");
            });

            modelBuilder.Entity<SpsStationAet>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sps_station_aet");

                entity.HasIndex(e => e.MwlItemFk)
                    .HasName("fk_js5xqyw5qa9rpttwmck14duow");

                entity.HasIndex(e => e.StationAet)
                    .HasName("uk_tm93u8kuxnasoguns5asgdx4a");

                entity.Property(e => e.MwlItemFk).HasColumnName("mwl_item_fk");

                entity.Property(e => e.StationAet)
                    .HasColumnName("station_aet")
                    .HasMaxLength(255);

                entity.HasOne(d => d.MwlItemFkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MwlItemFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_js5xqyw5qa9rpttwmck14duow");
            });

            modelBuilder.Entity<StgcmtResult>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("stgcmt_result_pkey");

                entity.ToTable("stgcmt_result");

                entity.HasIndex(e => e.BatchId)
                    .HasName("uk_f718gnu5js0mdg39q6j7fklia");

                entity.HasIndex(e => e.DeviceName)
                    .HasName("uk_7ltjgxoijy15rrwihl8euv7vh");

                entity.HasIndex(e => e.ExporterId)
                    .HasName("uk_gu96kxnbf2p84d1katepo0btq");

                entity.HasIndex(e => e.MsgId)
                    .HasName("uk_4iih0m0ueyvaim3033di45ems");

                entity.HasIndex(e => e.StgcmtStatus)
                    .HasName("uk_nyoefler7agcmxc8t8yfngq7e");

                entity.HasIndex(e => e.StudyIuid)
                    .HasName("uk_p65blcj4h0uh2itb0bp49mc07");

                entity.HasIndex(e => e.TransactionUid)
                    .HasName("uk_ey6qpep2qtiwayou7pd0vj22w")
                    .IsUnique();

                entity.HasIndex(e => e.UpdatedTime)
                    .HasName("uk_qko59fn9pb87j1eu070ilfkhm");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.BatchId)
                    .HasColumnName("batch_id")
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasColumnName("device_name")
                    .HasMaxLength(255);

                entity.Property(e => e.ExporterId)
                    .HasColumnName("exporter_id")
                    .HasMaxLength(255);

                entity.Property(e => e.MsgId)
                    .HasColumnName("msg_id")
                    .HasMaxLength(255);

                entity.Property(e => e.NumFailures).HasColumnName("num_failures");

                entity.Property(e => e.NumInstances).HasColumnName("num_instances");

                entity.Property(e => e.SeriesIuid)
                    .HasColumnName("series_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.SopIuid)
                    .HasColumnName("sop_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.StgcmtStatus).HasColumnName("stgcmt_status");

                entity.Property(e => e.StudyIuid)
                    .IsRequired()
                    .HasColumnName("study_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.TransactionUid)
                    .IsRequired()
                    .HasColumnName("transaction_uid")
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");
            });

            modelBuilder.Entity<StgverTask>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("stgver_task_pkey");

                entity.ToTable("stgver_task");

                entity.HasIndex(e => e.CreatedTime)
                    .HasName("uk_fe2td8g77y54d90w7339ka0ix");

                entity.HasIndex(e => e.QueueMsgFk)
                    .HasName("fk_hch5fanx7ejwew2ag2ividq9r");

                entity.HasIndex(e => e.UpdatedTime)
                    .HasName("uk_bja5px1r9qts4nydp1a2i61ok");

                entity.HasIndex(e => new { e.StudyIuid, e.SeriesIuid, e.SopIuid })
                    .HasName("uk_iudr0qmrm15i2evq1733h1ace");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.Completed).HasColumnName("completed");

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.Failed).HasColumnName("failed");

                entity.Property(e => e.LocalAet)
                    .IsRequired()
                    .HasColumnName("local_aet")
                    .HasMaxLength(255);

                entity.Property(e => e.QueueMsgFk).HasColumnName("queue_msg_fk");

                entity.Property(e => e.SeriesIuid)
                    .HasColumnName("series_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.SopIuid)
                    .HasColumnName("sop_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.StgcmtPolicy).HasColumnName("stgcmt_policy");

                entity.Property(e => e.StorageIds)
                    .HasColumnName("storage_ids")
                    .HasMaxLength(255);

                entity.Property(e => e.StudyIuid)
                    .IsRequired()
                    .HasColumnName("study_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.UpdateLocationStatus).HasColumnName("update_location_status");

                entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");

                entity.HasOne(d => d.QueueMsgFkNavigation)
                    .WithMany(p => p.StgverTask)
                    .HasForeignKey(d => d.QueueMsgFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_hch5fanx7ejwew2ag2ividq9r");
            });

            modelBuilder.Entity<Study>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("study_pkey");

                entity.ToTable("study");

                entity.HasIndex(e => e.AccessControlId)
                    .HasName("uk_24av2ewa70e7cykl340n63aqd");

                entity.HasIndex(e => e.AccessTime)
                    .HasName("uk_q8k2sl3kjl18qg1nr19l47tl1");

                entity.HasIndex(e => e.AccessionNo)
                    .HasName("uk_2ofn5q0fdfc6941e5j34bplmv");

                entity.HasIndex(e => e.AccnoIssuerFk)
                    .HasName("fk_lp0rdx659kewq8qrqg702yfyv");

                entity.HasIndex(e => e.AdmidIssuerFk)
                    .HasName("fk_9fqno60wc3gr4376ov1xlfme4");

                entity.HasIndex(e => e.AdmissionId)
                    .HasName("uk_n5froudmhk14pbhgors43xi68");

                entity.HasIndex(e => e.Completeness)
                    .HasName("uk_gl5rq54a0tr8nreu27c2t04rb");

                entity.HasIndex(e => e.CreatedTime)
                    .HasName("uk_6ry2squ4qcv129lxpae1oy93m");

                entity.HasIndex(e => e.DicomattrsFk)
                    .HasName("uk_5w0oynbw061mwu1rr9mrb6kj4")
                    .IsUnique();

                entity.HasIndex(e => e.ExpirationDate)
                    .HasName("uk_mlk5pdi8une92kru8g2ppappx");

                entity.HasIndex(e => e.ExpirationState)
                    .HasName("uk_fyasyw3wco6hoj2entr7l6d09");

                entity.HasIndex(e => e.ExtRetrieveAet)
                    .HasName("uk_cl9dmi0kb97ov1cjh7rn3dhve");

                entity.HasIndex(e => e.FailedRetrieves)
                    .HasName("uk_9qvng5j8xnli8yif7p0rjngb2");

                entity.HasIndex(e => e.PatientFk)
                    .HasName("fk_e3fdaqhw7u60trs5aspf4sna9");

                entity.HasIndex(e => e.RefPhysNameFk)
                    .HasName("fk_49eet5qgcsb32ktsqrf1mj3x2");

                entity.HasIndex(e => e.RejectionState)
                    .HasName("uk_hwu9omd369ju3nufufxd3vof2");

                entity.HasIndex(e => e.StorageIds)
                    .HasName("uk_fypbtohf5skbd3bkyd792a6dt");

                entity.HasIndex(e => e.StudyCustom1)
                    .HasName("uk_ksy103xef0hokd33y8ux7afxl");

                entity.HasIndex(e => e.StudyCustom2)
                    .HasName("uk_j63d3ip6x4xslkmyks1l89aay");

                entity.HasIndex(e => e.StudyCustom3)
                    .HasName("uk_8xolm3oljt08cuheepwq3fls7");

                entity.HasIndex(e => e.StudyDate)
                    .HasName("uk_a1rewlmf8uxfgshk25f6uawx2");

                entity.HasIndex(e => e.StudyDesc)
                    .HasName("uk_j3q7fkhhiu4bolglyve3lv385");

                entity.HasIndex(e => e.StudyIuid)
                    .HasName("uk_pt5qn20x278wb1f7p2t3lcxv")
                    .IsUnique();

                entity.HasIndex(e => e.StudySize)
                    .HasName("uk_q7vxiaj1q6ojfxdq1g9jjxgqv");

                entity.HasIndex(e => e.StudyTime)
                    .HasName("uk_16t2xvj9ttyvbwh1ijeve01ii");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccessControlId)
                    .IsRequired()
                    .HasColumnName("access_control_id")
                    .HasMaxLength(255);

                entity.Property(e => e.AccessTime).HasColumnName("access_time");

                entity.Property(e => e.AccessionNo)
                    .IsRequired()
                    .HasColumnName("accession_no")
                    .HasMaxLength(255);

                entity.Property(e => e.AccnoIssuerFk).HasColumnName("accno_issuer_fk");

                entity.Property(e => e.AdmidIssuerFk).HasColumnName("admid_issuer_fk");

                entity.Property(e => e.AdmissionId)
                    .IsRequired()
                    .HasColumnName("admission_id")
                    .HasMaxLength(255);

                entity.Property(e => e.Completeness).HasColumnName("completeness");

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.DicomattrsFk).HasColumnName("dicomattrs_fk");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnName("expiration_date")
                    .HasMaxLength(255);

                entity.Property(e => e.ExpirationExporterId)
                    .HasColumnName("expiration_exporter_id")
                    .HasMaxLength(255);

                entity.Property(e => e.ExpirationState).HasColumnName("expiration_state");

                entity.Property(e => e.ExtRetrieveAet)
                    .IsRequired()
                    .HasColumnName("ext_retrieve_aet")
                    .HasMaxLength(255);

                entity.Property(e => e.FailedRetrieves).HasColumnName("failed_retrieves");

                entity.Property(e => e.ModifiedTime).HasColumnName("modified_time");

                entity.Property(e => e.PatientFk).HasColumnName("patient_fk");

                entity.Property(e => e.RefPhysNameFk).HasColumnName("ref_phys_name_fk");

                entity.Property(e => e.RejectionState).HasColumnName("rejection_state");

                entity.Property(e => e.StorageIds)
                    .HasColumnName("storage_ids")
                    .HasMaxLength(255);

                entity.Property(e => e.StudyCustom1)
                    .IsRequired()
                    .HasColumnName("study_custom1")
                    .HasMaxLength(255);

                entity.Property(e => e.StudyCustom2)
                    .IsRequired()
                    .HasColumnName("study_custom2")
                    .HasMaxLength(255);

                entity.Property(e => e.StudyCustom3)
                    .IsRequired()
                    .HasColumnName("study_custom3")
                    .HasMaxLength(255);

                entity.Property(e => e.StudyDate)
                    .IsRequired()
                    .HasColumnName("study_date")
                    .HasMaxLength(255);

                entity.Property(e => e.StudyDesc)
                    .IsRequired()
                    .HasColumnName("study_desc")
                    .HasMaxLength(255);

                entity.Property(e => e.StudyId)
                    .IsRequired()
                    .HasColumnName("study_id")
                    .HasMaxLength(255);

                entity.Property(e => e.StudyIuid)
                    .IsRequired()
                    .HasColumnName("study_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.StudySize).HasColumnName("study_size");

                entity.Property(e => e.StudyTime)
                    .IsRequired()
                    .HasColumnName("study_time")
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");

                entity.Property(e => e.Version).HasColumnName("version");

                entity.HasOne(d => d.AccnoIssuerFkNavigation)
                    .WithMany(p => p.StudyAccnoIssuerFkNavigation)
                    .HasForeignKey(d => d.AccnoIssuerFk)
                    .HasConstraintName("fk_lp0rdx659kewq8qrqg702yfyv");

                entity.HasOne(d => d.AdmidIssuerFkNavigation)
                    .WithMany(p => p.StudyAdmidIssuerFkNavigation)
                    .HasForeignKey(d => d.AdmidIssuerFk)
                    .HasConstraintName("fk_9fqno60wc3gr4376ov1xlfme4");

                entity.HasOne(d => d.DicomattrsFkNavigation)
                    .WithOne(p => p.Study)
                    .HasForeignKey<Study>(d => d.DicomattrsFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_5w0oynbw061mwu1rr9mrb6kj4");

                entity.HasOne(d => d.PatientFkNavigation)
                    .WithMany(p => p.Study)
                    .HasForeignKey(d => d.PatientFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_e3fdaqhw7u60trs5aspf4sna9");

                entity.HasOne(d => d.RefPhysNameFkNavigation)
                    .WithMany(p => p.Study)
                    .HasForeignKey(d => d.RefPhysNameFk)
                    .HasConstraintName("fk_49eet5qgcsb32ktsqrf1mj3x2");
            });

            modelBuilder.Entity<StudyQueryAttrs>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("study_query_attrs_pkey");

                entity.ToTable("study_query_attrs");

                entity.HasIndex(e => e.StudyFk)
                    .HasName("fk_sxccj81423w8o6w2tsb7nshy9");

                entity.HasIndex(e => new { e.ViewId, e.StudyFk })
                    .HasName("uk_prn4qt6d42stw0gfi1yce1fap")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.Availability).HasColumnName("availability");

                entity.Property(e => e.CuidsInStudy)
                    .HasColumnName("cuids_in_study")
                    .HasMaxLength(4000);

                entity.Property(e => e.ModsInStudy)
                    .HasColumnName("mods_in_study")
                    .HasMaxLength(255);

                entity.Property(e => e.NumInstances).HasColumnName("num_instances");

                entity.Property(e => e.NumSeries).HasColumnName("num_series");

                entity.Property(e => e.RetrieveAets)
                    .HasColumnName("retrieve_aets")
                    .HasMaxLength(255);

                entity.Property(e => e.StudyFk).HasColumnName("study_fk");

                entity.Property(e => e.ViewId)
                    .HasColumnName("view_id")
                    .HasMaxLength(255);

                entity.HasOne(d => d.StudyFkNavigation)
                    .WithMany(p => p.StudyQueryAttrs)
                    .HasForeignKey(d => d.StudyFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sxccj81423w8o6w2tsb7nshy9");
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("subscription_pkey");

                entity.ToTable("subscription");

                entity.HasIndex(e => e.UpsFk)
                    .HasName("fk_jadcs2aho4ijh639r67qgk0g0");

                entity.HasIndex(e => new { e.SubscriberAet, e.UpsFk })
                    .HasName("uk_co8q5hn46dehb35qsrtwyys96")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeletionLock).HasColumnName("deletion_lock");

                entity.Property(e => e.SubscriberAet)
                    .IsRequired()
                    .HasColumnName("subscriber_aet")
                    .HasMaxLength(255);

                entity.Property(e => e.UpsFk).HasColumnName("ups_fk");

                entity.HasOne(d => d.UpsFkNavigation)
                    .WithMany(p => p.Subscription)
                    .HasForeignKey(d => d.UpsFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_jadcs2aho4ijh639r67qgk0g0");
            });

            modelBuilder.Entity<Uidmap>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("uidmap_pkey");

                entity.ToTable("uidmap");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.Uidmap1)
                    .IsRequired()
                    .HasColumnName("uidmap");
            });

            modelBuilder.Entity<Ups>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("ups_pkey");

                entity.ToTable("ups");

                entity.HasIndex(e => e.AdmissionId)
                    .HasName("uk_sqoo5rr8pu2qe4gtdne3xh031");

                entity.HasIndex(e => e.AdmissionIssuerFk)
                    .HasName("fk_61tpdp9aoy98jwiif5wq82ia3");

                entity.HasIndex(e => e.DicomattrsFk)
                    .HasName("uk_3frtpy5cstsoxk5jxw9cutr33")
                    .IsUnique();

                entity.HasIndex(e => e.ExpectedEndDateTime)
                    .HasName("uk_1hdr3ml1rwugwkmo3eks4no5p");

                entity.HasIndex(e => e.ExpirationDateTime)
                    .HasName("uk_e57ifctiig366oq9mhab8law3");

                entity.HasIndex(e => e.InputReadinessState)
                    .HasName("uk_brtgc3vpnoaq1xm80m568r16y");

                entity.HasIndex(e => e.PatientFk)
                    .HasName("fk_8xiqdli1p8cyw1y4hwyqhimcx");

                entity.HasIndex(e => e.ReplacedIuid)
                    .HasName("uk_crl67piqoxiccp3i6ckktphdd");

                entity.HasIndex(e => e.StartDateTime)
                    .HasName("uk_kh194du6g35fi5l80vbj18nnp");

                entity.HasIndex(e => e.StationClassFk)
                    .HasName("fk_ak183xmw0sai4jg9lib6m14o2");

                entity.HasIndex(e => e.StationLocationFk)
                    .HasName("fk_ox3hpmd042ywnww3yh33crcoj");

                entity.HasIndex(e => e.StationNameFk)
                    .HasName("fk_gd2hu9idxg6rd71g1i8r8wyjr");

                entity.HasIndex(e => e.UpdatedTime)
                    .HasName("uk_1umoxe7ig9n21q885mncxeq9");

                entity.HasIndex(e => e.UpsCodeFk)
                    .HasName("fk_1retecpk22a2tysmi5o6xcpbh");

                entity.HasIndex(e => e.UpsIuid)
                    .HasName("uk_qck03rlxht9myv77sc79a480t")
                    .IsUnique();

                entity.HasIndex(e => e.UpsLabel)
                    .HasName("uk_d3ejkrtcim0q3cbwpq4n9skes");

                entity.HasIndex(e => e.UpsPriority)
                    .HasName("uk_kgwfwmxj3i0n7c404uvhsav1g");

                entity.HasIndex(e => e.UpsState)
                    .HasName("uk_c8obxmqpdcy37r3pjga2pukac");

                entity.HasIndex(e => e.WorklistLabel)
                    .HasName("uk_7e44lxlg0m2l2wfdo3k2tec7o");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdmissionId)
                    .IsRequired()
                    .HasColumnName("admission_id")
                    .HasMaxLength(255);

                entity.Property(e => e.AdmissionIssuerFk).HasColumnName("admission_issuer_fk");

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.DicomattrsFk).HasColumnName("dicomattrs_fk");

                entity.Property(e => e.ExpectedEndDateTime)
                    .IsRequired()
                    .HasColumnName("expected_end_date_time")
                    .HasMaxLength(255);

                entity.Property(e => e.ExpirationDateTime)
                    .IsRequired()
                    .HasColumnName("expiration_date_time")
                    .HasMaxLength(255);

                entity.Property(e => e.InputReadinessState).HasColumnName("input_readiness_state");

                entity.Property(e => e.PatientFk).HasColumnName("patient_fk");

                entity.Property(e => e.PerformerAet)
                    .HasColumnName("performer_aet")
                    .HasMaxLength(255);

                entity.Property(e => e.ReplacedIuid)
                    .IsRequired()
                    .HasColumnName("replaced_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.StartDateTime)
                    .IsRequired()
                    .HasColumnName("start_date_time")
                    .HasMaxLength(255);

                entity.Property(e => e.StationClassFk).HasColumnName("station_class_fk");

                entity.Property(e => e.StationLocationFk).HasColumnName("station_location_fk");

                entity.Property(e => e.StationNameFk).HasColumnName("station_name_fk");

                entity.Property(e => e.TransactionIuid)
                    .HasColumnName("transaction_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");

                entity.Property(e => e.UpsCodeFk).HasColumnName("ups_code_fk");

                entity.Property(e => e.UpsIuid)
                    .IsRequired()
                    .HasColumnName("ups_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.UpsLabel)
                    .IsRequired()
                    .HasColumnName("ups_label")
                    .HasMaxLength(255);

                entity.Property(e => e.UpsPriority).HasColumnName("ups_priority");

                entity.Property(e => e.UpsState).HasColumnName("ups_state");

                entity.Property(e => e.Version).HasColumnName("version");

                entity.Property(e => e.WorklistLabel)
                    .IsRequired()
                    .HasColumnName("worklist_label")
                    .HasMaxLength(255);

                entity.HasOne(d => d.AdmissionIssuerFkNavigation)
                    .WithMany(p => p.Ups)
                    .HasForeignKey(d => d.AdmissionIssuerFk)
                    .HasConstraintName("fk_61tpdp9aoy98jwiif5wq82ia3");

                entity.HasOne(d => d.DicomattrsFkNavigation)
                    .WithOne(p => p.Ups)
                    .HasForeignKey<Ups>(d => d.DicomattrsFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_3frtpy5cstsoxk5jxw9cutr33");

                entity.HasOne(d => d.PatientFkNavigation)
                    .WithMany(p => p.Ups)
                    .HasForeignKey(d => d.PatientFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_8xiqdli1p8cyw1y4hwyqhimcx");

                entity.HasOne(d => d.StationClassFkNavigation)
                    .WithMany(p => p.UpsStationClassFkNavigation)
                    .HasForeignKey(d => d.StationClassFk)
                    .HasConstraintName("fk_ak183xmw0sai4jg9lib6m14o2");

                entity.HasOne(d => d.StationLocationFkNavigation)
                    .WithMany(p => p.UpsStationLocationFkNavigation)
                    .HasForeignKey(d => d.StationLocationFk)
                    .HasConstraintName("fk_ox3hpmd042ywnww3yh33crcoj");

                entity.HasOne(d => d.StationNameFkNavigation)
                    .WithMany(p => p.UpsStationNameFkNavigation)
                    .HasForeignKey(d => d.StationNameFk)
                    .HasConstraintName("fk_gd2hu9idxg6rd71g1i8r8wyjr");

                entity.HasOne(d => d.UpsCodeFkNavigation)
                    .WithMany(p => p.UpsUpsCodeFkNavigation)
                    .HasForeignKey(d => d.UpsCodeFk)
                    .HasConstraintName("fk_1retecpk22a2tysmi5o6xcpbh");
            });

            modelBuilder.Entity<UpsReq>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("ups_req_pkey");

                entity.ToTable("ups_req");

                entity.HasIndex(e => e.AccessionNo)
                    .HasName("uk_rfium2ybikqm1f4xmi24mnv4u");

                entity.HasIndex(e => e.AccnoIssuerFk)
                    .HasName("fk_gegm1c1ymem7tj2wcm0o7e0pu");

                entity.HasIndex(e => e.ReqPhysNameFk)
                    .HasName("fk_kocdb2pxx2fymu1modhneb4xm");

                entity.HasIndex(e => e.ReqProcId)
                    .HasName("uk_524vr0q4c0kvyjwov74eru44x");

                entity.HasIndex(e => e.ReqService)
                    .HasName("uk_emsk27nclko11ph2tcj5vk7hg");

                entity.HasIndex(e => e.StudyIuid)
                    .HasName("uk_hf0tly8umknn77civcsi0tdih");

                entity.HasIndex(e => e.UpsFk)
                    .HasName("fk_7vt6m05r0hertks2fcngd5wn1");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccessionNo)
                    .IsRequired()
                    .HasColumnName("accession_no")
                    .HasMaxLength(255);

                entity.Property(e => e.AccnoIssuerFk).HasColumnName("accno_issuer_fk");

                entity.Property(e => e.ReqPhysNameFk).HasColumnName("req_phys_name_fk");

                entity.Property(e => e.ReqProcId)
                    .IsRequired()
                    .HasColumnName("req_proc_id")
                    .HasMaxLength(255);

                entity.Property(e => e.ReqService)
                    .IsRequired()
                    .HasColumnName("req_service")
                    .HasMaxLength(255);

                entity.Property(e => e.StudyIuid)
                    .IsRequired()
                    .HasColumnName("study_iuid")
                    .HasMaxLength(255);

                entity.Property(e => e.UpsFk).HasColumnName("ups_fk");

                entity.HasOne(d => d.AccnoIssuerFkNavigation)
                    .WithMany(p => p.UpsReq)
                    .HasForeignKey(d => d.AccnoIssuerFk)
                    .HasConstraintName("fk_gegm1c1ymem7tj2wcm0o7e0pu");

                entity.HasOne(d => d.ReqPhysNameFkNavigation)
                    .WithMany(p => p.UpsReq)
                    .HasForeignKey(d => d.ReqPhysNameFk)
                    .HasConstraintName("fk_kocdb2pxx2fymu1modhneb4xm");

                entity.HasOne(d => d.UpsFkNavigation)
                    .WithMany(p => p.UpsReq)
                    .HasForeignKey(d => d.UpsFk)
                    .HasConstraintName("fk_7vt6m05r0hertks2fcngd5wn1");
            });

            modelBuilder.Entity<VerifyObserver>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("verify_observer_pkey");

                entity.ToTable("verify_observer");

                entity.HasIndex(e => e.InstanceFk)
                    .HasName("fk_qjgrn9rfyyt6sv14utk9ijcfq");

                entity.HasIndex(e => e.ObserverNameFk)
                    .HasName("fk_105wt9hglqsmtnoxgma9x18vj");

                entity.HasIndex(e => e.VerifyDatetime)
                    .HasName("uk_5btv5autls384ulwues8lym4p");

                entity.Property(e => e.Pk)
                    .HasColumnName("pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.InstanceFk).HasColumnName("instance_fk");

                entity.Property(e => e.ObserverNameFk).HasColumnName("observer_name_fk");

                entity.Property(e => e.VerifyDatetime)
                    .IsRequired()
                    .HasColumnName("verify_datetime")
                    .HasMaxLength(255);

                entity.HasOne(d => d.InstanceFkNavigation)
                    .WithMany(p => p.VerifyObserver)
                    .HasForeignKey(d => d.InstanceFk)
                    .HasConstraintName("fk_qjgrn9rfyyt6sv14utk9ijcfq");

                entity.HasOne(d => d.ObserverNameFkNavigation)
                    .WithMany(p => p.VerifyObserver)
                    .HasForeignKey(d => d.ObserverNameFk)
                    .HasConstraintName("fk_105wt9hglqsmtnoxgma9x18vj");
            });

            modelBuilder.HasSequence("code_pk_seq");

            modelBuilder.HasSequence("content_item_pk_seq");

            modelBuilder.HasSequence("dicomattrs_pk_seq");

            modelBuilder.HasSequence("diff_task_pk_seq");

            modelBuilder.HasSequence("export_task_pk_seq");

            modelBuilder.HasSequence("global_subscription_pk_seq");

            modelBuilder.HasSequence("hl7psu_task_pk_seq");

            modelBuilder.HasSequence("ian_task_pk_seq");

            modelBuilder.HasSequence("instance_pk_seq");

            modelBuilder.HasSequence("issuer_pk_seq");

            modelBuilder.HasSequence("location_pk_seq");

            modelBuilder.HasSequence("metadata_pk_seq");

            modelBuilder.HasSequence("mpps_pk_seq");

            modelBuilder.HasSequence("mwl_item_pk_seq");

            modelBuilder.HasSequence("patient_id_pk_seq");

            modelBuilder.HasSequence("patient_pk_seq");

            modelBuilder.HasSequence("person_name_pk_seq");

            modelBuilder.HasSequence("queue_msg_pk_seq");

            modelBuilder.HasSequence("rejected_instance_pk_seq");

            modelBuilder.HasSequence("retrieve_task_pk_seq");

            modelBuilder.HasSequence("series_pk_seq");

            modelBuilder.HasSequence("series_query_attrs_pk_seq");

            modelBuilder.HasSequence("series_req_pk_seq");

            modelBuilder.HasSequence("soundex_code_pk_seq");

            modelBuilder.HasSequence("stgcmt_result_pk_seq");

            modelBuilder.HasSequence("stgver_task_pk_seq");

            modelBuilder.HasSequence("study_pk_seq");

            modelBuilder.HasSequence("study_query_attrs_pk_seq");

            modelBuilder.HasSequence("subscription_pk_seq");

            modelBuilder.HasSequence("uidmap_pk_seq");

            modelBuilder.HasSequence("ups_pk_seq");

            modelBuilder.HasSequence("ups_request_pk_seq");

            modelBuilder.HasSequence("verify_observer_pk_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
