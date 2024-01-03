using TailwindMerge.Interfaces;

namespace TailwindMerge.Rules
{
    public class NeverRule : IRule
    {
        public bool Execute(string value)
        {
            return false;
        }
    }
}
