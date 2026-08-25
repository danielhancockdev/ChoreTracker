using ChoreTracker.Models;
namespace ChoreTracker.Services
{
    public class ChoreService
    {
        private List<Chore> chores = new List<Chore>
        {
            new Chore
            {
                Id = 1,
                Name = "Check Bathroom",
                Description = "Check the Bathroom is Clean",
                DueDate = DateTime.Today,
                IsCompleted = true,
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

        public List<Chore> GetAll()
        {
            return chores;
        }
    }
}

