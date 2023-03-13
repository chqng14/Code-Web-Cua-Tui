using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.Configurations
{
    public class KichCoConfigurations : IEntityTypeConfiguration<KichCo>
    {
        public void Configure(EntityTypeBuilder<KichCo> builder)
        {
            builder.ToTable("KichCo");
            builder.Property(c => c.Ma).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(c => c.Ten).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(c => c.TrangThai).HasColumnType("int");
        }
    }
}
