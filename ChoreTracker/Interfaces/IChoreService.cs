using ChoreTracker.Models;
using ChoreTracker.ViewModels;

namespace ChoreTracker.Interfaces
{
    public interface IChoreService
    {
        string GetChoreStatus(Chore chore);
        void ResetChoreCompletion(List<Chore> chores);
        List<Chore> GetAll();
        bool Complete(int id);
        Chore Create(CreateChoreViewModel createChoreViewModel);
    }
}
