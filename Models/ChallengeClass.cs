using System.ComponentModel.DataAnnotations;

namespace Challenge.Models
{
    public class ChallengeClass
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; } = "Challenge";

        [Required]
        public int DayCount { get; set; } = 7;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<ToDo> ToDos { get; set; }

        [Required]
        public Guid UserId { get; set; } // Foreign key

        public User User { get; set; } // Navigation property
    }
}
