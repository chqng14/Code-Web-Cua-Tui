using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.Configurations
{
    public class ChiTietSpConfigurations : IEntityTypeConfiguration<ChiTietSp>
    {
        public void Configure(EntityTypeBuilder<ChiTietSp> builder)
        {
            builder.ToTable("ChiTietSp");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Ma).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.MoTa).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.SoLuongTon).HasColumnType("int").IsRequired();
            builder.Property(x => x.GiaNhap).HasColumnType("Decimal").IsRequired();
            builder.Property(x => x.GiaBan).HasColumnType("Decimal").IsRequired();
            builder.Property(x => x.TrangThai).HasColumnType("int");


            builder.HasOne(x => x.SanPham).WithMany(y => y.ChiTietSps).
            HasForeignKey(c => c.IDSanPham).HasConstraintName("fk_sp");

            builder.HasOne(x => x.MauSac).WithMany(y => y.ChiTietSps).
            HasForeignKey(c => c.IDMauSac).HasConstraintName("fk_mausac");


            builder.HasOne(x => x.KichCos).WithMany(y => y.ChiTietSps).
            HasForeignKey(c => c.IDKichCo).HasConstraintName("fk_kichco");

            builder.HasOne(x => x.NhaSanXuat).WithMany(y => y.ChiTietSps).
            HasForeignKey(c => c.IDNhaSX).HasConstraintName("fk_nxs");

            builder.HasOne(x => x.TheLoai).WithMany(y => y.ChiTietSps).
            HasForeignKey(c => c.IDTheLoai).HasConstraintName("fk_theloai");
        }
    }
}
