using Trader.Pattern.Attributes;

namespace Trader.Pattern.Models.Common;

public class PatternMetaDescription
{
    public required Type PatternType { get; set; }
    public required PatternMetaAttribute MetaAttribute { get; init; }
}