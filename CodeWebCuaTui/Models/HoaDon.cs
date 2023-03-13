namespace CodeWebCuaTui.Models
{
    public class HoaDon
    {
        public Guid ID { get; set; }
        public Guid IDUser { get; set; }
        public Guid IDPTTT { get; set; }
        public string MaHD { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public string TenNguoiNhan { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string MoTa { get; set; }
        public decimal TongTien { get; set; }
        public int TrangThai { get; set; }
        public int TrangThaiGiaoHang { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
        public virtual PhuongThucThanhToan PhuongThucThanhToan { get; set; }  
        public virtual List<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
