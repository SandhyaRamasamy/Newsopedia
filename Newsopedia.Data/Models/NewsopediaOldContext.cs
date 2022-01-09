using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Newsopedia.Data.Models
{
    public partial class NewsopediaOldContext : DbContext
    {
        public NewsopediaOldContext()
        {
        }

        public NewsopediaOldContext(DbContextOptions<NewsopediaOldContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NewsTable> NewsTables { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserNewsTable> UserNewsTables { get; set; }
        public DbSet<GetTopUsers> GetTopUsers { get; set; }
   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NewsopediaOld;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<NewsTable>(entity =>
            {
                entity.HasKey(e => e.NewsId)
                    .HasName("PK_DateUrls");

                entity.ToTable("NewsTable");

                entity.Property(e => e.NewsImageUrl).HasColumnName("NewsImageURL");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Email, "Email_uc")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(150);
            });

            modelBuilder.Entity<UserNewsTable>(entity =>
            {
                entity.HasKey(e => e.UserNewsId);

                entity.ToTable("User_NewsTable");

                entity.Property(e => e.Date).HasMaxLength(50);

                entity.HasOne(d => d.News)
                    .WithMany(p => p.UserNewsTables)
                    .HasForeignKey(d => d.NewsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_NewsTable_NewsTable");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserNewsTables)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_NewsTable_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
