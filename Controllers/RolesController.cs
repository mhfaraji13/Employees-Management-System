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
        public async Task<IActionResult>  Index()
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

           if(result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }


            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("",error.Description);
            }




                return View(roleViewModel);
            
            
        }

        







    }
}
