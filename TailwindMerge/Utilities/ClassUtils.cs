using System;
using System.Collections.Generic;
using TailwindMerge.Models;

namespace TailwindMerge.Utilities
{
    public class ClassUtils
    {
        private const string IMPORTANT_MODIFIER = "!";
        private const string ARBITRARY_PROPERTY_REGEX = @"^\[(.+)]";

        private readonly ClassPart classMap;
        private readonly TailwindMergeConfig _config;

        public ClassUtils(TailwindMergeConfig config)
        {
            classMap = ClassMapFactory.Create(config);
            _config = config;
        }

        public string? GetClassGroupId(string className)
        {
            var classParts = className.Split('-');

            // Classes like "-inset-1" produce an empty string as the first classPart.
            // We assume that classes for negative values are used correctly and remove it from classParts.
            if (classParts[0] == "" && classParts.Length != 1)
            {
                Array.Copy(classParts, 1, classParts, 0, classParts.Length - 1);
                Array.Resize(ref classParts, classParts.Length - 1);
            }

            return GetGroupRecursive(classParts, classMap) ?? GetGroupIdForArbitraryProperty(className);
        }

        public List<string> GetConflictingClassGroupIds(string classGroupId, bool hasPostfixModifier)
        {
            var conflicts = _config.ConflictingClassGroupsValue.GetValueOrDefault(classGroupId) ?? new List<string>();

            if (hasPostfixModifier && _config.ConflictingClassGroupModifiersValue.ContainsKey(classGroupId))
            {
                conflicts.AddRange(_config.ConflictingClassGroupModifiersValue[classGroupId]);
            }

            return conflicts;
        }

        public ClassModifiersContext SplitModifiers(string className)
        {
            var separator = _config.SeparatorValue;
            var modifiers = new List<string>();
            var bracketDepth = 0;
            var modifierStart = 0;
            int? postfixModifierPosition = null;

            for (int index = 0; index < className.Length; index++)
            {
                var currentCharacter = className[index];

                if (bracketDepth == 0)
                {
                    if (currentCharacter == separator[0] &&
                        (separator.Length == 1 || className.Substring(index, separator.Length) == separator))
                    {
                        modifiers.Add(className.Substring(modifierStart, index - modifierStart));
                        modifierStart = index + separator.Length;
                        continue;
                    }

                    if (currentCharacter == '/')
                    {
                        postfixModifierPosition = index;
                        continue;
                    }
                }

                if (currentCharacter == '[')
                {
                    bracketDepth++;
                }
                else if (currentCharacter == ']')
                {
                    bracketDepth--;
                }
            }

            var baseClassNameWithImportantModifier = modifiers.Count == 0
                ? className
                : className.Substring(modifierStart);
            var hasImportantModifier = baseClassNameWithImportantModifier.StartsWith(IMPORTANT_MODIFIER);
            var baseClassName = hasImportantModifier
                ? baseClassNameWithImportantModifier.Substring(1)
                : baseClassNameWithImportantModifier;
            int? maybePostfixModifierPosition = postfixModifierPosition > modifierStart
                ? postfixModifierPosition - modifierStart
                : null;

            return new ClassModifiersContext(modifiers, hasImportantModifier, baseClassName, maybePostfixModifierPosition);
        }

        public IReadOnlyList<string> SortModifiers(IReadOnlyList<string> modifiers)
        {
            if (modifiers.Count <= 1)
            {
                return modifiers;
            }

            var sortedModifiers = new List<string>();
            var unsortedModifiers = new List<string>();

            foreach (var modifier in modifiers)
            {
                var isArbitraryVariant = modifier[0] == '[';
                if (isArbitraryVariant)
                {
                    unsortedModifiers.Sort();
                    sortedModifiers.AddRange(unsortedModifiers);
                    sortedModifiers.Add(modifier);
                    unsortedModifiers.Clear();
                }
                else
                {
                    unsortedModifiers.Add(modifier);
                }
            }

            unsortedModifiers.Sort();
            sortedModifiers.AddRange(unsortedModifiers);

            return sortedModifiers;
        }

        private string? GetGroupRecursive(string[] classParts, ClassPart classPart)
        {
            if (classParts.Length == 0)
            {
                return classPart.ClassGroupId;
            }

            var currentClassPart = classParts[0];


            if (classPart.NextPart.TryGetValue(currentClassPart, out var nextClassPartObject))
            {
                var classGroupFromNextClassPart = GetGroupRecursive(classParts[1..], nextClassPartObject);
                if (classGroupFromNextClassPart != null)
                {
                    return classGroupFromNextClassPart;
                }
            }

            if (classPart.Validators.Count == 0)
            {
                return null;
            }

            var classRest = string.Join("-", classParts);

            foreach (var classValidator in classPart.Validators)
            {
                if (classValidator.Rule.Execute(classRest))
                {
                    return classValidator.ClassGroupId;
                }
            }

            return null;
        }

        private string? GetGroupIdForArbitraryProperty(string className)
        {
            var match = System.Text.RegularExpressions.Regex.Match(className, ARBITRARY_PROPERTY_REGEX);
            if (match.Success)
            {
                var arbitraryPropertyClassName = match.Groups[1].Value;
                if (!string.IsNullOrEmpty(arbitraryPropertyClassName))
                {
                    var property = arbitraryPropertyClassName.Substring(0, arbitraryPropertyClassName.IndexOf(':'));
                    return "arbitrary.." + property;
                }
            }

            return null;
        }
    }
}
