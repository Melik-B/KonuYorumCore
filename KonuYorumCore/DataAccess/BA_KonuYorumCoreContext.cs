using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KonuYorumCore.DataAccess
{
    public partial class BA_KonuYorumCoreContext : DbContext
    {
        public BA_KonuYorumCoreContext()
        {
        }

        public BA_KonuYorumCoreContext(DbContextOptions<BA_KonuYorumCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Konu> Konu { get; set; }
        public virtual DbSet<Yorum> Yorum { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=BA_KonuYorumCore;user id=sa;password=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Konu>(entity =>
            {
                entity.Property(e => e.Aciklama)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Baslik)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Yorum>(entity =>
            {
                entity.Property(e => e.Icerik)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Yorumcu)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Konu)
                    .WithMany(p => p.Yorum)
                    .HasForeignKey(d => d.KonuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Yorum_Konu");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
