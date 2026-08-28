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

        // Handles Http GET request for create service

        [HttpGet]
        public IActionResult Create()
        {
            var createChoreViewModel = new CreateChoreViewModel();

            return View(createChoreViewModel);
        }

        // Handles Http POST request for create service

        [HttpPost]
        public IActionResult Create(CreateChoreViewModel createChoreViewModel)
        {
            _choreService.Create(createChoreViewModel);
            return RedirectToAction("Index");

        }

        // Handles Http GET request for edit service

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var selectedChore = _choreService.GetChoreById(id);

            if (selectedChore == null)
            {
                return NotFound();
            }

            var editChoreViewModel = new EditChoreViewModel();
            {
                editChoreViewModel.Id = selectedChore.Id;
                editChoreViewModel.Name = selectedChore.Name;
                editChoreViewModel.Description = selectedChore.Description;
                editChoreViewModel.DueDate = selectedChore.DueDate;
                editChoreViewModel.RecurrenceDays = selectedChore.RecurrenceDays;
            }
            return View(editChoreViewModel);
        }

        // Handles Http POST request for edit service

        [HttpPost]
        public IActionResult Edit(EditChoreViewModel editChoreViewModel)
        {
            if (editChoreViewModel == null)
            {
                return NotFound();
            }
            _choreService.Edit(editChoreViewModel);
            return RedirectToAction("Index");
        }

        // Handles Http POST request for Delete service

        [HttpPost]
        public IActionResult Delete(int id)
        {

            if (_choreService.Delete(id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }

        }

    }
}
