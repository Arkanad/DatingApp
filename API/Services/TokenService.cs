using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Entites;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API;

public class TokenService : ITokenService
{
    private readonly SymmetricSecurityKey _key;

    public TokenService(IConfiguration configuration){
        _key = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(configuration["TokenKey"]));
    }
    
    public async Task<string> CreateToken(AppUser appUser)
    {
        var claims = new List<Claim>{
            new Claim(JwtRegisteredClaimNames.UniqueName, appUser.Username),
            new Claim(JwtRegisteredClaimNames.NameId, appUser.Id.ToString())
        };

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor(){
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
