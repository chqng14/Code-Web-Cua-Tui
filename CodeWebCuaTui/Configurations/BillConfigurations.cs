using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.Configurations
{
    public class BillConfigurations : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bill");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.BillCode).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.DateCreate).HasColumnType("Datetime").IsRequired();
            builder.Property(x => x.Name).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Address).HasColumnType("nvarchar(1000)").IsRequired(true);
            builder.Property(x => x.Phone).HasColumnType("nvarchar(10)").IsRequired();
            builder.Property(x => x.Describe).HasColumnType("nvarchar(1000)").IsRequired(false);
            builder.Property(x => x.TotalAmount).HasColumnType("Decimal").IsRequired(true);
            builder.Property(x => x.Status).HasColumnType("int");

            builder.HasOne(x => x.User).WithMany(y => y.Bills).
            HasForeignKey(c => c.UserID).HasConstraintName("fk_user");
        }
    }
}
