namespace CepCSharp_API.Entities.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public DateTime BirthDay { get; set; }
        public string Sex { get; set; }
        public string Role { get; set; }
    }
}
