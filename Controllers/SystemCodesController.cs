using Employesmhfdev.Data;
using Employesmhfdev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employesmhfdev.Controllers
{
    public class SystemCodesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SystemCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get: /SystemCodes

        public async Task<IActionResult> Index()
        {
            return View(await _context.SystemCodes.ToListAsync());
        }

        // Get: /SystemCodes/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemCode = await _context.SystemCodes.FirstOrDefaultAsync(m=>m.Id == id);
            if (systemCode == null)
            {
                return NotFound();
            }

            return View(systemCode);
        }

        // Get: /SystemCodes/Create

        public IActionResult Create()
        {
            return View();
        }

        // Post: /SystemCodes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SystemCode systemCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(systemCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(systemCode);
        }


        //Get: /SystemCodes/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var systemCode = await _context.SystemCodes.FindAsync(id);

            if (systemCode == null)
            {
                return NotFound();
            }

            return View(systemCode);
        }

        //Post: /SystemCodes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , SystemCode systemCode)
        {
            if (id != systemCode.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(systemCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!SystemCodeExists(systemCode.Id))
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

            return View(systemCode);
        }


        //Get: /SystemCodes/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var systemCode = await _context.SystemCodes.FirstOrDefaultAsync(m=>m.Id == id);
            if (systemCode == null)
            {
                return NotFound();
            }

            return View(systemCode);
        }


        //Post: /SystemCodes/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int id)
        {
            var systemCode = await _context.SystemCodes.FindAsync(id);
            if(systemCode != null)
            {
                _context.SystemCodes.Remove(systemCode);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool SystemCodeExists(int id)
        {
            return _context.SystemCodes.Any(e=>e.Id == id);
        }

    }
}
