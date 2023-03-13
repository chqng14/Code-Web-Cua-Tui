using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.Configurations
{
    public class AnhConfigurations : IEntityTypeConfiguration<Anh>
    {
        public void Configure(EntityTypeBuilder<Anh> builder)
        {
            builder.ToTable("Anh");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.TenAnh).HasColumnType("nvarchar(1000)"); // Date time not null
            builder.Property(x => x.Duongdan).HasColumnType("nvarchar(1000)").IsRequired();

        }
    }
}
