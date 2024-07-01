using ChatApp.Core.Services.Interfaces;
using ChatApp.Domain.AuthorizeModels;
using ChatApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Core.Services
{
   public class UserService: IUserService
   {
      private ChatAppContext _appContext;
      public UserService()
      {
         _appContext = new ChatAppContext();
      }

      public UserModel GetUserLogin(string username, string password)
      {
         var user = _appContext.Users.Where(u => u.UserName == username && u.Password == password).FirstOrDefault();
         if (user != null)
         {
            return new UserModel { Username = user.UserName, Password = user.Password };
         }
         return null;
      }

      public (bool result, string message) Register(string username, string password)
      {
         var existing = _appContext.Users.Any(x => x.UserName == username);
         if (existing)
         {
            return (false, "User existed");
         }

         _appContext.Users.Add(new User { UserName = username, Password = password });
         _appContext.SaveChanges();
         return (true, string.Empty);
      }
   }
}
