using System;
using API.Entites;

namespace API;

public interface ITokenService
{
    string CreateToken(AppUser appUser);
}
