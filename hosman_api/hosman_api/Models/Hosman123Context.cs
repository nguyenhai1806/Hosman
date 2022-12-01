﻿using Microsoft.EntityFrameworkCore;

namespace hosman_api.Models;

public partial class Hosman123Context : DbContext
{
    public Hosman123Context()
    {
    }

    public Hosman123Context(DbContextOptions<Hosman123Context> options)
        : base(options)
    {
    }

    public virtual DbSet<BinhLuan> BinhLuans { get; set; }

    public virtual DbSet<DangKyXemPhong> DangKyXemPhongs { get; set; }

    public virtual DbSet<DanhSachNguoiTro> DanhSachNguoiTros { get; set; }

    public virtual DbSet<DichVu> DichVus { get; set; }

    public virtual DbSet<DichVuKhuTro> DichVuKhuTros { get; set; }

    public virtual DbSet<DichVuPhong> DichVuPhongs { get; set; }

    public virtual DbSet<DmManHinh> DmManHinhs { get; set; }

    public virtual DbSet<DongHoDien> DongHoDiens { get; set; }

    public virtual DbSet<DongHoNuoc> DongHoNuocs { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<HoaDonDichVu> HoaDonDichVus { get; set; }

    public virtual DbSet<HoaDonDien> HoaDonDiens { get; set; }

    public virtual DbSet<HoaDonNuoc> HoaDonNuocs { get; set; }

    public virtual DbSet<HopDongThue> HopDongThues { get; set; }

    public virtual DbSet<KhuTro> KhuTros { get; set; }

    public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<PhieuChi> PhieuChis { get; set; }

    public virtual DbSet<PhieuCocGiuPhong> PhieuCocGiuPhongs { get; set; }

    public virtual DbSet<Phong> Phongs { get; set; }

    public virtual DbSet<PhuLuc> PhuLucs { get; set; }

    public virtual DbSet<QlNguoiDungNhomNguoiDung> QlNguoiDungNhomNguoiDungs { get; set; }

    public virtual DbSet<QlNhomNguoiDung> QlNhomNguoiDungs { get; set; }

    public virtual DbSet<QlPhanQuyen> QlPhanQuyens { get; set; }

    public virtual DbSet<TienIch> TienIches { get; set; }

    public virtual DbSet<YeuCauSauChua> YeuCauSauChuas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Hosman123;TrustServerCertificate=True;User ID=sa;Password=123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BinhLuan>(entity =>
        {
            entity.HasKey(e => e.MaBinhLuan).HasName("PK__BinhLuan__87CB66A0B0FDAB7A");

            entity.ToTable("BinhLuan");

            entity.Property(e => e.MaBinhLuan)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ChuTro)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HinhAnh).IsUnicode(false);
            entity.Property(e => e.Ngay).HasColumnType("date");
            entity.Property(e => e.NguoiBinhLuan)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NoiDung).HasMaxLength(300);
            entity.Property(e => e.TrangThai).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.ChuTroNavigation).WithMany(p => p.BinhLuanChuTroNavigations)
                .HasForeignKey(d => d.ChuTro)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.NguoiBinhLuanNavigation).WithMany(p => p.BinhLuanNguoiBinhLuanNavigations)
                .HasForeignKey(d => d.NguoiBinhLuan)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DangKyXemPhong>(entity =>
        {
            entity.HasKey(e => e.MaDangKy).HasName("PK__DangKyXe__BA90F02DA4694EC3");

            entity.ToTable("DangKyXemPhong");

            entity.Property(e => e.MaDangKy)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GhiChu).HasMaxLength(300);
            entity.Property(e => e.MaPhong)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NgayDangKy).HasColumnType("date");
            entity.Property(e => e.NgayHenXem).HasColumnType("date");
            entity.Property(e => e.NguoiDung)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.DangKyXemPhongs)
                .HasForeignKey(d => d.MaPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DangKyXemPhong_Phong");

            entity.HasOne(d => d.NguoiDungNavigation).WithMany(p => p.DangKyXemPhongs)
                .HasForeignKey(d => d.NguoiDung)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DangKyXemPhong_NguoiDung");
        });

        modelBuilder.Entity<DanhSachNguoiTro>(entity =>
        {
            entity.HasKey(e => e.MaNguoiTro).HasName("PK__DanhSach__F9292A8015698B05");

            entity.ToTable("DanhSachNguoiTro");

            entity.Property(e => e.MaNguoiTro)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AnhCccdsau).HasColumnName("AnhCCCDSau");
            entity.Property(e => e.AnhCccdtruoc).HasColumnName("AnhCCCDTruoc");
            entity.Property(e => e.Cccd)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CCCD");
            entity.Property(e => e.MaHopDong)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NgayCap).HasColumnType("date");
            entity.Property(e => e.NgayDangKyTamTru).HasColumnType("date");
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.NoiCap).HasMaxLength(50);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenNguoiTro).HasMaxLength(150);
            entity.Property(e => e.XacMinhThongTin).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.MaHopDongNavigation).WithMany(p => p.DanhSachNguoiTros)
                .HasForeignKey(d => d.MaHopDong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DSNguoiTro_HopDong");
        });

        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.MaDichVu).HasName("PK__DichVu__C0E6DE8F8E463100");

            entity.ToTable("DichVu");

            entity.Property(e => e.MaDichVu)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DonViTinh).HasMaxLength(100);
            entity.Property(e => e.TenDichVu).HasMaxLength(150);
        });

        modelBuilder.Entity<DichVuKhuTro>(entity =>
        {
            entity.HasKey(e => new { e.MaDichVu, e.MaKhuTro });

            entity.ToTable("DichVu_KhuTro");

            entity.Property(e => e.MaDichVu)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaKhuTro)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DonGia).HasColumnType("decimal(19, 4)");

            entity.HasOne(d => d.MaDichVuNavigation).WithMany(p => p.DichVuKhuTros)
                .HasForeignKey(d => d.MaDichVu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DichVuKhuTro_DichVu");

            entity.HasOne(d => d.MaKhuTroNavigation).WithMany(p => p.DichVuKhuTros)
                .HasForeignKey(d => d.MaKhuTro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DichVuKhuTro_KhuTro");
        });

        modelBuilder.Entity<DichVuPhong>(entity =>
        {
            entity.HasKey(e => new { e.MaDichVu, e.MaKhuTro, e.MaPhong });

            entity.ToTable("DichVu_Phong");

            entity.Property(e => e.MaDichVu)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaKhuTro)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaPhong)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.DichVuPhongs)
                .HasForeignKey(d => d.MaPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DichVuPhong_Phong");

            entity.HasOne(d => d.Ma).WithMany(p => p.DichVuPhongs)
                .HasForeignKey(d => new { d.MaDichVu, d.MaKhuTro })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DichVu_Phong");
        });

        modelBuilder.Entity<DmManHinh>(entity =>
        {
            entity.HasKey(e => e.MaManHinh).HasName("PK__DM_ManHi__D849392226F29633");

            entity.ToTable("DM_ManHinh");

            entity.HasIndex(e => e.TenManHinh, "UQ__DM_ManHi__6A9FD4D76D83470C").IsUnique();

            entity.Property(e => e.MaManHinh)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenManHinh).HasMaxLength(150);
        });

        modelBuilder.Entity<DongHoDien>(entity =>
        {
            entity.HasKey(e => e.MaBanGhi).HasName("PK__DongHoDi__49DB953503538749");

            entity.ToTable("DongHoDien");

            entity.Property(e => e.MaBanGhi)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaPhong)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NgayGhi).HasColumnType("date");

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.DongHoDiens)
                .HasForeignKey(d => d.MaPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DongHoDien_Phong");
        });

        modelBuilder.Entity<DongHoNuoc>(entity =>
        {
            entity.HasKey(e => e.MaBanGhi).HasName("PK__DongHoNu__49DB9535A323F12D");

            entity.ToTable("DongHoNuoc");

            entity.Property(e => e.MaBanGhi)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaPhong)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NgayGhi).HasColumnType("date");

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.DongHoNuocs)
                .HasForeignKey(d => d.MaPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DongHoNuoc_Phong");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__HoaDon__835ED13B60A2DC16");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GhiChu).HasMaxLength(150);
            entity.Property(e => e.HanDongTien).HasColumnType("date");
            entity.Property(e => e.MaHopDong)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NgayLapHd)
                .HasColumnType("date")
                .HasColumnName("NgayLapHD");
            entity.Property(e => e.NgayThanhToan).HasColumnType("date");
            entity.Property(e => e.TienPhong).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.ToiNgay).HasColumnType("date");
            entity.Property(e => e.TongTien).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.TuNgay).HasColumnType("date");

            entity.HasOne(d => d.MaHopDongNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaHopDong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDon__MaHopDon__74AE54BC");

            entity.HasMany(d => d.MaPhieuChis).WithMany(p => p.MaHoaDons)
                .UsingEntity<Dictionary<string, object>>(
                    "HoaDonPhieuChi",
                    r => r.HasOne<PhieuChi>().WithMany()
                        .HasForeignKey("MaPhieuChi")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_HoaDonPhieuChi_PhieuChi"),
                    l => l.HasOne<HoaDon>().WithMany()
                        .HasForeignKey("MaHoaDon")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_HoaDonPhieuChi_HoaDon"),
                    j =>
                    {
                        j.HasKey("MaHoaDon", "MaPhieuChi");
                        j.ToTable("HoaDon_PhieuChi");
                    });
        });

        modelBuilder.Entity<HoaDonDichVu>(entity =>
        {
            entity.HasKey(e => new { e.MaHoaDon, e.MaDichVu });

            entity.ToTable("HoaDon_DichVu");

            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaDichVu)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DonGia).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(19, 4)");

            entity.HasOne(d => d.MaDichVuNavigation).WithMany(p => p.HoaDonDichVus)
                .HasForeignKey(d => d.MaDichVu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoaDonDichVu_DichVu");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.HoaDonDichVus)
                .HasForeignKey(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaHoaDonDichVu_HoaDon");
        });

        modelBuilder.Entity<HoaDonDien>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__HoaDon_D__835ED13B2A5C0175");

            entity.ToTable("HoaDon_Dien");

            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BanGhiSoCuoi)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BanGhiSoDau)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DonGia).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(19, 4)");

            entity.HasOne(d => d.BanGhiSoCuoiNavigation).WithMany(p => p.HoaDonDienBanGhiSoCuoiNavigations)
                .HasForeignKey(d => d.BanGhiSoCuoi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoaDonDien_SoCuoi");

            entity.HasOne(d => d.BanGhiSoDauNavigation).WithMany(p => p.HoaDonDienBanGhiSoDauNavigations)
                .HasForeignKey(d => d.BanGhiSoDau)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoaDonDien_SoDau");

            entity.HasOne(d => d.MaHoaDonNavigation).WithOne(p => p.HoaDonDien)
                .HasForeignKey<HoaDonDien>(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaHoaDon");
        });

        modelBuilder.Entity<HoaDonNuoc>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__HoaDon_N__835ED13BC84E2F66");

            entity.ToTable("HoaDon_Nuoc");

            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BanGhiSoCuoi)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BanGhiSoDau)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DonGia).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(19, 4)");

            entity.HasOne(d => d.BanGhiSoCuoiNavigation).WithMany(p => p.HoaDonNuocBanGhiSoCuoiNavigations)
                .HasForeignKey(d => d.BanGhiSoCuoi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoaDonNuoc_SoCuoi");

            entity.HasOne(d => d.BanGhiSoDauNavigation).WithMany(p => p.HoaDonNuocBanGhiSoDauNavigations)
                .HasForeignKey(d => d.BanGhiSoDau)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoaDonNuoc_SoDau");

            entity.HasOne(d => d.MaHoaDonNavigation).WithOne(p => p.HoaDonNuoc)
                .HasForeignKey<HoaDonNuoc>(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoaDonNuoc_HoaDon");
        });

        modelBuilder.Entity<HopDongThue>(entity =>
        {
            entity.HasKey(e => e.MaHopDong).HasName("PK__HopDongT__36DD43424DD1FF09");

            entity.ToTable("HopDongThue");

            entity.Property(e => e.MaHopDong)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FileHopDong).IsUnicode(false);
            entity.Property(e => e.MaNguoiThue)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaPhong)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TienCocDamBao).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.TinhTrangCoc).HasColumnType("decimal(19, 4)");

            entity.HasOne(d => d.MaNguoiThueNavigation).WithMany(p => p.HopDongThues)
                .HasForeignKey(d => d.MaNguoiThue)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HopDong_NguoiThue");

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.HopDongThues)
                .HasForeignKey(d => d.MaPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HopDong_Phong");
        });

        modelBuilder.Entity<KhuTro>(entity =>
        {
            entity.HasKey(e => e.MaKhuTro).HasName("PK__KhuTro__05E24E48B101ED40");

            entity.ToTable("KhuTro");

            entity.Property(e => e.MaKhuTro)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GiaDien).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.GiaNuoc).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.MaNguoiDung)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NgayLapHd).HasColumnName("NgayLapHD");
            entity.Property(e => e.SoPhong).HasDefaultValueSql("((0))");
            entity.Property(e => e.TenKhu).HasMaxLength(150);

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.KhuTros)
                .HasForeignKey(d => d.MaNguoiDung)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KhuTro_NguoiDung");
        });

        modelBuilder.Entity<LoaiPhong>(entity =>
        {
            entity.HasKey(e => e.MaLoai).HasName("PK__LoaiPhon__730A5759D14A35CA");

            entity.ToTable("LoaiPhong");

            entity.HasIndex(e => e.TenLoai, "UQ__LoaiPhon__E29B1042A2C4B62F").IsUnique();

            entity.Property(e => e.MaLoai)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GhiChu).HasMaxLength(150);
            entity.Property(e => e.TenLoai).HasMaxLength(150);

            entity.HasMany(d => d.MaPhongs).WithMany(p => p.MaLoais)
                .UsingEntity<Dictionary<string, object>>(
                    "LoaiPhongPhong",
                    r => r.HasOne<Phong>().WithMany()
                        .HasForeignKey("MaPhong")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_LoaiPhongPhong_Phong"),
                    l => l.HasOne<LoaiPhong>().WithMany()
                        .HasForeignKey("MaLoai")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_LoaiPhongPhong_LoaiPhong"),
                    j =>
                    {
                        j.HasKey("MaLoai", "MaPhong");
                        j.ToTable("LoaiPhong_Phong");
                    });
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.MaNguoiDung).HasName("PK__NguoiDun__C539D7620A9C0A60");

            entity.ToTable("NguoiDung");

            entity.HasIndex(e => e.SoDienThoai, "UQ__NguoiDun__0389B7BDFD9FBF31").IsUnique();

            entity.HasIndex(e => e.Cccd, "UQ__NguoiDun__A955A0AAB6E89F14").IsUnique();

            entity.Property(e => e.MaNguoiDung)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AnhCccdsau).HasColumnName("AnhCCCDSau");
            entity.Property(e => e.AnhCccdtruoc).HasColumnName("AnhCCCDTruoc");
            entity.Property(e => e.Cccd)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CCCD");
            entity.Property(e => e.NgayCap).HasColumnType("date");
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.NoiCap).HasMaxLength(50);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenNguoiDung).HasMaxLength(150);
        });

        modelBuilder.Entity<PhieuChi>(entity =>
        {
            entity.HasKey(e => e.MaPhieuChi).HasName("PK__PhieuChi__00AC0F196874754A");

            entity.ToTable("PhieuChi");

            entity.Property(e => e.MaPhieuChi)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ChiPhi).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.ChiTietChi).HasMaxLength(150);
            entity.Property(e => e.GhiChu).HasMaxLength(150);
            entity.Property(e => e.MaKhuTro)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NgayChi).HasColumnType("date");
            entity.Property(e => e.TienKhachTra)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(19, 4)");

            entity.HasOne(d => d.MaKhuTroNavigation).WithMany(p => p.PhieuChis)
                .HasForeignKey(d => d.MaKhuTro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhieuChi_KhuTro");
        });

        modelBuilder.Entity<PhieuCocGiuPhong>(entity =>
        {
            entity.HasKey(e => e.MaPhieuCoc).HasName("PK__PhieuCoc__00AC24AA907F7A5B");

            entity.ToTable("PhieuCocGiuPhong");

            entity.Property(e => e.MaPhieuCoc).HasMaxLength(40);
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.MaNguoiDung)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaPhong)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NgayCoc)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.NgayDuKienVaoO).HasColumnType("date");
            entity.Property(e => e.SoTien).HasColumnType("decimal(19, 4)");

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.PhieuCocGiuPhongs)
                .HasForeignKey(d => d.MaNguoiDung)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhieuCoc_NguoiDung");

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.PhieuCocGiuPhongs)
                .HasForeignKey(d => d.MaPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhieuCoc_Phong");
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.HasKey(e => e.MaPhong).HasName("PK__Phong__20BD5E5B10DFAD48");

            entity.ToTable("Phong", tb =>
                {
                    tb.HasTrigger("trgCapNhapPhongKhuTro");
                    tb.HasTrigger("trgTaoDongHoDienNuoc");
                });

            entity.Property(e => e.MaPhong)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GhiChu).HasMaxLength(150);
            entity.Property(e => e.GiaThue).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.MaKhuTro)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenPhong).HasMaxLength(150);

            entity.HasOne(d => d.MaKhuTroNavigation).WithMany(p => p.Phongs)
                .HasForeignKey(d => d.MaKhuTro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Phong_KhuTro");
        });

        modelBuilder.Entity<PhuLuc>(entity =>
        {
            entity.HasKey(e => e.MaPhuLuc).HasName("PK__PhuLuc__FB0ECCD87D9A972E");

            entity.ToTable("PhuLuc");

            entity.Property(e => e.MaPhuLuc)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GhiChu).HasMaxLength(150);
            entity.Property(e => e.GiaThue).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.MaHopDong)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NgayBatDau).HasColumnType("date");
            entity.Property(e => e.NgayKetThuc).HasColumnType("date");

            entity.HasOne(d => d.MaHopDongNavigation).WithMany(p => p.PhuLucs)
                .HasForeignKey(d => d.MaHopDong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhuLuc_HopDong");
        });

        modelBuilder.Entity<QlNguoiDungNhomNguoiDung>(entity =>
        {
            entity.HasKey(e => new { e.MaNguoiDung, e.MaNhomNguoiDung }).HasName("PK_NguoiDungNhomNguoiDung");

            entity.ToTable("QL_NguoiDungNhomNguoiDung");

            entity.Property(e => e.MaNguoiDung)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaNhomNguoiDung)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GhiChu).HasMaxLength(50);

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.QlNguoiDungNhomNguoiDungs)
                .HasForeignKey(d => d.MaNguoiDung)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NguoiDungNhomNguoiDung_NguoiDung");

            entity.HasOne(d => d.MaNhomNguoiDungNavigation).WithMany(p => p.QlNguoiDungNhomNguoiDungs)
                .HasForeignKey(d => d.MaNhomNguoiDung)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NguoiDungNhomNguoiDung_NhomNguoiDung");
        });

        modelBuilder.Entity<QlNhomNguoiDung>(entity =>
        {
            entity.HasKey(e => e.MaNhom).HasName("PK__QL_NhomN__234F91CDC94D19BD");

            entity.ToTable("QL_NhomNguoiDung");

            entity.HasIndex(e => e.TenNhom, "UQ__QL_NhomN__2B432D0D4F64146E").IsUnique();

            entity.Property(e => e.MaNhom)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GhiChu).HasMaxLength(150);
            entity.Property(e => e.TenNhom).HasMaxLength(150);
        });

        modelBuilder.Entity<QlPhanQuyen>(entity =>
        {
            entity.HasKey(e => new { e.MaNhomNguoiDung, e.MaManHinh }).HasName("PK_PhanQuyen");

            entity.ToTable("QL_PhanQuyen");

            entity.Property(e => e.MaNhomNguoiDung)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaManHinh)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MaManHinhNavigation).WithMany(p => p.QlPhanQuyens)
                .HasForeignKey(d => d.MaManHinh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhanQuyen_ManHinh");

            entity.HasOne(d => d.MaNhomNguoiDungNavigation).WithMany(p => p.QlPhanQuyens)
                .HasForeignKey(d => d.MaNhomNguoiDung)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhanQuyen_NhomNguoiDung");
        });

        modelBuilder.Entity<TienIch>(entity =>
        {
            entity.HasKey(e => e.MaTienIch).HasName("PK__TienIch__4697D8EA81CAF1E4");

            entity.ToTable("TienIch");

            entity.HasIndex(e => e.TenTienIch, "UQ__TienIch__0DE17DA8DC1B1434").IsUnique();

            entity.Property(e => e.MaTienIch)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GhiChu).HasMaxLength(150);
            entity.Property(e => e.TenTienIch).HasMaxLength(150);

            entity.HasMany(d => d.MaKhuTros).WithMany(p => p.MaTienIches)
                .UsingEntity<Dictionary<string, object>>(
                    "KhuTroTienIch",
                    r => r.HasOne<KhuTro>().WithMany()
                        .HasForeignKey("MaKhuTro")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_KhuTroTienIchKhuTro"),
                    l => l.HasOne<TienIch>().WithMany()
                        .HasForeignKey("MaTienIch")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_KhuTroTienIch_TienIch"),
                    j =>
                    {
                        j.HasKey("MaTienIch", "MaKhuTro");
                        j.ToTable("KhuTro_TienIch");
                    });
        });

        modelBuilder.Entity<YeuCauSauChua>(entity =>
        {
            entity.HasKey(e => e.MaYeuCau).HasName("PK__YeuCauSa__CFA5DF4E21E3B009");

            entity.ToTable("YeuCauSauChua");

            entity.Property(e => e.MaYeuCau)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ChiTiet).HasMaxLength(150);
            entity.Property(e => e.HinhAnh).IsUnicode(false);
            entity.Property(e => e.MaHopDong)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NgayYeuCau).HasColumnType("date");

            entity.HasOne(d => d.MaHopDongNavigation).WithMany(p => p.YeuCauSauChuas)
                .HasForeignKey(d => d.MaHopDong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SuaChua_HopDong");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
