using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppDomain.Model
{
    public class User
    {
        public User()
        {

        }
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email address is required")
                     .EmailAddress().WithMessage("A valid email is required");

            RuleFor(x => x.DateOfBirth).Must(dob => AgeValidator(dob)).WithMessage("Age must be 18 years old");
            RuleFor(x => x.UserName).MinimumLength(5)
                .WithMessage("Minimum Length must be 5 character")
                .Must(userName => SpaceValidator(userName)).WithMessage("User name cant have space");

        }
        public bool AgeValidator(DateTime dob)
        {
            int age = DateTime.Now.Year - dob.Year;
            return age >= 18 ? true : false;
        }
        public bool SpaceValidator(string userName)
        {
            return userName.Contains(" ") ? false : true;
        }
    }
}
