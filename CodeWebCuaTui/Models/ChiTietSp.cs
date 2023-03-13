namespace CodeWebCuaTui.Models
{
    public class ChiTietSp
    {
        public Guid ID { get; set; }
        public Guid IDSanPham { get; set; }
        public Guid IDMauSac { get; set; }
        public Guid IDKichCo { get; set; }
        public Guid IDNhaSX { get; set; }
        public Guid IDTheLoai { get; set; }
        public string Ma { get; set; }
        public string MoTa { get; set; }
        public int SoLuongTon { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal GiaBan { get; set; }
        public int TrangThai { get; set; }
        public virtual TheLoai TheLoai { get; set; }
        public virtual SanPham SanPham { get; set; }
        public virtual NhaSanXuat NhaSanXuat { get; set; }
        public virtual MauSac MauSac { get; set; }
        public virtual KichCo KichCos { get; set; }
        public virtual List<Anh> Anhs { get; set; }
        public virtual List<ChiTietGioHang> ChiTietGioHangs { get; set; }
        public virtual List<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    }
}
