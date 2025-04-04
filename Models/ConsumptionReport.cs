namespace TieuHaoSanXuat.Models
{
    public class ConsumptionReport
    {
        public int Id { get; set; } // Khóa chính
        public DateTime ReportDate { get; set; } // Ngày lập báo cáo
        public int TotalMaterialsUsed { get; set; } // Tổng vật tư tiêu hao
        public string Notes { get; set; } = string.Empty; // Ghi chú

        public virtual ICollection<MaterialConsumption> MaterialConsumptions { get; set; } = new List<MaterialConsumption>();
    }
}
