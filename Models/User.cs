using System.ComponentModel.DataAnnotations;

namespace Challenge.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string UserName { get; set; } = "Codefrydev";

        public string UserDescription { get; set; } = "www.codefrydev.in";
        public byte[] Image { get; set; } = new byte[0]; 
        public List<ChallengeClass> Challenges { get; set; }
    }
}
