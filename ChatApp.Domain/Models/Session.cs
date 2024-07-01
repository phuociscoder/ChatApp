using System;
using System.Collections.Generic;

namespace ChatApp.Domain.Models;

public partial class Session
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string SessionRefId { get; set; } = null!;

    public int ReceiverId { get; set; }

    public int Status { get; set; }

    public DateTime? StartAt { get; set; }

    public DateTime? EndAt { get; set; }

    public virtual User Receiver { get; set; } = null!;

    public virtual ICollection<SessionDetail> SessionDetails { get; set; } = new List<SessionDetail>();

    public virtual User User { get; set; } = null!;
}
