using System.ComponentModel.DataAnnotations;

namespace CepCSharp_API.Entities.Records
{
    public class CepRecord
    {
        [Required]
        public string? Cep { get; set; }
    }
}
