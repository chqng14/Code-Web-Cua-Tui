using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.Configurations
{
    public class BillDetailsConfigurations : IEntityTypeConfiguration<BillDetails>
    {
        public void Configure(EntityTypeBuilder<BillDetails> builder)
        {
            builder.ToTable("BillDetails");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Quantity).HasColumnType("int").IsRequired(true);
            builder.Property(x => x.Price).HasColumnType("Decimal").IsRequired(true);
            builder.Property(x => x.Status).HasColumnType("int");


            builder.HasOne(x => x.Bill).WithMany(y => y.BillDetails).
            HasForeignKey(c => c.BillID);

            builder.HasOne(x => x.Product).WithMany(y => y.BillDetails).
            HasForeignKey(c => c.ProductId);
        }
    }
}
