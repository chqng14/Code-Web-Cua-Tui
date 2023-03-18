using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ProductCode).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Describe).HasColumnType("nvarchar(1000)").IsRequired(false);
            builder.Property(x => x.ProductCode).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.Name).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.Quantity).HasColumnType("int").IsRequired();
            builder.Property(x => x.Price).HasColumnType("Decimal").IsRequired();
            builder.Property(x => x.Status).HasColumnType("int");




            builder.HasOne(x => x.Color).WithMany(y => y.Product).
            HasForeignKey(c => c.ColorID);


            builder.HasOne(x => x.Sizes).WithMany(y => y.Product).
            HasForeignKey(c => c.SizeID);

            builder.HasOne(x => x.Suppliers).WithMany(y => y.Product).
            HasForeignKey(c => c.SupplierID);

            builder.HasOne(x => x.Category).WithMany(y => y.Product).
            HasForeignKey(c => c.CategoryID);

            builder.HasOne(x => x.Images).WithMany(y => y.Product).
            HasForeignKey(c => c.ImageID);
        }
    }
}
