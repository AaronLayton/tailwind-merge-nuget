using System.Collections.Generic;

namespace TailwindMerge.Models
{
    public class ClassPart
    {
        public Dictionary<string, ClassPart> NextPart { get; } = new Dictionary<string, ClassPart>();
        public List<ClassValidator> Validators { get; } = new List<ClassValidator>();
        public string? ClassGroupId { get; private set; }

        public ClassPart(string? classGroupId = null)
        {
            ClassGroupId = classGroupId;
        }

        public ClassPart SetClassGroupId(string classGroupId)
        {
            ClassGroupId = classGroupId;
            return this;
        }
    }
}
