using CinemaTickets.Data;
using CinemaTickets.Models;
using CinemaTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace CinemaTickets.Controllers
{
    public class CinemaController : Controller
    {
		private readonly ICinemaService _service;
		public CinemaController(ICinemaService service)
		{
			_service = service;
		}
		public async Task<IActionResult> Index()
        {
			var AllCinemas = await _service.GetAllAsync();
			return View(AllCinemas);
        }
		public IActionResult Create() 
		{ 
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create([Bind("Name,Logo,Description")] Cinema cinema)
		{
			if (!ModelState.IsValid)
			{
				return View(cinema);
			}
			await _service.AddAsync(cinema);
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Details(int id)
		{
			var CinemaDetails = await _service.GetByIdAsync(id);
			if (CinemaDetails == null)
				return View("Not Found");
			return View(CinemaDetails);
		}
		public async Task<IActionResult> Edit(int id)
		{
			var CinemaDetails= await _service.GetByIdAsync(id);
			if (CinemaDetails == null)
				return View("Not Found");
			return View(CinemaDetails);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(int id, Cinema cinema)
		{
			if (!ModelState.IsValid)
			{
				return View(cinema);
			}
			await _service.UpdateAsync(id,cinema);
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await _service.DeleteAsync(id);
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("Exception", ex.InnerException.Message);
				return View(nameof(Details));
			}
		}
	}
}
