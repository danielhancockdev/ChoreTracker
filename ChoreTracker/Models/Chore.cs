using System.ComponentModel.DataAnnotations.Schema;

namespace ChoreTracker.Models
{
    public class Chore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "date")]
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CompletedDate { get; set; }
        public int RecurrenceDays { get; set; }
    }
}
