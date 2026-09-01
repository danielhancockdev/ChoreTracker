using ChoreTracker.Data;
using ChoreTracker.Interfaces;
using ChoreTracker.Models;
using ChoreTracker.ViewModels;
namespace ChoreTracker.Services
{
    public class ChoreService : IChoreService
    {
        private readonly ChoreDbContext _context;


        public ChoreService(ChoreDbContext context)
        {
            _context = context;
        }

        // Checks if a chore is either complete/notdue/late/due today and gets the appropriate status text

        public string GetChoreStatus(Chore chore)
        {
            if (chore.IsCompleted)
            {
                return "Completed";
            }
            else if (chore.DueDate > DateTime.Today)
            {
                return "Not Due";
            }
            else if (chore.DueDate < DateTime.Today)
            {
                return "Late";

            }

            return "Due Today";

        }

        // Checks if a completed chores next due date has arrived

        public void ResetChoreCompletion(List<Chore> chores)
        {
            foreach (var chore in chores)
            {
                if (chore.IsCompleted && chore.DueDate <= DateTime.Today)
                {
                    chore.IsCompleted = false;
                    chore.CompletedDate = null;
                }
            }
            _context.SaveChanges();
        }

        // Returns list of all chores for Index

        public List<Chore> GetAll()
        {
            return _context.Chores.ToList();
        }

        public Chore GetChoreById(int id)
        {
            var chore = _context.Chores.FirstOrDefault(c => c.Id == id);
            if (chore == null)
            {
                return null;
            }

            return chore;
        }

        // Logic for complete button press

        public bool Complete(int id)
        {
            var chore = _context.Chores.FirstOrDefault(c => c.Id == id);
            if (chore == null)
            {
                return false;
            }
            chore.IsCompleted = true;
            chore.CompletedDate = DateTime.Today;
            chore.DueDate = chore.DueDate.AddDays(chore.RecurrenceDays);
            _context.SaveChanges();
            return true;
        }

        public void Create(CreateChoreViewModel createChoreViewModel)
        {
            var chore = new Chore();

            chore.Name = createChoreViewModel.Name;
            chore.Description = createChoreViewModel.Description;
            chore.DueDate = createChoreViewModel.DueDate;
            chore.RecurrenceDays = createChoreViewModel.RecurrenceDays;
            chore.IsCompleted = false;
            chore.CompletedDate = null;

            _context.Chores.Add(chore);
            _context.SaveChanges();

        }

        public void Edit(EditChoreViewModel editChoreViewModel)
        {
            var chore = _context.Chores.FirstOrDefault(c => c.Id == editChoreViewModel.Id);

            if (chore == null)
            {
                return;
            }

            chore.Name = editChoreViewModel.Name;
            chore.Description = editChoreViewModel.Description;
            chore.DueDate = editChoreViewModel.DueDate;
            chore.RecurrenceDays = editChoreViewModel.RecurrenceDays;
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var chore = _context.Chores.FirstOrDefault(chore => chore.Id == id);
            if (chore == null)
            {
                return false;
            }
            _context.Chores.Remove(chore);
            _context.SaveChanges();
            return true;
        }
    }
}

