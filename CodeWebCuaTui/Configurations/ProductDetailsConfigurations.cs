using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.Configurations
{
    public class ProductDetailsConfigurations : IEntityTypeConfiguration<ProductDetails>
    {
        public void Configure(EntityTypeBuilder<ProductDetails> builder)
        {
            builder.ToTable("ProductDetails");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ProductCode).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Describe).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.Quantity).HasColumnType("int").IsRequired();
            builder.Property(x => x.Price).HasColumnType("Decimal").IsRequired();
            builder.Property(x => x.Status).HasColumnType("int");


            builder.HasOne(x => x.Product).WithMany(y => y.ProductDetails).
            HasForeignKey(c => c.ProductID);

            builder.HasOne(x => x.Color).WithMany(y => y.ProductDetails).
            HasForeignKey(c => c.ColorID);


            builder.HasOne(x => x.Sizes).WithMany(y => y.ProductDetails).
            HasForeignKey(c => c.SizeID);

            builder.HasOne(x => x.Suppliers).WithMany(y => y.ProductDetails).
            HasForeignKey(c => c.SupplierID);

            builder.HasOne(x => x.Category).WithMany(y => y.ProductDetails).
            HasForeignKey(c => c.CategoryID);
        }
    }
}
