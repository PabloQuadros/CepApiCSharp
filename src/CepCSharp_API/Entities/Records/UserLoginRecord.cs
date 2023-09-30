using System.ComponentModel.DataAnnotations;

namespace CepCSharp_API.Entities.Records
{
    public class UserLoginRecord
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
