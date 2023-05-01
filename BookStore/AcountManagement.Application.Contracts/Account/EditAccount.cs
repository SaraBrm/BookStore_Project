using _0_Framework.Application;
using AcountManagement.Application.Contracts.Role;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcountManagement.Application.Contracts.Account

{
    public class EditAccount 
    {
        public long Id { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Fullname { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Username { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Mobile { get; set; }

        public long RoleId { get; set; }


    }
}
