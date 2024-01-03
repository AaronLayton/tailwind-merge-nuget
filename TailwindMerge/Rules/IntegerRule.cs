using TailwindMerge.Interfaces;

namespace TailwindMerge.Rules
{
    public class IntegerRule : IRule
    {
        public bool Execute(string value)
        {
            return int.TryParse(value, out _);
        }
    }
}
