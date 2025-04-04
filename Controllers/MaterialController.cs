using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TieuHaoSanXuat.Models;

namespace TieuHaoSanXuat.Controllers
{
    public class MaterialsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaterialsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Material
        public async Task<IActionResult> Index()
        {
            var materials = await _context.Materials.Include(m => m.Warehouse).Include(m => m.Supplier).ToListAsync();
            return View(materials);
        }

        // GET: Material/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.WarehouseId = new SelectList(_context.Warehouses, "Id", "Name");
            ViewBag.SupplierId = new SelectList(_context.Suppliers, "Id", "Name");
            return View();
        }

        // POST: Material/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Unit,QuantityInStock,WarehouseId,SupplierId")] Material material)
        {
            if (ModelState.IsValid)
            {
                _context.Add(material);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.WarehouseId = new SelectList(_context.Warehouses, "Id", "Name",material.WarehouseId);
            ViewBag.SupplierId = new SelectList(_context.Suppliers, "Id", "Name",material.SupplierId);
            return View(material);
        }

        // GET: Material/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var material = await _context.Materials.FindAsync(id);
            if (material == null) return NotFound();
            ViewBag.WarehouseId = new SelectList(_context.Warehouses, "Id", "Name", material.WarehouseId);
            ViewBag.SupplierId = new SelectList(_context.Suppliers, "Id", "Name", material.SupplierId);
            return View(material);
        }

        // POST: Material/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Unit,QuantityInStock,WarehouseId,SupplierId")] Material material)
        {
            if (id != material.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(material);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.WarehouseId = new SelectList(_context.Warehouses, "Id", "Name", material.WarehouseId);
            ViewBag.SupplierId = new SelectList(_context.Suppliers, "Id", "Name", material.SupplierId);
            return View(material);
        }

        // GET: Material/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var material = await _context.Materials.FindAsync(id);
            if (material == null) return NotFound();
            return View(material);
        }

        // POST: Material/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var material = await _context.Materials.FindAsync(id);
            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
