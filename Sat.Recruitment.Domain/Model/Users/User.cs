using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Sat.Recruitment.Api.Domain.Validators;

namespace Sat.Recruitment.Api.Domain.Model
{
    public abstract class User : IUser
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The name is required")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage= "The email is not valid")]
        //[EmailValidator(ErrorMessage = "The email is not valid")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The address is required")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The phone is required")]
        public string Phone { get; set; }

        public virtual string UserType { get; }

        public virtual decimal Money { get; set; }
    }
}
