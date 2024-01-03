namespace TailwindMerge.Rules
{
    public class ArbitraryPositionRule : ArbitraryValueRule
    {
        protected string Parameter { get; set; } = "position";

        protected override bool TestValue(string value)
        {
            return false;
        }
    }
}
