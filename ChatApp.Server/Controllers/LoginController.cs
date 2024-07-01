using ChatApp.Core.Services.Interfaces;
using ChatApp.Domain.AuthorizeModels;
using ChatApp.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChatApp.Server.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class LoginController : ControllerBase
   {
      private readonly IConfiguration _config;
      private readonly IUserService _userService;
      public LoginController(IConfiguration config, IUserService userService)
      {
         _config = config;
         _userService = userService;
      }

      [AllowAnonymous]
      [HttpPost]
      public IActionResult Login([FromBody] UserLogin userLogin)
      {
         var user = Authenticate(userLogin);
         if (user != null)
         {
            var token = GenerateToken(user);
            var objResponse = new UserSession { Username = user.Username.Trim(), Token = token };
            return Ok(objResponse);
         }

         return NotFound("user not found");
      }

      [AllowAnonymous]
      [HttpPost("register")]
      public IActionResult Register([FromBody] UserLogin userLogin)
      {
         var objResult = _userService.Register(userLogin.Username, userLogin.Password);
         if (objResult.result) 
         {
            return Ok();
         }
         return BadRequest(objResult.message);
      }

      // To generate token
      private string GenerateToken(UserModel user)
      {
         var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
         var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
         var claims = new[]
         {
                new Claim(ClaimTypes.NameIdentifier,user.Username)
                //new Claim(ClaimTypes.Role,user.Role)
            };
         var token = new JwtSecurityToken(_config["Jwt:Issuer"],
             _config["Jwt:Audience"],
             claims,
             expires: DateTime.Now.AddMinutes(15),
             signingCredentials: credentials);


         return new JwtSecurityTokenHandler().WriteToken(token);

      }

      //To authenticate user
      private UserModel Authenticate(UserLogin userLogin)
      {

         return _userService.GetUserLogin(userLogin.Username, userLogin.Password);
      }
   }
}

