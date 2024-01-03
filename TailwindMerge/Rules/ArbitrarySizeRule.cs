namespace TailwindMerge.Rules
{
    public class ArbitrarySizeRule : ArbitraryValueRule
    {
        protected string Parameter { get; set; } = "size";

        protected override bool TestValue(string value)
        {
            return false;
        }
    }
}
