using System.Text.RegularExpressions;

namespace TailwindMerge.Rules
{
    public class ArbitraryLengthRule : ArbitraryValueRule
    {
        private const string LengthUnitRegex = @"\d+(%|px|r?em|[sdl]?v([hwib]|min|max)|pt|pc|in|cm|mm|cap|ch|ex|r?lh|cq(w|h|i|b|min|max))|\b(calc|min|max|clamp)\(.+\)|^0$";

        protected string Parameter { get; set; } = "length";

        protected override bool TestValue(string value)
        {
            return Regex.IsMatch(value, LengthUnitRegex);
        }
    }
}
