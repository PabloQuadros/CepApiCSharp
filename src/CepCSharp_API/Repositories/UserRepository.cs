using CepCSharp_API.Entities.DomainEntities;

namespace CepCSharp_API.Repositories
{
    public class UserRepository
    {
        public bool CreateUser(User user)
        {
            if (user == null) return false;
            return true;
        }
    }
}
