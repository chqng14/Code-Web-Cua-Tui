using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.Configurations
{
    public class MauSacConfigurations : IEntityTypeConfiguration<MauSac>
    {
        public void Configure(EntityTypeBuilder<MauSac> builder)
        {
            builder.ToTable("MauSac");
            builder.HasKey(x => x.ID);
            builder.Property(c => c.Ma).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(c => c.Ten).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(c => c.TrangThai).HasColumnType("int");
        }
    }
}
