using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.AuthorizeModels
{
   public class UserModel
   {
      public string Username { get; set; }
      public string Password { get; set; }
      public string Role { get; set; }
   }

   public class UserLogin
   {
      public string Username { get; set; }
      public string Password { get; set; }
   }

   public class UserConstants
   {
      public static List<UserModel> Users = new()
            {
                    new UserModel(){ Username="naeem",Password="naeem_admin",Role="Admin"}
            };
   }
}
