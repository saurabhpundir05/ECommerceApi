using ECommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.BusinessLogic.Interfaces
{
    public interface IAccountService
    {
        Task<bool> CreateUser(AccountSignUpDTO requestData);
    }
}
