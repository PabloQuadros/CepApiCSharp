using CepCSharp_API.DataBase;
using CepCSharp_API.Entities.DomainEntities;
using Microsoft.EntityFrameworkCore;

namespace CepCSharp_API.Repositories
{
    public class UserRepository
    {
        public readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<Guid?> CreateUser(User user)
        {
            var dbResponse = _context.Add(user);
            await _context.SaveChangesAsync();
            return dbResponse.Entity.Id;
        }

        public async Task UpdateUser(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserById(Guid id)
        {
            var user =await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
