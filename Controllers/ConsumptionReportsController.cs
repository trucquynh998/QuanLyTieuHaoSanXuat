using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TieuHaoSanXuat.Models;

public class ConsumptionReportController : Controller
{
    private readonly ApplicationDbContext _context;

    public ConsumptionReportController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: ConsumptionReport
    public async Task<IActionResult> Index()
    {
        var reports = await _context.ConsumptionReports
            .Include(cr => cr.MaterialConsumptions)
            .ToListAsync();
        return View(reports);
    }

    // GET: ConsumptionReport/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ConsumptionReport/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,ReportDate,TotalMaterialsUsed,Notes")] ConsumptionReport report)
    {
        if (ModelState.IsValid)
        {
            _context.Add(report);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(report);
    }

    // GET: ConsumptionReport/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var report = await _context.ConsumptionReports
            .Include(cr => cr.MaterialConsumptions)
            .ThenInclude(mc => mc.Material)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (report == null)
        {
            return NotFound();
        }

        return View(report);
    }
}
