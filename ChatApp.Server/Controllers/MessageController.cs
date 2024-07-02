using ChatApp.Core.Services.Interfaces;
using ChatApp.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Server.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   [Authorize]
   public class MessageController : ControllerBase
   {
      private readonly IMessageService _messageService;
      public MessageController(IMessageService messageService)
      {
         _messageService = messageService;
      }

      [HttpPost("create-session")]
      public async Task<IActionResult> CreateNewMessageSession([FromBody] CreateMessageSessionRQ request)
      {
        var objResult = await _messageService.CreateNewSession(request.Receiver, request.Requestor);
         if (objResult.result)
         {
            return Ok(objResult);
         }
         else { 
            return BadRequest(objResult);
         }
      }

      [HttpPost("update-session")]
      public async Task<IActionResult> UpdateSession([FromBody] UpdateMessageSessionRQ request)
      {
         var objResult = await _messageService.UpdateSession(request.SessionID, request.Status, request.sessionContent);
         if (objResult.result)
         {
            return Ok(objResult);
         }
         else
         {
            return BadRequest(objResult);
         }
      }
   }
}
