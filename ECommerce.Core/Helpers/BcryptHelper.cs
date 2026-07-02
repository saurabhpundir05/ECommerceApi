using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Helpers
{
    public class BcryptHelper
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, 10);
        }
        public static bool VerifyPassword(string password, string? hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
