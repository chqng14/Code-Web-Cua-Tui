using System.Data;

namespace CodeWebCuaTui.Models
{
    public class NguoiDung
    {
        public Guid ID { get; set; }
        public Guid IdVaiTro { get; set; }
        public string Ma { get; set; }
        public string Ho { get; set; }
        public string TenDem { get; set; }
        public string Ten { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public int GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Email { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public int TrangThai { get; set; }
        public virtual VaiTro VaiTro { get; set; }
        public virtual List<HoaDon> HoaDons { get; set; }
        public virtual List<GioHang> GioHang { get; set; } = new List<GioHang> { new GioHang() };
    }
}
