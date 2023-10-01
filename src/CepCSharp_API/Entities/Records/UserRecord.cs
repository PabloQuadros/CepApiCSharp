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
        [RegularExpression("^(Male|Female)$", ErrorMessage = "Sex must be 'Male' or 'Female'.")]
        public string? Sex { get; set; }
        [Required]
        [RegularExpression("^(Admin|Normal)$", ErrorMessage = "Role must be 'Admin' or 'Normal'.")]
        public string? Role { get; set; }
    }
}
