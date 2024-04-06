using MassTransit;
using System.Reflection;

namespace OpenTrader.Pattern.Core.Extensions;

public static class TypeExtensions
{
    public static bool IsExistsConsumers(this Assembly? assembly)
    {
        return assembly is not null && assembly.GetTypes().Where(type => type.IsClass)
            .Any(type => type.GetInterfaces().Any(@interface 
                => @interface.IsGenericType && @interface.GetGenericTypeDefinition() == typeof(IConsumer<>)));
    }
}