namespace CodeWebCuaTui.Models
{
    public class ChiTietHoaDon
    {
        public Guid ID { get; set; }
        public Guid IDHoaDon { get; set; }
        public Guid IDChiTietSP { get; set; }
        public int Soluong { get; set; }
        public decimal DonGia { get; set; }
        public int TrangThai { get; set; }
        public virtual ChiTietSp ChiTietSp { get; set; }
        public virtual HoaDon HoaDon { get; set; }
    }
}
