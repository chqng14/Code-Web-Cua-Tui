using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace CodeWebCuaTui.Models
{
    public class CodeWebCuaTuiDbContex : DbContext
    {
        public CodeWebCuaTuiDbContex()
        {
            
        }
        public CodeWebCuaTuiDbContex(DbContextOptions options) : base(options) { }

        public DbSet<Images> Images { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
        public DbSet<BillDetails> BillDetails { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PaymentMethods> PaymentMethods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Net104;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
