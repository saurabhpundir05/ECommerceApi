using ECommerce.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ECommerce.BusinessLogic.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetUserId()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var nameId = user?.FindFirst("nameid")?.Value ?? user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!int.TryParse(nameId, out int userId))
                throw new UnauthorizedAccessException("Invalid nameid in token");

            return userId;
        }
    }
}
