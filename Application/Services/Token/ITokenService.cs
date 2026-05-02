using Application.Services.Token.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Token
{
    public interface ITokenService
    {
        Task<List<GetTokenDto>> GetUserTokens(Guid userId);
    }
}
