using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TieuHaoSanXuat.Models;

public class MaterialConsumptionController : Controller
{
    private readonly ApplicationDbContext _context;

    public MaterialConsumptionController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    // GET: MaterialConsumption
    public async Task<IActionResult> Index()
    {
        var materialConsumptions = await _context.MaterialConsumptions
            .Include(mc => mc.Material)
            .Include(mc => mc.Process)
            .ToListAsync();
        return View(materialConsumptions);
    }

    // GET: MaterialConsumption/Create
    public IActionResult Create()
    {
        ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Name");
        ViewData["ProcessId"] = new SelectList(_context.ProductionProcesses, "Id", "ProcessName");
        return View();
    }

    // POST: MaterialConsumption/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,MaterialId,ProcessId,QuantityUsed,ConsumptionDate,Notes")] MaterialConsumption materialConsumption)
    {
        if (ModelState.IsValid)
        {
            _context.Add(materialConsumption);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Name", materialConsumption.MaterialId);
        ViewData["ProcessId"] = new SelectList(_context.ProductionProcesses, "Id", "ProcessName", materialConsumption.ProcessId);
        return View(materialConsumption);
    }

    // GET: MaterialConsumption/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var materialConsumption = await _context.MaterialConsumptions.FindAsync(id);
        if (materialConsumption == null)
        {
            return NotFound();
        }
        ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Name", materialConsumption.MaterialId);
        ViewData["ProcessId"] = new SelectList(_context.ProductionProcesses, "Id", "ProcessName", materialConsumption.ProcessId);
        return View(materialConsumption);
    }

    // POST: MaterialConsumption/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,MaterialId,ProcessId,QuantityUsed,ConsumptionDate,Notes")] MaterialConsumption materialConsumption)
    {
        if (id != materialConsumption.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(materialConsumption);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialConsumptionExists(materialConsumption.Id))
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
        ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Name", materialConsumption.MaterialId);
        ViewData["ProcessId"] = new SelectList(_context.ProductionProcesses, "Id", "ProcessName", materialConsumption.ProcessId);
        return View(materialConsumption);
    }

    // GET: MaterialConsumption/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var materialConsumption = await _context.MaterialConsumptions
            .Include(mc => mc.Material)
            .Include(mc => mc.Process)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (materialConsumption == null)
        {
            return NotFound();
        }

        return View(materialConsumption);
    }

    // POST: MaterialConsumption/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var materialConsumption = await _context.MaterialConsumptions.FindAsync(id);
        _context.MaterialConsumptions.Remove(materialConsumption);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MaterialConsumptionExists(int id)
    {
        return _context.MaterialConsumptions.Any(e => e.Id == id);
    }
}
