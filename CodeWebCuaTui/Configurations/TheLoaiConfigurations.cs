using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.Configurations
{
    public class TheLoaiConfigurations : IEntityTypeConfiguration<TheLoai>
    {
        public void Configure(EntityTypeBuilder<TheLoai> builder)
        {
            builder.ToTable("TheLoai");
            builder.HasKey(x => x.ID);
            builder.Property(c => c.Ma).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(c => c.Ten).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(c => c.TrangThai).HasColumnType("int");
        }
    }
}
