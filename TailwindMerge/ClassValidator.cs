using TailwindMerge.Interfaces; // Assuming RuleInterface is located here

namespace TailwindMerge
{
    public class ClassValidator
    {
        public string ClassGroupId { get; }
        public IRule Rule { get; }

        public ClassValidator(string classGroupId, IRule rule)
        {
            ClassGroupId = classGroupId;
            Rule = rule;
        }
    }
}
