using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            var formEntry = _context.FormEntry.Where(fe => fe.FormId == id).ToList();
            
            int ageCountTotal = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Select(fe => fe.AgeGroup)
                .ToList().Count;

            int AgeCountByMale1 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.AgeGroup == 1)
                .Where(fe => fe.Sex == FormEntry.Sexes.Male)
                .ToList().Count;
            
            
            int AgeCountByMale2 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.AgeGroup == 2)
                .Where(fe => fe.Sex == FormEntry.Sexes.Male)
                .ToList().Count;
            
            
            int AgeCountByMale3 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.AgeGroup == 3)
                .Where(fe => fe.Sex == FormEntry.Sexes.Male)
                .ToList().Count;
            
            int AgeCountByMale4 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.AgeGroup == 4)
                .Where(fe => fe.Sex == FormEntry.Sexes.Male)
                .ToList().Count;
            
            int AgeCountByFemale1 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.AgeGroup == 1)
                .Where(fe => fe.Sex == FormEntry.Sexes.Female)
                .ToList().Count;
            
            
            int AgeCountByFemale2 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.AgeGroup == 2)
                .Where(fe => fe.Sex == FormEntry.Sexes.Female)
                .ToList().Count;
            
            
            int AgeCountByFemale3 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.AgeGroup == 3)
                .Where(fe => fe.Sex == FormEntry.Sexes.Female)
                .ToList().Count;
            
            int AgeCountByFemale4 = _context.FormEntry
                .Where(fe => fe.FormId == id)
                .Where(fe => fe.AgeGroup == 4)
                .Where(fe => fe.Sex == FormEntry.Sexes.Female)
                .ToList().Count;
            
            
            int[] ageByMale = { AgeCountByMale1, AgeCountByMale2, AgeCountByMale3 ,AgeCountByMale4 };

            ViewBag.ageByMale = ageByMale;
            
            

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