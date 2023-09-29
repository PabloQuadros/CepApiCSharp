using CepCSharp_API.Entities.DomainEntities;
using CepCSharp_API.Entities.Records;
using CepCSharp_API.Repositories;

namespace CepCSharp_API.Servicies
{
    public class UserService
    {
        public readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid?> CreateUser(UserRecord userRecord)
        {
            try
            {
                User newUser = new User(new Guid(), userRecord.Name, userRecord.Email, userRecord.Password, userRecord.BirthDay, userRecord.Sex, userRecord.Role, DateTime.Now, null);
                return await _userRepository.CreateUser(newUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
