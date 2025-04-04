namespace TieuHaoSanXuat.Models
{
    public class Material
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!; 
        public string Unit { get; set; } = null!;
        public int QuantityInStock { get; set; } 
        public int WarehouseId { get; set; } 
        public int SupplierId { get; set; } 

        public virtual Warehouse? Warehouse { get; set; } = null!;
        public virtual Supplier? Supplier { get; set; } = null!;
    }
}
