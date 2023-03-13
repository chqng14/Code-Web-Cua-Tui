namespace CodeWebCuaTui.Models
{
    public class Anh
    {
        public Guid ID { get; set; }
        public Guid IDctsp { get; set; }
        public string TenAnh { get; set; }
        public string Duongdan { get; set; }
        public int TrangThai { get; set; }
        public virtual ChiTietSp ChiTietSp { get; set; }
    }
}
