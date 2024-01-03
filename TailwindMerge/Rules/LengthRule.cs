using System.Text.RegularExpressions;
using TailwindMerge.Interfaces;

namespace TailwindMerge.Rules
{
    public class LengthRule : IRule
    {
        private const string FractionRegex = @"^\d+/\d+$";
        private static readonly string[] StringLengths = { "px", "full", "screen" };

        public bool Execute(string value)
        {
            return double.TryParse(value, out _) 
                   || StringLengths.Contains(value) 
                   || Regex.IsMatch(value, FractionRegex);
        }
    }
}
