namespace ChoreTracker.ViewModels
{
    public class EditChoreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int RecurrenceDays { get; set; }
        public DateTime DueDate { get; set; }       
    }
}
