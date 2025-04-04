namespace TieuHaoSanXuat.Models
{
    public class Warehouse
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!; 
        public string Location { get; set; } = null!;

        public  int Capacity { get; set; }


        public string Status { get; set; } = null!;
        public virtual ICollection<Material> Materials { get; set; } = new List<Material>(); 
    }
}
