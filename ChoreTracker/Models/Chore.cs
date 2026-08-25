namespace ChoreTracker.Models
{
    public class Chore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int RecurrenceDays { get; set; }
    }
}
