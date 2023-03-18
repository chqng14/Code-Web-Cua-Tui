using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.Configurations
{
    public class CartDetailsConfigurations : IEntityTypeConfiguration<CartDetails>
    {
        public void Configure(EntityTypeBuilder<CartDetails> builder)
        {
            builder.ToTable("CartDetails");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Quantity).HasColumnType("int").IsRequired(true);
            builder.Property(x=>x.Status).HasColumnType("int");
            builder.HasOne(x => x.Product).WithMany(x => x.CartDetails).HasForeignKey(x => x.ProductId).HasConstraintName("Fk_ctsp");
            builder.HasOne(x => x.Cart).WithMany(x => x.CartDetails).HasForeignKey(x => x.UserID).HasConstraintName("Fk_GioHang");
        }
    }
}
