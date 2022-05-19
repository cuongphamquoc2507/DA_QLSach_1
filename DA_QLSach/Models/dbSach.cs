using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DA_QLSach.Models
{
    public partial class dbSach : DbContext
    {
        public dbSach()
            : base("name=dbSach2")
        {
        }

        public virtual DbSet<CT_HoaDon> CT_HoaDon { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TacGia> TacGias { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.CT_HoaDon)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SoDT)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MatKhau)
                .IsFixedLength();

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.CT_HoaDon)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TacGia>()
                .HasMany(e => e.Saches)
                .WithRequired(e => e.TacGia)
                .WillCascadeOnDelete(false);
        }
    }
}
