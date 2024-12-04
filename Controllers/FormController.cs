using System.Diagnostics;
using feedback.Data;
using Microsoft.AspNetCore.Mvc;
using feedback.Models;

namespace feedback.Controllers;

public class FormController : Controller
{
    private readonly ApplicationDbContext _context;

    
    private readonly ILogger<FormController> _logger;

    public FormController(ILogger<FormController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context ?? throw new ArgumentNullException(nameof(context));

    }

    public IActionResult Index(int id, int category)
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(
        [Bind(
            "Id,AgeGroup,Education,Sex,Scale1,Scale2,Scale3,Scale4,Scale5,Scale6,Scale7,Scale8,Scale9,Scale10,Scale11,Scale12,Scale13,OpenQuestion")]
        FormEntry entry)
    {
        if (ModelState.IsValid)
        {
            
            _context.Add(entry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Success));
        }

        return View(entry);
    }

    public IActionResult Success()
    {
        return View();
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}