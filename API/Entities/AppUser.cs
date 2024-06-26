﻿using System;
using System.Collections.Generic;

namespace API.Entites;

public class AppUser
{
    public int Id {get;set;}

    public string Username { get; set; }

    public byte[] PasswordHash { get; set; }
    
    public byte[] PasswordSalt { get; set; }

    public DateOnly DateOfBirth {get;set;}

    public string KnownAs {get;set;}

    public DateTime Created {get;set;} = DateTime.UtcNow;

    public DateTime LastActive {get; set;} = DateTime.UtcNow;

    public string Gender {get;set;}

    public string Introduction {get;set;}

    public string LookingFor {get;set;}

    public string City {get;set;}

    public string Country {get;set;}

    public ICollection<Photo> Photos {get;set;}

 //   public int GetAge(){
   //     return DateOfBirth.CalculateAge();
    //  }
}