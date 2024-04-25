using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Data;
using API.Entites;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class UsersController : BaseApiController
{
    private UserRepository _userRepository;
    private IMapper _mapper;

    public UsersController(UserRepository userRepository, IMapper mapper){
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers(){
        var users = await _userRepository.GetMemberAsync();

        return Ok(users);
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        return await _userRepository.GetMemberAsync(username);
    }
    
    [HttpPut]
    public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto){
        var username = User.FindFirst(ClaimTypes.Name)?.Value;
        var user = await _userRepository.GetUserByUsernameAsync(username);

        if (user == null) return NotFound();

        _mapper.Map(memberUpdateDto, user);

        if(await _userRepository.SaveAllAsync()) 
            return NoContent();

        return BadRequest("Failed to update user");
    }

    [HttpPost("add-photo")]
    public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file){
        var user
    }

}
 