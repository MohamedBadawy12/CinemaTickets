using CinemaTickets.Data;
using CinemaTickets.Data.ViewModelData;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CinemaTickets.Data.CodeOfRegister;

namespace CinemaTickets.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly AppDbContext _context;

		public AccountController(UserManager<ApplicationUser> userManger, SignInManager<ApplicationUser> signInManager, AppDbContext context)
		{
			_userManager = userManger;
			_signInManager = signInManager;
			_context = context;
		}
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
		{
			if (ModelState.IsValid == true)
			{
				var newUser = new ApplicationUser()
				{
					FullName = registerViewModel.FullName,
					Email = registerViewModel.Email,
					UserName = registerViewModel.Email
				};
				var result = await _userManager.CreateAsync(newUser, registerViewModel.Password);
				if (result.Succeeded)
				{
					await _userManager.AddToRoleAsync(newUser, "User");
					//await _signInManager.SignInAsync(newUser, false);//create cookie
					return View("RegisterCompleted");
				}
				else
				{
					foreach(var error in result.Errors)
					{
						ModelState.AddModelError("",error.Description);
					}
				}
			}
			return View (registerViewModel);
		
		}
		//--------------------------------------------------------

		public IActionResult CodeToRegister(CodeRegister codeRegister)
		{
			if (codeRegister.CodeNumber!=1907)
			{
				return View("CodeToRegister");	
			}
			return RedirectToAction("AddAdmin");
		}
		public IActionResult AddAdmin()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddAdmin(RegisterViewModel registerViewModel)
		{
			if (ModelState.IsValid == true)
			{
				var newUser = new ApplicationUser()
				{
					FullName = registerViewModel.FullName,
					Email = registerViewModel.Email,
					UserName = registerViewModel.Email
				};
				var result = await _userManager.CreateAsync(newUser, registerViewModel.Password);
				if (result.Succeeded)
				{
					await _userManager.AddToRoleAsync(newUser, "Admin");
					//await _signInManager.SignInAsync(newUser, false);//create cookie
					return View("RegisterCompleted");
				}
				else
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				}
			}
			return View(registerViewModel);

		}


		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			if(ModelState.IsValid==true) 
			{
				var user=await _userManager.FindByEmailAsync(loginViewModel.Email);
				if (user != null)
				{
					var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password,false,false);
					if (result.Succeeded)
					{
						return RedirectToAction("Index", "Movie");
					}
					TempData["Error"] = "Wrong credentials. please,try again!";
					return View(loginViewModel);
				}
				TempData["Error"] = "Wrong credentials. please,try again!";
			}
			return View(loginViewModel);

		}
		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index","Movie");
		}
		public async Task<IActionResult> Users()
		{
			var users = await _context.Users.ToListAsync();
			return View(users);
		}
		public IActionResult AccessDenied(string ReturnUrl)
		{
			return View();
		}

	}
}
