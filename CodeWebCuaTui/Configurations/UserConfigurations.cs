using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Code).HasColumnType("nvarchar(1000)").IsRequired(false);
            builder.Property(x => x.Name).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Phone).HasColumnType("nvarchar(10)").IsRequired();
            builder.Property(x => x.Address).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.Birthday).HasColumnType("Datetime");
            builder.Property(x => x.Email).HasColumnType("nvarchar(1000)").IsRequired(false);
            builder.Property(x => x.UserName).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Password).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Status).HasColumnType("int");


            builder.HasOne(x => x.Role).WithMany(y => y.User).
            HasForeignKey(c => c.RoleID);

        }
    }
}
