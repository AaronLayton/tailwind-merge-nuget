namespace TailwindMerge.Rules
{
    public class ArbitraryIntegerRule : ArbitraryValueRule
    {
        protected string Parameter { get; set; } = "number";

        protected override bool TestValue(string value)
        {
            if (int.TryParse(value, out _))
            {
                return true;
            }
            return false;
        }
    }
}
