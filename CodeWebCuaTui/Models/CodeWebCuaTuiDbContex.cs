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

        public DbSet<Anh> anhs { get; set; }
        public DbSet<ChiTietGioHang> ChiTietGioHang { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDoon { get; set; }
        public DbSet<ChiTietSp> ChiTietSP { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<HoaDon> hoaDons { get; set; }
        public DbSet<KichCo> kichCos { get; set; }
        public DbSet<MauSac> mauSacs { get; set; }
        public DbSet<NguoiDung> nguoiDungs { get; set; }
        public DbSet<NhaSanXuat> NhaSanXuats { get; set; }
        public DbSet<PhuongThucThanhToan> PhuongThucThanhToans { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<TheLoai> theLoais { get; set; }
        public DbSet<VaiTro> vaiTros { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=C#4_PH25680;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
