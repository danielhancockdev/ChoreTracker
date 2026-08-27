using ChoreTracker.Models;

namespace ChoreTracker.Interfaces
{
    public interface IChoreService
    {
        string GetChoreStatus(Chore chore);
        void ResetChoreCompletion(List<Chore> chores);
        List<Chore> GetAll();
        bool Complete(int id);

    }
}
