using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using feedback.Data;
using feedback.Models;

namespace feedback.Controllers
{
    public class FormCreator : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormCreator(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FormCreator
        public async Task<IActionResult> Index()
        {
            return View(await _context.Form
                .Include(f => f.FormEntries)
                .ToListAsync());
        }

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

            ViewBag.test = formEntry;


            int Scale1Count1 = 0;
            int Scale1Count2 = 0;
            int Scale1Count3 = 0;
            int Scale1Count4 = 0;
            int Scale1Count5 = 0;
            
            int AgeCount1 = 0;
            int AgeCount2 = 0;
            int AgeCount3 = 0;
            int AgeCount4 = 0;

            

            foreach (var entry in formEntry)
            {
                if (entry.Scale2 == 1)
                {
                    Scale1Count1 += 1;
                }

                if (entry.Scale2 == 2)
                {
                    Scale1Count2 += 1;
                }

                if (entry.Scale2 == 3)
                {
                    Scale1Count3 += 1;
                }

                if (entry.Scale2 == 4)
                {
                    Scale1Count4 += 1;
                }

                if (entry.Scale2 == 5)
                {
                    Scale1Count4 += 1;
                }     
                
                if (entry.AgeGroup == 1)
                {
                    AgeCount1 += 1;
                }

                if (entry.AgeGroup == 2)
                {
                    AgeCount1 += 1;
                }

                if (entry.AgeGroup == 3)
                {
                    AgeCount1 += 1;
                }

                if (entry.AgeGroup == 4)
                {
                    AgeCount1 += 1;
                }
                
            }

            ViewBag.Scale1Count1 = Scale1Count1;
            ViewBag.Scale1Count2 = Scale1Count2;
            ViewBag.Scale1Count3 = Scale1Count3;
            ViewBag.Scale1Count4 = Scale1Count4;
            ViewBag.Scale1Count5 = Scale1Count5;   
            
            
            ViewBag.AgeCount1 = AgeCount1;
            ViewBag.AgeCount2 = AgeCount2;
            ViewBag.AgeCount3 = AgeCount3;
            ViewBag.AgeCount4 = AgeCount4;

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

        // GET: FormCreator/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormCreator/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind(
                "id,FormTitleAr,FormTitleEn,FormSectionOneLabelAr,FormSectionOneLabelEn,FormSectionTwoLabelAr,FormSectionTwoLabelEn,FormSectionThreeLabelAr,FormSectionThreeLabelEn,Question1,Question2,Question3,Question4,Question5,Question6,Question7,Question8,Question9,Question10,Question11,Question12,Question13,Question1EN,Question2EN,Question3EN,Question4EN,Question5EN,Question6EN,Question7EN,Question8EN,Question9EN,Question10EN,Question11EN,Question12EN,Question13EN,OpenQuestionAr,OpenQuestionEn,CreationDate")]
            Form form)
        {
            if (ModelState.IsValid)
            {
                _context.Add(form);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(form);
        }

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

            return View(form);
        }

        // POST: FormCreator/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind(
                "id,FormTitleAr,FormTitleEn,FormSectionOneLabelAr,FormSectionOneLabelEn,FormSectionTwoLabelAr,FormSectionTwoLabelEn,FormSectionThreeLabelAr,FormSectionThreeLabelEn,Question1,Question2,Question3,Question4,Question5,Question6,Question7,Question8,Question9,Question10,Question11,Question12,Question13,Question1EN,Question2EN,Question3EN,Question4EN,Question5EN,Question6EN,Question7EN,Question8EN,Question9EN,Question10EN,Question11EN,Question12EN,Question13EN,Question14,Question14En,OpenQuestionAr,OpenQuestionEn,CreationDate")]
            Form form)
        {
            if (id != form.id)
            {
                return NotFound();
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

            return View(form);
        }

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