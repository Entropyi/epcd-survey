using System.Diagnostics;
using feedback.Data;
using Microsoft.AspNetCore.Mvc;
using feedback.Models;

namespace feedback.Controllers;

public class FormController : Controller
{
    private readonly ApplicationDbContext _context;


    private readonly ILogger<FormController> _logger;

    public FormController(ILogger<FormController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(
        [Bind(
            "Id,FullNameInArabic,FullNameInEnglish,PhoneNumber,Email,Nationality,DateOfBirth,IdeaName,IdeaDescription,TeamName,CreationDate")]
        Request requests)
    {
        if (ModelState.IsValid)
        {
            _context.Add(requests);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(requests);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}