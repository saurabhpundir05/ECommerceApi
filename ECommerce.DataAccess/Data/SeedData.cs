#region imports
using ECommerce.Core.Enums;
using ECommerce.Core.Helpers;
using ECommerce.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
#endregion

#region Seeding
namespace ECommerce.DataAccess.Data
{
    public class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            #region User Seeding
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Doraemon",
                    Password = BcryptHelper.HashPassword("Doraemon$456"),
                    Email = "doraemon@doraemon.com",
                    Role = UserRole.Admin,
                    CreatedAt = DateTime.UtcNow,
                    Status = UserStatus.Active
                },
                new User
                {
                    Id = 2,
                    Name = "Nobita",
                    Password = BcryptHelper.HashPassword("Doraemon$456"),
                    Email = "nobita@doraemon.com",
                    Role = UserRole.User,
                    CreatedAt = DateTime.UtcNow,
                    Status = UserStatus.Active
                },
                new User
                {
                    Id = 3,
                    Name = "Shizuka",
                    Password = BcryptHelper.HashPassword("Doraemon$456"),
                    Email = "shizuka@doraemon.com",
                    Role = UserRole.Seller,
                    CreatedAt = DateTime.UtcNow,
                    Status = UserStatus.Active
                },
                new User
                {
                    Id = 4,
                    Name = "Naruto",
                    Password = BcryptHelper.HashPassword("Doraemon$456"),
                    Email = "naruto@naruto.com",
                    Role = UserRole.User,
                    CreatedAt = DateTime.UtcNow,
                    Status = UserStatus.Active
                });
            #endregion
        }
    }
}
#endregion