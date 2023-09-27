using System.ComponentModel;

namespace CepCSharp_API.Entities.Enums
{
    public enum UserRole
    {
        [Description("Admin")]
        Admin = 0,
        [Description("Normal")]
        Normal = 1,
    }
}
