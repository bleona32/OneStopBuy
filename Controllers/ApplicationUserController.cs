using OneStopBuy.Data;
using OneStopBuy.Models;
using OneStopBuy.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneStopBuy.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHostingEnvironment _hostingEnvironment;


        public ApplicationUserController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, RoleManager<IdentityRole> roleManager, IHostingEnvironment hostingEnvironment, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
            _hostingEnvironment = hostingEnvironment;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        /*public async Task<IActionResult> Index(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                //var posts = _context.Posts.Where(x => x.UserId.Equals(id)).ToList();

                AccountViewModel model = new AccountViewModel
                {
                    userId = user.Id,
                    Username = user.User_Username,
                    Bio = user.Bio,
                    Photo = user.ProfilePicture,

                };
                return View(model);
            }
        }*/

        public async Task<IActionResult> Account(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                //var posts = _context.Posts.Where(x => x.UserId.Equals(id)).ToList();

                AccountViewModel model = new AccountViewModel
                {
                    userId = user.Id,
                    Username = user.User_Username,
                    Bio = user.Bio,
                    Photo = user.ProfilePicture,

                };
                return View(model);
            }
        }
    }
}
