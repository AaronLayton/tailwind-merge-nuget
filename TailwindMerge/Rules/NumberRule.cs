using TailwindMerge.Interfaces;

namespace TailwindMerge.Rules
{
    public class NumberRule : IRule
    {
        public bool Execute(string value)
        {
            return double.TryParse(value, out _);
        }
    }
}
