﻿using System;

namespace LocalMind.Server.CustomExceptions;

public class ValidationException : Exception
{
    public ValidationException()
    { }

    public ValidationException(string message)
        : base(message)
    { }

    public ValidationException(string message, Exception inner)
        : base(message, inner)
    { }
}
