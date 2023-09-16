using CinemaTickets.Data.ViewModelData;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CinemaTickets.Controllers
{
	public class RolesController : Controller
	{
		private readonly RoleManager<IdentityRole> _roleManager;

		public RolesController(RoleManager<IdentityRole> roleManager)
        {
			_roleManager = roleManager;
		}
		public async Task <IActionResult> Index()
		{
			var roles = _roleManager.Roles.ToListAsync();
			return View(roles);
		}
		public IActionResult CreateRoles()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateRoles(RoleViewModel newRole)
		{
			if(ModelState.IsValid==true)
			{
				var role = new IdentityRole()
				{
					Name = newRole.RoleName,
				};
				var result = await _roleManager.CreateAsync(role);
				if(result.Succeeded)
				{
					return View();
				}
				else
				{
					foreach(var error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				}
			}
			return View(newRole);
		}
	}
}
