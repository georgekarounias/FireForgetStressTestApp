using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Model.Models
{
    public partial class Notifications_TestingContext : DbContext
    {
        public Notifications_TestingContext()
        {
        }

        public Notifications_TestingContext(DbContextOptions<Notifications_TestingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TaskInformation> TaskInformations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-1TDJQRD;Database=Notifications_Testing;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Greek_CI_AS");

            modelBuilder.Entity<TaskInformation>(entity =>
            {
                entity.ToTable("TaskInformation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.TimeToComplete).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
