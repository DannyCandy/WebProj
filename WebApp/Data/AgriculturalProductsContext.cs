using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public partial class AgriculturalProductsContext : IdentityDbContext<ApplicationUser>
    {
        public AgriculturalProductsContext()
        {
        }

        public AgriculturalProductsContext(DbContextOptions<AgriculturalProductsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<ChungNhan> ChungNhans { get; set; } = null!;
        public virtual DbSet<NhaPhanPhoi> NhaPhanPhois { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<SanPham> SanPhams { get; set; } = null!;
        public virtual DbSet<ThongTinLienHe> ThongTinLienHes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DANNYCANDY\\SQLEXPRESS;Database=AgriculturalProducts;Trusted_Connection=True;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Idcategory);

                entity.ToTable("Category");

                entity.Property(e => e.Idcategory).HasColumnName("IDCategory");

                entity.Property(e => e.NameCategory).HasMaxLength(100);
            });

            modelBuilder.Entity<ChungNhan>(entity =>
            {
                entity.HasKey(e => e.IdchungNhan);

                entity.ToTable("ChungNhan");

                entity.Property(e => e.IdchungNhan).HasColumnName("IDChungNhan");
            });

            modelBuilder.Entity<NhaPhanPhoi>(entity =>
            {
                entity.HasKey(e => e.Idnpp);

                entity.ToTable("NhaPhanPhoi");

                entity.Property(e => e.Idnpp).HasColumnName("IDNPP");

                entity.Property(e => e.DiaChiNpp).HasColumnName("DiaChiNPP");

                entity.Property(e => e.GioDongCua).HasColumnType("time(0)");

                entity.Property(e => e.GioMoCua).HasColumnType("time(0)");

                entity.Property(e => e.PhoneNpp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PhoneNPP");

                entity.Property(e => e.TenNpp)
                    .HasMaxLength(100)
                    .HasColumnName("TenNPP");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");

                entity.Property(e => e.DcgiaoHang).HasColumnName("DCGiaoHang");

                entity.Property(e => e.Idsp)
                    .HasMaxLength(450)
                    .HasColumnName("IDSp");

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TotalPrice)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(450)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.IdspNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.Idsp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tb.OrderDetail_Tb.SanPham");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.Idsp);

                entity.ToTable("SanPham");

                entity.HasIndex(e => e.Idcategory, "IX_SanPham_IDCategory");

                entity.HasIndex(e => e.IdchungNhan, "IX_SanPham_IDChungNhan");

                entity.HasIndex(e => e.Idnpp, "IX_SanPham_IDNPP");

                entity.Property(e => e.Idsp).HasColumnName("IDSP");

                entity.Property(e => e.Hdsd).HasColumnName("HDSD");

                entity.Property(e => e.HinhAnhSp).HasColumnName("HinhAnhSP");

                entity.Property(e => e.Idcategory).HasColumnName("IDCategory");

                entity.Property(e => e.IdchungNhan).HasColumnName("IDChungNhan");

                entity.Property(e => e.Idnpp).HasColumnName("IDNPP");

                entity.Property(e => e.SoLuongSp).HasColumnName("SoLuongSP");

                entity.HasOne(d => d.IdcategoryNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.Idcategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tb.SanPham_Tb.Category");

                entity.HasOne(d => d.IdchungNhanNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.IdchungNhan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tb.SanPham_Tb.ChungNhan");

                entity.HasOne(d => d.IdnppNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.Idnpp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tb.SanPham_Tb.NhaPhanPhoi");
            });

            modelBuilder.Entity<ThongTinLienHe>(entity =>
            {
                entity.HasKey(e => e.Idttlh);

                entity.ToTable("ThongTinLienHe");

                entity.Property(e => e.Idttlh).HasColumnName("IDTTLH");

                entity.Property(e => e.DcgiaoHang).HasColumnName("DCGiaoHang");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasMaxLength(450);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
