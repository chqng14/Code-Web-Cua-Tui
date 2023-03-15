using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.Configurations
{
    public class CartConfigurations : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Describe).HasColumnType("nvarchar(1000)");

            builder.HasOne(x => x.User).WithOne(y => y.Cart).HasForeignKey<Cart>(x=>x.ID);
        }
    }
}
