using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.AuthorizeModels
{
   public class UserModel
   {
      public int Id { get; set; }   
      public string Username { get; set; }
      public string Password { get; set; }
   }

   public class UserLogin
   {
      public string Username { get; set; }
      public string Password { get; set; }
   }

   public class UserSession {
      public int Id { get; set; }
      public string Username { get; set; }
      public string Token { get; set; }
   }
}
