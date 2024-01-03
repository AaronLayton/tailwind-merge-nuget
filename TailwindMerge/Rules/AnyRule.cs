using TailwindMerge.Interfaces;

namespace TailwindMerge.Rules
{
    public class AnyRule : IRule
    {
        public bool Execute(string value)
        {
            return true;
        }
    }
}
