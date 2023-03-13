namespace CodeWebCuaTui.Models
{
    public class PhuongThucThanhToan
    {
        public Guid ID { get; set; }
        public string Ma { get; set; }
        public string Ten  { get; set; }
        public int TrangThai { get; set; }

        public virtual List<HoaDon> HoaDons { get; set; }
    }
}
