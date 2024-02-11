using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace API;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{

}
