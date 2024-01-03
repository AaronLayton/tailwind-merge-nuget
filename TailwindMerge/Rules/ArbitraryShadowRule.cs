using System.Text.RegularExpressions;

namespace TailwindMerge.Rules
{
    public class ArbitraryShadowRule : ArbitraryValueRule
    {
        private const string ShadowRegex = @"^-?((\d+)?\.?(\d+)[a-z]+|0)_-?((\d+)?\.?(\d+)[a-z]+|0)";

        protected override bool TestValue(string value)
        {
            return Regex.IsMatch(value, ShadowRegex);
        }
    }
}
