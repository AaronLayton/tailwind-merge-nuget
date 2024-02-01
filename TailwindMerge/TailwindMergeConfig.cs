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
                { "borderWidth", spacingWithArbitrary },
                { "contrast", lengthWithEmpty },
                { "grayscale", zeroAndEmpty },
                { "hueRotate", numberAndArbitrary },
                { "invert", zeroAndEmpty },
                { "gap", numberAndArbitrary },
                { "gradientColorStops", new List<object> { colors } },
                { "gradientColorStopPositions", new List<object> { isPercent, isArbitraryLength } },
                { "inset", spacingWithAutoAndArbitrary },
                { "margin", spacingWithAutoAndArbitrary },
                { "opacity", numberAndArbitrary },
                { "padding", numberAndArbitrary },
                { "saturate", numberAndArbitrary },
                { "scale", numberAndArbitrary },
                { "sepia", zeroAndEmpty },
                { "skew", numberAndArbitrary },
                { "space", numberAndArbitrary },
                { "translate", numberAndArbitrary }
            };

            var defaultClassGroups = new Dictionary<string, List<object>>
            {
                 {
                    "aspect",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "aspect", new List<object> { "auto", "square", "video", isArbitraryValue } }
                        }
                    }
                },
                {
                    "container",
                    new List<object> { "container" }
                },
                {
                    "columns",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "columns", new List<object> { isTshirtSize } }
                        }
                    }
                },
                {
                    "break-after",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "break-after", new List<object> { "getBreaks()" } }
                        }
                    }
                },
                {
                    "break-before",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "break-before", new List<object> { "getBreaks()" } }
                        }
                    }
                },
                {
                    "break-inside",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "break-inside", new List<object> { "auto", "avoid", "avoid-page", "avoid-column" } }
                        }
                    }
                },
                {
                    "box-decoration",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "box-decoration", new List<object> { "slice", "clone" } }
                        }
                    }
                },
                {
                    "box",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "box", new List<object> { "border", "content" } }
                        }
                    }
                },
                {
                    "display",
                    new List<object>
                    {
                        "block", "inline-block", "inline", "flex", "inline-flex", "table",
                        "inline-table", "table-caption", "table-cell", "table-column", "table-column-group",
                        "table-footer-group", "table-header-group", "table-row-group", "table-row", "flow-root",
                        "grid", "inline-grid", "contents", "list-item", "hidden"
                    }
                },
                {
                    "float",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "float", new List<object> { "right", "left", "none", "start", "end" } }
                        }
                    }
                },

                {
                    "clear",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "clear", new List<object> { "left", "right", "both", "none", "start", "end" } }
                        }
                    }
                },
                {
                    "isolation",
                    new List<object> { "isolate", "isolation-auto" }
                },
                {
                    "object-fit",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "object", new List<object> { "contain", "cover", "fill", "none", "scale-down" } }
                        }
                    }
                },
                {
                    "object-position",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "object", new List<object> { "...getPositions()", "isArbitraryValue" } } // Adjust with actual method or values
                        }
                    }
                },
                {
                    "overflow",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "overflow", new List<object> { "getOverflow()" } } // Adjust with actual method or values
                        }
                    }
                },
                {
                    "overflow-x",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "overflow-x", new List<object> { "getOverflow()" } } // Adjust with actual method or values
                        }
                    }
                },
                {
                    "overflow-y",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "overflow-y", new List<object> { "getOverflow()" } } // Adjust with actual method or values
                        }
                    }
                },
                {
                    "overscroll",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "overscroll", new List<object> { "getOverscroll()" } } // Adjust with actual method or values
                        }
                    }
                },
                {
                    "overscroll-x",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "overscroll-x", new List<object> { "getOverscroll()" } } // Adjust with actual method or values
                        }
                    }
                },
                {
                    "overscroll-y",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "overscroll-y", new List<object> { "getOverscroll()" } } // Adjust with actual method or values
                        }
                    }
                },
                {
                    "position",
                    new List<object> { "static", "fixed", "absolute", "relative", "sticky" }
                },

                {
                    "inset",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "inset", new List<object> { "inset" } } // Assuming "inset" is a variable or method to be replaced
                        }
                    }
                },
                {
                    "inset-x",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "inset-x", new List<object> { "inset" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "inset-y",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "inset-y", new List<object> { "inset" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "start",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "start", new List<object> { "inset" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "end",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "end", new List<object> { "inset" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "top",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "top", new List<object> { "inset" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "right",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "right", new List<object> { "inset" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "bottom",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "bottom", new List<object> { "inset" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "left",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "left", new List<object> { "inset" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "visibility",
                    new List<object> { "visible", "invisible", "collapse" }
                },
                {
                    "z",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "z", new List<object> { "auto", "isInteger", "isArbitraryValue" } } // Use actual variables or methods
                        }
                    }
                },

                {
                    "basis",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "basis", new List<object> { "getSpacingWithAutoAndArbitrary()" } } // Use actual function call
                        }
                    }
                },
                {
                    "flex-direction",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "flex", new List<object> { "row", "row-reverse", "col", "col-reverse" } }
                        }
                    }
                },
                {
                    "flex-wrap",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "flex", new List<object> { "wrap", "wrap-reverse", "nowrap" } }
                        }
                    }
                },
                {
                    "flex",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "flex", new List<object> { "1", "auto", "initial", "none", "isArbitraryValue" } } // Use actual variable or method
                        }
                    }
                },
                {
                    "grow",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "grow", new List<object> { "getZeroAndEmpty()" } } // Use actual function call
                        }
                    }
                },
                {
                    "shrink",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "shrink", new List<object> { "getZeroAndEmpty()" } } // Use actual function call
                        }
                    }
                },
                {
                    "order",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "order", new List<object> { "first", "last", "none", "isInteger", "isArbitraryValue" } } // Use actual variables or methods
                        }
                    }
                },
                {
                    "grid-cols",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "grid-cols", new List<object> { "isAny" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "col-start-end",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            {
                                "col", new List<object>
                                {
                                    "auto",
                                    new Dictionary<string, object> { { "span", new List<object> { "full", "isInteger", "isArbitraryValue" } } },
                                    "isArbitraryValue"
                                }
                            }
                        }
                    }
                },
                {
                    "col-start",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "col-start", new List<object> { "getNumberWithAutoAndArbitrary()" } } // Use actual function call
                        }
                    }
                },
                {
                    "col-end",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "col-end", new List<object> { "getNumberWithAutoAndArbitrary()" } } // Use actual function call
                        }
                    }
                },

                {
                    "grid-rows",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "grid-rows", new List<object> { "isAny" } } // Use actual variable or method
                        }
                    }
                },
                {
                    "row-start-end",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            {
                                "row", new List<object>
                                {
                                    "auto",
                                    new Dictionary<string, object> { { "span", new List<object> { "isInteger", "isArbitraryValue" } } },
                                    "isArbitraryValue"
                                }
                            }
                        }
                    }
                },
                {
                    "row-start",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "row-start", new List<object> { "getNumberWithAutoAndArbitrary()" } } // Use actual function call
                        }
                    }
                },
                {
                    "row-end",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "row-end", new List<object> { "getNumberWithAutoAndArbitrary()" } } // Use actual function call
                        }
                    }
                },
                {
                    "grid-flow",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "grid-flow", new List<object> { "row", "col", "dense", "row-dense", "col-dense" } }
                        }
                    }
                },
                {
                    "auto-cols",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "auto-cols", new List<object> { "auto", "min", "max", "fr", "isArbitraryValue" } } // Use actual variable or method
                        }
                    }
                },
                {
                    "auto-rows",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "auto-rows", new List<object> { "auto", "min", "max", "fr", "isArbitraryValue" } } // Use actual variable or method
                        }
                    }
                },
                {
                    "gap",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "gap", new List<object> { "gap" } } // Assuming "gap" is a variable or method to be replaced
                        }
                    }
                },
                {
                    "gap-x",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "gap-x", new List<object> { "gap" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "gap-y",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "gap-y", new List<object> { "gap" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "justify-content",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "justify", new List<object> { "normal", "getAlign()" } } // Use actual function call or replace "getAlign()" with real values
                        }
                    }
                },

                {
                    "justify-items",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "justify-items", new List<object> { "start", "end", "center", "stretch" } }
                        }
                    }
                },
                {
                    "justify-self",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "justify-self", new List<object> { "auto", "start", "end", "center", "stretch" } }
                        }
                    }
                },
                {
                    "align-content",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "content", new List<object> { "normal", "getAlign()", "baseline" } } // Use actual function call or replace "getAlign()" with real values
                        }
                    }
                },
                {
                    "align-items",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "items", new List<object> { "start", "end", "center", "baseline", "stretch" } }
                        }
                    }
                },
                {
                    "align-self",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "self", new List<object> { "auto", "start", "end", "center", "stretch", "baseline" } }
                        }
                    }
                },
                {
                    "place-content",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "place-content", new List<object> { "getAlign()", "baseline" } } // Use actual function call or replace "getAlign()" with real values
                        }
                    }
                },
                {
                    "place-items",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "place-items", new List<object> { "start", "end", "center", "baseline", "stretch" } }
                        }
                    }
                },
                {
                    "place-self",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "place-self", new List<object> { "auto", "start", "end", "center", "stretch" } }
                        }
                    }
                },
                {
                    "p",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "p", new List<object> { "padding" } } // Assuming "padding" is a variable or method to be replaced
                        }
                    }
                },
                {
                    "px",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "px", new List<object> { "padding" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "py",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "py", new List<object> { "padding" } } // Adjust with actual variable or method
                        }
                    }
                },

                {
                    "ps",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "ps", new List<object> { "padding" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "pe",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "pe", new List<object> { "padding" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "pt",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "pt", new List<object> { "padding" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "pr",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "pr", new List<object> { "padding" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "pb",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "pb", new List<object> { "padding" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "pl",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "pl", new List<object> { "padding" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "m",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "m", new List<object> { "margin" } } // Assuming "margin" is a variable or method to be replaced
                        }
                    }
                },
                {
                    "mx",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "mx", new List<object> { "margin" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "my",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "my", new List<object> { "margin" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "ms",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "ms", new List<object> { "margin" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "me",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "me", new List<object> { "margin" } } // Adjust with actual variable or method
                        }
                    }
                },

                {
                    "mt",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "mt", new List<object> { "margin" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "mr",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "mr", new List<object> { "margin" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "mb",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "mb", new List<object> { "margin" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "ml",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "ml", new List<object> { "margin" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "space-x",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "space-x", new List<object> { "space" } } // Assuming "space" is a variable or method to be replaced
                        }
                    }
                },
                {
                    "space-x-reverse",
                    new List<object> { "space-x-reverse" }
                },
                {
                    "space-y",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "space-y", new List<object> { "space" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "space-y-reverse",
                    new List<object> { "space-y-reverse" }
                },
                {
                    "w",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            {
                                "w", new List<object>
                                {
                                    "auto", "min", "max", "fit", "svw", "lvw", "dvw", "isArbitraryValue", "spacing"
                                }
                            } // Adjust with actual variable, method, or replace "spacing" and "isArbitraryValue" with real values
                        }
                    }
                },
                {
                    "min-w",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            {
                                "min-w", new List<object>
                                {
                                    "isArbitraryValue", "spacing", "min", "max", "fit"
                                }
                            } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "max-w",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            {
                                "max-w", new List<object>
                                {
                                    "isArbitraryValue",
                                    "spacing",
                                    "none",
                                    "full",
                                    "min",
                                    "max",
                                    "fit",
                                    "prose",
                                    new Dictionary<string, object>
                                    {
                                        { "screen", new List<object> { "isTshirtSize" } }
                                    },
                                    "isTshirtSize"
                                }
                            } // Adjust with actual variables, methods, or replace "isTshirtSize" with real values
                        }
                    }
                },

                {
                    "h",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            {
                                "h", new List<object>
                                {
                                    "isArbitraryValue", "spacing", "auto", "min", "max", "fit", "svh", "lvh", "dvh"
                                }
                            } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "min-h",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            {
                                "min-h", new List<object>
                                {
                                    "isArbitraryValue", "spacing", "min", "max", "fit", "svh", "lvh", "dvh"
                                }
                            } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "max-h",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            {
                                "max-h", new List<object>
                                {
                                    "isArbitraryValue", "spacing", "min", "max", "fit", "svh", "lvh", "dvh"
                                }
                            } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "size",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            {
                                "size", new List<object>
                                {
                                    "isArbitraryValue", "spacing", "auto", "min", "max", "fit"
                                }
                            } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "font-size",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            {
                                "text", new List<object>
                                {
                                    "base", "isTshirtSize", "isArbitraryLength"
                                }
                            } // Use actual variables or methods
                        }
                    }
                },
                {
                    "font-smoothing",
                    new List<object> { "antialiased", "subpixel-antialiased" }
                },
                {
                    "font-style",
                    new List<object> { "italic", "not-italic" }
                },
                {
                    "font-weight",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            {
                                "font", new List<object>
                                {
                                    "thin", "extralight", "light", "normal", "medium", "semibold", "bold", "extrabold", "black", "isArbitraryNumber"
                                }
                            } // Use actual variable or method
                        }
                    }
                },
                {
                    "font-family",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "font", new List<object> { "isAny" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "fvn-normal",
                    new List<object> { "normal-nums" }
                },
                {
                    "fvn-ordinal",
                    new List<object> { "ordinal" }
                },


                {
                    "fvn-slashed-zero",
                    new List<object> { "slashed-zero" }
                },
                {
                    "fvn-figure",
                    new List<object> { "lining-nums", "oldstyle-nums" }
                },
                {
                    "fvn-spacing",
                    new List<object> { "proportional-nums", "tabular-nums" }
                },
                {
                    "fvn-fraction",
                    new List<object> { "diagonal-fractions", "stacked-fractions" }
                },
                {
                    "tracking",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            {
                                "tracking", new List<object>
                                {
                                    "tighter", "tight", "normal", "wide", "wider", "widest", "isArbitraryValue"
                                }
                            } // Use actual variable or method
                        }
                    }
                },
                {
                    "line-clamp",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            {
                                "line-clamp", new List<object>
                                {
                                    "none", "isNumber", "isArbitraryNumber"
                                }
                            } // Use actual variable or method
                        }
                    }
                },
                {
                    "leading",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            {
                                "leading", new List<object>
                                {
                                    "none", "tight", "snug", "normal", "relaxed", "loose", "isLength", "isArbitraryValue"
                                }
                            } // Use actual variable or method
                        }
                    }
                },
                {
                    "list-image",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "list-image", new List<object> { "none", "isArbitraryValue" } } // Use actual variable or method
                        }
                    }
                },
                {
                    "list-style-type",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "list", new List<object> { "none", "disc", "decimal", "isArbitraryValue" } } // Use actual variable or method
                        }
                    }
                },
                {
                    "list-style-position",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "list", new List<object> { "inside", "outside" } } // Use actual variable or method
                        }
                    }
                },


                {
                    "placeholder-color",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "placeholder", new List<object> { "colors" } } // Assuming "colors" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "placeholder-opacity",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "placeholder-opacity", new List<object> { "opacity" } } // Assuming "opacity" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "text-alignment",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "text", new List<object> { "left", "center", "right", "justify", "start", "end" } }
                        }
                    }
                },
                {
                    "text-color",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "text", new List<object> { "colors" } } // Assuming "colors" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "text-opacity",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "text-opacity", new List<object> { "opacity" } } // Assuming "opacity" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "text-decoration",
                    new List<object> { "underline", "overline", "line-through", "no-underline" }
                },
                {
                    "text-decoration-style",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "decoration", new List<object> { "getLineStyles()", "wavy" } } // Use actual function call or replace "getLineStyles()" with real values
                        }
                    }
                },
                {
                    "text-decoration-thickness",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "decoration", new List<object> { "auto", "from-font", "isLength", "isArbitraryLength" } } // Use actual variables or methods
                        }
                    }
                },
                {
                    "underline-offset",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "underline-offset", new List<object> { "auto", "isLength", "isArbitraryValue" } } // Use actual variables or methods
                        }
                    }
                },
                {
                    "text-decoration-color",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "decoration", new List<object> { "colors" } } // Assuming "colors" is a method or variable to be replaced
                        }
                    }
                },


                {
                    "text-transform",
                    new List<object> { "uppercase", "lowercase", "capitalize", "normal-case" }
                },
                {
                    "text-overflow",
                    new List<object> { "truncate", "text-ellipsis", "text-clip" }
                },
                {
                    "text-wrap",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "text", new List<object> { "wrap", "nowrap", "balance", "pretty" } } // Adjust if necessary for your implementation
                        }
                    }
                },
                {
                    "indent",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "indent", new List<object> { "getSpacingWithArbitrary()" } } // Use actual function call
                        }
                    }
                },
                {
                    "vertical-align",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            {
                                "align", new List<object>
                                {
                                    "baseline", "top", "middle", "bottom", "text-top", "text-bottom", "sub", "super", "isArbitraryValue"
                                }
                            }
                        }
                    }
                },
                {
                    "whitespace",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            {
                                "whitespace", new List<object>
                                {
                                    "normal", "nowrap", "pre", "pre-line", "pre-wrap", "break-spaces"
                                }
                            }
                        }
                    }
                },
                {
                    "word-break",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "break", new List<object> { "normal", "words", "all", "keep" } }
                        }
                    }
                },
                {
                    "hyphens",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "hyphens", new List<object> { "none", "manual", "auto" } }
                        }
                    }
                },
                {
                    "content",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "content", new List<object> { "none", "isArbitraryValue" } } // Use actual variable or method
                        }
                    }
                },


                {
                    "bg-attachment",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "bg", new List<object> { "fixed", "local", "scroll" } }
                        }
                    }
                },
                {
                    "bg-clip",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "bg-clip", new List<object> { "border", "padding", "content", "text" } }
                        }
                    }
                },
                {
                    "bg-opacity",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "bg-opacity", new List<object> { "opacity" } } // Assuming "opacity" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "bg-origin",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "bg-origin", new List<object> { "border", "padding", "content" } }
                        }
                    }
                },
                {
                    "bg-position",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "bg", new List<object> { "getPositions()", "isArbitraryPosition" } } // Use actual function call or replace "isArbitraryPosition" with real values
                        }
                    }
                },
                {
                    "bg-repeat",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            {
                                "bg", new List<object>
                                {
                                    "no-repeat",
                                    new Dictionary<string, object> { { "repeat", new List<object> { "", "x", "y", "round", "space" } } }
                                }
                            }
                        }
                    }
                },
                {
                    "bg-size",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "bg", new List<object> { "auto", "cover", "contain", "isArbitrarySize" } } // Use actual variable or method
                        }
                    }
                },
                {
                    "bg-image",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            {
                                "bg", new List<object>
                                {
                                    "none",
                                    new Dictionary<string, object> { { "gradient-to", new List<object> { "t", "tr", "r", "br", "b", "bl", "l", "tl" } } },
                                    "isArbitraryImage"
                                }
                            }
                        }
                    }
                },
                {
                    "bg-color",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "bg", new List<object> { "colors" } } // Assuming "colors" is a method or variable to be replaced
                        }
                    }
                },

                {
                    "gradient-from-pos",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "from", new List<object> { "gradientColorStopPositions" } } // Assuming this references a variable or method
                        }
                    }
                },
                {
                    "gradient-via-pos",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "via", new List<object> { "gradientColorStopPositions" } } // Assuming this references a variable or method
                        }
                    }
                },
                {
                    "gradient-to-pos",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "to", new List<object> { "gradientColorStopPositions" } } // Assuming this references a variable or method
                        }
                    }
                },
                {
                    "gradient-from",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "from", new List<object> { "gradientColorStops" } } // Assuming this references a variable or method
                        }
                    }
                },
                {
                    "gradient-via",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "via", new List<object> { "gradientColorStops" } } // Assuming this references a variable or method
                        }
                    }
                },
                {
                    "gradient-to",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "to", new List<object> { "gradientColorStops" } } // Assuming this references a variable or method
                        }
                    }
                },
                {
                    "rounded",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "rounded", new List<object> { "borderRadius" } } // Assuming "borderRadius" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "rounded-s",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "rounded-s", new List<object> { "borderRadius" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "rounded-e",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "rounded-e", new List<object> { "borderRadius" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "rounded-t",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "rounded-t", new List<object> { "borderRadius" } } // Adjust with actual variable or method
                        }
                    }
                },

                {
                    "rounded-r",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "rounded-r", new List<object> { "borderRadius" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "rounded-b",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "rounded-b", new List<object> { "borderRadius" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "rounded-l",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "rounded-l", new List<object> { "borderRadius" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "rounded-ss",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "rounded-ss", new List<object> { "borderRadius" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "rounded-se",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "rounded-se", new List<object> { "borderRadius" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "rounded-ee",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "rounded-ee", new List<object> { "borderRadius" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "rounded-es",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "rounded-es", new List<object> { "borderRadius" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "rounded-tl",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "rounded-tl", new List<object> { "borderRadius" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "rounded-tr",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "rounded-tr", new List<object> { "borderRadius" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "rounded-br",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "rounded-br", new List<object> { "borderRadius" } } // Adjust with actual variable or method
                        }
                    }
                },


                {
                    "rounded-bl",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "rounded-bl", new List<object> { "borderRadius" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "border-w",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border", new List<object> { "borderWidth" } } // Assuming "borderWidth" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "border-w-x",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border-x", new List<object> { "borderWidth" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "border-w-y",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border-y", new List<object> { "borderWidth" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "border-w-s",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border-s", new List<object> { "borderWidth" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "border-w-e",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border-e", new List<object> { "borderWidth" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "border-w-t",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border-t", new List<object> { "borderWidth" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "border-w-r",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border-r", new List<object> { "borderWidth" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "border-w-b",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border-b", new List<object> { "borderWidth" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "border-w-l",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border-l", new List<object> { "borderWidth" } } // Adjust with actual variable or method
                        }
                    }
                },


                {
                    "border-opacity",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border-opacity", new List<object> { "opacity" } } // Assuming "opacity" is a variable or method
                        }
                    }
                },
                {
                    "border-style",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border", new List<object> { "solid", "dashed", "dotted", "double", "hidden" } } // Example styles added
                        }
                    }
                },
                {
                    "divide-x",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "divide-x", new List<object> { "borderWidth" } } // Adjust with actual variable or method for divide width
                        }
                    }
                },
                {
                    "divide-x-reverse",
                    new List<object> { "divide-x-reverse" }
                },
                {
                    "divide-y",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "divide-y", new List<object> { "borderWidth" } } // Adjust with actual variable or method for divide width
                        }
                    }
                },
                {
                    "divide-y-reverse",
                    new List<object> { "divide-y-reverse" }
                },
                {
                    "divide-opacity",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "divide-opacity", new List<object> { "opacity" } } // Assuming "opacity" is a variable or method
                        }
                    }
                },
                {
                    "divide-style",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "divide", new List<object> { "solid", "dashed", "dotted", "double" } } // Example styles added
                        }
                    }
                },
                {
                    "border-color",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border", new List<object> { "colors" } } // Assuming "colors" is a method or variable
                        }
                    }
                },
                {
                    "border-color-x",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border-x", new List<object> { "colors" } } // Assuming "colors" is a method or variable
                        }
                    }
                },


                {
                    "border-color-y",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border-y", new List<object> { "colors" } } // Assuming "colors" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "border-color-t",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border-t", new List<object> { "colors" } } // Assuming "colors" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "border-color-r",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border-r", new List<object> { "colors" } } // Assuming "colors" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "border-color-b",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border-b", new List<object> { "colors" } } // Assuming "colors" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "border-color-l",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border-l", new List<object> { "colors" } } // Assuming "colors" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "divide-color",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "divide", new List<object> { "colors" } } // Assuming "colors" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "outline-style",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "outline", new List<object> { "", "solid", "dashed", "dotted", "double" } } // Adjust with actual styles
                        }
                    }
                },
                {
                    "outline-offset",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "outline-offset", new List<object> { "isLength", "isArbitraryValue" } } // Use actual variables or methods
                        }
                    }
                },
                {
                    "outline-w",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "outline", new List<object> { "isLength", "isArbitraryLength" } } // Use actual variables or methods
                        }
                    }
                },
                {
                    "outline-color",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "outline", new List<object> { "colors" } } // Assuming "colors" is a method or variable to be replaced
                        }
                    }
                },


                {
                    "ring-w",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "ring", new List<object> { "getLengthWithEmptyAndArbitrary()" } } // Use actual function call or replace with real values
                        }
                    }
                },
                {
                    "ring-w-inset",
                    new List<object> { "ring-inset" }
                },
                {
                    "ring-color",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "ring", new List<object> { "colors" } } // Assuming "colors" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "ring-opacity",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "ring-opacity", new List<object> { "opacity" } } // Assuming "opacity" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "ring-offset-w",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "ring-offset", new List<object> { "isLength", "isArbitraryLength" } } // Use actual variables or methods
                        }
                    }
                },
                {
                    "ring-offset-color",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "ring-offset", new List<object> { "colors" } } // Assuming "colors" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "shadow",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "shadow", new List<object> { "", "inner", "none", "isTshirtSize", "isArbitraryShadow" } } // Use actual variables or methods
                        }
                    }
                },
                {
                    "shadow-color",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "shadow", new List<object> { "isAny" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "opacity",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "opacity", new List<object> { "opacity" } } // Assuming "opacity" is a variable or method to be replaced
                        }
                    }
                },
                {
                    "mix-blend",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "mix-blend", new List<object> { "getBlendModes()" } } // Use actual function call or replace with real values
                        }
                    }
                },


                {
                    "bg-blend",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "bg-blend", new List<object> { "getBlendModes()" } } // Use actual function call or replace with real values
                        }
                    }
                },
                {
                    "filter",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "filter", new List<object> { "", "none" } } // Specify filter types if applicable
                        }
                    }
                },
                {
                    "blur",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "blur", new List<object> { "blur" } } // Assuming "blur" is a variable or method to be replaced
                        }
                    }
                },
                {
                    "brightness",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "brightness", new List<object> { "brightness" } } // Assuming "brightness" is a variable or method to be replaced
                        }
                    }
                },
                {
                    "contrast",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "contrast", new List<object> { "contrast" } } // Assuming "contrast" is a variable or method to be replaced
                        }
                    }
                },
                {
                    "drop-shadow",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "drop-shadow", new List<object> { "", "none", "isTshirtSize", "isArbitraryValue" } } // Use actual variables or methods
                        }
                    }
                },
                {
                    "grayscale",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "grayscale", new List<object> { "grayscale" } } // Assuming "grayscale" is a variable or method to be replaced
                        }
                    }
                },
                {
                    "hue-rotate",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "hue-rotate", new List<object> { "hueRotate" } } // Assuming "hueRotate" is a variable or method to be replaced
                        }
                    }
                },
                {
                    "invert",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "invert", new List<object> { "invert" } } // Assuming "invert" is a variable or method to be replaced
                        }
                    }
                },
                {
                    "saturate",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "saturate", new List<object> { "saturate" } } // Assuming "saturate" is a variable or method to be replaced
                        }
                    }
                },


                {
                    "sepia",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "sepia", new List<object> { "sepia" } } // Assuming "sepia" is a variable or method to be replaced
                        }
                    }
                },
                {
                    "backdrop-filter",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "backdrop-filter", new List<object> { "", "none" } } // Specify backdrop filter types if applicable
                        }
                    }
                },
                {
                    "backdrop-blur",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "backdrop-blur", new List<object> { "blur" } } // Assuming "blur" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "backdrop-brightness",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "backdrop-brightness", new List<object> { "brightness" } } // Assuming "brightness" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "backdrop-contrast",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "backdrop-contrast", new List<object> { "contrast" } } // Assuming "contrast" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "backdrop-grayscale",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "backdrop-grayscale", new List<object> { "grayscale" } } // Assuming "grayscale" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "backdrop-hue-rotate",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "backdrop-hue-rotate", new List<object> { "hueRotate" } } // Assuming "hueRotate" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "backdrop-invert",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "backdrop-invert", new List<object> { "invert" } } // Assuming "invert" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "backdrop-opacity",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "backdrop-opacity", new List<object> { "opacity" } } // Assuming "opacity" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "backdrop-saturate",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "backdrop-saturate", new List<object> { "saturate" } } // Assuming "saturate" is a method or variable to be replaced
                        }
                    }
                },



                {
                    "backdrop-sepia",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "backdrop-sepia", new List<object> { "sepia" } } // Assuming "sepia" is a variable or method to be replaced
                        }
                    }
                },
                {
                    "border-collapse",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border", new List<object> { "collapse", "separate" } }
                        }
                    }
                },
                {
                    "border-spacing",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border-spacing", new List<object> { "borderSpacing" } } // Assuming "borderSpacing" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "border-spacing-x",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border-spacing-x", new List<object> { "borderSpacing" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "border-spacing-y",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "border-spacing-y", new List<object> { "borderSpacing" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "table-layout",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "table", new List<object> { "auto", "fixed" } }
                        }
                    }
                },
                {
                    "caption",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "caption", new List<object> { "top", "bottom" } }
                        }
                    }
                },
                {
                    "transition",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            {
                                "transition", new List<object>
                                {
                                    "none", "all", "", "colors", "opacity", "shadow", "transform", "isArbitraryValue"
                                }
                            }
                        }
                    }
                },
                {
                    "duration",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "duration", new List<object> { "getNumberAndArbitrary()" } } // Use actual function call or replace with real values
                        }
                    }
                },
                {
                    "ease",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "ease", new List<object> { "linear", "in", "out", "in-out", "isArbitraryValue" } } // Use actual variables or methods
                        }
                    }
                },


                {
                    "delay",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "delay", new List<object> { "getNumberAndArbitrary()" } } // Use actual function call or replace with real values
                        }
                    }
                },
                {
                    "animate",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "animate", new List<object> { "none", "spin", "ping", "pulse", "bounce", "isArbitraryValue" } } // Use actual variables or methods
                        }
                    }
                },
                {
                    "transform",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "transform", new List<object> { "", "gpu", "none" } }
                        }
                    }
                },
                {
                    "scale",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scale", new List<object> { "scale" } } // Assuming "scale" is a variable or method to be replaced
                        }
                    }
                },
                {
                    "scale-x",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scale-x", new List<object> { "scale" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "scale-y",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scale-y", new List<object> { "scale" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "rotate",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "rotate", new List<object> { "isInteger", "isArbitraryValue" } } // Use actual variables or methods
                        }
                    }
                },
                {
                    "translate-x",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "translate-x", new List<object> { "translate" } } // Assuming "translate" is a variable or method to be replaced
                        }
                    }
                },
                {
                    "translate-y",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "translate-y", new List<object> { "translate" } } // Adjust with actual variable or method
                        }
                    }
                },
                {
                    "skew-x",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "skew-x", new List<object> { "skew" } } // Assuming "skew" is a variable or method to be replaced
                        }
                    }
                },



                {
                    "skew-y",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "skew-y", new List<object> { "skew" } } // Assuming "skew" is a variable or method to be replaced
                        }
                    }
                },
                {
                    "transform-origin",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            {
                                "origin", new List<object>
                                {
                                    "center", "top", "top-right", "right", "bottom-right",
                                    "bottom", "bottom-left", "left", "top-left", "isArbitraryValue"
                                }
                            }
                        }
                    }
                },
                {
                    "accent",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "accent", new List<object> { "auto", "colors" } } // Assuming "colors" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "appearance",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "appearance", new List<object> { "none", "auto" } }
                        }
                    }
                },
                {
                    "cursor",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            {
                                "cursor", new List<object>
                                {
                                    "auto", "default", "pointer", "wait", "text", "move", "help", "not-allowed",
                                    "none", "context-menu", "progress", "cell", "crosshair", "vertical-text",
                                    "alias", "copy", "no-drop", "grab", "grabbing", "all-scroll",
                                    "col-resize", "row-resize", "n-resize", "e-resize", "s-resize",
                                    "w-resize", "ne-resize", "nw-resize", "se-resize", "sw-resize",
                                    "ew-resize", "ns-resize", "nesw-resize", "nwse-resize", "zoom-in",
                                    "zoom-out", "isArbitraryValue"
                                }
                            }
                        }
                    }
                },
                {
                    "caret-color",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "caret", new List<object> { "colors" } } // Assuming "colors" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "pointer-events",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "pointer-events", new List<object> { "none", "auto" } }
                        }
                    }
                },
                {
                    "resize",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "resize", new List<object> { "none", "y", "x", "" } } // Specify actual resize values if applicable
                        }
                    }
                },
                {
                    "scroll-behavior",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scroll", new List<object> { "auto", "smooth" } }
                        }
                    }
                },
                {
                    "scroll-m",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scroll-m", new List<object> { "getSpacingWithArbitrary()" } } // Use actual function call or replace with real values
                        }
                    }
                },


                {
                    "scroll-mx",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scroll-mx", new List<object> { "getSpacingWithArbitrary()" } } // Use actual function call or replace with real values
                        }
                    }
                },
                {
                    "scroll-my",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scroll-my", new List<object> { "getSpacingWithArbitrary()" } } // Use actual function call or replace with real values
                        }
                    }
                },
                {
                    "scroll-ms",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scroll-ms", new List<object> { "getSpacingWithArbitrary()" } } // Use actual function call or replace with real values
                        }
                    }
                },
                {
                    "scroll-me",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scroll-me", new List<object> { "getSpacingWithArbitrary()" } } // Use actual function call or replace with real values
                        }
                    }
                },
                {
                    "scroll-mt",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scroll-mt", new List<object> { "getSpacingWithArbitrary()" } } // Use actual function call or replace with real values
                        }
                    }
                },
                {
                    "scroll-mr",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scroll-mr", new List<object> { "getSpacingWithArbitrary()" } } // Use actual function call or replace with real values
                        }
                    }
                },
                {
                    "scroll-mb",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scroll-mb", new List<object> { "getSpacingWithArbitrary()" } } // Use actual function call or replace with real values
                        }
                    }
                },
                {
                    "scroll-ml",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scroll-ml", new List<object> { "getSpacingWithArbitrary()" } } // Use actual function call or replace with real values
                        }
                    }
                },
                {
                    "scroll-p",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scroll-p", new List<object> { "getSpacingWithArbitrary()" } } // Use actual function call or replace with real values
                        }
                    }
                },
                {
                    "scroll-px",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scroll-px", new List<object> { "getSpacingWithArbitrary()" } } // Use actual function call or replace with real values
                        }
                    }
                },


                {
                    "scroll-py",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scroll-py", new List<object> { "getSpacingWithArbitrary()" } } // Use actual function call or replace with real values
                        }
                    }
                },
                {
                    "scroll-ps",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scroll-ps", new List<object> { "getSpacingWithArbitrary()" } } // Use actual function call or replace with real values
                        }
                    }
                },
                {
                    "scroll-pe",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scroll-pe", new List<object> { "getSpacingWithArbitrary()" } } // Use actual function call or replace with real values
                        }
                    }
                },
                {
                    "scroll-pt",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scroll-pt", new List<object> { "getSpacingWithArbitrary()" } } // Use actual function call or replace with real values
                        }
                    }
                },
                {
                    "scroll-pr",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scroll-pr", new List<object> { "getSpacingWithArbitrary()" } } // Use actual function call or replace with real values
                        }
                    }
                },
                {
                    "scroll-pb",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scroll-pb", new List<object> { "getSpacingWithArbitrary()" } } // Use actual function call or replace with real values
                        }
                    }
                },
                {
                    "scroll-pl",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "scroll-pl", new List<object> { "getSpacingWithArbitrary()" } } // Use actual function call or replace with real values
                        }
                    }
                },
                {
                    "snap-align",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "snap", new List<object> { "start", "end", "center", "align-none" } }
                        }
                    }
                },
                {
                    "snap-stop",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "snap", new List<object> { "normal", "always" } }
                        }
                    }
                },
                {
                    "snap-type",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "snap", new List<object> { "none", "x", "y", "both" } }
                        }
                    }
                },


                {
                    "snap-strictness",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "snap", new List<object> { "mandatory", "proximity" } }
                        }
                    }
                },
                {
                    "touch",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "touch", new List<object> { "auto", "none", "manipulation" } }
                        }
                    }
                },
                {
                    "touch-x",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "touch-pan", new List<object> { "x", "left", "right" } }
                        }
                    }
                },
                {
                    "touch-y",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "touch-pan", new List<object> { "y", "up", "down" } }
                        }
                    }
                },
                {
                    "touch-pz",
                    new List<object> { "touch-pinch-zoom" }
                },
                {
                    "select",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "select", new List<object> { "none", "text", "all", "auto" } }
                        }
                    }
                },
                {
                    "will-change",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "will-change", new List<object> { "auto", "scroll", "contents", "transform", "isArbitraryValue" } } // Use actual variables or methods
                        }
                    }
                },
                {
                    "fill",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "fill", new List<object> { "colors", "none" } } // Assuming "colors" is a method or variable to be replaced
                        }
                    }
                },
                {
                    "stroke-w",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "stroke", new List<object> { "isLength", "isArbitraryLength", "isArbitraryNumber" } } // Use actual variables or methods
                        }
                    }
                },
                {
                    "stroke",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "stroke", new List<object> { "colors", "none" } } // Assuming "colors" is a method or variable to be replaced
                        }
                    }
                },


                {
                    "sr",
                    new List<object> { "sr-only", "not-sr-only" }
                },
                {
                    "forced-color-adjust",
                    new List<object>
                    {
                        new Dictionary<string, List<object>>
                        {
                            { "forced-color-adjust", new List<object> { "auto", "none" } }
                        }
                    }
                }











            };

            var defaultConflictingClassGroups = new Dictionary<string, List<string>>
            {
                { "overflow", new List<string> { "overflow-x", "overflow-y" } },
                { "overscroll", new List<string> { "overscroll-x", "overscroll-y" } },
                { "inset", new List<string> { "inset-x", "inset-y", "start", "end", "top", "right", "bottom", "left" } },
                { "inset-x", new List<string> { "right", "left" } },
                { "inset-y", new List<string> { "top", "bottom" } },
                { "flex", new List<string> { "basis", "grow", "shrink" } },
                { "gap", new List<string> { "gap-x", "gap-y" } },
                { "p", new List<string> { "px", "py", "ps", "pe", "pt", "pr", "pb", "pl" } },
                { "px", new List<string> { "pr", "pl" } },
                { "py", new List<string> { "pt", "pb" } },
                { "m", new List<string> { "mx", "my", "ms", "me", "mt", "mr", "mb", "ml" } },
                { "mx", new List<string> { "mr", "ml" } },
                { "my", new List<string> { "mt", "mb" } },
                { "size", new List<string> { "w", "h" } },
                { "font-size", new List<string> { "leading" } },
                { "fvn-normal", new List<string> { "fvn-ordinal", "fvn-slashed-zero", "fvn-figure", "fvn-spacing", "fvn-fraction" } },
                { "fvn-ordinal", new List<string> { "fvn-normal" } },
                { "fvn-slashed-zero", new List<string> { "fvn-normal" } },
                { "fvn-figure", new List<string> { "fvn-normal" } },
                { "fvn-spacing", new List<string> { "fvn-normal" } },
                { "fvn-fraction", new List<string> { "fvn-normal" } },
                { "line-clamp", new List<string> { "display", "overflow" } },
                { "rounded", new List<string>
                    {
                        "rounded-s", "rounded-e", "rounded-t", "rounded-r", "rounded-b", "rounded-l",
                        "rounded-ss", "rounded-se", "rounded-ee", "rounded-es", "rounded-tl", "rounded-tr",
                        "rounded-br", "rounded-bl"
                    }
                },
                { "rounded-s", new List<string> { "rounded-ss", "rounded-es" } },
                { "rounded-e", new List<string> { "rounded-se", "rounded-ee" } },
                { "rounded-t", new List<string> { "rounded-tl", "rounded-tr" } },
                { "rounded-r", new List<string> { "rounded-tr", "rounded-br" } },
                { "rounded-b", new List<string> { "rounded-br", "rounded-bl" } },
                { "rounded-l", new List<string> { "rounded-tl", "rounded-bl" } },
                { "border-spacing", new List<string> { "border-spacing-x", "border-spacing-y" } },
                { "border-w", new List<string>
                    {
                        "border-w-s", "border-w-e", "border-w-t", "border-w-r", "border-w-b", "border-w-l"
                    }
                },
                { "border-w-x", new List<string> { "border-w-r", "border-w-l" } },
                { "border-w-y", new List<string> { "border-w-t", "border-w-b" } },
                { "border-color", new List<string>
                    {
                        "border-color-t", "border-color-r", "border-color-b", "border-color-l"
                    }
                },
                { "border-color-x", new List<string> { "border-color-r", "border-color-l" } },
                { "border-color-y", new List<string> { "border-color-t", "border-color-b" } },
                { "scroll-m", new List<string>
                    {
                        "scroll-mx", "scroll-my", "scroll-ms", "scroll-me", "scroll-mt", "scroll-mr", "scroll-mb", "scroll-ml"
                    }
                },
                { "scroll-mx", new List<string> { "scroll-mr", "scroll-ml" } },
                { "scroll-my", new List<string> { "scroll-mt", "scroll-mb" } },
                { "scroll-p", new List<string>
                    {
                        "scroll-px", "scroll-py", "scroll-ps", "scroll-pe", "scroll-pt", "scroll-pr", "scroll-pb", "scroll-pl"
                    }
                },
                { "scroll-px", new List<string> { "scroll-pr", "scroll-pl" } },
                { "scroll-py", new List<string> { "scroll-pt", "scroll-pb" } },
                { "touch", new List<string> { "touch-x", "touch-y", "touch-pz" } },
                { "touch-x", new List<string> { "touch" } },
                { "touch-y", new List<string> { "touch" } },
                { "touch-pz", new List<string> { "touch" } },

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
