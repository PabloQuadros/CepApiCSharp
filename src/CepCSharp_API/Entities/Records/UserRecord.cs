using CepCSharp_API.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CepCSharp_API.Entities.Records
{
    public class UserRecord
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public DateTime? BirthDay { get; set; }
        public UserSex? Sex { get; set; }
        [Required]
        public UserRole? Role { get; set; }
    }
}
