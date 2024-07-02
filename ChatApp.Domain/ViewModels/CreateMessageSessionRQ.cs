using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.ViewModels
{
   public class CreateMessageSessionRQ
   {
      public string Receiver { get; set; }
      public string Requestor { get; set; }
   }
}
