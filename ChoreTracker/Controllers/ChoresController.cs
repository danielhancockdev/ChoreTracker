using Microsoft.AspNetCore.Mvc;
using ChoreTracker.Models;
using ChoreTracker.Services;
using ChoreTracker.ViewModels;
using ChoreTracker.Interfaces;

namespace ChoreTracker.Controllers
{
    public class ChoresController : Controller
    {
        // Store ChoreService provided by ASP.NET DI

        private readonly IChoreService _choreService;

        public ChoresController(IChoreService choreService)
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
        [HttpGet]
        public IActionResult Create()
        {
            var createChoreViewModel = new CreateChoreViewModel();

            return View(createChoreViewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateChoreViewModel createChoreViewModel)
        {
            _choreService.Create(createChoreViewModel);
            return RedirectToAction("Index");
            
        }
    }
}
