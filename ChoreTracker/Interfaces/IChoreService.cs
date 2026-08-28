using ChoreTracker.Models;
using ChoreTracker.ViewModels;

namespace ChoreTracker.Interfaces
{
    public interface IChoreService
    {
        string GetChoreStatus(Chore chore);
        void ResetChoreCompletion(List<Chore> chores);
        List<Chore> GetAll();
        Chore GetChoreById(int id);
        bool Complete(int id);
        void Create(CreateChoreViewModel createChoreViewModel);
        bool Delete(int id);
        void Edit(EditChoreViewModel editChoreViewModel); 
    }
}
