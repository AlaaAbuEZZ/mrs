using Application.Services.CurrentUserService;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Infastructer.CurrentUserService
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;

        public Guid? UserId
        {
            get
            {
                var claim = User?.FindFirst(ClaimTypes.NameIdentifier);
                return claim != null ? Guid.Parse(claim.Value) : null;
            }
        }

        public string? Name => User?.FindFirst(ClaimTypes.Name)?.Value;

        public string? Email => User?.FindFirst(ClaimTypes.Email)?.Value;

        public string? MobilePhone => User?.FindFirst(ClaimTypes.MobilePhone)?.Value;

        public string? Role => User?.FindFirst(ClaimTypes.Role)?.Value;
    }
}