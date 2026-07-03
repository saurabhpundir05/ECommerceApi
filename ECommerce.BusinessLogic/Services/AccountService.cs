#region imports
using ECommerce.BusinessLogic.Interfaces;
using ECommerce.Core.DTO;
using ECommerce.Core.Enums;
using ECommerce.Core.Helpers;
using ECommerce.DataAccess.Entities;
using ECommerce.DataAccess.Interfaces;
#endregion

#region Account Service
namespace ECommerce.BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly IEntityRepository<User> _userRepo;
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IEntityRepository<User> userRepo, IUnitOfWork unitOfWork)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Create an account
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public async Task<bool> CreateUser(AccountSignUpDTO requestData)
        {
            var isEmailExist = _userRepo.Select(x => x.Email == requestData.Email).Any();
            if (isEmailExist)
                return false;

            var user = new User
            {
                Name = requestData.Name,
                Email = requestData.Email,
                Password = BcryptHelper.HashPassword(requestData.Password),
                Role = requestData.Role,
                CreatedAt = DateTime.UtcNow,
                Status = UserStatus.Active,
            };
            _userRepo.Insert(user);
            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }

    }
}
#endregion