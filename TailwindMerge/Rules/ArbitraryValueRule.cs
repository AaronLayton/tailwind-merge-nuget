using System.Text.RegularExpressions;
using TailwindMerge.Interfaces;

namespace TailwindMerge.Rules
{
    public class ArbitraryValueRule : IRule
    {
        private const string RegexPattern = @"^\[(?:([a-z-]+):)?(.+)]$";

        protected string Parameter { get; set; }

        public bool Execute(string value)
        {
            var matches = Regex.Match(value, RegexPattern);

            if (matches.Success)
            {
                if (!string.IsNullOrEmpty(matches.Groups[1].Value))
                {
                    return matches.Groups[1].Value == Parameter;
                }

                return TestValue(matches.Groups[2].Value);
            }

            return false;
        }

        protected virtual bool TestValue(string value)
        {
            return true;
        }
    }
}
