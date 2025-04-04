namespace TieuHaoSanXuat.Models
{
    public class Supplier
    {
        public int Id { get; set; } // Khóa chính
        public string Name { get; set; } = null!; // Tên nhà cung cấp
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Material> Materials { get; set; } = new List<Material>(); // Vật tư cung cấp
    }
}