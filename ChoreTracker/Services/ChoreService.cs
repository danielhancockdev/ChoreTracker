using ChoreTracker.Interfaces;
using ChoreTracker.Models;
namespace ChoreTracker.Services
{
    public class ChoreService : IChoreService
    {
       
        // creating mock chores for testing

        private List<Chore> chores = new List<Chore>
        {
            new Chore
            {
                Id = 1,
                Name = "Check Bathroom",
                Description = "Check the Bathroom is Clean",
                DueDate = DateTime.Today,
                IsCompleted = false,
                CompletedDate = null,
                RecurrenceDays = 1,
            },
            new Chore
            {
                Id = 2,
                Name = "Check Kitchen",
                Description = "Check the Kitchen is Clean",
                DueDate = DateTime.Today,
                IsCompleted = false,
                CompletedDate = null,
                RecurrenceDays = 1,
            }
        };

        // checks if a chore is either complete/notdue/late/due today and gets the appropriate status text

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

        // checks if a completed chores next due date has arrived

        public void ResetChoreCompletion(List<Chore> chores)
        {
            foreach(var chore in chores)
            {
                if(chore.IsCompleted && chore.DueDate <= DateTime.Today)
                {
                    chore.IsCompleted = false;
                    chore.CompletedDate = null;
                }

            }
        }

        //Returns list of all chores for Index

        public List<Chore> GetAll()
        {
            return chores;
        }

        // Logic for complete button press

        public bool Complete(int id)
        {
            var chore = chores.FirstOrDefault(c => c.Id == id);
            if (chore == null)
            {
                return false;
            }

            chore.IsCompleted = true;
            chore.CompletedDate = DateTime.Today;
            chore.DueDate = chore.DueDate.AddDays(chore.RecurrenceDays);
            return true;
        }
    }
}

