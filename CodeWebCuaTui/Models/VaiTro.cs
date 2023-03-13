namespace CodeWebCuaTui.Models
{
    public class VaiTro
    {
        public Guid ID { get; set; }
        public string Ma { get; set; }
        public string TenVaiTro { get; set; }
        public int TrangThai { get; set; }
        public virtual List<NguoiDung> NguoiDung { get; set; }
    }
}
