using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.Configurations
{
    public class ChiTietGioHangConfigurations : IEntityTypeConfiguration<ChiTietGioHang>
    {
        public void Configure(EntityTypeBuilder<ChiTietGioHang> builder)
        {
            builder.ToTable("ChiTietGioHang");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.SoLuong).HasColumnType("int");
            builder.Property(x=>x.TrangThai).HasColumnType("int");
            builder.HasOne(x => x.ChiTietSp).WithMany(x => x.ChiTietGioHangs).HasForeignKey(x => x.IDCtsp).HasConstraintName("Fk_ctsp");
            builder.HasOne(x => x.GioHang).WithMany(x => x.ChitietGioHang).HasForeignKey(x => x.IDUser).HasConstraintName("Fk_GioHang");
        }
    }
}
