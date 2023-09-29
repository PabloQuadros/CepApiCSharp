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
    }
}
