using System.Diagnostics;
using feedback.Data;
using Microsoft.AspNetCore.Mvc;
using feedback.Models;

namespace feedback.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    
    public HomeController(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IActionResult Index()
    {
        int tableCount = _context.Default.Count();

        int indestryFormID = 0;
        int communityFormID = 0;

        DateTime? indestryFormStartDate = null;
        DateTime? indestryFormEndtDate = null;
        DateTime? communityFormIDStartDate = null;
        DateTime? communityFormIDEndDate = null;


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

                indestryFormStartDate = _context.Form
                    .Where(d => d.id == indestryFormID)
                    .Select(d => d.StartDate)
                    .Single();

                indestryFormEndtDate = _context.Form
                    .Where(d => d.id == indestryFormID)
                    .Select(d => d.EndDate)
                    .Single();
            }


            Console.WriteLine(indestryFormEndtDate);
            Console.WriteLine(indestryFormStartDate);

            int communityCount = _context.Default
                .Count(d => d.Category == "Community");


            if (communityCount > 0)
            {
                communityFormID = _context.Default
                    .Where(d => d.Category == "Community")
                    .Select(d => d.FormID)
                    .Single();

                communityFormIDStartDate = _context.Form
                    .Where(d => d.id == communityFormID)
                    .Select(d => d.StartDate)
                    .Single();

                communityFormIDEndDate = _context.Form
                    .Where(d => d.id == communityFormID)
                    .Select(d => d.EndDate)
                    .Single();
            }
        }


        if (indestryFormStartDate.HasValue && indestryFormEndtDate.HasValue)
        {
            ViewBag.indestryFormStartDate = indestryFormStartDate;
            ViewBag.indestryFormEndtDate = indestryFormEndtDate;
        }

        if (communityFormIDStartDate.HasValue && communityFormIDEndDate.HasValue)
        {
            ViewBag.communityFormIDStartDate = communityFormIDStartDate;
            ViewBag.communityFormIDEndDate = communityFormIDEndDate;
        }


        ViewData["CommunityForm"] = -1;
        ViewData["IndustryForm"] = -1;

        ViewData["communityStatusColor"] = "Red";
        ViewData["industryStatusColor"] = "Red";


        if (communityFormIDEndDate.HasValue)
        {
            TimeSpan? communityTimeDifference = communityFormIDEndDate - DateTime.Now;

            if (communityTimeDifference > TimeSpan.Zero)
            {
                ViewData["CommunityForm"] = communityFormID;
                ViewData["communityStatusColor"] = "Green";
            }
        }


        if (indestryFormEndtDate.HasValue)
        {
            TimeSpan? communityTimeDifference = indestryFormEndtDate - DateTime.Now;

            if (communityTimeDifference > TimeSpan.Zero)
            {
                ViewData["CommunityForm"] = indestryFormID;
                ViewData["industryStatusColor"] = "Green";
            }
        }

        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}