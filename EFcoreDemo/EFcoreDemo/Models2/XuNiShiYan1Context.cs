using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFcoreDemo.Models2
{
    public partial class XuNiShiYan1Context : DbContext
    {
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<College> College { get; set; }
        public virtual DbSet<OperateErrorRecord> OperateErrorRecord { get; set; }
        public virtual DbSet<OperatePicture> OperatePicture { get; set; }
        public virtual DbSet<OperateRecord> OperateRecord { get; set; }
        public virtual DbSet<OperateScoreRecords> OperateScoreRecords { get; set; }
        public virtual DbSet<Process> Process { get; set; }
        public virtual DbSet<QuestionLibrary> QuestionLibrary { get; set; }
        public virtual DbSet<QuestionLibraryAnswer> QuestionLibraryAnswer { get; set; }
        public virtual DbSet<QuestionType> QuestionType { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<TestPaperRecords> TestPaperRecords { get; set; }
        public virtual DbSet<TestPaperRecordsQustion> TestPaperRecordsQustion { get; set; }
        public virtual DbSet<TestPaperRule> TestPaperRule { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(Connection.Conndb);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.College)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.CollegeId)
                    .HasConstraintName("FK_CLASS_REFERENCE_COLLEGE");
            });

            modelBuilder.Entity<College>(entity =>
            {
                entity.Property(e => e.CollegeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<OperateErrorRecord>(entity =>
            {
                entity.Property(e => e.Error).HasMaxLength(100);

                entity.HasOne(d => d.OperateScore)
                    .WithMany(p => p.OperateErrorRecord)
                    .HasForeignKey(d => d.OperateScoreId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OPERATEE_REFERENCE_OPERATES");
            });

            modelBuilder.Entity<OperatePicture>(entity =>
            {
                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.HasOne(d => d.OperateScore)
                    .WithMany(p => p.OperatePicture)
                    .HasForeignKey(d => d.OperateScoreId)
                    .HasConstraintName("FK_OperatePicture_OperateScoreRecords");
            });

            modelBuilder.Entity<OperateRecord>(entity =>
            {
                entity.Property(e => e.Discribe).HasMaxLength(100);

                entity.Property(e => e.Operatetime).HasColumnType("datetime");

                entity.HasOne(d => d.OperateScore)
                    .WithMany(p => p.OperateRecord)
                    .HasForeignKey(d => d.OperateScoreId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OPERATER_REFERENCE_OPERATES");
            });

            modelBuilder.Entity<OperateScoreRecords>(entity =>
            {
                entity.Property(e => e.OperateEndTime).HasColumnType("datetime");

                entity.Property(e => e.OperateStartTime).HasColumnType("datetime");

                entity.Property(e => e.StoreTime).HasColumnType("datetime");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.OperateScoreRecords)
                    .HasForeignKey(d => d.ProcessId)
                    .HasConstraintName("FK_OPERATES_REFERENCE_PROCESS");

                entity.HasOne(d => d.Use)
                    .WithMany(p => p.OperateScoreRecords)
                    .HasForeignKey(d => d.UseId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OPERATES_REFERENCE_USER");
            });

            modelBuilder.Entity<Process>(entity =>
            {
                entity.Property(e => e.ProcessName).HasMaxLength(50);
            });

            modelBuilder.Entity<QuestionLibrary>(entity =>
            {
                entity.Property(e => e.QuestionContent).HasMaxLength(1000);

                entity.HasOne(d => d.QuestionType)
                    .WithMany(p => p.QuestionLibrary)
                    .HasForeignKey(d => d.QuestionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestionLibrary_QuestionType");
            });

            modelBuilder.Entity<QuestionLibraryAnswer>(entity =>
            {
                entity.HasKey(e => new { e.QuestionId, e.ItemIndex });

                entity.Property(e => e.ItemIndex).HasMaxLength(50);

                entity.Property(e => e.ItemContent)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionLibraryAnswer)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_QuestionLibraryAnswer_QuestionLibrary");
            });

            modelBuilder.Entity<QuestionType>(entity =>
            {
                entity.Property(e => e.QuestionType1)
                    .IsRequired()
                    .HasColumnName("QuestionType")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TestPaperRecords>(entity =>
            {
                entity.Property(e => e.BeginTime).HasColumnType("datetime");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TestPaperRecords)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_TESTPAPE_REFERENCE_USER");
            });

            modelBuilder.Entity<TestPaperRecordsQustion>(entity =>
            {
                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.MyAnswer).HasMaxLength(10);

                entity.HasOne(d => d.QuestionLibrary)
                    .WithMany(p => p.TestPaperRecordsQustion)
                    .HasForeignKey(d => d.QuestionLibraryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TESTPAPE_REFERENCE_QUESTION");

                entity.HasOne(d => d.TestPaperRecords)
                    .WithMany(p => p.TestPaperRecordsQustion)
                    .HasForeignKey(d => d.TestPaperRecordsId)
                    .HasConstraintName("FK_TestPaperRecordsQustion_TestPaperRecords");
            });

            modelBuilder.Entity<TestPaperRule>(entity =>
            {
                entity.Property(e => e.IsPassScore).HasColumnName("IsPassSCore");

                entity.Property(e => e.SetTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.PassWord)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RealName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TheoryNum).HasDefaultValueSql("((2))");

                entity.Property(e => e.UserNo)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
