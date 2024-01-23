namespace Trader.Constants.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class ProviderAttribute : Attribute
{
    public string Name { get; set; }
    public string BaseUrl { get; set; }
    public string DisplayName { get; set; }
    public string ResourceName { get; set; }

    public ProviderAttribute(string name, string displayName, string baseUrl, string resourceName)
    {
        Name = name;
        BaseUrl = baseUrl;
        DisplayName = displayName;
        ResourceName = resourceName;
    }
}