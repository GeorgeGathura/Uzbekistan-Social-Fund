using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using Uzbekistan_Social_Fund.Data;
using Uzbekistan_Social_Fund.Models;
using Uzbekistan_Social_Fund.Models.ViewModels;
using Uzbekistan_Social_Fund.Utilities;

namespace Uzbekistan_Social_Fund.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly SocialFundDbContext _context;
        SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;
        UserManager<ApplicationUser> _userManager;

        public ApplicationController(SocialFundDbContext db,SignInManager<ApplicationUser>signInManager,
                                    RoleManager<IdentityRole>roleManager,UserManager<ApplicationUser>userManager)
        {
            _context = db;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;

        }
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.EmailAddress, login.Password, login.RememberMe, false);
            if (result.Succeeded)
            {
                
                return RedirectToAction("Index", "Applicants");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Login Attempt");
            }
  
           return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Register()
        {
 
            if (!_roleManager.RoleExistsAsync(RolesHelper.Admin).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(RolesHelper.Admin));
                await _roleManager.CreateAsync(new IdentityRole(RolesHelper.DataEntry));

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Roles = RolesHelper.GetRoles();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {

                var user = new ApplicationUser
                {
                    UserName=registerVM.Email,
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    Email = registerVM.Email,

                };

                var result = await _userManager.CreateAsync(user, registerVM.Password);
                if (result.Succeeded)
                {
                    //Login user if submitted
                    if (!User.IsInRole(RolesHelper.Admin) || !User.IsInRole(RolesHelper.DataEntry))
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        var role = await _roleManager.FindByNameAsync(registerVM.Role);
                        await _userManager.AddToRoleAsync(user, role.Name);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

            }
            ViewBag.Roles = RolesHelper.GetRoles();
            return View(registerVM);
        }
    }
}
