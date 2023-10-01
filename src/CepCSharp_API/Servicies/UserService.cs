using AutoMapper;
using CepCSharp_API.Authentication;
using CepCSharp_API.Entities.DomainEntities;
using CepCSharp_API.Entities.DTOs;
using CepCSharp_API.Entities.Records;
using CepCSharp_API.Repositories;

namespace CepCSharp_API.Servicies
{
    public class UserService
    {
        public readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Guid?> CreateUser(UserRecord userRecord)
        {
            try
            {
                User? exist = await _userRepository.GetUserByEmail(userRecord.Email);
                if (exist != null)
                {
                    throw new Exception("The informed e-mail is already in use.");
                }
                User newUser = new User(
                    new Guid(), 
                    userRecord.Name, 
                    userRecord.Email, 
                    userRecord.Password,
                    userRecord.BirthDay,
                    userRecord.Sex,
                    userRecord.Role,
                    DateTime.UtcNow,
                    null);
                return await _userRepository.CreateUser(newUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        public async Task UpdateUser(UserRecord userRecord, Guid id)
        {
            try
            {
                User? exist = await _userRepository.GetUserById(id);
                if (exist == null)
                {
                    throw new Exception("The informed user not exist.");
                }
                User? existEmail = await _userRepository.GetUserByEmail(userRecord.Email);
                if (existEmail != null && existEmail.Id != id)
                {
                    throw new Exception("The informed e-mail is already in use.");
                }
                User updateUser = new User(
                    id,
                    userRecord.Name,
                    userRecord.Email,
                    userRecord.Password,
                    userRecord.BirthDay,
                    userRecord.Sex,
                    userRecord.Role,
                    exist.CreatedDate,
                    DateTime.UtcNow);
                exist.Name = updateUser.Name;
                exist.Email = updateUser.Email;
                exist.Password = updateUser.Password;
                exist.BirthDay = updateUser.BirthDay;
                exist.Sex = updateUser.Sex;
                exist.Role = updateUser.Role;
                exist.LastUpdatedDate = DateTime.UtcNow;
                await _userRepository.UpdateUser(exist);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteUser(Guid id)
        {
            try
            {
                User? exist = await _userRepository.GetUserById(id);
                if (exist == null)
                {
                    throw new Exception("The informed user not exist.");
                }
                await _userRepository.DeleteUser(exist);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserDto> GetUserById(Guid id)
        {
            try
            {
                User? exist = await _userRepository.GetUserById(id);
                if (exist == null)
                {
                    throw new Exception("The informed user not exist.");
                }
                return _mapper.Map<UserDto>(exist);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            try
            {
                IEnumerable<User> users = await _userRepository.GetAllUsers();
                IEnumerable<UserDto> usersDto = users.Select(u => _mapper.Map<UserDto>(u));
                return usersDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Object> Login(UserLoginRecord loginUser)
        {
            try
            {
                User? user = await _userRepository.GetUserByEmail(loginUser.Email);
                if (user == null)
                {
                    throw new Exception("E-mail inválido.");
                }
                if ((PasswordHashing.VerifyPassword(user.Password, loginUser.Password)) == false)
                {
                    throw new Exception("Senha inválida.");
                }
                var token = TokenService.GenerateToken(user);
                var userToken = new UserTokenDto
                {
                    UserId = user.Id,
                    Token = token
                };
                return userToken;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
