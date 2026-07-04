using ECommerce.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.DTO
{
    public class AccountLoginResponseDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public string AccessToken { get; set; }
        public string Message { get; set; }
    }
}
