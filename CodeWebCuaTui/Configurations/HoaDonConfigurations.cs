using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.Configurations
{
    public class HoaDonConfigurations : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.ToTable("HoaDon");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.MaHD).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.NgayTao).HasColumnType("Datetime").IsRequired();
            builder.Property(x => x.NgayThanhToan).HasColumnType("Datetime");
            builder.Property(x => x.TenNguoiNhan).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.DiaChi).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.SDT).HasColumnType("nvarchar(10)").IsRequired();
            builder.Property(x => x.MoTa).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.TongTien).HasColumnType("Decimal");
            builder.Property(x => x.TrangThai).HasColumnType("int");
            builder.Property(x => x.TrangThaiGiaoHang).HasColumnType("int");


            builder.HasOne(x => x.PhuongThucThanhToan).WithMany(y => y.HoaDons).
            HasForeignKey(c => c.IDPTTT).HasConstraintName("fk_pttt");

            builder.HasOne(x => x.NguoiDung).WithMany(y => y.HoaDons).
            HasForeignKey(c => c.IDUser).HasConstraintName("fk_user");
        }
    }
}
