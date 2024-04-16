using MassTransit;
using System.Reflection;

namespace OpenTrader.Pattern.Core.Extensions;

public static class AssemblyExtensions
{
    /// <summary>
    /// Check in <see cref="Assembly"/> exists or no <c>ICustomer</c> implemented classes
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static bool IsExistsConsumers(this Assembly? assembly)
    {
        return assembly is not null && assembly.GetTypes().Where(type => type.IsClass)
            .Any(type => type.GetInterfaces().Any(@interface 
                => @interface.IsGenericType && @interface.GetGenericTypeDefinition() == typeof(IConsumer<>)));
    }
}