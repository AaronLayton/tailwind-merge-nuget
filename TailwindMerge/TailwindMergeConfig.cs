using System;
using System.Collections.Generic;
using TailwindMerge.Exceptions;
using TailwindMerge.Interfaces;
using TailwindMerge.Rules;
using TailwindMerge.Utilities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TailwindMerge
{
    public class TailwindMergeConfig
    {
        public int CacheSizeValue { get; private set; }
        public string SeparatorValue { get; private set; }
        public string PrefixValue { get; private set; }
        public Dictionary<string, object> ThemeValue { get; private set; }
        public Dictionary<string, List<object>> ClassGroupsValue { get; private set; }
        public Dictionary<string, List<string>> ConflictingClassGroupsValue { get; private set; }
        public Dictionary<string, List<string>> ConflictingClassGroupModifiersValue { get; private set; }

        public TailwindMergeConfig(
            int cacheSize = 500,
            string separator = ":",
            string? prefix = null,
            Dictionary<string, object>? theme = null,
            Dictionary<string, List<object>>? classGroups = null,
            Dictionary<string, List<string>>? conflictingClassGroups = null,
            Dictionary<string, List<string>>? conflictingClassGroupModifiers = null)
        {
            CacheSizeValue = cacheSize;
            SeparatorValue = separator;
            PrefixValue = prefix ?? string.Empty;
            ThemeValue = theme ?? new Dictionary<string, object>();
            ClassGroupsValue = classGroups ?? new Dictionary<string, List<object>>();
            ConflictingClassGroupsValue = conflictingClassGroups ?? new Dictionary<string, List<string>>();
            ConflictingClassGroupModifiersValue = conflictingClassGroupModifiers ?? new Dictionary<string, List<string>>();

            Validate();
        }

        public static TailwindMergeConfig FromArray(Dictionary<string, object> config, bool extend = true)
        {
            var output = Default();

            foreach (var keyValuePair in config)
            {
                var methodName = char.ToLowerInvariant(keyValuePair.Key[0]) + keyValuePair.Key.Substring(1);
                var method = output.GetType().GetMethod(methodName);
                if (method != null)
                {
                    method.Invoke(output, new object[] { keyValuePair.Value, extend });
                }
            }

            return output;
        }

        public TailwindMergeConfig Separator(string separator)
        {
            SeparatorValue = separator;
            return Validate();
        }

        public TailwindMergeConfig CacheSize(int cacheSize)
        {
            CacheSizeValue = cacheSize;
            return Validate();
        }

        public TailwindMergeConfig Prefix(string prefix)
        {
            PrefixValue = prefix;
            return Validate();
        }

        public TailwindMergeConfig Theme(Dictionary<string, object> theme, bool extend = true)
        {
            ThemeValue = extend ? Merge(ThemeValue, theme) : theme;
            return Validate();
        }

        public TailwindMergeConfig ClassGroups(Dictionary<string, List<object>> classGroups, bool extend = true)
        {
            ClassGroupsValue = extend ? Merge(ClassGroupsValue, classGroups) : classGroups;
            return Validate();
        }

        public TailwindMergeConfig ConflictingClassGroups(Dictionary<string, List<string>> conflictingClassGroups, bool extend = true)
        {
            ConflictingClassGroupsValue = extend ? Merge(ConflictingClassGroupsValue, conflictingClassGroups) : conflictingClassGroups;
            return Validate();
        }

        public TailwindMergeConfig ConflictingClassGroupModifiers(Dictionary<string, List<string>> conflictingClassGroupModifiers, bool extend = true)
        {
            ConflictingClassGroupModifiersValue = extend ? Merge(ConflictingClassGroupModifiersValue, conflictingClassGroupModifiers) : conflictingClassGroupModifiers;
            return Validate();
        }


        private TailwindMergeConfig Validate()
        {
            foreach (var kvp in ThemeValue)
            {
                if (!(kvp.Key is string) || !IsClassGroup(kvp.Value))
                {
                    throw new BadThemeException("`theme` must be a dictionary of class group", this);
                }
            }

            foreach (var kvp in ClassGroupsValue)
            {
                if (!(kvp.Key is string) || !IsClassGroup(kvp.Value))
                {
                    throw new BadThemeException("`classGroups` must be an associative dictionary of class group", this);
                }
            }

            foreach (var kvp in ConflictingClassGroupsValue)
            {
                if (!(kvp.Key is string) || !IsListOfStrings(kvp.Value))
                {
                    throw new BadThemeException("`conflictingClassGroups` must be an associative dictionary of string list", this);
                }
            }

            foreach (var kvp in ConflictingClassGroupModifiersValue)
            {
                if (!(kvp.Key is string) || !IsListOfStrings(kvp.Value))
                {
                    throw new BadThemeException("`conflictingClassGroupModifiers` must be an associative dictionary of string list", this);
                }
            }

            return this;
        }

        private Dictionary<T, U> Merge<T, U>(Dictionary<T, U> a, Dictionary<T, U> b)
        {
            // Merge logic here
            // This is a simple merge method. You may need to customize this method based on your specific merge logic.
            var result = new Dictionary<T, U>(a);
            foreach (var kvp in b)
            {
                result[kvp.Key] = kvp.Value;
            }
            return result;
        }

        public static TailwindMergeConfig Default()
        {
            var colors = new ThemeGetter("colors");
            
            // Set up default values for each property.
            var defaultTheme = new Dictionary<string, object>
            {
                'colors' = colors,
            };

            var defaultClassGroups = new Dictionary<string, List<object>>
            {
                // Populate with default class group values
            };

            var defaultConflictingClassGroups = new Dictionary<string, List<string>>
            {
                // Populate with default conflicting class group values
            };

            var defaultConflictingClassGroupModifiers = new Dictionary<string, List<string>>
            {
                // Populate with default conflicting class group modifier values
            };
            
            
            return new TailwindMergeConfig(
                cacheSize: 500, // Default cache size
                separator: ":", // Default separator
                prefix: null,  // Default prefix
                theme: defaultTheme,
                classGroups: defaultClassGroups,
                conflictingClassGroups: defaultConflictingClassGroups,
                conflictingClassGroupModifiers: defaultConflictingClassGroupModifiers
            );
        }


        private bool IsListOfStrings(object value)
        {
            if (value is List<string> list)
            {
                return true;
            }
            return false;
        }

        private bool IsClassGroup(object value)
        {
            // Check if the object is a valid class group
            // Return true if valid, false otherwise
            return value is List<object> || value is IRule || value is ThemeGetter;
        }

        private bool IsClassDefinition(object value)
        {
            // Check if the object is a valid class definition
            // Return true if valid, false otherwise
            return value is string || value is IRule || value is ThemeGetter;
        }
    }
}
