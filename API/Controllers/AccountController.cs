using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

public class AccountController: BaseApiController
{
    DataContext _context;
    ITokenService _tokenService ;
    public AccountController(DataContext context, ITokenService tokenService){
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto){
       if(await UserExists(registerDto.Username)){
            return BadRequest("Username is taken");
       }

        using var hmac = new HMACSHA512();

        var user = new AppUser(){
            UserName = registerDto.Username,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new UserDto(){
            Username = user.UserName,
            Token = _tokenService.CreateToken(user)
        };
    } 
    
    public async Task<bool> UserExists(string username){
        return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
    }

    [HttpPost("login")]
    public async Task<ActionResult<AppUser>> Login(LoginDtoRequest loginDtoRequest){
        var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDtoRequest.Username);

        if(user == null)
            return Unauthorized("Wrong username");

        var hmac = new HMACSHA512(user.PasswordSalt);

        var hashPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDtoRequest.Password));

        for(int i = 0; i < hashPassword.Length;i++){
            if(hashPassword[i] != user.PasswordHash[i]) 
                return Unauthorized("Wrong password");
        }

        return user;
    }
}
