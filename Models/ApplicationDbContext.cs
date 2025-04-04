using Microsoft.EntityFrameworkCore;

namespace TieuHaoSanXuat.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<MaterialConsumption> MaterialConsumptions { get; set; }
        public DbSet<ProductionProcess> ProductionProcesses { get; set; }
        public DbSet<ConsumptionReport> ConsumptionReports { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>()
                .HasOne(m => m.Warehouse)
                .WithMany(w => w.Materials)
                .HasForeignKey(m => m.WarehouseId);

            modelBuilder.Entity<Material>()
                .HasOne(m => m.Supplier)
                .WithMany(s => s.Materials)
                .HasForeignKey(m => m.SupplierId);
        }
        
    }
}
