using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.Configurations
{
    public class ChiTietHoaDonConfigurations : IEntityTypeConfiguration<ChiTietHoaDon>
    {
        public void Configure(EntityTypeBuilder<ChiTietHoaDon> builder)
        {
            builder.ToTable("ChiTietHoaDon");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Soluong).HasColumnType("int");
            builder.Property(x => x.DonGia).HasColumnType("Decimal");
            builder.Property(x => x.TrangThai).HasColumnType("int");


            builder.HasOne(x => x.HoaDon).WithMany(y => y.ChiTietHoaDons).
            HasForeignKey(c => c.IDHoaDon).HasConstraintName("fk_hoadon");

            builder.HasOne(x => x.ChiTietSp).WithMany(y => y.ChiTietHoaDons).
            HasForeignKey(c => c.IDChiTietSP).HasConstraintName("fk_ctspp");
        }
    }
}
