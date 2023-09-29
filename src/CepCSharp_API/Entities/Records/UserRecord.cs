using CepCSharp_API.Entities.Enums;

namespace CepCSharp_API.Entities.Records
{
    public class UserRecord
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? BirthDay { get; set; }
        public UserSex? Sex { get; set; }
        public UserRole? Role { get; set; }
    }
}
