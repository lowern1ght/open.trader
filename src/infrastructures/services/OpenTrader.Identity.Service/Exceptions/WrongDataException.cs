namespace OpenTrader.Identity.Service.Exceptions;

public class WrongDataException(string message) 
    : Exception(message);