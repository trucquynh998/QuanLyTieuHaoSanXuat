namespace TieuHaoSanXuat.Models
{
    public class ProductionProcess
    {
        internal object Material;

        public int Id { get; set; } // Khóa chính
        public string ProcessName { get; set; } = null!; // Tên quy trình
        public string Description { get; set; } = string.Empty; // Mô tả quy trình

        public virtual ICollection<MaterialConsumption> MaterialConsumptions { get; set; } = new List<MaterialConsumption>();
        
    }
}
