using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Server.Message
{
   public class MessageHub : Hub
   {

      public async Task SendInvitation(string userName, string message)
      {
         await Clients.User(userName).SendAsync("ReceiveInvite", message);
      }

      public async Task SendMessage(string userName, string message)
      {
         await Clients.All.SendAsync("ReceiveMessage", message);
      }

   }
}
