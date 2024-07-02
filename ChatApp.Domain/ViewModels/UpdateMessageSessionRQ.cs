using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.ViewModels
{
   public class UpdateMessageSessionRQ
   {
      public int SessionID { get; set; }
      public int Status { get; set; }
      public string sessionContent { get; set; }
   }
}
