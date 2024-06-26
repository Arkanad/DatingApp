﻿using System;
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
            Username = registerDto.Username,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new UserDto(){
            Username = user.Username,
            Token = await _tokenService.CreateToken(user)
        };
    } 
    
    public async Task<bool> UserExists(string username){
        return await _context.Users.AnyAsync(x => x.Username == username.ToLower());
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDtoRequest loginDtoRequest){
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == loginDtoRequest.Username.ToLower());

        if(user == null)
            return Unauthorized("Wrong username");

        var hmac = new HMACSHA512(user.PasswordSalt);

        var hashPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDtoRequest.Password));

        for(int i = 0; i < hashPassword.Length;i++){
            if(hashPassword[i] != user.PasswordHash[i]) 
                return Unauthorized("Wrong password");
        }

        return new UserDto{
            Username = user.Username,
            Token = await _tokenService.CreateToken(user)   
        };
    }
}
