using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_Android.Models.Entities;

public partial class QlQuanCafeContext : DbContext
{
    public QlQuanCafeContext()
    {
    }

    public QlQuanCafeContext(DbContextOptions<QlQuanCafeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ban> Bans { get; set; }

    public virtual DbSet<Calam> Calams { get; set; }

    public virtual DbSet<Chucvu> Chucvus { get; set; }

    public virtual DbSet<CtHoadon> CtHoadons { get; set; }

    public virtual DbSet<Hoadon> Hoadons { get; set; }

    public virtual DbSet<Khachhang> Khachhangs { get; set; }

    public virtual DbSet<Loaithucuong> Loaithucuongs { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<NhanvienCoCalam> NhanvienCoCalams { get; set; }

    public virtual DbSet<Thucuong> Thucuongs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-02U2UQD\\VANHIEN;Initial Catalog=QL_QuanCafe;User ID=sa;Password=123;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ban>(entity =>
        {
            entity.HasKey(e => e.Maban);

            entity.ToTable("BAN");

            entity.Property(e => e.Maban)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MABAN");
            entity.Property(e => e.Tenban)
                .HasMaxLength(50)
                .HasColumnName("TENBAN");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(20)
                .HasColumnName("TRANGTHAI");
        });

        modelBuilder.Entity<Calam>(entity =>
        {
            entity.HasKey(e => e.Macalam);

            entity.ToTable("CALAM");

            entity.Property(e => e.Macalam)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MACALAM");
            entity.Property(e => e.Tencalam)
                .HasMaxLength(50)
                .HasColumnName("TENCALAM");
            entity.Property(e => e.Thoigianbatdau).HasColumnName("THOIGIANBATDAU");
            entity.Property(e => e.Thoigianketthuc).HasColumnName("THOIGIANKETTHUC");
        });

        modelBuilder.Entity<Chucvu>(entity =>
        {
            entity.HasKey(e => e.Machucvu);

            entity.ToTable("CHUCVU");

            entity.Property(e => e.Machucvu)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MACHUCVU");
            entity.Property(e => e.Tenchucvu)
                .HasMaxLength(40)
                .HasColumnName("TENCHUCVU");
        });

        modelBuilder.Entity<CtHoadon>(entity =>
        {
            entity.HasKey(e => new { e.Manuoc, e.Mahoadon });

            entity.ToTable("CT_HOADON", tb => tb.HasTrigger("CAPNHAT_THANHTIEN"));

            entity.Property(e => e.Manuoc)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MANUOC");
            entity.Property(e => e.Mahoadon)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MAHOADON");
            entity.Property(e => e.Dongia).HasColumnName("DONGIA");
            entity.Property(e => e.Sl).HasColumnName("SL");
            entity.Property(e => e.Tennuoc)
                .HasMaxLength(30)
                .HasColumnName("TENNUOC");
            entity.Property(e => e.Thanhtien)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("THANHTIEN");

            entity.HasOne(d => d.MahoadonNavigation).WithMany(p => p.CtHoadons)
                .HasForeignKey(d => d.Mahoadon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CT_HOADO_CT_HOADON_HOADON");

            entity.HasOne(d => d.ManuocNavigation).WithMany(p => p.CtHoadons)
                .HasForeignKey(d => d.Manuoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CT_HOADO_CT_HOADON_THUCUONG");
        });

        modelBuilder.Entity<Hoadon>(entity =>
        {
            entity.HasKey(e => e.Mahoadon);

            entity.ToTable("HOADON");

            entity.Property(e => e.Mahoadon)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MAHOADON");
            entity.Property(e => e.Giora).HasColumnName("GIORA");
            entity.Property(e => e.Giovao).HasColumnName("GIOVAO");
            entity.Property(e => e.Maban)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MABAN");
            entity.Property(e => e.Manhanvien)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MANHANVIEN");
            entity.Property(e => e.Ngayxuat)
                .HasColumnType("date")
                .HasColumnName("NGAYXUAT");
            entity.Property(e => e.Tenhoadon)
                .HasMaxLength(20)
                .HasColumnName("TENHOADON");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(20)
                .HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.MabanNavigation).WithMany(p => p.Hoadons)
                .HasForeignKey(d => d.Maban)
                .HasConstraintName("FK_HOADON_BAN");

            entity.HasOne(d => d.ManhanvienNavigation).WithMany(p => p.Hoadons)
                .HasForeignKey(d => d.Manhanvien)
                .HasConstraintName("FK_HOADON_RELATIONS_NHANVIEN");
        });

        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.Makhachhang);

            entity.ToTable("KHACHHANG");

            entity.Property(e => e.Makhachhang)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MAKHACHHANG");
            entity.Property(e => e.Maban)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MABAN");
            entity.Property(e => e.Thoigianden)
                .HasColumnType("datetime")
                .HasColumnName("THOIGIANDEN");

            entity.HasOne(d => d.MabanNavigation).WithMany(p => p.Khachhangs)
                .HasForeignKey(d => d.Maban)
                .HasConstraintName("FK_KHACHHANG_BAN");
        });

        modelBuilder.Entity<Loaithucuong>(entity =>
        {
            entity.HasKey(e => e.Maloai);

            entity.ToTable("LOAITHUCUONG");

            entity.Property(e => e.Maloai)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MALOAI");
            entity.Property(e => e.Tenloai)
                .HasMaxLength(30)
                .HasColumnName("TENLOAI");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.Manhanvien);

            entity.ToTable("NHANVIEN");

            entity.Property(e => e.Manhanvien)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MANHANVIEN");
            entity.Property(e => e.Diachi)
                .HasMaxLength(100)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Gioitinh)
                .HasMaxLength(4)
                .HasColumnName("GIOITINH");
            entity.Property(e => e.Machucvu)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MACHUCVU");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MATKHAU");
            entity.Property(e => e.Sdt)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.Taikhoan)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("TAIKHOAN");
            entity.Property(e => e.Tennhanvien)
                .HasMaxLength(50)
                .HasColumnName("TENNHANVIEN");

            entity.HasOne(d => d.MachucvuNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.Machucvu)
                .HasConstraintName("FK_NHANVIEN_RELATIONS_CHUCVU");
        });

        modelBuilder.Entity<NhanvienCoCalam>(entity =>
        {
            entity.HasKey(e => new { e.Manhanvien, e.Macalam });

            entity.ToTable("NHANVIEN_CO_CALAM");

            entity.Property(e => e.Manhanvien)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MANHANVIEN");
            entity.Property(e => e.Macalam)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MACALAM");
            entity.Property(e => e.Thoigianra)
                .HasColumnType("datetime")
                .HasColumnName("THOIGIANRA");
            entity.Property(e => e.Thoigianvao)
                .HasColumnType("datetime")
                .HasColumnName("THOIGIANVAO");

            entity.HasOne(d => d.MacalamNavigation).WithMany(p => p.NhanvienCoCalams)
                .HasForeignKey(d => d.Macalam)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NHANVIEN_NHANVIEN__CALAM");

            entity.HasOne(d => d.ManhanvienNavigation).WithMany(p => p.NhanvienCoCalams)
                .HasForeignKey(d => d.Manhanvien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NHANVIEN_NHANVIEN__NHANVIEN");
        });

        modelBuilder.Entity<Thucuong>(entity =>
        {
            entity.HasKey(e => e.Manuoc);

            entity.ToTable("THUCUONG");

            entity.Property(e => e.Manuoc)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MANUOC");
            entity.Property(e => e.Gia).HasColumnName("GIA");
            entity.Property(e => e.Maloai)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MALOAI");
            entity.Property(e => e.Size)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("SIZE");
            entity.Property(e => e.Tennuoc)
                .HasMaxLength(40)
                .HasColumnName("TENNUOC");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.MaloaiNavigation).WithMany(p => p.Thucuongs)
                .HasForeignKey(d => d.Maloai)
                .HasConstraintName("FK_THUCUONG_RELATIONS_LOAITHUC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
