using CepCSharp_API.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CepCSharp_API.Entities.DomainEntities
{
    public class User
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        [UserNameValidation]
        public string Name { get; set; } = String.Empty;
        [UserEmailValidation]
        public string Email { get; set; } = String.Empty;
        [UserPasswordValidation]
        public string Password { get; set; } = String.Empty;
        public DateOnly BirthDay { get; set; }
        [UserSexValidation]
        public UserSex Sex { get; set; }
        [UserRoleValidation]
        public UserRole Role { get; set; }

    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class UserNameValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }

            var name = value.ToString();

            if (!Regex.IsMatch(name, @"^[a-zA-Z ]{3,50}$"))
            {
                return false;
            }

            return true;
        }

        public override string FormatErrorMessage(string field)
        {
            return $"The field {field} cannot be null and must contain a maximum of 50 characters, including: letters and spaces.";
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class UserRoleValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }

            var role = value.ToString();

            if (role != UserRole.Normal.ToString() && role != UserRole.Admin.ToString())
            {
                return false;
            }
            return true;
        }
        public override string FormatErrorMessage(string field)
        {
            return $"The field {field} is invalid.";
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class UserSexValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }

            var role = value.ToString();

            if (role != UserSex.F.ToString() && role != UserSex.M.ToString())
            {
                return false;
            }
            return true;
        }
        public override string FormatErrorMessage(string field)
        {
            return $"The field {field} is invalid.";
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class UserEmailValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }

            var email = value.ToString();

            if (!Regex.IsMatch(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
            {
                return false;
            }
            return true;
        }
        public override string FormatErrorMessage(string field)
        {
            return $"The field {field} is invalid.";
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class UserPasswordValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }

            var password = value.ToString();

            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
            {
                return false;
            }
            return true;
        }
        public override string FormatErrorMessage(string field)
        {
            return $"The password must contain at least 8 characters, including at least one uppercase letter, one lowercase letter, one number and one special character (@, $, !, %, *, ?, &).";
        }
    }

}
