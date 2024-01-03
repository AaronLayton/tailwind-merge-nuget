using System.Text.RegularExpressions;
using TailwindMerge.Interfaces;

namespace TailwindMerge.Rules
{
    public class TshirtSizeRule : IRule
    {
        private const string RegexPattern = @"^(\d+(\.\d+)?)?(xs|sm|md|lg|xl)$";

        public bool Execute(string value)
        {
            return Regex.IsMatch(value, RegexPattern);
        }
    }
}
