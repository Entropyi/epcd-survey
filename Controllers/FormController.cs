using System.Diagnostics;
using System.Text.Encodings.Web;
using feedback.Data;
using Microsoft.AspNetCore.Mvc;
using feedback.Models;
using feedback.Shared;

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


    public async Task<IActionResult> Index(string Category, int FormID)
    {
        string category = HtmlEncoder.Default.Encode(Category);

        List<string> Categories = new();
        Categories.Add("Community");
        Categories.Add("Industry");
        
        ViewData["Category"] = category;
        
        ViewBag.Form = await _context.Form.FindAsync(FormID);
        
        
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(
        [Bind(
            "Id,FormId,AgeGroup,Education,Sex,Scale1,Scale2,Scale3,Scale4,Scale5,Scale6,Scale7,Scale8,Scale9,Scale10,OpenQuestion,Language,Category,CreationDate")]
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
    
    public IActionResult Home()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}