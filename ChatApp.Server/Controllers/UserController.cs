using ChatApp.Core.Services.Interfaces;
using ChatApp.Domain.AuthorizeModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChatApp.Server.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   //[Authorize]
   public class UserController : ControllerBase
   {
      private readonly IUserService _userService;

      public UserController(IUserService userService)
      {
         _userService = userService;
      }

      [HttpGet("user-list")]
      public IActionResult Users()
      {
         var objResponse = _userService.GetUsers();
         if (objResponse != null) 
         { 
            return Ok(objResponse);
         }
         return Ok(new List<UserModel>());
      }
      private UserModel GetCurrentUser()
      {
         //var identity = HttpContext.User.Identity as ClaimsIdentity;
         //if (identity != null)
         //{
         //   var userClaims = identity.Claims;
         //   return new UserModel
         //   {
         //      Username = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
         //      Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
         //   };
         //}
         return null;
      }
   }
}

