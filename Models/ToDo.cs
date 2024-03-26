using System.ComponentModel.DataAnnotations;

namespace Challenge.Models
{
    public class ToDo
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public bool IsCompleted { get; set; } = false;

        public int DayNumber { get; set; } = 0;

        [Required]
        public string Description { get; set; } = "Exercise";

        public DateTime CompletionDate { get; set; } = DateTime.Now.AddDays(360);
        public Guid ChallengeId { get; set; } // Foreign key

        public ChallengeClass Challenge { get; set; } // Navigation property
    }
}
