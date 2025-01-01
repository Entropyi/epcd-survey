using System.Diagnostics;
using Edi.Captcha;
using feedback.Data;
using Microsoft.AspNetCore.Mvc;
using feedback.Models;
using Humanizer;

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
        
        
        int tableCount = _context.Default.Count();
        
        int indestryFormID = 0;
        int communityFormID = 0;
        
        
        if (tableCount > 0)
        {
            int indestryCount = _context.Default
                .Count(d => d.Category == "Industry");

            if (indestryCount > 0)
            {
                 indestryFormID = _context.Default
                     .Where(d => d.Category == "Industry")
                     .Select(d => d.FormID)
                     .Single();
                 
                 
            }
            int communityCount = _context.Default
                .Count(d => d.Category == "Community");


            if (communityCount > 0)
            {
                 communityFormID = _context.Default
                     .Where(d => d.Category == "Community")
                     .Select(d => d.FormID)
                     .Single();
            }
        
        }

        var lastestFormDate = _context.Form
            .Where(form => form.id == latestEntryId)
            .Select(form => form.EndDate)
            .Single();
        
        Console.WriteLine(communityFormID);
        
        if (lastestFormDate.HasValue)
        {
            TimeSpan? dateDifference = lastestFormDate - DateTime.Now;
            if (dateDifference > TimeSpan.Zero)
            {
                ViewData["IndustryForm"] = indestryFormID;
                ViewData["CommunityForm"] = communityFormID;
                ViewData["StatusColor"] = "Green";
                return View();
            }
        }

        ViewData["From"] = -1;
        ViewData["StatusColor"] = "Red";
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}