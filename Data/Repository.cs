using Challenge.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Challenge.Data
{
    public class Repository : DbContext
    {
        public Repository(DbContextOptions<Repository> opts) : base(opts)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ChallengeClass> Challenges { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed Users
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = "Default",
                Image = await GetDefaultImage(),
            };
            var chlng = new ChallengeClass
            {
                Id = Guid.NewGuid(),
                Name = "Streak Visitors",
                DayCount = 7,
                StartDate = DateTime.Now,
                UserId = user.Id
            };
            var todoOne = new ToDo
            {
                Id = Guid.NewGuid(),
                Description = "Task 1",
                ChallengeId = chlng.Id
            };
            var todoTwo = new ToDo
            {
                Id = Guid.NewGuid(),
                Description = "Task 2",
                ChallengeId = chlng.Id
            };
            #endregion

            modelBuilder.Entity<User>().HasData(user);

            // Seed Challenges
            modelBuilder.Entity<ChallengeClass>().HasData(chlng);

            // Seed ToDos
            modelBuilder.Entity<ToDo>().HasData(todoOne, todoTwo);

            base.OnModelCreating(modelBuilder);
        }

        private async Task<byte[]> GetDefaultImage()
        {
            try
            {
                using var httpClient = new HttpClient();
                var stream = await httpClient.GetStreamAsync("IconCodefrydev.png");
                using var ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                return ms.ToArray();  
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed In Reading Default Image {ex.Message}");
                return new byte[0];
            }
        }
    } 
}

