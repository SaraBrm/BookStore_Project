using _0_Framework.Application;
using AcountManagement.Application.Contracts.Role;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcountManagement.Application.Contracts.Account
{
    public class RegisterAccount
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Fullname { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Username { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Password { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Mobile { get; set; }

        public long RoleId { get; set; }
        
        public List<RoleViewModel> Roles { get; set; }
    }
}
