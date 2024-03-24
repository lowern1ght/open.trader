using Microsoft.AspNetCore.Identity;

namespace OpenTrader.Identity.Service.Exceptions;

public class InvalidCreateUser(IdentityError[] errors) 
    : Exception($"Invalid create user: {string.Join(", ", errors.Select(error => error.Description))}");