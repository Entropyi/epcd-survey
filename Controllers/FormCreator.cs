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
            int communityCount = _context.Default.Count(d => d.Category == "Community");
            int industryCount = _context.Default.Count(d => d.Category == "Industry");

            if (communityCount > 0)
            {
                ViewBag.communityDefault = _context.Default
                    .Where(d => d.Category == "Community")
                    .Select(d => d.FormID)
                    .Single();
            }

            if (industryCount > 0)
            {
                ViewBag.IndustryDefault = _context.Default
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

            int communityCount = _context.Default.Count(d => d.Category == "Community");
            int industryCount = _context.Default.Count(d => d.Category == "Industry");

            if (communityCount > 0)
            {
                communityDefault = _context.Default
                    .Where(d => d.Category == "Community")
                    .Select(d => d.FormID)
                    .Single();
            }

            if (industryCount > 0)
            {
                IndustryDefault = _context.Default
                    .Where(d => d.Category == "Industry")
                    .Select(d => d.FormID)
                    .Single();
            }


            if (defualt.FormID > 0 && (defualt.Category.Equals("Industry") || defualt.Category.Equals("Community")))
            {
                int? Industry = _context.Default
                    .Where(d => d.Category == defualt.Category)
                    .ToList().Count();

                int? Community = _context.Default
                    .Where(d => d.Category == defualt.Category)
                    .ToList().Count();

                if (defualt.Category.Equals("Industry") && Industry > 0)
                {
                    try
                    {
                        if (IndustryDefault == defualt.FormID)
                        {
                            _context.Default.Where(d => d.FormID == defualt.FormID)
                                .Where(d => d.Category == defualt.Category).ExecuteDeleteAsync();
                            return RedirectToAction(nameof(Index));
                        }

                        _context.Default
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
                            _context.Default.Where(d => d.FormID == defualt.FormID)
                                .Where(d => d.Category == defualt.Category).ExecuteDeleteAsync();
                            return RedirectToAction(nameof(Index));
                        }

                        _context.Default
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

            ViewBag.eduCount1 = eduCount1;
            ViewBag.eduCount2 = eduCount2;
            ViewBag.eduCount3 = eduCount3;
            ViewBag.eduCount4 = eduCount4;

            ViewBag.AgeCount1 = AgeCount1;
            ViewBag.AgeCount2 = AgeCount2;
            ViewBag.AgeCount3 = AgeCount3;
            ViewBag.AgeCount4 = AgeCount4;

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