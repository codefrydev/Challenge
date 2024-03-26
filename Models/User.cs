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
        public byte[] Image { get; set; } = DefaultImage();
        private static byte[] DefaultImage()
        {
            // Provide logic to load a default image from a file or resource
            // For example:
            // return File.ReadAllBytes("default_image.png");
            return new byte[0]; // Placeholder default image
        }
        public List<ChallengeClass> Challenges { get; set; }
    }
}
