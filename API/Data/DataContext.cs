using System;
using Microsoft.EntityFrameworkCore;
using API.Entites;

namespace API.Data;

public class DataContext: DbContext
{
     public DataContext(DbContextOptions options) : base(options){
     }

 //table name
     public DbSet<AppUser> Users {get;set;}
}
