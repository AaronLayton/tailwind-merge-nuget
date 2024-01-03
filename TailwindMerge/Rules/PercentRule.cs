using TailwindMerge.Interfaces;

namespace TailwindMerge.Rules
{
    public class PercentRule : IRule
    {
        public bool Execute(string value)
        {
            if (string.IsNullOrEmpty(value) || !value.EndsWith("%"))
            {
                return false;
            }

            var numericPart = value.TrimEnd('%');
            return double.TryParse(numericPart, out _);
        }
    }
}
