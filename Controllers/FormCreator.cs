using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using feedback.Data;
using feedback.Models;
using Microsoft.AspNetCore.Authorization;

namespace feedback.Controllers
{
    public class FormCreator : Controller
    {
        string locale = Thread.CurrentThread.CurrentCulture.Name;

        public enum Sexes
        {
            Male,
            Female
        };

        private readonly ApplicationDbContext _context;

        public FormCreator(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: FormCreator
        public async Task<IActionResult> Index()
        {
            int communityCount = _context.FormDefault.Count(d => d.Category == "Community");
            int industryCount = _context.FormDefault.Count(d => d.Category == "Industry");

            if (communityCount > 0)
            {
                ViewBag.communityDefault = _context.FormDefault
                    .Where(d => d.Category == "Community")
                    .Select(d => d.FormID)
                    .Single();
            }

            if (industryCount > 0)
            {
                ViewBag.IndustryDefault = _context.FormDefault
                    .Where(d => d.Category == "Industry")
                    .Select(d => d.FormID)
                    .Single();
            }


            return View(await _context.Form
                .Include(f => f.FormEntries)
                .ToListAsync());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SetDefaultForm([Bind(
                "FormID,Category")]
            DefaultForm defualt)
        {
            int communityDefault = 0;
            int IndustryDefault = 0;

            int communityCount = _context.FormDefault.Count(d => d.Category == "Community");
            int industryCount = _context.FormDefault.Count(d => d.Category == "Industry");

            if (communityCount > 0)
            {
                communityDefault = _context.FormDefault
                    .Where(d => d.Category == "Community")
                    .Select(d => d.FormID)
                    .Single();
            }

            if (industryCount > 0)
            {
                IndustryDefault = _context.FormDefault
                    .Where(d => d.Category == "Industry")
                    .Select(d => d.FormID)
                    .Single();
            }


            if (defualt.FormID > 0 && (defualt.Category.Equals("Industry") || defualt.Category.Equals("Community")))
            {
                int? Industry = _context.FormDefault
                    .Where(d => d.Category == defualt.Category)
                    .ToList().Count();

                int? Community = _context.FormDefault
                    .Where(d => d.Category == defualt.Category)
                    .ToList().Count();

                if (defualt.Category.Equals("Industry") && Industry > 0)
                {
                    try
                    {
                        if (IndustryDefault == defualt.FormID)
                        {
                            _context.FormDefault.Where(d => d.FormID == defualt.FormID)
                                .Where(d => d.Category == defualt.Category).ExecuteDeleteAsync();
                            return RedirectToAction(nameof(Index));
                        }

                        _context.FormDefault
                            .Where(d => d.Category == defualt.Category)
                            .ExecuteUpdateAsync(setters => setters.SetProperty(d => d.FormID, defualt.FormID));

                        await _context.SaveChangesAsync();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }

                if (defualt.Category.Equals("Industry") && Industry <= 0)
                {
                    _context.Add(defualt);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }


                if (defualt.Category.Equals("Community") && Community > 0)
                {
                    try
                    {
                        if (communityDefault == defualt.FormID)
                        {
                            _context.FormDefault.Where(d => d.FormID == defualt.FormID)
                                .Where(d => d.Category == defualt.Category).ExecuteDeleteAsync();
                            return RedirectToAction(nameof(Index));
                        }

                        _context.FormDefault
                            .Where(d => d.Category == defualt.Category)
                            .ExecuteUpdateAsync(setters => setters.SetProperty(d => d.FormID, defualt.FormID));

                        await _context.SaveChangesAsync();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }

                if (defualt.Category.Equals("Community") && Community <= 0)
                {
                    _context.Add(defualt);
                    await _context.SaveChangesAsync();
                }
            }


            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        // GET: FormCreator/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Form
                .Include(f => f.FormEntries) // Ensure FormEntries is loaded
                .FirstOrDefaultAsync(m => m.id == id);

            int ageCountTotal = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Select(fe => fe.AgeGroup)
                .ToList().Count;

            int AgeCount1 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.AgeGroup == 1)
                .ToList().Count;

            int AgeCount2 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.AgeGroup == 2)
                .ToList().Count;

            int AgeCount3 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.AgeGroup == 3)
                .ToList().Count;

            int AgeCount4 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.AgeGroup == 4)
                .ToList().Count;

            int eduCountTotal = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Select(fe => fe.Education)
                .ToList().Count;

            int eduCount1 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Education == 1)
                .ToList().Count;

            int eduCount2 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Education == 2)
                .ToList().Count;

            int eduCount3 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Education == 3)
                .ToList().Count;

            int eduCount5 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Education == 5)
                .ToList().Count;

            int eduCount4 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Education == 4)
                .ToList().Count;

            int sexesCountTotal = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Select(fe => fe.Sex)
                .ToList().Count;

            int sexesCount1 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Sex == FormEntry.Sexes.Male)
                .ToList().Count;

            int sexesCount2 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Sex == FormEntry.Sexes.Female)
                .ToList().Count;

            int Scale1Count1 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale1 == 1)
                .ToList().Count;

            int Scale1Count2 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale1 == 2)
                .ToList().Count;

            int Scale1Count3 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale1 == 3)
                .ToList().Count;

            int Scale1Count4 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale1 == 4)
                .ToList().Count;

            int Scale1Count5 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale1 == 5)
                .ToList().Count;

            int Scale2Count1 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale2 == 1)
                .ToList().Count;

            int Scale2Count2 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale2 == 2)
                .ToList().Count;

            int Scale2Count3 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale2 == 3)
                .ToList().Count;

            int Scale2Count4 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale2 == 4)
                .ToList().Count;

            int Scale2Count5 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale2 == 5)
                .ToList().Count;


            int Scale3Count1 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale3 == 1)
                .ToList().Count;

            int Scale3Count2 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale3 == 2)
                .ToList().Count;

            int Scale3Count3 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale3 == 3)
                .ToList().Count;

            int Scale3Count4 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale3 == 4)
                .ToList().Count;

            int Scale3Count5 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale3 == 5)
                .ToList().Count;

            int Scale4Count1 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale4 == 1)
                .ToList().Count;

            int Scale4Count2 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale4 == 2)
                .ToList().Count;

            int Scale4Count3 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale4 == 3)
                .ToList().Count;

            int Scale4Count4 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale4 == 4)
                .ToList().Count;

            int Scale4Count5 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale4 == 5)
                .ToList().Count;

            int Scale5Count1 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale5 == 1)
                .ToList().Count;

            int Scale5Count2 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale5 == 2)
                .ToList().Count;

            int Scale5Count3 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale5 == 3)
                .ToList().Count;

            int Scale5Count4 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale5 == 4)
                .ToList().Count;

            int Scale5Count5 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale5 == 5)
                .ToList().Count;

            int Scale6Count1 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale6 == 1)
                .ToList().Count;

            int Scale6Count2 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale6 == 2)
                .ToList().Count;

            int Scale6Count3 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale6 == 3)
                .ToList().Count;

            int Scale6Count4 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale6 == 4)
                .ToList().Count;

            int Scale6Count5 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale6 == 5)
                .ToList().Count;

            int Scale7Count1 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale7 == 1)
                .ToList().Count;

            int Scale7Count2 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale7 == 2)
                .ToList().Count;

            int Scale7Count3 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale7 == 3)
                .ToList().Count;

            int Scale7Count4 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale7 == 4)
                .ToList().Count;

            int Scale7Count5 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.Scale7 == 5)
                .ToList().Count;


            List<string> openQuestiona = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.OpenQuestion != null)
                .Select(fe => fe.OpenQuestion)
                .ToList();

            int openQuestionaCount = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.OpenQuestion != null)
                .Select(fe => fe.OpenQuestion)
                .Count();


            int[] maleByAge = Enumerable.Range(1, 4)
                .Select(ageGroup => _context.FormEntry
                    .Where(fe => fe.FormId == id)
                    .Where(fe => fe.AgeGroup == ageGroup)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Male))
                .ToArray();

            ViewBag.maleByAge = maleByAge;

            int[] maleByEdu = Enumerable.Range(1, 5)
                .Select(Education => _context.FormEntry
                    .Where(fe => fe.FormId == id)
                    .Where(fe => fe.Education == Education)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Male))
                .ToArray();

            ViewBag.maleByEdu = maleByEdu;


            int[] maleByScale1 = Enumerable.Range(1, 5)
                .Select(Scale1 => _context.FormEntry
                    .Where(fe => fe.FormId == id && fe.Scale1 == Scale1)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Male))
                .ToArray();

            ViewBag.maleByScale1 = maleByScale1;


            int[] maleByScale2 = Enumerable.Range(1, 5)
                .Select(Scale2 => _context.FormEntry
                    .Where(fe => fe.FormId == id && fe.Scale2 == Scale2)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Male))
                .ToArray();

            ViewBag.maleByScale2 = maleByScale2;


            int[] maleByScale3 = Enumerable.Range(1, 5)
                .Select(Scale3 => _context.FormEntry
                    .Where(fe => fe.FormId == id && fe.Scale3 == Scale3)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Male))
                .ToArray();

            ViewBag.maleByScale3 = maleByScale3;


            int[] maleByScale4 = Enumerable.Range(1, 5)
                .Select(Scale4 => _context.FormEntry
                    .Where(fe => fe.FormId == id && fe.Scale4 == Scale4)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Male))
                .ToArray();

            ViewBag.maleByScale4 = maleByScale4;


            int[] maleByScale5 = Enumerable.Range(1, 5)
                .Select(Scale5 => _context.FormEntry
                    .Where(fe => fe.FormId == id && fe.Scale5 == Scale5)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Male))
                .ToArray();

            ViewBag.maleByScale5 = maleByScale5;


            int[] maleByScale6 = Enumerable.Range(1, 5)
                .Select(Scale6 => _context.FormEntry
                    .Where(fe => fe.FormId == id && fe.Scale6 == Scale6)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Male))
                .ToArray();

            ViewBag.maleByScale6 = maleByScale6;


            int[] maleByScale7 = Enumerable.Range(1, 5)
                .Select(Scale7 => _context.FormEntry
                    .Where(fe => fe.FormId == id && fe.Scale7 == Scale7)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Male))
                .ToArray();


            ViewBag.maleByScale7 = maleByScale7;

            int[] maleByScale8 = Enumerable.Range(1, 5)
                .Select(Scale8 => _context.FormEntry
                    .Where(fe => fe.FormId == id && fe.Scale8 == Scale8)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Male))
                .ToArray();

            ViewBag.maleByScale8 = maleByScale8;

            int[] maleByScale9 = Enumerable.Range(1, 5)
                .Select(Scale9 => _context.FormEntry
                    .Where(fe => fe.FormId == id && fe.Scale9 == Scale9)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Male))
                .ToArray();

            ViewBag.maleByScale9 = maleByScale9;

            int[] maleByScale10 = Enumerable.Range(1, 5)
                .Select(Scale10 => _context.FormEntry
                    .Where(fe => fe.FormId == id && fe.Scale10 == Scale10)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Male))
                .ToArray();

            ViewBag.maleByScale10 = maleByScale10;


            int[] femaleByAge = Enumerable.Range(1, 4)
                .Select(ageGroup => _context.FormEntry
                    .Where(fe => fe.FormId == id)
                    .Where(fe => fe.AgeGroup == ageGroup)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Female))
                .ToArray();

            ViewBag.femaleByAge = femaleByAge;

            int[] femaleByEdu = Enumerable.Range(1, 5)
                .Select(Education => _context.FormEntry
                    .Where(fe => fe.FormId == id)
                    .Where(fe => fe.Education == Education)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Female))
                .ToArray();

            ViewBag.femaleByEdu = femaleByEdu;

            int[] femaleByScale1 = Enumerable.Range(1, 5)
                .Select(Scale1 => _context.FormEntry
                    .Where(fe => fe.FormId == id && fe.Scale1 == Scale1)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Female))
                .ToArray();

            ViewBag.femaleByScale1 = femaleByScale1;

            int[] femaleByScale2 = Enumerable.Range(1, 5)
                .Select(Scale2 => _context.FormEntry
                    .Where(fe => fe.FormId == id && fe.Scale2 == Scale2)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Female))
                .ToArray();

            ViewBag.femaleByScale2 = femaleByScale2;

            int[] femaleByScale3 = Enumerable.Range(1, 5)
                .Select(Scale3 => _context.FormEntry
                    .Where(fe => fe.FormId == id && fe.Scale3 == Scale3)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Female))
                .ToArray();

            ViewBag.femaleByScale3 = femaleByScale3;

            int[] femaleByScale4 = Enumerable.Range(1, 5)
                .Select(Scale4 => _context.FormEntry
                    .Where(fe => fe.FormId == id && fe.Scale4 == Scale4)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Female))
                .ToArray();

            ViewBag.femaleByScale4 = femaleByScale4;

            int[] femaleByScale5 = Enumerable.Range(1, 5)
                .Select(Scale5 => _context.FormEntry
                    .Where(fe => fe.FormId == id && fe.Scale5 == Scale5)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Female))
                .ToArray();

            ViewBag.femaleByScale5 = femaleByScale5;

            int[] femaleByScale6 = Enumerable.Range(1, 5)
                .Select(Scale6 => _context.FormEntry
                    .Where(fe => fe.FormId == id && fe.Scale6 == Scale6)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Female))
                .ToArray();

            ViewBag.femaleByScale6 = femaleByScale6;

            int[] femaleByScale7 = Enumerable.Range(1, 5)
                .Select(Scale7 => _context.FormEntry
                    .Where(fe => fe.FormId == id && fe.Scale7 == Scale7)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Female))
                .ToArray();

            ViewBag.femaleByScale7 = femaleByScale7;

            int[] femaleByScale8 = Enumerable.Range(1, 5)
                .Select(Scale8 => _context.FormEntry
                    .Where(fe => fe.FormId == id && fe.Scale8 == Scale8)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Female))
                .ToArray();

            ViewBag.femaleByScale8 = femaleByScale8;

            int[] femaleByScale9 = Enumerable.Range(1, 5)
                .Select(Scale9 => _context.FormEntry
                    .Where(fe => fe.FormId == id && fe.Scale9 == Scale9)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Female))
                .ToArray();

            ViewBag.femaleByScale9 = femaleByScale9;

            int[] femaleByScale10 = Enumerable.Range(1, 5)
                .Select(Scale10 => _context.FormEntry
                    .Where(fe => fe.FormId == id && fe.Scale10 == Scale10)
                    .Count(fe => fe.Sex == FormEntry.Sexes.Female))
                .ToArray();

            ViewBag.femaleByScale10 = femaleByScale10;

            int[] edu1ByAge = Enumerable.Range(1, 4)
                .Select(ageGroup => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.AgeGroup == ageGroup && fe.Education == 1))
                .ToArray();

            ViewBag.edu1ByAge = edu1ByAge;

            int edu1BySex1 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.Education == 1)
                .Count(fe => fe.Sex == FormEntry.Sexes.Male);

            int edu1BySex2 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.Education == 1)
                .Count(fe => fe.Sex == FormEntry.Sexes.Female);

            ViewBag.edu1BySex = new int[] { edu1BySex1, edu1BySex2 };


            int[] edu1ByEdu = Enumerable.Range(1, 5)
                .Select(Education => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Education == Education && fe.Education == 1))
                .ToArray();

            ViewBag.edu1ByEdu = edu1ByEdu;

            int[] edu1ByScale1 = Enumerable.Range(1, 5)
                .Select(Scale1 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale1 == Scale1 && fe.Education == 1))
                .ToArray();

            ViewBag.edu1ByScale1 = edu1ByScale1;

            int[] edu1ByScale2 = Enumerable.Range(1, 5)
                .Select(Scale2 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale2 == Scale2 && fe.Education == 1))
                .ToArray();

            ViewBag.edu1ByScale2 = edu1ByScale2;

            int[] edu1ByScale3 = Enumerable.Range(1, 5)
                .Select(Scale3 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale3 == Scale3 && fe.Education == 1))
                .ToArray();

            ViewBag.edu1ByScale3 = edu1ByScale3;

            int[] edu1ByScale4 = Enumerable.Range(1, 5)
                .Select(Scale4 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale4 == Scale4 && fe.Education == 1))
                .ToArray();

            ViewBag.edu1ByScale4 = edu1ByScale4;

            int[] edu1ByScale5 = Enumerable.Range(1, 5)
                .Select(Scale5 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale5 == Scale5 && fe.Education == 1))
                .ToArray();

            ViewBag.edu1ByScale5 = edu1ByScale5;

            int[] edu1ByScale6 = Enumerable.Range(1, 5)
                .Select(Scale6 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale6 == Scale6 && fe.Education == 1))
                .ToArray();

            ViewBag.edu1ByScale6 = edu1ByScale6;

            int[] edu1ByScale7 = Enumerable.Range(1, 5)
                .Select(Scale7 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale7 == Scale7 && fe.Education == 1))
                .ToArray();

            ViewBag.edu1ByScale7 = edu1ByScale7;

            int[] edu1ByScale8 = Enumerable.Range(1, 5)
                .Select(Scale8 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale8 == Scale8 && fe.Education == 1))
                .ToArray();

            ViewBag.edu1ByScale8 = edu1ByScale8;

            int[] edu1ByScale9 = Enumerable.Range(1, 5)
                .Select(Scale9 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale9 == Scale9 && fe.Education == 1))
                .ToArray();

            ViewBag.edu1ByScale9 = edu1ByScale9;

            int[] edu1ByScale10 = Enumerable.Range(1, 5)
                .Select(Scale10 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale10 == Scale10 && fe.Education == 1))
                .ToArray();

            ViewBag.edu1ByScale10 = edu1ByScale10;

            int[] edu2ByAge = Enumerable.Range(1, 4)
                .Select(ageGroup => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.AgeGroup == ageGroup && fe.Education == 2))
                .ToArray();

            ViewBag.edu2ByAge = edu2ByAge;


            int edu2BySex1 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.Education == 2)
                .Count(fe => fe.Sex == FormEntry.Sexes.Male);

            int edu2BySex2 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.Education == 2)
                .Count(fe => fe.Sex == FormEntry.Sexes.Female);

            ViewBag.edu2BySex = new int[] { edu2BySex1, edu2BySex2 };

            int[] edu2ByEdu = Enumerable.Range(1, 5)
                .Select(Education => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Education == Education && fe.Education == 2))
                .ToArray();

            ViewBag.edu2ByEdu = edu2ByEdu;

            int[] edu2ByScale1 = Enumerable.Range(1, 5)
                .Select(Scale1 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale1 == Scale1 && fe.Education == 2))
                .ToArray();

            ViewBag.edu2ByScale1 = edu2ByScale1;

            int[] edu2ByScale2 = Enumerable.Range(1, 5)
                .Select(Scale2 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale2 == Scale2 && fe.Education == 2))
                .ToArray();

            ViewBag.edu2ByScale2 = edu2ByScale2;

            int[] edu2ByScale3 = Enumerable.Range(1, 5)
                .Select(Scale3 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale3 == Scale3 && fe.Education == 2))
                .ToArray();

            ViewBag.edu2ByScale3 = edu2ByScale3;

            int[] edu2ByScale4 = Enumerable.Range(1, 5)
                .Select(Scale4 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale4 == Scale4 && fe.Education == 2))
                .ToArray();

            ViewBag.edu2ByScale4 = edu2ByScale4;

            int[] edu2ByScale5 = Enumerable.Range(1, 5)
                .Select(Scale5 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale5 == Scale5 && fe.Education == 2))
                .ToArray();

            ViewBag.edu2ByScale5 = edu2ByScale5;

            int[] edu2ByScale6 = Enumerable.Range(1, 5)
                .Select(Scale6 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale6 == Scale6 && fe.Education == 2))
                .ToArray();

            ViewBag.edu2ByScale6 = edu2ByScale6;

            int[] edu2ByScale7 = Enumerable.Range(1, 5)
                .Select(Scale7 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale7 == Scale7 && fe.Education == 2))
                .ToArray();

            ViewBag.edu2ByScale7 = edu2ByScale7;

            int[] edu2ByScale8 = Enumerable.Range(1, 5)
                .Select(Scale8 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale8 == Scale8 && fe.Education == 2))
                .ToArray();

            ViewBag.edu2ByScale8 = edu2ByScale8;

            int[] edu2ByScale9 = Enumerable.Range(1, 5)
                .Select(Scale9 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale9 == Scale9 && fe.Education == 2))
                .ToArray();

            ViewBag.edu2ByScale9 = edu2ByScale9;

            int[] edu2ByScale10 = Enumerable.Range(1, 5)
                .Select(Scale10 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale10 == Scale10 && fe.Education == 2))
                .ToArray();

            ViewBag.edu2ByScale10 = edu2ByScale10;

            int[] edu3ByAge = Enumerable.Range(1, 4)
                .Select(ageGroup => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.AgeGroup == ageGroup && fe.Education == 3))
                .ToArray();

            ViewBag.edu3ByAge = edu3ByAge;

            int edu3BySex1 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.Education == 3)
                .Count(fe => fe.Sex == FormEntry.Sexes.Male);

            int edu3BySex2 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.Education == 3)
                .Count(fe => fe.Sex == FormEntry.Sexes.Female);

            ViewBag.edu3BySex = new int[] { edu3BySex1, edu3BySex2 };

            int[] edu3ByEdu = Enumerable.Range(1, 5)
                .Select(Education => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Education == Education && fe.Education == 3))
                .ToArray();

            ViewBag.edu3ByEdu = edu3ByEdu;

            int[] edu3ByScale1 = Enumerable.Range(1, 5)
                .Select(Scale1 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale1 == Scale1 && fe.Education == 3))
                .ToArray();

            ViewBag.edu3ByScale1 = edu3ByScale1;

            int[] edu3ByScale2 = Enumerable.Range(1, 5)
                .Select(Scale2 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale2 == Scale2 && fe.Education == 3))
                .ToArray();

            ViewBag.edu3ByScale2 = edu3ByScale2;

            int[] edu3ByScale3 = Enumerable.Range(1, 5)
                .Select(Scale3 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale3 == Scale3 && fe.Education == 3))
                .ToArray();

            ViewBag.edu3ByScale3 = edu3ByScale3;

            int[] edu3ByScale4 = Enumerable.Range(1, 5)
                .Select(Scale4 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale4 == Scale4 && fe.Education == 3))
                .ToArray();

            ViewBag.edu3ByScale4 = edu3ByScale4;

            int[] edu3ByScale5 = Enumerable.Range(1, 5)
                .Select(Scale5 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale5 == Scale5 && fe.Education == 3))
                .ToArray();

            ViewBag.edu3ByScale5 = edu3ByScale5;

            int[] edu3ByScale6 = Enumerable.Range(1, 5)
                .Select(Scale6 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale6 == Scale6 && fe.Education == 3))
                .ToArray();

            ViewBag.edu3ByScale6 = edu3ByScale6;

            int[] edu3ByScale7 = Enumerable.Range(1, 5)
                .Select(Scale7 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale7 == Scale7 && fe.Education == 3))
                .ToArray();

            ViewBag.edu3ByScale7 = edu3ByScale7;

            int[] edu3ByScale8 = Enumerable.Range(1, 5)
                .Select(Scale8 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale8 == Scale8 && fe.Education == 3))
                .ToArray();

            ViewBag.edu3ByScale8 = edu3ByScale8;

            int[] edu3ByScale9 = Enumerable.Range(1, 5)
                .Select(Scale9 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale9 == Scale9 && fe.Education == 3))
                .ToArray();

            ViewBag.edu3ByScale9 = edu3ByScale9;

            int[] edu3ByScale10 = Enumerable.Range(1, 5)
                .Select(Scale10 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale10 == Scale10 && fe.Education == 3))
                .ToArray();

            ViewBag.edu3ByScale10 = edu3ByScale10;

            int[] edu4ByAge = Enumerable.Range(1, 4)
                .Select(ageGroup => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.AgeGroup == ageGroup && fe.Education == 4))
                .ToArray();

            ViewBag.edu4ByAge = edu4ByAge;

            int edu4BySex1 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.Education == 4)
                .Count(fe => fe.Sex == FormEntry.Sexes.Male);

            int edu4BySex2 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.Education == 4)
                .Count(fe => fe.Sex == FormEntry.Sexes.Female);

            ViewBag.edu4BySex = new int[] { edu4BySex1, edu4BySex2 };

            int[] edu4ByEdu = Enumerable.Range(1, 5)
                .Select(Education => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Education == Education && fe.Education == 4))
                .ToArray();

            ViewBag.edu4ByEdu = edu4ByEdu;

            int[] edu4ByScale1 = Enumerable.Range(1, 5)
                .Select(Scale1 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale1 == Scale1 && fe.Education == 4))
                .ToArray();

            ViewBag.edu4ByScale1 = edu4ByScale1;

            int[] edu4ByScale2 = Enumerable.Range(1, 5)
                .Select(Scale2 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale2 == Scale2 && fe.Education == 4))
                .ToArray();

            ViewBag.edu4ByScale2 = edu4ByScale2;

            int[] edu4ByScale3 = Enumerable.Range(1, 5)
                .Select(Scale3 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale3 == Scale3 && fe.Education == 4))
                .ToArray();

            ViewBag.edu4ByScale3 = edu4ByScale3;

            int[] edu4ByScale4 = Enumerable.Range(1, 5)
                .Select(Scale4 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale4 == Scale4 && fe.Education == 4))
                .ToArray();

            ViewBag.edu4ByScale4 = edu4ByScale4;

            int[] edu4ByScale5 = Enumerable.Range(1, 5)
                .Select(Scale5 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale5 == Scale5 && fe.Education == 4))
                .ToArray();

            ViewBag.edu4ByScale5 = edu4ByScale5;

            int[] edu4ByScale6 = Enumerable.Range(1, 5)
                .Select(Scale6 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale6 == Scale6 && fe.Education == 4))
                .ToArray();

            ViewBag.edu4ByScale6 = edu4ByScale6;

            int[] edu4ByScale7 = Enumerable.Range(1, 5)
                .Select(Scale7 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale7 == Scale7 && fe.Education == 4))
                .ToArray();

            ViewBag.edu4ByScale7 = edu4ByScale7;

            int[] edu4ByScale8 = Enumerable.Range(1, 5)
                .Select(Scale8 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale8 == Scale8 && fe.Education == 4))
                .ToArray();

            ViewBag.edu4ByScale8 = edu4ByScale8;

            int[] edu4ByScale9 = Enumerable.Range(1, 5)
                .Select(Scale9 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale9 == Scale9 && fe.Education == 4))
                .ToArray();

            ViewBag.edu4ByScale9 = edu4ByScale9;

            int[] edu4ByScale10 = Enumerable.Range(1, 5)
                .Select(Scale10 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale10 == Scale10 && fe.Education == 4))
                .ToArray();

            ViewBag.edu4ByScale10 = edu4ByScale10;

            int[] edu5ByAge = Enumerable.Range(1, 4)
                .Select(ageGroup => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.AgeGroup == ageGroup && fe.Education == 5))
                .ToArray();

            ViewBag.edu5ByAge = edu5ByAge;

            int edu5BySex1 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.Education == 5)
                .Count(fe => fe.Sex == FormEntry.Sexes.Male);

            int edu5BySex2 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.Education == 5)
                .Count(fe => fe.Sex == FormEntry.Sexes.Female);

            ViewBag.edu5BySex = new int[] { edu5BySex1, edu5BySex2 };


            int[] edu5ByEdu = Enumerable.Range(1, 5)
                .Select(Education => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Education == Education && fe.Education == 5))
                .ToArray();

            ViewBag.edu5ByEdu = edu5ByEdu;

            int[] edu5ByScale1 = Enumerable.Range(1, 5)
                .Select(Scale1 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale1 == Scale1 && fe.Education == 5))
                .ToArray();

            ViewBag.edu5ByScale1 = edu5ByScale1;

            int[] edu5ByScale2 = Enumerable.Range(1, 5)
                .Select(Scale2 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale2 == Scale2 && fe.Education == 5))
                .ToArray();

            ViewBag.edu5ByScale2 = edu5ByScale2;

            int[] edu5ByScale3 = Enumerable.Range(1, 5)
                .Select(Scale3 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale3 == Scale3 && fe.Education == 5))
                .ToArray();

            ViewBag.edu5ByScale3 = edu5ByScale3;

            int[] edu5ByScale4 = Enumerable.Range(1, 5)
                .Select(Scale4 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale4 == Scale4 && fe.Education == 5))
                .ToArray();

            ViewBag.edu5ByScale4 = edu5ByScale4;

            int[] edu5ByScale5 = Enumerable.Range(1, 5)
                .Select(Scale5 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale5 == Scale5 && fe.Education == 5))
                .ToArray();

            ViewBag.edu5ByScale5 = edu5ByScale5;

            int[] edu5ByScale6 = Enumerable.Range(1, 5)
                .Select(Scale6 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale6 == Scale6 && fe.Education == 5))
                .ToArray();

            ViewBag.edu5ByScale6 = edu5ByScale6;

            int[] edu5ByScale7 = Enumerable.Range(1, 5)
                .Select(Scale7 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale7 == Scale7 && fe.Education == 5))
                .ToArray();

            ViewBag.edu5ByScale7 = edu5ByScale7;

            int[] edu5ByScale8 = Enumerable.Range(1, 5)
                .Select(Scale8 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale8 == Scale8 && fe.Education == 5))
                .ToArray();

            ViewBag.edu5ByScale8 = edu5ByScale8;

            int[] edu5ByScale9 = Enumerable.Range(1, 5)
                .Select(Scale9 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale9 == Scale9 && fe.Education == 5))
                .ToArray();

            ViewBag.edu5ByScale9 = edu5ByScale9;

            int[] edu5ByScale10 = Enumerable.Range(1, 5)
                .Select(Scale10 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale10 == Scale10 && fe.Education == 5))
                .ToArray();

            ViewBag.edu5ByScale10 = edu5ByScale10;

            int[] age1ByAge = Enumerable.Range(1, 4)
                .Select(ageGroup => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.AgeGroup == ageGroup && fe.AgeGroup == 1))
                .ToArray();

            ViewBag.age1ByAge = age1ByAge;

            int age1BySex1 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.AgeGroup == 1)
                .Count(fe => fe.Sex == FormEntry.Sexes.Male);

            int age1BySex2 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.AgeGroup == 1)
                .Count(fe => fe.Sex == FormEntry.Sexes.Female);

            ViewBag.age1BySex = new int[] { age1BySex1, age1BySex2 };

            int[] age1ByEdu = Enumerable.Range(1, 5)
                .Select(Education => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Education == Education && fe.AgeGroup == 1))
                .ToArray();

            ViewBag.age1ByEdu = age1ByEdu;

            int[] age1ByScale1 = Enumerable.Range(1, 5)
                .Select(Scale1 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale1 == Scale1 && fe.AgeGroup == 1))
                .ToArray();

            ViewBag.age1ByScale1 = age1ByScale1;

            int[] age1ByScale2 = Enumerable.Range(1, 5)
                .Select(Scale2 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale2 == Scale2 && fe.AgeGroup == 1))
                .ToArray();

            ViewBag.age1ByScale2 = age1ByScale2;

            int[] age1ByScale3 = Enumerable.Range(1, 5)
                .Select(Scale3 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale3 == Scale3 && fe.AgeGroup == 1))
                .ToArray();

            ViewBag.age1ByScale3 = age1ByScale3;

            int[] age1ByScale4 = Enumerable.Range(1, 5)
                .Select(Scale4 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale4 == Scale4 && fe.AgeGroup == 1))
                .ToArray();

            ViewBag.age1ByScale4 = age1ByScale4;

            int[] age1ByScale5 = Enumerable.Range(1, 5)
                .Select(Scale5 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale5 == Scale5 && fe.AgeGroup == 1))
                .ToArray();

            ViewBag.age1ByScale5 = age1ByScale5;

            int[] age1ByScale6 = Enumerable.Range(1, 5)
                .Select(Scale6 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale6 == Scale6 && fe.AgeGroup == 1))
                .ToArray();

            ViewBag.age1ByScale6 = age1ByScale6;

            int[] age1ByScale7 = Enumerable.Range(1, 5)
                .Select(Scale7 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale7 == Scale7 && fe.AgeGroup == 1))
                .ToArray();

            ViewBag.age1ByScale7 = age1ByScale7;

            int[] age1ByScale8 = Enumerable.Range(1, 5)
                .Select(Scale8 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale8 == Scale8 && fe.AgeGroup == 1))
                .ToArray();

            ViewBag.age1ByScale8 = age1ByScale8;

            int[] age1ByScale9 = Enumerable.Range(1, 5)
                .Select(Scale9 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale9 == Scale9 && fe.AgeGroup == 1))
                .ToArray();

            ViewBag.age1ByScale9 = age1ByScale9;

            int[] age1ByScale10 = Enumerable.Range(1, 5)
                .Select(Scale10 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale10 == Scale10 && fe.AgeGroup == 1))
                .ToArray();

            ViewBag.age1ByScale10 = age1ByScale10;

            int[] age2ByAge = Enumerable.Range(1, 4)
                .Select(ageGroup => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.AgeGroup == ageGroup && fe.AgeGroup == 2))
                .ToArray();

            ViewBag.age2ByAge = age2ByAge;

            int age2BySex1 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.AgeGroup == 2)
                .Count(fe => fe.Sex == FormEntry.Sexes.Male);

            int age2BySex2 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.AgeGroup == 2)
                .Count(fe => fe.Sex == FormEntry.Sexes.Female);

            ViewBag.age2BySex = new int[] { age2BySex1, age2BySex2 };

            int[] age2ByEdu = Enumerable.Range(1, 5)
                .Select(Education => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Education == Education && fe.AgeGroup == 2))
                .ToArray();

            ViewBag.age2ByEdu = age2ByEdu;

            int[] age2ByScale1 = Enumerable.Range(1, 5)
                .Select(Scale1 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale1 == Scale1 && fe.AgeGroup == 2))
                .ToArray();

            ViewBag.age2ByScale1 = age2ByScale1;

            int[] age2ByScale2 = Enumerable.Range(1, 5)
                .Select(Scale2 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale2 == Scale2 && fe.AgeGroup == 2))
                .ToArray();

            ViewBag.age2ByScale2 = age2ByScale2;

            int[] age2ByScale3 = Enumerable.Range(1, 5)
                .Select(Scale3 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale3 == Scale3 && fe.AgeGroup == 2))
                .ToArray();

            ViewBag.age2ByScale3 = age2ByScale3;

            int[] age2ByScale4 = Enumerable.Range(1, 5)
                .Select(Scale4 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale4 == Scale4 && fe.AgeGroup == 2))
                .ToArray();

            ViewBag.age2ByScale4 = age2ByScale4;

            int[] age2ByScale5 = Enumerable.Range(1, 5)
                .Select(Scale5 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale5 == Scale5 && fe.AgeGroup == 2))
                .ToArray();

            ViewBag.age2ByScale5 = age2ByScale5;

            int[] age2ByScale6 = Enumerable.Range(1, 5)
                .Select(Scale6 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale6 == Scale6 && fe.AgeGroup == 2))
                .ToArray();

            ViewBag.age2ByScale6 = age2ByScale6;

            int[] age2ByScale7 = Enumerable.Range(1, 5)
                .Select(Scale7 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale7 == Scale7 && fe.AgeGroup == 2))
                .ToArray();

            ViewBag.age2ByScale7 = age2ByScale7;

            int[] age2ByScale8 = Enumerable.Range(1, 5)
                .Select(Scale8 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale8 == Scale8 && fe.AgeGroup == 2))
                .ToArray();

            ViewBag.age2ByScale8 = age2ByScale8;

            int[] age2ByScale9 = Enumerable.Range(1, 5)
                .Select(Scale9 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale9 == Scale9 && fe.AgeGroup == 2))
                .ToArray();

            ViewBag.age2ByScale9 = age2ByScale9;

            int[] age2ByScale10 = Enumerable.Range(1, 5)
                .Select(Scale10 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale10 == Scale10 && fe.AgeGroup == 2))
                .ToArray();

            ViewBag.age2ByScale10 = age2ByScale10;
            int[] age3ByAge = Enumerable.Range(1, 4)
                .Select(ageGroup => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.AgeGroup == ageGroup && fe.AgeGroup == 3))
                .ToArray();

            ViewBag.age3ByAge = age3ByAge;

            int age3BySex1 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.AgeGroup == 3)
                .Count(fe => fe.Sex == FormEntry.Sexes.Male);

            int age3BySex2 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.AgeGroup == 3)
                .Count(fe => fe.Sex == FormEntry.Sexes.Female);

            ViewBag.age3BySex = new int[] { age3BySex1, age3BySex2 };

            int[] age3ByEdu = Enumerable.Range(1, 5)
                .Select(Education => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Education == Education && fe.AgeGroup == 3))
                .ToArray();

            ViewBag.age3ByEdu = age3ByEdu;

            int[] age3ByScale1 = Enumerable.Range(1, 5)
                .Select(Scale1 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale1 == Scale1 && fe.AgeGroup == 3))
                .ToArray();

            ViewBag.age3ByScale1 = age3ByScale1;

            int[] age3ByScale2 = Enumerable.Range(1, 5)
                .Select(Scale2 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale2 == Scale2 && fe.AgeGroup == 3))
                .ToArray();

            ViewBag.age3ByScale2 = age3ByScale2;

            int[] age3ByScale3 = Enumerable.Range(1, 5)
                .Select(Scale3 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale3 == Scale3 && fe.AgeGroup == 3))
                .ToArray();

            ViewBag.age3ByScale3 = age3ByScale3;

            int[] age3ByScale4 = Enumerable.Range(1, 5)
                .Select(Scale4 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale4 == Scale4 && fe.AgeGroup == 3))
                .ToArray();

            ViewBag.age3ByScale4 = age3ByScale4;

            int[] age3ByScale5 = Enumerable.Range(1, 5)
                .Select(Scale5 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale5 == Scale5 && fe.AgeGroup == 3))
                .ToArray();

            ViewBag.age3ByScale5 = age3ByScale5;

            int[] age3ByScale6 = Enumerable.Range(1, 5)
                .Select(Scale6 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale6 == Scale6 && fe.AgeGroup == 3))
                .ToArray();

            ViewBag.age3ByScale6 = age3ByScale6;

            int[] age3ByScale7 = Enumerable.Range(1, 5)
                .Select(Scale7 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale7 == Scale7 && fe.AgeGroup == 3))
                .ToArray();

            ViewBag.age3ByScale7 = age3ByScale7;

            int[] age3ByScale8 = Enumerable.Range(1, 5)
                .Select(Scale8 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale8 == Scale8 && fe.AgeGroup == 3))
                .ToArray();

            ViewBag.age3ByScale8 = age3ByScale8;

            int[] age3ByScale9 = Enumerable.Range(1, 5)
                .Select(Scale9 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale9 == Scale9 && fe.AgeGroup == 3))
                .ToArray();

            ViewBag.age3ByScale9 = age3ByScale9;

            int[] age3ByScale10 = Enumerable.Range(1, 5)
                .Select(Scale10 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale10 == Scale10 && fe.AgeGroup == 3))
                .ToArray();

            ViewBag.age3ByScale10 = age3ByScale10;


            int[] age4ByAge = Enumerable.Range(1, 4)
                .Select(ageGroup => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.AgeGroup == ageGroup && fe.AgeGroup == 4))
                .ToArray();

            ViewBag.age4ByAge = age4ByAge;

            int age4BySex1 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.AgeGroup == 4)
                .Count(fe => fe.Sex == FormEntry.Sexes.Male);

            int age4BySex2 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.AgeGroup == 4)
                .Count(fe => fe.Sex == FormEntry.Sexes.Female);

            ViewBag.age4BySex = new int[] { age4BySex1, age4BySex2 };

            int[] age4ByEdu = Enumerable.Range(1, 5)
                .Select(Education => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Education == Education && fe.AgeGroup == 4))
                .ToArray();

            ViewBag.age4ByEdu = age4ByEdu;

            int[] age4ByScale1 = Enumerable.Range(1, 5)
                .Select(Scale1 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale1 == Scale1 && fe.AgeGroup == 4))
                .ToArray();

            ViewBag.age4ByScale1 = age4ByScale1;

            int[] age4ByScale2 = Enumerable.Range(1, 5)
                .Select(Scale2 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale2 == Scale2 && fe.AgeGroup == 4))
                .ToArray();

            ViewBag.age4ByScale2 = age4ByScale2;

            int[] age4ByScale3 = Enumerable.Range(1, 5)
                .Select(Scale3 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale3 == Scale3 && fe.AgeGroup == 4))
                .ToArray();

            ViewBag.age4ByScale3 = age4ByScale3;

            int[] age4ByScale4 = Enumerable.Range(1, 5)
                .Select(Scale4 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale4 == Scale4 && fe.AgeGroup == 4))
                .ToArray();

            ViewBag.age4ByScale4 = age4ByScale4;

            int[] age4ByScale5 = Enumerable.Range(1, 5)
                .Select(Scale5 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale5 == Scale5 && fe.AgeGroup == 4))
                .ToArray();

            ViewBag.age4ByScale5 = age4ByScale5;

            int[] age4ByScale6 = Enumerable.Range(1, 5)
                .Select(Scale6 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale6 == Scale6 && fe.AgeGroup == 4))
                .ToArray();

            ViewBag.age4ByScale6 = age4ByScale6;

            int[] age4ByScale7 = Enumerable.Range(1, 5)
                .Select(Scale7 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale7 == Scale7 && fe.AgeGroup == 4))
                .ToArray();

            ViewBag.age4ByScale7 = age4ByScale7;

            int[] age4ByScale8 = Enumerable.Range(1, 5)
                .Select(Scale8 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale8 == Scale8 && fe.AgeGroup == 4))
                .ToArray();

            ViewBag.age4ByScale8 = age4ByScale8;

            int[] age4ByScale9 = Enumerable.Range(1, 5)
                .Select(Scale9 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale9 == Scale9 && fe.AgeGroup == 4))
                .ToArray();

            ViewBag.age4ByScale9 = age4ByScale9;

            int[] age4ByScale10 = Enumerable.Range(1, 5)
                .Select(Scale10 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale10 == Scale10 && fe.AgeGroup == 4))
                .ToArray();

            ViewBag.age4ByScale10 = age4ByScale10;

            int[] category1ByAge = Enumerable.Range(1, 5)
                .Select(AgeGroup => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.AgeGroup == AgeGroup  && fe.Category == "Community"))
                .ToArray();
            
            ViewBag.category1ByAge = category1ByAge;

            int category1BySex1 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.Category == "Community")
                .Count(fe => fe.Sex == FormEntry.Sexes.Male);

            int category1BySex2 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.Category == "Community")
                .Count(fe => fe.Sex == FormEntry.Sexes.Female);

            ViewBag.category1BySex = new int[] { category1BySex1, category1BySex2 };

            int[] category1ByEdu = Enumerable.Range(1, 5)
                .Select(Education => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Education == Education && fe.Category == "Community"))
                .ToArray();

            ViewBag.category1ByEdu = category1ByEdu;

            int[] category1ByScale1 = Enumerable.Range(1, 5)
                .Select(Scale1 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale1 == Scale1 && fe.Category == "Community"))
                .ToArray();

            ViewBag.category1ByScale1 = category1ByScale1;

            int[] category1ByScale2 = Enumerable.Range(1, 5)
                .Select(Scale2 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale2 == Scale2 && fe.Category == "Community"))
                .ToArray();

            ViewBag.category1ByScale2 = category1ByScale2;

            int[] category1ByScale3 = Enumerable.Range(1, 5)
                .Select(Scale3 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale3 == Scale3 && fe.Category == "Community"))
                .ToArray();

            ViewBag.category1ByScale3 = category1ByScale3;

            int[] category1ByScale4 = Enumerable.Range(1, 5)
                .Select(Scale4 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale4 == Scale4 && fe.Category == "Community"))
                .ToArray();

            ViewBag.category1ByScale4 = category1ByScale4;

            int[] category1ByScale5 = Enumerable.Range(1, 5)
                .Select(Scale5 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale5 == Scale5 && fe.Category == "Community"))
                .ToArray();

            ViewBag.category1ByScale5 = category1ByScale5;

            int[] category1ByScale6 = Enumerable.Range(1, 5)
                .Select(Scale6 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale6 == Scale6 && fe.Category == "Community"))
                .ToArray();

            ViewBag.category1ByScale6 = category1ByScale6;

            int[] category1ByScale7 = Enumerable.Range(1, 5)
                .Select(Scale7 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale7 == Scale7 && fe.Category == "Community"))
                .ToArray();

            ViewBag.category1ByScale7 = category1ByScale7;

            int[] category1ByScale8 = Enumerable.Range(1, 5)
                .Select(Scale8 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale8 == Scale8 && fe.Category == "Community"))
                .ToArray();

            ViewBag.category1ByScale8 = category1ByScale8;

            int[] category1ByScale9 = Enumerable.Range(1, 5)
                .Select(Scale9 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale9 == Scale9 && fe.Category == "Community"))
                .ToArray();

            ViewBag.category1ByScale9 = category1ByScale9;

            int[] category1ByScale10 = Enumerable.Range(1, 5)
                .Select(Scale10 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale10 == Scale10 && fe.Category == "Community"))
                .ToArray();

            ViewBag.category1ByScale10 = category1ByScale10;
            
            int[] category2ByAge = Enumerable.Range(1, 5)
                .Select(AgeGroup => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.AgeGroup == AgeGroup  && fe.Category == "Industry"))
                .ToArray();
            
            ViewBag.category2ByAge = category2ByAge;

            int category2BySex1 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.Category == "Industry")
                .Count(fe => fe.Sex == FormEntry.Sexes.Male);

            int category2BySex2 = _context.FormEntry
                .Where(fe => fe.FormId == id && fe.Category == "Industry")
                .Count(fe => fe.Sex == FormEntry.Sexes.Female);

            ViewBag.category2BySex = new int[] { category2BySex1, category2BySex2 };

            int[] category2ByEdu = Enumerable.Range(1, 5)
                .Select(Education => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Education == Education && fe.Category == "Industry"))
                .ToArray();

            ViewBag.category2ByEdu = category2ByEdu;

            int[] category2ByScale1 = Enumerable.Range(1, 5)
                .Select(Scale1 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale1 == Scale1 && fe.Category == "Industry"))
                .ToArray();

            ViewBag.category2ByScale1 = category2ByScale1;

            int[] category2ByScale2 = Enumerable.Range(1, 5)
                .Select(Scale2 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale2 == Scale2 && fe.Category == "Industry"))
                .ToArray();

            ViewBag.category2ByScale2 = category2ByScale2;

            int[] category2ByScale3 = Enumerable.Range(1, 5)
                .Select(Scale3 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale3 == Scale3 && fe.Category == "Industry"))
                .ToArray();

            ViewBag.category2ByScale3 = category2ByScale3;

            int[] category2ByScale4 = Enumerable.Range(1, 5)
                .Select(Scale4 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale4 == Scale4 && fe.Category == "Industry"))
                .ToArray();

            ViewBag.category2ByScale4 = category2ByScale4;

            int[] category2ByScale5 = Enumerable.Range(1, 5)
                .Select(Scale5 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale5 == Scale5 && fe.Category == "Industry"))
                .ToArray();

            ViewBag.category2ByScale5 = category2ByScale5;

            int[] category2ByScale6 = Enumerable.Range(1, 5)
                .Select(Scale6 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale6 == Scale6 && fe.Category == "Industry"))
                .ToArray();

            ViewBag.category2ByScale6 = category2ByScale6;

            int[] category2ByScale7 = Enumerable.Range(1, 5)
                .Select(Scale7 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale7 == Scale7 && fe.Category == "Industry"))
                .ToArray();

            ViewBag.category2ByScale7 = category2ByScale7;

            int[] category2ByScale8 = Enumerable.Range(1, 5)
                .Select(Scale8 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale8 == Scale8 && fe.Category == "Industry"))
                .ToArray();

            ViewBag.category2ByScale8 = category2ByScale8;

            int[] category2ByScale9 = Enumerable.Range(1, 5)
                .Select(Scale9 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale9 == Scale9 && fe.Category == "Industry"))
                .ToArray();

            ViewBag.category2ByScale9 = category2ByScale9;

            int[] category2ByScale10 = Enumerable.Range(1, 5)
                .Select(Scale10 => _context.FormEntry
                    .Count(fe => fe.FormId == id && fe.Scale10 == Scale10 && fe.Category == "Industry"))
                .ToArray();

            ViewBag.category2ByScale10 = category2ByScale10;

            ViewBag.openQuestiona = openQuestiona;
            ViewBag.openQuestionaCount = openQuestionaCount;

            ViewBag.Scale1Count1 = Scale1Count1;
            ViewBag.Scale1Count2 = Scale1Count2;
            ViewBag.Scale1Count3 = Scale1Count3;
            ViewBag.Scale1Count4 = Scale1Count4;
            ViewBag.Scale1Count5 = Scale1Count5;

            ViewBag.Scale2Count1 = Scale2Count1;
            ViewBag.Scale2Count2 = Scale2Count2;
            ViewBag.Scale2Count3 = Scale2Count3;
            ViewBag.Scale2Count4 = Scale2Count4;
            ViewBag.Scale2Count5 = Scale2Count5;

            ViewBag.Scale3Count1 = Scale3Count1;
            ViewBag.Scale3Count2 = Scale3Count2;
            ViewBag.Scale3Count3 = Scale3Count3;
            ViewBag.Scale3Count4 = Scale3Count4;
            ViewBag.Scale3Count5 = Scale3Count5;

            ViewBag.Scale4Count1 = Scale4Count1;
            ViewBag.Scale4Count2 = Scale4Count2;
            ViewBag.Scale4Count3 = Scale4Count3;
            ViewBag.Scale4Count4 = Scale4Count4;
            ViewBag.Scale4Count5 = Scale4Count5;


            ViewBag.Scale5Count1 = Scale5Count1;
            ViewBag.Scale5Count2 = Scale5Count2;
            ViewBag.Scale5Count3 = Scale5Count3;
            ViewBag.Scale5Count4 = Scale5Count4;
            ViewBag.Scale5Count5 = Scale5Count5;

            ViewBag.Scale6Count1 = Scale6Count1;
            ViewBag.Scale6Count2 = Scale6Count2;
            ViewBag.Scale6Count3 = Scale6Count3;
            ViewBag.Scale6Count4 = Scale6Count4;
            ViewBag.Scale6Count5 = Scale6Count5;

            ViewBag.Scale7Count1 = Scale7Count1;
            ViewBag.Scale7Count2 = Scale7Count2;
            ViewBag.Scale7Count3 = Scale7Count3;
            ViewBag.Scale7Count4 = Scale7Count4;
            ViewBag.Scale7Count5 = Scale7Count5;

            ViewBag.ageCountTotal = ageCountTotal;
            ViewBag.eduCount1 = eduCount1;
            ViewBag.eduCount2 = eduCount2;
            ViewBag.eduCount3 = eduCount3;
            ViewBag.eduCount4 = eduCount4;
            ViewBag.eduCount5 = eduCount5;

            ViewBag.eduCountTotal = eduCountTotal;
            ViewBag.AgeCount1 = AgeCount1;
            ViewBag.AgeCount2 = AgeCount2;
            ViewBag.AgeCount3 = AgeCount3;
            ViewBag.AgeCount4 = AgeCount4;

            ViewBag.sexesCountTotal = sexesCountTotal;
            ViewBag.Sex1 = sexesCount1;
            ViewBag.Sex2 = sexesCount2;

            ViewBag.PageTitle = form.FormTitleAr;
            ViewBag.Question1 = form.Question1;
            ViewBag.Question2 = form.Question2;
            ViewBag.Question3 = form.Question3;
            ViewBag.Question4 = form.Question4;
            ViewBag.Question5 = form.Question5;
            ViewBag.Question6 = form.Question6;
            ViewBag.Question7 = form.Question7;
            ViewBag.Question8 = form.Question8;
            ViewBag.Question9 = form.Question9;
            ViewBag.Question10 = form.Question10;
            ViewBag.Question11 = form.Question11;
            ViewBag.Question12 = form.Question12;
            ViewBag.Question13 = form.Question13;
            ViewBag.OpenQuestion = form.OpenQuestionAr;
            ViewBag.startDate = form.StartDate;
            ViewBag.endDate = form.EndDate;


            int numberOfQuestions = 1;

            if (form.Question1 != null)
            {
                numberOfQuestions++;
            }

            if (form.Question2 != null)
            {
                numberOfQuestions++;
            }

            if (form.Question3 != null)
            {
                numberOfQuestions++;
            }

            if (form.Question4 != null)
            {
                numberOfQuestions++;
            }

            if (form.Question5 != null)
            {
                numberOfQuestions++;
            }

            if (form.Question6 != null)
            {
                numberOfQuestions++;
            }

            if (form.Question7 != null)
            {
                numberOfQuestions++;
            }

            if (form.Question8 != null)
            {
                numberOfQuestions++;
            }

            if (form.Question9 != null)
            {
                numberOfQuestions++;
            }

            if (form.Question10 != null)
            {
                numberOfQuestions++;
            }

            if (form.Question11 != null)
            {
                numberOfQuestions++;
            }

            if (form.Question12 != null)
            {
                numberOfQuestions++;
            }

            if (form.Question13 != null)
            {
                numberOfQuestions++;
            }

            ViewBag.numberOfQuestions = numberOfQuestions;

            if (numberOfQuestions == 12)
            {
                int Scale8Count1 = _context.FormEntry
                    .Where(fe => fe.FormId == id)
                    .Where(fe => fe.Scale8 == 1)
                    .ToList().Count;

                int Scale8Count2 = _context.FormEntry
                    .Where(fe => fe.FormId == id)
                    .Where(fe => fe.Scale8 == 2)
                    .ToList().Count;

                int Scale8Count3 = _context.FormEntry
                    .Where(fe => fe.FormId == id)
                    .Where(fe => fe.Scale8 == 3)
                    .ToList().Count;

                int Scale8Count4 = _context.FormEntry
                    .Where(fe => fe.FormId == id)
                    .Where(fe => fe.Scale8 == 4)
                    .ToList().Count;

                int Scale8Count5 = _context.FormEntry
                    .Where(fe => fe.FormId == id)
                    .Where(fe => fe.Scale8 == 5)
                    .ToList().Count;


                ViewBag.Scale8Count1 = Scale8Count1;
                ViewBag.Scale8Count2 = Scale8Count2;
                ViewBag.Scale8Count3 = Scale8Count3;
                ViewBag.Scale8Count4 = Scale8Count4;
                ViewBag.Scale8Count5 = Scale8Count5;
            }

            if (numberOfQuestions == 13)
            {
                int Scale9Count1 = _context.FormEntry
                    .Where(fe => fe.FormId == id)
                    .Where(fe => fe.Scale9 == 1)
                    .ToList().Count;

                int Scale9Count2 = _context.FormEntry
                    .Where(fe => fe.FormId == id)
                    .Where(fe => fe.Scale9 == 2)
                    .ToList().Count;

                int Scale9Count3 = _context.FormEntry
                    .Where(fe => fe.FormId == id)
                    .Where(fe => fe.Scale9 == 3)
                    .ToList().Count;

                int Scale9Count4 = _context.FormEntry
                    .Where(fe => fe.FormId == id)
                    .Where(fe => fe.Scale9 == 4)
                    .ToList().Count;

                int Scale9Count5 = _context.FormEntry
                    .Where(fe => fe.FormId == id)
                    .Where(fe => fe.Scale9 == 5)
                    .ToList().Count;


                ViewBag.Scale9Count1 = Scale9Count1;
                ViewBag.Scale9Count2 = Scale9Count2;
                ViewBag.Scale9Count3 = Scale9Count3;
                ViewBag.Scale9Count4 = Scale9Count4;
                ViewBag.Scale9Count5 = Scale9Count5;
            }

            if (numberOfQuestions == 14)
            {
                int Scale10Count1 = _context.FormEntry
                    .Where(fe => fe.FormId == id)
                    .Where(fe => fe.Scale10 == 1)
                    .ToList().Count;

                int Scale10Count2 = _context.FormEntry
                    .Where(fe => fe.FormId == id)
                    .Where(fe => fe.Scale10 == 2)
                    .ToList().Count;

                int Scale10Count3 = _context.FormEntry
                    .Where(fe => fe.FormId == id)
                    .Where(fe => fe.Scale10 == 3)
                    .ToList().Count;

                int Scale10Count4 = _context.FormEntry
                    .Where(fe => fe.FormId == id)
                    .Where(fe => fe.Scale10 == 4)
                    .ToList().Count;

                int Scale10Count5 = _context.FormEntry
                    .Where(fe => fe.FormId == id)
                    .Where(fe => fe.Scale10 == 5)
                    .ToList().Count;


                ViewBag.Scale10Count1 = Scale10Count1;
                ViewBag.Scale10Count2 = Scale10Count2;
                ViewBag.Scale10Count3 = Scale10Count3;
                ViewBag.Scale10Count4 = Scale10Count4;
                ViewBag.Scale10Count5 = Scale10Count5;
            }

            if (Thread.CurrentThread.CurrentCulture.Name != "ar")
            {
                ViewBag.PageTitle = form.FormTitleEn;
                ViewBag.Question1 = form.Question1EN;
                ViewBag.Question1 = form.Question1EN;
                ViewBag.Question2 = form.Question2EN;
                ViewBag.Question3 = form.Question3EN;
                ViewBag.Question4 = form.Question4EN;
                ViewBag.Question5 = form.Question5EN;
                ViewBag.Question6 = form.Question6EN;
                ViewBag.Question7 = form.Question7EN;
                ViewBag.Question8 = form.Question8EN;
                ViewBag.Question9 = form.Question9EN;
                ViewBag.Question10 = form.Question10EN;
                ViewBag.Question11 = form.Question11EN;
                ViewBag.Question12 = form.Question12EN;
                ViewBag.Question13 = form.Question13EN;
                ViewBag.OpenQuestion = form.OpenQuestionEn;
                ViewBag.startDate = form.StartDate;
                ViewBag.endDate = form.EndDate;
            }

            if (form == null)
            {
                return NotFound();
            }

            return View(form);
        }

        private (string, bool, string, bool) validateDateOnCreation(DateTime? startDate, DateTime? endDate,
            string type = "Create")
        {
            if (type == "Create")
            {
                bool startDateValid = startDate > @DateTime.Now.AddMonths(-1) &&
                                      startDate < DateTime.Now.AddYears(5);

                bool endDateValid = endDate > DateTime.Now.AddHours(1) &&
                                    endDate < DateTime.Now.AddYears(5);

                return validateDates(startDateValid, endDateValid);
            }

            bool startDateValida = startDate < DateTime.Now.AddYears(5);

            bool endDateValida = endDate > DateTime.Now.AddMinutes(10) &&
                                 endDate < DateTime.Now.AddYears(5).AddMinutes(10);

            return validateDates(startDateValida, endDateValida);
        }

        private (string, bool, string, bool) validateDates(bool startDateValid, bool endDateValid)
        {
            if (startDateValid && endDateValid)
            {
                return ("startDateValid", true, "endDateValid", true);
            }

            if (startDateValid && !endDateValid)
            {
                return ("startDateValid", true, "endDateValid", false);
            }

            if (!startDateValid && endDateValid)
            {
                return ("startDateValid", false, "endDateValid", true);
            }

            if (!startDateValid && !endDateValid)
            {
                return ("startDateValid", false, "endDateValid", false);
            }

            return ("startDateValid", false, "endDateValid", false);
        }


        [Authorize]
        // GET: FormCreator/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: FormCreator/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind(
                "id,FormTitleAr,FormTitleEn,FormSectionOneLabelAr,FormSectionOneLabelEn,FormSectionTwoLabelAr,FormSectionTwoLabelEn,FormSectionThreeLabelAr,FormSectionThreeLabelEn,Question1,Question2,Question3,Question4,Question5,Question6,Question7,Question8,Question9,Question10,Question11,Question12,Question13,Question1EN,Question2EN,Question3EN,Question4EN,Question5EN,Question6EN,Question7EN,Question8EN,Question9EN,Question10EN,Question11EN,Question12EN,Question13EN,OpenQuestionAr,OpenQuestionEn,CreationDate,StartDate,EndDate")]
            Form form)
        {
            (_, bool startDateValidtionResult, _, bool endDateValidtionResult) =
                validateDateOnCreation(form.StartDate, form.EndDate);


            if (!startDateValidtionResult)
            {
                if (locale == "ar")
                {
                    ModelState.AddModelError("startDate",
                        " وقت البداية يجب ان لا يكون اكثر من خمس سنوات او اقل من شهر  من تاريخ اليوم");
                }

                if (locale == "en")
                {
                    ModelState.AddModelError("startDate",
                        "Start Date must not exceed 5 years from today's date and not be less than one month from today");
                }
            }

            if (!endDateValidtionResult)
            {
                if (locale == "ar")
                {
                    ModelState.AddModelError("endDate", " وقت النهاية يجب ان لا يكون اقل من وقت البداية بعشر دقائق ");
                }

                if (locale == "en")
                {
                    ModelState.AddModelError("endDate", "End date must be 10 minutes grater than start date.");
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(form);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(form);
        }

        public string NullChecker(string value)
        {
            if (value == null)
            {
                return "none";
            }

            return "not null";
        }


        [Authorize]
        // GET: FormCreator/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Form.FindAsync(id);
            if (form == null)
            {
                return NotFound();
            }

            ViewBag.Question11Display = NullChecker(form.Question11);
            ViewBag.Question12Display = NullChecker(form.Question12);
            ViewBag.Question13Display = NullChecker(form.Question13);

            return View(form);
        }


        [Authorize]
        // POST: FormCreator/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind(
                "id,FormTitleAr,FormTitleEn,FormSectionOneLabelAr,FormSectionOneLabelEn,FormSectionTwoLabelAr,FormSectionTwoLabelEn,FormSectionThreeLabelAr,FormSectionThreeLabelEn,Question1,Question2,Question3,Question4,Question5,Question6,Question7,Question8,Question9,Question10,Question11,Question12,Question13,Question1EN,Question2EN,Question3EN,Question4EN,Question5EN,Question6EN,Question7EN,Question8EN,Question9EN,Question10EN,Question11EN,Question12EN,Question13EN,Question14,Question14En,OpenQuestionAr,OpenQuestionEn,CreationDate,StartDate,EndDate")]
            Form form)
        {
            if (id != form.id)
            {
                return NotFound();
            }

            (_, bool startDateValidtionResult, _, bool endDateValidtionResult) =
                validateDateOnCreation(form.StartDate, form.EndDate, "Edit");

            if (!startDateValidtionResult)
            {
                if (locale == "ar")
                {
                    ModelState.AddModelError("startDate",
                        " وقت البداية يجب ان لا يكون اكثر من خمس سنوات او اقل من شهر من تاريخ اليوم");
                }

                if (locale == "en")
                {
                    ModelState.AddModelError("startDate",
                        "Start Date must not exceed 5 years from today's date and not be less than one month from today");
                }
            }

            if (!endDateValidtionResult)
            {
                if (locale == "ar")
                {
                    ModelState.AddModelError("endDate",
                        " وقت النهاية يجب ان لا يكون اقل من وقت الحالي ووقت البداية بعشر دقائق ");
                }

                if (locale == "en")
                {
                    ModelState.AddModelError("endDate", "End date must be 10 minutes grater than start date.");
                }
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(form);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormExists(form.id))
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

            return View(form);
        }


        [Authorize]
        // GET: FormCreator/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Form
                .FirstOrDefaultAsync(m => m.id == id);
            if (form == null)
            {
                return NotFound();
            }

            ViewBag.Question11Display = NullChecker(form.Question11);
            ViewBag.Question12Display = NullChecker(form.Question12);
            ViewBag.Question13Display = NullChecker(form.Question13);

            return View(form);
        }


        [Authorize]
        // POST: FormCreator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var form = await _context.Form.FindAsync(id);
            if (form != null)
            {
                _context.Form.Remove(form);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormExists(int id)
        {
            return _context.Form.Any(e => e.id == id);
        }
    }
}