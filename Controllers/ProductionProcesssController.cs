using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TieuHaoSanXuat.Models;
using System.Threading.Tasks;
using System.Linq;

namespace TieuHaoSanXuat.Controllers
{
    public class ProductionProcesssController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductionProcesssController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductionProcesss
        public async Task<IActionResult> Index()
        {
            var productionProcesses = await _context.ProductionProcesses
                .Include(p => p.Material)
                .Include(p => p.MaterialConsumptions)
                .ToListAsync();
            return View(productionProcesses);
        }

        // GET: ProductionProcesss/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductionProcesss/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProcessName,Description")] ProductionProcess productionProcess)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productionProcess);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productionProcess);
        }

        // GET: ProductionProcesss/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionProcess = await _context.ProductionProcesses.FindAsync(id);
            if (productionProcess == null)
            {
                return NotFound();
            }
            return View(productionProcess);
        }

        // POST: ProductionProcesss/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProcessName,Description")] ProductionProcess productionProcess)
        {
            if (id != productionProcess.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productionProcess);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionProcessExists(productionProcess.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productionProcess);
        }

        // GET: ProductionProcesss/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionProcess = await _context.ProductionProcesses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productionProcess == null)
            {
                return NotFound();
            }

            return View(productionProcess);
        }

        // POST: ProductionProcesss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productionProcess = await _context.ProductionProcesses.FindAsync(id);
            if (productionProcess != null)
            {
                _context.ProductionProcesses.Remove(productionProcess);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProductionProcessExists(int id)
        {
            return _context.ProductionProcesses.Any(e => e.Id == id);
        }
    }
}
