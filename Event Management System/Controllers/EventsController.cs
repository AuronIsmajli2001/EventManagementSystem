using Event_Management_System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class EventsController : Controller
{
    private readonly ApplicationDbContext _context;

    public EventsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // LIST + FILTER + SORT + PAGINATION
    public async Task<IActionResult> Index(
        string search,
        string sortOrder,
        int page = 1)
    {
        var query = _context.Events
            .Where(e => e.IsActive);

        if (!string.IsNullOrEmpty(search))
            query = query.Where(e => e.Title.Contains(search));

        query = sortOrder switch
        {
            "date_desc" => query.OrderByDescending(e => e.EventDate),
            _ => query.OrderBy(e => e.EventDate)
        };

        int pageSize = 5;
        var events = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return View(events);
    }

    public async Task<IActionResult> Details(int id)
    {
        var ev = await _context.Events
            .FirstOrDefaultAsync(e => e.Id == id && e.IsActive);

        if (ev == null) return NotFound();
        return View(ev);
    }
}
