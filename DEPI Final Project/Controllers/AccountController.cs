using DEPI_Final_Project.Data;
using DEPI_Final_Project.Models;
using DEPI_Final_Project.ViewModels.AccountVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace DEPI_Final_Project.Controllers
{
    public class AccountController : Controller
    {   
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ApplicationDbContext _context;


        public AccountController
            (UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> signInManager,ApplicationDbContext context)
        {
            userManager = _userManager;
            this.signInManager = signInManager;
            _context = context;
        }
 
        [HttpGet]
        public IActionResult Register()
        {
            var roles = _context.Roles.ToList();
            var rolesList = roles.Select(r => new SelectListItem
            {
                Value = r.Name,
                Text = r.Name   
            }).ToList();
            var VM = new AdminRegisterVM()
            {
                RolesList= rolesList
            };

            return View(VM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Register(AdminRegisterVM newUserVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userModel = new ApplicationUser
                {
                    Email = newUserVM.RegisterUserVM.Email,
                    UserName = newUserVM.RegisterUserVM.UserName,
                    PasswordHash = newUserVM.RegisterUserVM.Password,
                };

                IdentityResult result = await userManager.CreateAsync(userModel, newUserVM.RegisterUserVM.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(userModel, newUserVM.SelectedRole);                        
                      await signInManager.SignInAsync(userModel, isPersistent: false);
                      
                    return RedirectToAction(nameof(Login));
                }
                foreach (var item in result.Errors)
                    ModelState.AddModelError("", item.Description);
            }
            return View(newUserVM);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM userVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser? userModel = await userManager.FindByEmailAsync(userVM.Email);
                if (userModel is not null)
                {
                    bool find = await userManager.CheckPasswordAsync(userModel, userVM.Password);
                    if (find == true)
                    {
                        List<Claim> claims = new List<Claim>();
                        await signInManager.SignInWithClaimsAsync(userModel, userVM.RemeberMe, claims);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "User and Password is invalid");
            }
            return View(userVM);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync(); 
            return RedirectToAction("Login");
        }
    }
}
