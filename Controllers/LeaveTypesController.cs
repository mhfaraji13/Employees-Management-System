using Employesmhfdev.Data;
using Employesmhfdev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employesmhfdev.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaveTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get: /LeaveTypes

        public async Task<IActionResult> Index()
        {
            return View(await _context.LeaveTypes.ToListAsync());
        }

        // Get: /LeaveTypes/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _context.LeaveTypes.FirstOrDefaultAsync(m=>m.Id == id);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // Get: /LeaveTypes/Create

        public IActionResult Create()
        {
            return View();
        }

        // Post: /LeaveTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveType leaveType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaveType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(leaveType);
        }


        //Get: /LeaveTypes/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var leaveType = await _context.LeaveTypes.FindAsync(id);

            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        //Post: /LeaveTypes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , LeaveType leaveType)
        {
            if (id != leaveType.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!LeaveTypeExists(leaveType.Id))
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

            return View(leaveType);
        }


        //Get: /LeaveTypes/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var leaveType = await _context.LeaveTypes.FirstOrDefaultAsync(m=>m.Id == id);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }


        //Post: /LeaveTypes/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int id)
        {
            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if(leaveType != null)
            {
                _context.LeaveTypes.Remove(leaveType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool LeaveTypeExists(int id)
        {
            return _context.LeaveTypes.Any(e=>e.Id == id);
        }

    }
}
