using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.Configurations
{
    public class ImagesConfigurations : IEntityTypeConfiguration<Images>
    {
        public void Configure(EntityTypeBuilder<Images> builder)
        {
            builder.ToTable("Image");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Path1).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Path2).HasColumnType("nvarchar(1000)").IsRequired(false);
            builder.Property(x => x.Name).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Path3).HasColumnType("nvarchar(1000)").IsRequired(false);
            builder.Property(x => x.Path4).HasColumnType("nvarchar(1000)").IsRequired(false);

        }
    }
}
