﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.Data;

#nullable disable

namespace WebApp.Migrations
{
    [DbContext(typeof(AgriculturalProductsContext))]
    partial class AgriculturalProductsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WebApp.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<byte[]>("Avatar")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKhachHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("WebApp.Models.Category", b =>
                {
                    b.Property<string>("Idcategory")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("IDCategory");

                    b.Property<string>("NameCategory")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Idcategory");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("WebApp.Models.ChungNhan", b =>
                {
                    b.Property<string>("IdchungNhan")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("IDChungNhan");

                    b.Property<string>("HinhAnhChungNhan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdchungNhan");

                    b.ToTable("ChungNhan", (string)null);
                });

            modelBuilder.Entity("WebApp.Models.NhaPhanPhoi", b =>
                {
                    b.Property<string>("Idnpp")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("IDNPP");

                    b.Property<string>("DiaChiNpp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DiaChiNPP");

                    b.Property<TimeSpan>("GioDongCua")
                        .HasColumnType("time(0)");

                    b.Property<TimeSpan>("GioMoCua")
                        .HasColumnType("time(0)");

                    b.Property<string>("HinhAnhNPP")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("HinhAnhNPP");

                    b.Property<string>("PhoneNpp")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("PhoneNPP");

                    b.Property<string>("TenNpp")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("TenNPP");

                    b.HasKey("Idnpp");

                    b.ToTable("NhaPhanPhoi", (string)null);
                });

            modelBuilder.Entity("WebApp.Models.Order", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("OrderId");

                    b.Property<string>("DcGiaoHang")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("DcGiaoHang");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Message");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("datetime");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("UserID");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("WebApp.Models.OrderDetail", b =>
                {
                    b.Property<string>("OrderDetailId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("OrderDetailID");

                    b.Property<string>("Idsp")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("IDSp");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("OrderId");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("Idsp");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetail", (string)null);
                });

            modelBuilder.Entity("WebApp.Models.SanPham", b =>
                {
                    b.Property<string>("Idsp")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("IDSP");

                    b.Property<string>("CongDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hdsd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("HDSD");

                    b.Property<string>("HinhAnhSp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("HinhAnhSP");

                    b.Property<string>("Idcategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("IDCategory");

                    b.Property<string>("IdchungNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("IDChungNhan");

                    b.Property<string>("Idnpp")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("IDNPP");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("SoLuongSp")
                        .HasColumnType("int")
                        .HasColumnName("SoLuongSP");

                    b.Property<string>("SpName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThanhPhanDinhDuong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Idsp");

                    b.HasIndex(new[] { "Idcategory" }, "IX_SanPham_IDCategory");

                    b.HasIndex(new[] { "IdchungNhan" }, "IX_SanPham_IDChungNhan");

                    b.HasIndex(new[] { "Idnpp" }, "IX_SanPham_IDNPP");

                    b.ToTable("SanPham", (string)null);
                });

            modelBuilder.Entity("WebApp.Models.ThongTinLienHe", b =>
                {
                    b.Property<string>("Idttlh")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("IDTTLH");

                    b.Property<string>("DcgiaoHang")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DCGiaoHang");

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Idttlh");

                    b.HasIndex("UserId");

                    b.ToTable("ThongTinLienHe", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebApp.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebApp.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebApp.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp.Models.Order", b =>
                {
                    b.HasOne("WebApp.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApp.Models.OrderDetail", b =>
                {
                    b.HasOne("WebApp.Models.SanPham", "IdspNavigation")
                        .WithMany("OrderDetails")
                        .HasForeignKey("Idsp")
                        .IsRequired()
                        .HasConstraintName("FK_Tb.OrderDetail_Tb.SanPham");

                    b.HasOne("WebApp.Models.Order", "OrderIdNavigation")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK_Tb.OrderDetail_Tb.Order");

                    b.Navigation("IdspNavigation");

                    b.Navigation("OrderIdNavigation");
                });

            modelBuilder.Entity("WebApp.Models.SanPham", b =>
                {
                    b.HasOne("WebApp.Models.Category", "IdcategoryNavigation")
                        .WithMany("SanPhams")
                        .HasForeignKey("Idcategory")
                        .IsRequired()
                        .HasConstraintName("FK_Tb.SanPham_Tb.Category");

                    b.HasOne("WebApp.Models.ChungNhan", "IdchungNhanNavigation")
                        .WithMany("SanPhams")
                        .HasForeignKey("IdchungNhan")
                        .IsRequired()
                        .HasConstraintName("FK_Tb.SanPham_Tb.ChungNhan");

                    b.HasOne("WebApp.Models.NhaPhanPhoi", "IdnppNavigation")
                        .WithMany("SanPhams")
                        .HasForeignKey("Idnpp")
                        .IsRequired()
                        .HasConstraintName("FK_Tb.SanPham_Tb.NhaPhanPhoi");

                    b.Navigation("IdcategoryNavigation");

                    b.Navigation("IdchungNhanNavigation");

                    b.Navigation("IdnppNavigation");
                });

            modelBuilder.Entity("WebApp.Models.ThongTinLienHe", b =>
                {
                    b.HasOne("WebApp.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApp.Models.Category", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("WebApp.Models.ChungNhan", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("WebApp.Models.NhaPhanPhoi", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("WebApp.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("WebApp.Models.SanPham", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
