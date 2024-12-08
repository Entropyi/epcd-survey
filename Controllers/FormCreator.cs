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
            return View(await _context.Form.ToListAsync());
        }

        // GET: FormCreator/Details/5
        public async Task<IActionResult> Details(int? id)
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
        public async Task<IActionResult> Create([Bind("id,Category,FromTitleAr,FromTitleEn,FromSectionOneLabelAr,FromSectionOneLabelEn,FromSectionTwoLabelAr,FromSectionTwoLabelEn,FromSectionThreeLabelAr,FromSectionThreeLabelEn,Question1,Questions2,Questions3,Questions4,Questions5,Questions6,Questions7,Questions8,Questions9,Questions10,Questions11,Questions12,Questions13,Question1EN,Questions2EN,Questions3EN,Questions4EN,Questions5EN,Questions6EN,Questions7EN,Questions8EN,Questions9EN,Questions10EN,Questions11EN,Questions12EN,Questions13EN,OpenQuestionAr,OpenQuestionEn,CreationDate")] Form form)
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
        public async Task<IActionResult> Edit(int id, [Bind("id,Category,FromTitleAr,FromTitleEn,FromSectionOneLabelAr,FromSectionOneLabelEn,FromSectionTwoLabelAr,FromSectionTwoLabelEn,FromSectionThreeLabelAr,FromSectionThreeLabelEn,Question1,Questions2,Questions3,Questions4,Questions5,Questions6,Questions7,Questions8,Questions9,Questions10,Questions11,Questions12,Questions13,Question1EN,Questions2EN,Questions3EN,Questions4EN,Questions5EN,Questions6EN,Questions7EN,Questions8EN,Questions9EN,Questions10EN,Questions11EN,Questions12EN,Questions13EN,OpenQuestionAr,OpenQuestionEn,CreationDate")] Form form)
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
