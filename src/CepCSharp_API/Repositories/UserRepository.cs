using CepCSharp_API.Entities.DomainEntities;

namespace CepCSharp_API.Repositories
{
    public class UserRepository
    {
        public async Task<Guid?> CreateUser(User user)
        {
            if (user == null) return null;
            return user.Id;
        }

        public async Task UpdateUser(User user)
        {
            if (user == null);
        }
        public async Task DeleteUser(Guid id)
        {
            if (id == null) ;
        }

        public async Task<User?> GetUserById(Guid id)
        {
            if (id == null) return null;
            return new User();
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            if (email == null) return null;
            return new User();
        }

        public async Task<ICollection<User>?> GetAllUsers()
        {
            return new List<User>();
        }
    }
}
