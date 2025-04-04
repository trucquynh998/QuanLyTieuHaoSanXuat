using TieuHaoSanXuat.Models;

public class MaterialConsumption
{
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public int ProcessId { get; set; }
    public int QuantityUsed { get; set; }
    public DateTime ConsumptionDate { get; set; }
    public string Notes { get; set; } = string.Empty;

    public virtual Material Material { get; set; } = null!;
    public virtual ProductionProcess Process { get; set; } = null!;
}
