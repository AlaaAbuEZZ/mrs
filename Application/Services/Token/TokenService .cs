using Application.Reposetories;
using Application.Services.Token.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace Application.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly IGenericRepository<Domain.Entites.Token> _repo;

        public TokenService(IGenericRepository<Domain.Entites.Token> repo)
        {
            _repo = repo;
        }

        public async Task<List<GetTokenDto>> GetUserTokens(Guid userId)
        {
            return await _repo.GetAll()
                .Where(x => x.UserId == userId)
                .Select(x => new GetTokenDto
                {
                    Token = x.TokenStr,
                    Expiry = x.ExpiaryDate
                }).ToListAsync();
        }
    }
}
