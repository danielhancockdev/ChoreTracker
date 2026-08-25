using Microsoft.AspNetCore.Mvc;
using ChoreTracker.Models;
using ChoreTracker.Services;

namespace ChoreTracker.Controllers
{
    public class ChoresController : Controller
    {
        private readonly ChoreService _choreService;

        public ChoresController(ChoreService choreService)
        {
            _choreService = choreService;
        }

        public IActionResult Index()
        {
            var chores = _choreService.GetAll();

            return View(chores);
        }

        [HttpPost]
        public IActionResult Complete(int id)
        {
            return Content($"You Completed chore {id}!");
        }

        
    }
}
