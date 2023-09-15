using CinemaTickets.Data;
using CinemaTickets.Data.Services;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTickets.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService _service;
        public ActorController(IActorService service)
        {
            _service = service;
        }
		[AllowAnonymous]
		public async Task<IActionResult> Index()
        {
            var AllActors = await _service.GetAllAsync();
            return View(AllActors);
        }
        public IActionResult Create()
        {
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")] Actor actor)
		{
			if (!ModelState.IsValid)
			{
				return View(actor);
			}
			await _service.AddAsync(actor);
			return RedirectToAction(nameof(Index));
		}
		[AllowAnonymous]
		public async Task<IActionResult> Details(int id)
		{
            var actorDetails = await _service.GetByIdAsync(id);
            if(actorDetails == null)
                return View("Not Found");
			return View(actorDetails);
		}

        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
			if(actorDetails == null)
				return View("Not Found");
            return View(actorDetails);
		}
        [HttpPost]
		public async Task<IActionResult> Edit(int id, Actor actor)
		{
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id,actor);
			return RedirectToAction(nameof(Index));
		}
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Exception", ex.InnerException.Message);
                return View(nameof(Details));
            }
        }
	}
}
