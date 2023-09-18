using CinemaTickets.Data;
using CinemaTickets.Models;
using CinemaTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;

namespace CinemaTickets.Controllers
{
	[Authorize(Roles = "Admin")]
	public class ProducerController : Controller
    {
		private readonly IProducerServices _service;
		public ProducerController(IProducerServices service)
		{
			_service = service;
		}
		[AllowAnonymous]
		public async Task <IActionResult> Index()
        {
			var AllProducers = await _service.GetAllAsync();
			return View(AllProducers);
        }
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")] Producer producer)
		{
			if (!ModelState.IsValid)
			{
				return View(producer);
			}
			await _service.AddAsync(producer);
			return RedirectToAction(nameof(Index));
		}
		[AllowAnonymous]
		public async Task<IActionResult> Details(int id)
		{
			var ProducerDetails = await _service.GetByIdAsync(id);
			if (ProducerDetails == null)
				return View("Not Found");
			return View(ProducerDetails);
		}
		public async Task<IActionResult> Edit(int id)
		{
			var ProducerDetails = await _service.GetByIdAsync(id);
			if (ProducerDetails == null)
				return View("Not Found");
			return View(ProducerDetails);
		}
		[HttpPost]
		public async Task<IActionResult>Edit(int id,Producer producer)
		{
			if (!ModelState.IsValid)
			{
				return View(producer);
			}
			await _service.UpdateAsync(id,producer);
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
