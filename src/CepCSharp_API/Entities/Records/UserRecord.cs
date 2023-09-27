using CepCSharp_API.Entities.Enums;

namespace CepCSharp_API.Entities.Records
{
    public record UserRecord
    {
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public DateOnly BirthDay { get; set; }
        public UserSex Sex { get; set; }
        public UserRole Role { get; set; }
    }
}
