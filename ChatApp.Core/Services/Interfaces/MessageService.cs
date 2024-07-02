using ChatApp.Core.Helpers;
using ChatApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Core.Services.Interfaces
{
   public class MessageService : IMessageService
   {
      private readonly ChatAppContext _chatAppContext;
      public MessageService(ChatAppContext chatAppContext)
      {
         _chatAppContext = chatAppContext;
      }

      public async Task<(bool result, string message)> CreateNewSession(string receiver, string requestor)
      {
         User currentUser = _chatAppContext.Users.FirstOrDefault(x => x.UserName == requestor);
         if (currentUser == null)
         {
            return (false, "User could not found");
         }

         User _receiver = _chatAppContext.Users.FirstOrDefault(x => x.UserName == receiver);
         if (_receiver == null)
         {
            return (false, "Receiver could not found");
         }

         Session model = new Session
         {
            UserId = currentUser.Id,
            SessionRefId = Guid.NewGuid().ToString("N"),
            ReceiverId = _receiver.Id,
            Status = (int)SessionStatus.New,
         };

         _chatAppContext.Sessions.Add(model);
         var result =  await _chatAppContext.SaveChangesAsync();
         if (result > 0)
         {
            return (true, string.Empty);
         }
         else {
            return (false, "Could not create new session");
         }
      }


      public async Task<(bool result, string message)> UpdateSession(int sessionID, int sessionStatus, string sessionContent)
      {
         var session = _chatAppContext.Sessions.FirstOrDefault(x => x.Id == sessionID);
         if(session == null)
         {
            return (false, "Could not fould session");
         }

         if (sessionStatus == (int)SessionStatus.End)
         { 
            //update content to Session details
         }

         session.Status = sessionStatus;
         session.StartAt = sessionStatus == (int)SessionStatus.Accept ? DateTime.Now : DateTime.MinValue;
         _chatAppContext.Sessions.Attach(session);
         var result = await _chatAppContext.SaveChangesAsync();
         if (result > 0)
         { 
         
         return (true, string.Empty); 
         }
         return (false, "update session fail");
      }
   }
}
