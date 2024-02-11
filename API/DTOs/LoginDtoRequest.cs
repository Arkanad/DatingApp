﻿using System;
using System.ComponentModel.DataAnnotations;

namespace API;

public class LoginDtoRequest
{
    [Required]
    public string Username{get;set;}

    [Required]
    public string Password{get;set;}
}
