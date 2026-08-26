namespace ChoreTracker.ViewModels
{
    public class CreateChoreViewModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int RecurrenceDays { get; set; }
        public DateTime DueDate { get; set; }       
    }
}
