using ECommerce.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerce.Core.DTO
{
    public class AccountUpdateDTO
    {
        [MinLength(1, ErrorMessage = "Name cannot be empty.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string? Name { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
        ErrorMessage = "Password must contain uppercase, lowercase, number, special character and be at least 8 characters long.")]
        public required string Password { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
        ErrorMessage = "Password must contain uppercase, lowercase, number, special character and be at least 8 characters long.")]
        public string? NewPassword { get; set; }

        [EnumDataType(typeof(UserStatus))]
        public UserStatus? Status { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(255, ErrorMessage = "Email cannot exceed 100 characters.")]
        public required string Email { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(255, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string? NewEmail { get; set; }
    }
}
