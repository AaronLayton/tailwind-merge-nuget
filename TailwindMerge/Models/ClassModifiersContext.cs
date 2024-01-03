using System;
using System.Collections.Generic;

namespace TailwindMerge.Models
{
    public class ClassModifiersContext
    {
        public IReadOnlyList<string> Modifiers { get; }
        public bool HasImportantModifier { get; }
        public string BaseClassName { get; }
        public int? MaybePostfixModifierPosition { get; }

        public ClassModifiersContext(IReadOnlyList<string> modifiers, bool hasImportantModifier, string baseClassName, int? maybePostfixModifierPosition)
        {
            Modifiers = modifiers ?? throw new ArgumentNullException(nameof(modifiers));
            HasImportantModifier = hasImportantModifier;
            BaseClassName = baseClassName ?? throw new ArgumentNullException(nameof(baseClassName));
            MaybePostfixModifierPosition = maybePostfixModifierPosition;
        }
    }
}
