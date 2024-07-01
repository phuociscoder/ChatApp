using System;
using System.Collections.Generic;

namespace ChatApp.Domain.Models;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Session> SessionReceivers { get; set; } = new List<Session>();

    public virtual ICollection<Session> SessionUsers { get; set; } = new List<Session>();
}
