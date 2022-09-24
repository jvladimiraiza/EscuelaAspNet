using System;

public class EscuelaException : Exception
{
    public EscuelaException()
    {
    }

    public EscuelaException(string message)
        : base(message)
    {
    }

    public EscuelaException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}