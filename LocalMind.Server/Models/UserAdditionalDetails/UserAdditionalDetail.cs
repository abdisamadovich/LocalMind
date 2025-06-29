﻿using LocalMind.Server.Models.Users;
using System;

namespace LocalMind.Server.Models.UserAdditionalDetails;

public class UserAdditionalDetail
{
    public Guid Id { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Country { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
}
