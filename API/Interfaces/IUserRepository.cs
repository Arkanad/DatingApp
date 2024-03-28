using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entites;

namespace API;

public interface IUserRepository{
  void Update(AppUser user );

  Task<bool> SaveAllAsync();

  Task<IEnumerable<AppUser>> GetUsersAsync();

  Task<AppUser> GetUserByIdAsync(int id);

   Task<AppUser> GetUserByUsernameAsync(string username);

    Task<IEnumerable<MemberDto>> GetMemberAsync();

    Task<MemberDto> GetMemberAsync(string username);
}
