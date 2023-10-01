
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using System;

namespace CepCSharp_API.Entities.DomainEntities
{
    public class User
    {
        public User() { }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? Sex { get; set; }
        public string? Role { get; set; }

        public User(Guid id, string? name, string? email, string? password, DateTime? birthDay, string? sex, string? role, DateTime createdDate, DateTime? lastUpdatedDate)
        {
            var validationErrors = new List<string>();

            Id = id;
            CreatedDate = createdDate;
            LastUpdatedDate = lastUpdatedDate;
            Name = UserNameValidation(name, validationErrors);
            Email = UserEmailValidation(email, validationErrors);
            Password = UserPasswordValidation(password, validationErrors);
            BirthDay = birthDay;
            Sex = UserSexValidation(sex, validationErrors);
            Role = UserRoleValidation(role, validationErrors);

            if (validationErrors.Count > 0)
            {
                throw new Exception(string.Join(Environment.NewLine, validationErrors));
            }
        }

        public string UserNameValidation(string name, List<string> validationErrors)
        {
            string errorMessage = $"The field name cannot be null and must contain a minimum of 3 and a maximum of 50 characters, including: letters and spaces.";
            if (name == null)
            {
                validationErrors.Add(errorMessage);
            }

            if (!Regex.IsMatch(name, @"^[a-zA-Z ]{3,50}$"))
            {
                validationErrors.Add(errorMessage);
            }

            return name;
        }

        public string UserEmailValidation(string email, List<string> validationErrors)
        {
            var errorMessage = $"The field e-mail is invalid.";
            if (email == null)
            {
                validationErrors.Add(errorMessage);
            }

            if (!Regex.IsMatch(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
            {
                validationErrors.Add(errorMessage);
            }
            return email;
        }

        public string? UserRoleValidation(string? role, List<string> validationErrors)
        {
            var errorMessage = $"The field role is invalid, role must be 'Normal' or 'Admin'.";
            if (role == null)
            {
                validationErrors.Add(errorMessage);
            };

            if (role != "Normal" && role != "Admin")
            {
                validationErrors.Add(errorMessage);
            }
            return role;
        }

        public string? UserSexValidation(string? sex, List<string> validationErrors)
        {
            var errorMessage = $"The field sex is invalid, sex must be 'Male' or 'Female'.";
            if (sex == null)
            {
                validationErrors.Add(errorMessage);
            }

            if (sex != "Female" && sex != "Male")
            {
                validationErrors.Add(errorMessage);
            }
            return sex;
        }

        public string UserPasswordValidation(string password, List<string> validationErrors)
        {
            var errorMessage = $"The password must contain at least 8 characters, including at least one uppercase letter, one lowercase letter, one number and one special character (@, $, !, %, *, ?, &).";
            if (password == null)
            {
                validationErrors.Add(errorMessage);
            }

            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
            {
                validationErrors.Add(errorMessage);
            }
            return password;
        }
    }
}
