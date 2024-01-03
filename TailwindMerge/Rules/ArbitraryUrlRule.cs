namespace TailwindMerge.Rules
{
    public class ArbitraryUrlRule : ArbitraryValueRule
    {
        protected string Parameter { get; set; } = "url";

        protected override bool TestValue(string value)
        {
            return value.StartsWith("url(");
        }
    }
}
