using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiDemo.Model
{
    public partial class ClaimManagementContext : DbContext
    {
        public ClaimManagementContext() { }

        public ClaimManagementContext(DbContextOptions<ClaimManagementContext> options) : base(options) { }

        public virtual DbSet<MediClaim> MediClaims { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NGL001535; Database=ClaimManagement; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MediClaim>(entity =>
            {
                entity.ToTable("MediClaim");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ClaimCause)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}