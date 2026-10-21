using Employesmhfdev.Data;
using Employesmhfdev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employesmhfdev.Controllers
{
    public class DesignationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DesignationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get: /Designations

        public async Task<IActionResult> Index()
        {
            return View(await _context.Designations.ToListAsync());
        }

        // Get: /Designations/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designation = await _context.Designations.FirstOrDefaultAsync(m=>m.Id == id);
            if (designation == null)
            {
                return NotFound();
            }

            return View(designation);
        }

        // Get: /Designations/Create

        public IActionResult Create()
        {
            return View();
        }

        // Post: /Designations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Designation designation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(designation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(designation);
        }


        //Get: /Designations/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var designation = await _context.Designations.FindAsync(id);

            if (designation == null)
            {
                return NotFound();
            }

            return View(designation);
        }

        //Post: /Designations/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , Designation designation)
        {
            if (id != designation.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(designation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!DesignationExists(designation.Id))
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

            return View(designation);
        }


        //Get: /Designations/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var designation = await _context.Designations.FirstOrDefaultAsync(m=>m.Id == id);
            if (designation == null)
            {
                return NotFound();
            }

            return View(designation);
        }


        //Post: /Designations/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int id)
        {
            var designation = await _context.Designations.FindAsync(id);
            if(designation != null)
            {
                _context.Designations.Remove(designation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool DesignationExists(int id)
        {
            return _context.Designations.Any(e=>e.Id == id);
        }

    }
}
