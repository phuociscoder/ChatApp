using System;
using System.Collections.Generic;

namespace ChatApp.Domain.Models;

public partial class SessionDetail
{
    public int Id { get; set; }

    public int SessionId { get; set; }

    public string? ConversationContent { get; set; }

    public virtual Session Session { get; set; } = null!;
}
