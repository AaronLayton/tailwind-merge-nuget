namespace TailwindMerge.Rules
{
    public class ArbitraryNumberRule : ArbitraryValueRule
    {
        protected string Parameter { get; set; } = "number";

        protected override bool TestValue(string value)
        {
            return double.TryParse(value, out _);
        }
    }
}
