namespace Trader.Storage.Inventory.Attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class BucketAttribute : Attribute
{
    public required string BucketName { get; set; }
}