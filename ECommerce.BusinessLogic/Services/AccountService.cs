#region imports
using ECommerce.BusinessLogic.Interfaces;
using ECommerce.Core.Constants;
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
        private readonly JwtTokenHelper _jwtHelper;
        private readonly ICurrentUserService _currentUserService;
        public AccountService(IEntityRepository<User> userRepo,
            IUnitOfWork unitOfWork, JwtTokenHelper jwtTokenHelper, ICurrentUserService currentUserService)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
            _jwtHelper = jwtTokenHelper;
            _currentUserService = currentUserService;
        }

        private async Task<User?> GetActiveUserByEmailAsync(string email)
        {
            return await _userRepo.FirstOrDefaultAsync(x => x.Email == email && x.DeletedAt == null);
        }

        /// <summary>
        /// Create an account
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public async Task<bool> Create(AccountSignUpDTO requestData)
        {
            var isEmailExist = await GetActiveUserByEmailAsync(requestData.Email);

            if (isEmailExist != null)
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

        /// <summary>
        /// User login
        /// </summary>
        /// <param name="loginData"></param>
        /// <returns></returns>
        public async Task<AccountLoginResponseDTO?> Login(AccountLoginDTO loginData)
        {
            var user = await GetActiveUserByEmailAsync(loginData.Email);
            if (user is null || user.Status == UserStatus.Inactive || !BcryptHelper.VerifyPassword(loginData.Password, user.Password))
                return null;

            return new AccountLoginResponseDTO
            {
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                AccessToken = _jwtHelper.GenerateToken(user.Id, user.Name, (int)user.Role),
                Message = AppMessages.Account.Login,
            };
        }

        /// <summary>
        /// Update user details.
        /// </summary>
        /// <param name="updateData"></param>
        /// <returns></returns>
        public async Task<bool> Update(AccountUpdateDTO updateData)
        {
            var user = await GetActiveUserByEmailAsync(updateData.Email);
            if (user is null || user.Status == UserStatus.Inactive)
                return false;

            if (user.Id != _currentUserService.GetUserId())
                return false;

            if (!BcryptHelper.VerifyPassword(updateData.Password, user.Password))
                return false;

            var now = DateTime.UtcNow;
            var updated = false;

            if (!string.IsNullOrEmpty(updateData.Name))
            {
                user.Name = updateData.Name;
                updated = true;
            }

            if (updateData.Status.HasValue)
            {
                user.Status = (UserStatus)updateData.Status;
                updated = true;
            }
            if (!string.IsNullOrEmpty(updateData.NewEmail))
            {
                var existingUser = await GetActiveUserByEmailAsync(updateData.NewEmail);
                if (existingUser != null)
                    return false;

                user.Email = updateData.NewEmail;
                updated = true;
            }

            if (!updated)
                return true;

            user.UpdatedAt = now;

            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }

        /// <summary>
        /// soft delete an account
        /// </summary>
        /// <param name="deleteData"></param>
        /// <returns></returns>
        public async Task<bool> Delete(AccountLoginDTO deleteData)
        {
            var user = await GetActiveUserByEmailAsync(deleteData.Email);
            if (user is null || user.Status == UserStatus.Inactive)
                return false;

            if (user.Id != _currentUserService.GetUserId())
                return false;

            if (!BcryptHelper.VerifyPassword(deleteData.Password, user.Password))
                return false;

            user.DeletedAt = DateTime.UtcNow;
            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }
    }
}
#endregion