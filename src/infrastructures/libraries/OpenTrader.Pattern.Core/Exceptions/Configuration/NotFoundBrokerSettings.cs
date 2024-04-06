namespace OpenTrader.Pattern.Core.Exceptions.Configuration;

public class NotFoundBrokerSettings(string? nameBroker = null) 
    : InvalidOperationException(nameBroker == null 
        ? $"Invalid get broker settings: {nameBroker}" 
        : "Invalid get broker settings");