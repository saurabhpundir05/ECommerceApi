using ECommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.BusinessLogic.Interfaces
{
    public interface IAccountService
    {
        Task<bool> Create(AccountSignUpDTO signUpData);
        Task<AccountLoginResponseDTO?> Login(AccountLoginDTO loginData);
        Task <bool> Update(AccountUpdateDTO updateData);
        Task<bool> Delete(AccountLoginDTO deleteData);
    }
}
