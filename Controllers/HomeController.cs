using System.Diagnostics;
using feedback.Data;
using Microsoft.AspNetCore.Mvc;
using feedback.Models;

namespace feedback.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;


    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context ?? throw new ArgumentNullException(nameof(context));

    }

    public IActionResult Index()
    {
        var latestEntryId = _context.Form
            .OrderByDescending(form => form.id)
            .Select(e => e.id)
            .FirstOrDefault();


        ViewData["From"] = latestEntryId;
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}