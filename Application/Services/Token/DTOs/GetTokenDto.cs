using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Token.DTOs
{
    public class GetTokenDto
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}
