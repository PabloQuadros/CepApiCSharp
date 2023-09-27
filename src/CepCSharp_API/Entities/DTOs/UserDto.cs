using CepCSharp_API.Entities.Enums;

namespace CepCSharp_API.Entities.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public DateOnly BirthDay { get; set; }
        public UserSex Sex { get; set; }
        public UserRole Role { get; set; }
    }
}
