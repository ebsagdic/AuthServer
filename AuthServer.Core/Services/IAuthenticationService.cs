﻿using AuthServer.Core.DTO_s;
using SharedLibrary.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDto>>CreateTokenAsync(LoginDto loginDto);
        Task<Response<TokenDto>>CreateTokenByRefreshToken(string refreshToken);
        Task<Response<NoDataDto>>RevokeRefreshToken(string refreshToken);
        Response<ClientTokenDto> CreateTokenByClient(ClientLoginDto loginDto); 

    }
}
