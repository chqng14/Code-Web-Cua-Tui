namespace CodeWebCuaTui.Models
{
    public class ChiTietGioHang
    {
        public Guid ID { get; set; }
        public Guid IDUser { get; set; }
        public Guid IDCtsp { get; set; }
        public int SoLuong { get; set; }
        public int TrangThai { get; set; }

        public virtual ChiTietSp ChiTietSp { get; set; }
        public virtual GioHang GioHang { get; set; }
    }
}
