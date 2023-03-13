using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.Configurations
{
    public class NguoiDungConfigurations : IEntityTypeConfiguration<NguoiDung>
    {
        public void Configure(EntityTypeBuilder<NguoiDung> builder)
        {
            builder.ToTable("NguoiDung");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Ma).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Ho).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.TenDem).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.Ten).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.SDT).HasColumnType("nvarchar(10)").IsRequired();
            builder.Property(x => x.DiaChi).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.GioiTinh).HasColumnType("int");
            builder.Property(x => x.NgaySinh).HasColumnType("Datetime");
            builder.Property(x => x.Email).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.TaiKhoan).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.MatKhau).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.TrangThai).HasColumnType("int");


            builder.HasOne(x => x.VaiTro).WithMany(y => y.NguoiDung).
            HasForeignKey(c => c.IdVaiTro).HasConstraintName("fk_vaitro");

        }
    }
}
