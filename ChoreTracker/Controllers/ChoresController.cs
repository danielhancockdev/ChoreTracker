using Microsoft.AspNetCore.Mvc;
using ChoreTracker.Models;
using ChoreTracker.Services;
using ChoreTracker.ViewModels;

namespace ChoreTracker.Controllers
{
    public class ChoresController : Controller
    {
        // Store ChoreService provided by ASP.NET DI

        private readonly ChoreService _choreService;

        public ChoresController(ChoreService choreService)
        {
            _choreService = choreService;
        }

        // Handles Http request for index service

        public IActionResult Index()
        {
            var chores = _choreService.GetAll();

            var viewModels = chores.Select(chore => new ChoreViewModel
            {
                Chore = chore,
                Status = _choreService.GetChoreStatus(chore)

            }).ToList();

            return View(viewModels);
        }

        // Handles Http Request for complete service

        [HttpPost]
        public IActionResult Complete(int id)
        {
            var completed = _choreService.Complete(id);
            if (!completed)
            {
                return NotFound();
            }

            return RedirectToAction("Index");

        }
    }
}
