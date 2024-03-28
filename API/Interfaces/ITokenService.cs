using System;
using System.Threading.Tasks;
using API.Entites;

namespace API;

public interface ITokenService
{
   Task<string> CreateToken(AppUser appUser);
}
