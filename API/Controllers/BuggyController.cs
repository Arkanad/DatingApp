using API.Data;
using API.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController: BaseApiController{
        private readonly DataContext _dataContext;
        public BuggyController(DataContext context){
            _dataContext = context;
        }

        [HttpGet("auth")]
        [Authorize]
        public ActionResult<string> GetSecret(){
            return "secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound(){
            var thing = _dataContext.Users.Find(-1);
            
            if(thing == null)
                return NotFound();  
            else
                return thing;
        }
        
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError(){
            var thing = _dataContext.Users.Find(-1);
            
            return thing.ToString();
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest(){
            return BadRequest("This was not a good request");
        }
    }
}