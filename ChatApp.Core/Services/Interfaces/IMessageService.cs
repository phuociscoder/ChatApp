using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Core.Services.Interfaces
{
   public interface IMessageService
   {
      Task<(bool result, string message)> CreateNewSession(string receiverID, string requestor);

      Task<(bool result, string message)> UpdateSession(int sessionID, int sessionStatus, string sessionContent);
   }
}
