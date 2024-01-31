using System;
using System.Collections.Generic;
using System.Numerics;
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
            var isTshirtSize = new TshirtSizeRule();
            var isArbitraryLength = new ArbitraryLengthRule();
            var isAny = new AnyRule();
            var isArbitraryPosition = new ArbitraryPositionRule();
            var isArbitrarySize = new ArbitrarySizeRule();
            var isArbitraryUrl = new ArbitraryUrlRule();
            var isArbitraryShadow = new ArbitraryShadowRule();
            var isInteger = new IntegerRule();
            var isLength = new LengthRule();
            var isNumber = new NumberRule();
            var isPercent = new PercentRule();
            var isArbitraryValue = new ArbitraryValueRule();
            var isArbitraryNumber = new ArbitraryNumberRule();
            var isArbitraryInteger = new ArbitraryIntegerRule();

            var colors = new ThemeGetter("colors");
            var spacing = new ThemeGetter("spacing");
            var blur = new ThemeGetter("blur");
            var brightness = new ThemeGetter("brightness");
            var borderColor = new ThemeGetter("borderColor");
            var borderRadius = new ThemeGetter("borderRadius");
            var borderSpacing = new ThemeGetter("borderSpacing");
            var borderWidth = new ThemeGetter("borderWidth");
            var contrast = new ThemeGetter("contrast");
            var grayscale = new ThemeGetter("grayscale");
            var hueRotate = new ThemeGetter("hueRotate");
            var invert = new ThemeGetter("invert");
            var gap = new ThemeGetter("gap");
            var gradientColorStops = new ThemeGetter("gradientColorStops");
            var gradientColorStopPositions = new ThemeGetter("gradientColorStopPositions");
            var inset = new ThemeGetter("inset");
            var margin = new ThemeGetter("margin");
            var opacity = new ThemeGetter("opacity");
            var padding = new ThemeGetter("padding");
            var saturate = new ThemeGetter("saturate");
            var scale = new ThemeGetter("scale");
            var sepia = new ThemeGetter("sepia");
            var skew = new ThemeGetter("skew");
            var space = new ThemeGetter("space");
            var translate = new ThemeGetter("translate");


            // common class groups
            var overscroll = new List<object> { "auto", "contain", "none" };
            var overflow = new List<object> { "auto", "hidden", "clip", "visible", "scroll" };
            var spacingWithAutoAndArbitrary = new List<object> { "auto", isArbitraryValue, spacing };
            var spacingWithArbitrary = new List<object> { isArbitraryValue, spacing };
            var lengthWithEmpty = new List<object> { "", isLength, isArbitraryLength };
            var numberWithAutoAndArbitrary = new List<object> { "auto", isNumber, isArbitraryValue };
            var positions = new List<object>
            {
                "bottom", "center", "left", "left-bottom", "left-top", "right",
                "right-bottom", "right-top", "top"
            };
            var lineStyles = new List<object> { "solid", "dashed", "dotted", "double", "none" };
            var blendModes = new List<object>
            {
                "normal", "multiply", "screen", "overlay", "darken", "lighten", "color-dodge", "color-burn",
                "hard-light", "soft-light", "difference", "exclusion", "hue", "saturation", "color",
                "luminosity", "plus-lighter"
            };
            var align = new List<object> { "start", "end", "center", "between", "around", "evenly", "stretch" };
            var zeroAndEmpty = new List<object> { "", "0", isArbitraryValue };
            var breaks = new List<object> { "auto", "avoid", "all", "avoid-page", "page", "left", "right", "column" };
            var number = new List<object> { isNumber, isArbitraryNumber };
            var numberAndArbitrary = new List<object> { isNumber, isArbitraryValue };



            // Set up default values for each property.
            var defaultTheme = new Dictionary<string, object>
            {
                { "colors", new List<object> { isAny } },
                { "spacing", new List<object> { isLength, isArbitraryLength } },
                { "blur", new List<object> { "none", "", isTshirtSize, isArbitraryValue } },
                { "brightness", numberAndArbitrary },
                { "borderColor", new List<object> { colors } },
                { "borderRadius", new List<object> { "none", "", "full", isTshirtSize, isArbitraryValue } },
                { "borderSpacing", spacingWithArbitrary },
                //{ "borderWidth", GetLengthWithEmptyAndArbitrary() },
                //{ "contrast", GetNumberAndArbitrary() },
                //{ "grayscale", GetZeroAndEmpty() },
                //{ "hueRotate", GetNumberAndArbitrary() },
                //{ "invert", GetZeroAndEmpty() },
                //{ "gap", GetSpacingWithArbitrary() },
                { "gradientColorStops", new List<object> { colors } },
                { "gradientColorStopPositions", new List<object> { isPercent, isArbitraryLength } },
                //{ "inset", GetSpacingWithAutoAndArbitrary() },
                //{ "margin", GetSpacingWithAutoAndArbitrary() },
                //{ "opacity", GetNumberAndArbitrary() },
                //{ "padding", GetSpacingWithArbitrary() },
                //{ "saturate", GetNumberAndArbitrary() },
                //{ "scale", GetNumberAndArbitrary() },
                //{ "sepia", GetZeroAndEmpty() },
                //{ "skew", GetNumberAndArbitrary() },
                //{ "space", GetSpacingWithArbitrary() },
                //{ "translate", GetSpacingWithArbitrary() }
            };

            var defaultClassGroups = new Dictionary<string, List<object>>
            {
                 {
                    "aspect", 
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "aspect", new List<object> { "auto", "square", "video", isArbitraryValue } } // Replace "isArbitraryValue" as needed
                        }
                    }
                },
                 {
                    "gubby",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "gubby", new List<object> { "correct", "wrong", "wizard" } } // Replace "isArbitraryValue" as needed
                        }
                    }
                },
                {
                "overflow",
                    new List<object>
                    {
                        new Dictionary<string, List<object>> 
                        { 
                            { "overflow", overflow } 
                        }
                    }
                },
                 {
                    "overflow-x",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>  { { "overflow-x", overflow } }
                    }
                },
                {
                    "overflow-y",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>  { { "overflow-y", overflow } }
                    }
                },

            };

            var defaultConflictingClassGroups = new Dictionary<string, List<string>>
            {
                { "overflow", new List<string> { "overflow-x", "overflow-y" } },
                { "inset", new List<string> { "inset-x", "inset-y", "top", "right", "bottom", "left" } },
            };

            var defaultConflictingClassGroupModifiers = new Dictionary<string, List<string>>
            {
                { "font-size", new List<string> { "leading" } },
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
