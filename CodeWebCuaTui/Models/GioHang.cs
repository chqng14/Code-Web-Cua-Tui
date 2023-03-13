namespace CodeWebCuaTui.Models
{
    public class GioHang
    {
        public Guid ID { get; set; }
        public string Mota { get; set; }
        public virtual NguoiDung NguoiDung { get; set; } 
        public virtual List<ChiTietGioHang> ChitietGioHang { get; set; }
    }
}
