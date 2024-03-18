using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entites;

namespace API;

public interface IUserRepository
{
    void Update(AppUser user);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<AppUser> GetUserByIdAsync(int id);

    Task<AppUser> GetUserByUserNameAsync(string username);
}
