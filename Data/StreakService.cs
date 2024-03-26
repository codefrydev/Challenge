using Challenge.Models;
using Microsoft.EntityFrameworkCore;
using SqliteWasmHelper;

namespace Challenge.Data
{

    public class StreakService
    {
        public User CurrentUser { get; set; }
        public ChallengeClass CureentChallenge { get; set; }


        private readonly ISqliteWasmDbContextFactory<Repository> ctx;

        public StreakService(ISqliteWasmDbContextFactory<Repository> ctx)
        {
            this.ctx = ctx;
        }


        #region User Context
        // Add new user
        public async Task<User?> AddNewUserAsync(User user)
        {
            using var repository = await ctx.CreateDbContextAsync();
            if (user != null)
            {
                await repository.Users.AddAsync(user);
                await repository.SaveChangesAsync();
            }
            return user;
        }
        // Get all users 
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            using var repository = await ctx.CreateDbContextAsync();
            if (repository.Users.Any())
            {
                return await repository.Users.ToListAsync();
            }
            return new List<User>();
        }

        // Get User With Id

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            using var repository = await ctx.CreateDbContextAsync();
            return await repository.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        // delete User With Id

        public async Task<bool> DeleteUserByIdAsync(Guid id)
        {
            using var repository = await ctx.CreateDbContextAsync();
            var res = await GetUserByIdAsync(id);
            repository.Users.Remove(res);
            var ress = await repository.SaveChangesAsync();
            return ress > 0;
        }

        // update User With Id

        public async Task<bool> UpdateUserAsync(User user)
        {
            using var repository = await ctx.CreateDbContextAsync();
            repository.Users.Update(user);
            var res = await repository.SaveChangesAsync();
            return res > 0;
        }
        #endregion

        // Add new Challenge

        public async Task<ChallengeClass> AddChallengeAsync(ChallengeClass challenge)
        {
            using var repository = await ctx.CreateDbContextAsync();
            var respose = await repository.Challenges.AddAsync(challenge);
            await repository.SaveChangesAsync();
            return respose.Entity;
        }
        // Get all Challenge 

        public async Task<IEnumerable<ChallengeClass>> GetChallengesAsync(User user)
        {
            using var repository = await ctx.CreateDbContextAsync();
            return await repository.Challenges.Where(x => x.UserId == user.Id).ToListAsync();
        }


        // delete Challenge by Id
        public async Task<bool> DeleteChallengesByIdAsync(Guid guid)
        {
            using var repository = await ctx.CreateDbContextAsync();
            var res = await repository.Challenges.FirstAsync(x => x.Id == guid);
            repository.Challenges.Remove(res);
            var ress = await repository.SaveChangesAsync();
            return ress > 0;
        }
        // update Challenge by Id

        public async Task<bool> UpdateChallengesByIdAsync(ChallengeClass challenge)
        {
            using var repository = await ctx.CreateDbContextAsync();
            repository.Challenges.Update(challenge);
            var ress = await repository.SaveChangesAsync();
            return ress > 0;
        }

        // Add new ToDos

        public async Task<ToDo> AddTodoAsync(ToDo todo)
        {
            using var repository = await ctx.CreateDbContextAsync();
            await repository.ToDos.AddAsync(todo);
            await repository.SaveChangesAsync();
            return todo;
        }
        // Get ToDos ByChallenge Id
        public async Task<IEnumerable<ToDo>> GetToDosAsync(ChallengeClass challenge)
        {
            using var repository = await ctx.CreateDbContextAsync();
            return await repository.ToDos.Where(x => x.ChallengeId == challenge.Id).ToListAsync();
        }
        // update ToDos ById Id

        public async Task<bool> UpdateTodoAsync(ToDo todo)
        {
            using var repository = await ctx.CreateDbContextAsync();
            repository.ToDos.Update(todo);
            var ress = await repository.SaveChangesAsync();
            return ress > 0;
        }

    }

}

