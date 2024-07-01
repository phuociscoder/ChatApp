using ChatApp.Domain.AuthorizeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Core.Services.Interfaces
{
   public interface IUserService
   {
      UserModel GetUserLogin(string username, string password);
      (bool result, string message) Register(string username, string password);
   }
}
