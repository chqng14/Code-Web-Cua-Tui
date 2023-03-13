namespace CodeWebCuaTui.Models
{
    public class MauSac
    {
        public Guid ID { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public int TrangThai { get; set; }
        public virtual List<ChiTietSp> ChiTietSps { get; set; }
    }
}
