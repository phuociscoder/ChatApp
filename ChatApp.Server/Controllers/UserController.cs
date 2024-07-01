using ChatApp.Domain.AuthorizeModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChatApp.Server.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class UserController : ControllerBase
   {
      [HttpGet]
      [Route("Admins")]
      [Authorize(Roles = "Admin")]
      public IActionResult AdminEndPoint()
      {
         var currentUser = GetCurrentUser();
         return Ok($"Hi {currentUser.Username} you are an {currentUser.Role}");
      }
      private UserModel GetCurrentUser()
      {
         var identity = HttpContext.User.Identity as ClaimsIdentity;
         if (identity != null)
         {
            var userClaims = identity.Claims;
            return new UserModel
            {
               Username = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
               Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
            };
         }
         return null;
      }
   }
}

