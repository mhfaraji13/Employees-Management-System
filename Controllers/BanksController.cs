using Employesmhfdev.Data;
using Employesmhfdev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employesmhfdev.Controllers
{
    public class BanksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BanksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get: /Banks

        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // Get: /Banks/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bank = await _context.Banks.FirstOrDefaultAsync(m=>m.Id == id);
            if (bank == null)
            {
                return NotFound();
            }

            return View(bank);
        }

        // Get: /Banks/Create

        public IActionResult Create()
        {
            return View();
        }

        // Post: /Banks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bank bank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(bank);
        }


        //Get: /Banks/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var bank = await _context.Banks.FindAsync(id);

            if (bank == null)
            {
                return NotFound();
            }

            return View(bank);
        }

        //Post: /Banks/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , Bank bank)
        {
            if (id != bank.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!BankExists(bank.Id))
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

            return View(bank);
        }


        //Get: /Banks/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var bank = await _context.Banks.FirstOrDefaultAsync(m=>m.Id == id);
            if (bank == null)
            {
                return NotFound();
            }

            return View(bank);
        }


        //Post: /Banks/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int id)
        {
            var bank = await _context.Banks.FindAsync(id);
            if(bank != null)
            {
                _context.Banks.Remove(bank);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool BankExists(int id)
        {
            return _context.Banks.Any(e=>e.Id == id);
        }

    }
}
