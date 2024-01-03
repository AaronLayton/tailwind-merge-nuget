namespace TailwindMerge.Models
{
    public class ClassContext
    {
        public bool IsTailwindClass { get; }
        public string OriginalClassName { get; }
        public bool HasPostfixModifier { get; }
        public string? ModifierId { get; }
        public string? ClassGroupId { get; }

        public ClassContext(bool isTailwindClass, string originalClassName, bool hasPostfixModifier = false, string? modifierId = null, string? classGroupId = null)
        {
            IsTailwindClass = isTailwindClass;
            OriginalClassName = originalClassName;
            HasPostfixModifier = hasPostfixModifier;
            ModifierId = modifierId;
            ClassGroupId = classGroupId;
        }
    }
}
