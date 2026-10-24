using Employesmhfdev.ViewModels;
using Employesmhfdev.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Employesmhfdev.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }






        // GET: RolesController
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        // Get: Create Roles


        public IActionResult Create()
        {
            return View();
        }


        // Post : Create Role

        [HttpPost]
        [ValidateAntiForgeryToken]


        public async Task<IActionResult> Create(RoleViewModel roleViewModel)
        {
            var identityRole = new IdentityRole();
            identityRole.Name = roleViewModel.RoleName;

            var result = await _roleManager.CreateAsync(identityRole);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }


            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }




            return View(roleViewModel);


        }


        // Get: Edit/Role/5

        public async Task<IActionResult> Edit(string? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                return NotFound();

            }

            var model = new RoleViewModel()
            {
                Id = role.Id,
                RoleName = role.Name
            };

            return View(model);



        }


        // Post: Edit/Role/5

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(string id , RoleViewModel roleViewModel)
        {
            if(id != roleViewModel.Id)
            {
                return NotFound();
            }

            var exists = await _roleManager.RoleExistsAsync(roleViewModel.RoleName);


            if (exists == true)
            {
                ModelState.AddModelError("", "This role name alreadey exists.");

                return View(roleViewModel);
            }

            var role = await _roleManager.FindByIdAsync(id);
            if(role == null)
            {
                return NotFound();
            }

            role.Name = roleViewModel.RoleName;

            var result = await _roleManager.UpdateAsync(role);
            if(result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }


            foreach ( var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);

               

            }

            return View(roleViewModel);
        }









    }
}
