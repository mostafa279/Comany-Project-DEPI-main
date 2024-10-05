using DEPI_Final_Project.ViewModels.RoleVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace DEPI_Final_Project.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _role;

        public RoleController(RoleManager<IdentityRole> role)
        {
            _role = role;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRoleAsync(RoleVM roleVM)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = roleVM.Role;
                var state = await _role.CreateAsync(role);
                if (state.Succeeded)
                {
                    ViewBag.success = true;
                    return View(nameof(Login),"Account");
                }
                else
                {
                    foreach (var item in state.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(nameof(AddRole), roleVM);
        }
    }
}
