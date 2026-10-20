using Employesmhfdev.Data;
using Employesmhfdev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employesmhfdev.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get: /Countries

        public async Task<IActionResult> Index()
        {
            return View(await _context.Countries.ToListAsync());
        }

        // Get: /Countries/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.FirstOrDefaultAsync(m=>m.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // Get: /Countries/Create

        public IActionResult Create()
        {
            return View();
        }

        // Post: /Countries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Add(country);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(country);
        }


        //Get: /Countries/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        //Post: /Countries/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , Country country)
        {
            if (id != country.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!CountryExists(country.Id))
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

            return View(country);
        }


        //Get: /Countries/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.FirstOrDefaultAsync(m=>m.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }


        //Post: /Countries/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if(country != null)
            {
                _context.Countries.Remove(country);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e=>e.Id == id);
        }

    }
}
