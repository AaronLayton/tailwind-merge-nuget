namespace TailwindMerge
{
    /// <summary>
    /// Provides methods for merging Tailwind CSS classes.
    /// </summary>
    public static class TW
    {
        private static readonly HashSet<string> KnownPrefixes = new HashSet<string>
        {
            "accent", "align-content", "align-items", "align-self", "animate", "appearance",
            "aspect", "auto-cols", "auto-rows", "backdrop-blur", "backdrop-brightness",
            "backdrop-contrast", "backdrop-filter", "backdrop-grayscale", "backdrop-hue-rotate",
            "backdrop-invert", "backdrop-opacity", "backdrop-saturate", "backdrop-sepia",
            "basis", "bg-attachment", "bg-blend", "bg-clip", "bg-color", "bg-image",
            "bg-opacity", "bg-origin", "bg-position", "bg-repeat", "bg-size", "bg", "blur",
            "border-collapse", "border-color-b", "border-color-l", "border-color-r",
            "border-color-t", "border-color-x", "border-color-y", "border-color",
            "border-opacity", "border-spacing-x", "border-spacing-y", "border-spacing",
            "border-style", "border-w-b", "border-w-e", "border-w-l", "border-w-r",
            "border-w-s", "border-w-t", "border-w-x", "border-w-y", "border-w", "bottom",
            "box-decoration", "box", "break-after", "break-before", "break-inside", "break",
            "brightness", "caption", "caret-color", "clear", "col-end", "col-start-end",
            "col-start", "columns", "container", "content", "contrast", "cursor", "delay",
            "display", "divide-color", "divide-opacity", "divide-style", "divide-x-reverse",
            "divide-x", "divide-y-reverse", "divide-y", "drop-shadow", "duration", "ease",
            "end", "fill", "filter", "flex-direction", "flex-wrap", "flex", "float",
            "font-family", "font-size", "font-smoothing", "font-style", "font-weight",
            "fvn-figure", "fvn-fraction", "fvn-normal", "fvn-ordinal", "fvn-slashed-zero",
            "fvn-spacing", "gap-x", "gap-y", "gap", "gradient-from-pos", "gradient-from",
            "gradient-to-pos", "gradient-to", "gradient-via-pos", "gradient-via", "grayscale",
            "grid-cols", "grid-flow", "grid-rows", "grow", "h", "hue-rotate", "hyphens",
            "indent", "inset-x", "inset-y", "inset", "invert", "isolation", "justify-content",
            "justify-items", "justify-self", "leading", "left", "line-clamp", "list-image",
            "list-style-position", "list-style-type", "m", "max-h", "max-w", "mb", "me",
            "min-h", "min-w", "mix-blend", "ml", "mr", "ms", "mt", "mx", "my", "object-fit",
            "object-position", "opacity", "order", "outline-color", "outline-offset",
            "outline-style", "outline-w", "overflow-x", "overflow-y", "overflow", "overscroll-x",
            "overscroll-y", "overscroll", "p", "pb", "pe", "pl", "place-content", "place-items",
            "place-self", "placeholder-color", "placeholder-opacity", "pointer-events",
            "position", "pr", "ps", "pt", "px", "py", "resize", "right", "ring-color",
            "ring-offset-color", "ring-offset-w", "ring-opacity", "ring-w-inset", "ring-w",
            "rotate", "rounded-b", "rounded-bl", "rounded-br", "rounded-e", "rounded-ee",
            "rounded-es", "rounded-l", "rounded-r", "rounded-s", "rounded-se", "rounded-ss",
            "rounded-t", "rounded-tl", "rounded-tr", "rounded", "row-end", "row-start-end",
            "row-start", "saturate", "scale-x", "scale-y", "scale", "scroll-behavior",
            "scroll-m", "scroll-mb", "scroll-me", "scroll-ml", "scroll-mr", "scroll-ms",
            "scroll-mt", "scroll-mx", "scroll-my", "scroll-p", "scroll-pb", "scroll-pe",
            "scroll-pl", "scroll-pr", "scroll-ps", "scroll-pt", "scroll-px", "scroll-py",
            "select", "sepia", "shadow-color", "shadow", "shrink", "skew-x", "skew-y",
            "snap-align", "snap-stop", "snap-strictness", "snap-type", "space-x-reverse",
            "space-x", "space-y-reverse", "space-y", "sr", "start", "stroke-w", "stroke",
            "table-layout", "text-alignment", "text-color", "text-decoration-color",
            "text-decoration-style", "text-decoration-thickness", "text-decoration",
            "text-opacity", "text-overflow", "text-transform", "text", "top", "touch", "touch-x",
            "touch-y", "touch-pz", "tracking", "transform-origin", "transform", "transition",
            "translate-x", "translate-y", "underline-offset", "vertical-align", "visibility",
            "w", "whitespace", "will-change", "z"
        };

        /// <summary>
        /// Merges a set of Tailwind CSS classes into a single string, ensuring that only the last instance
        /// of a class in the same group (defined by the prefix) is kept.
        /// </summary>
        /// <param name="classes">An array of class strings to merge.</param>
        /// <returns>A string containing the merged classes.</returns>
        /// <example>
        /// <code>
        /// string result = TW.Merge("text-red-500", "text-blue-600", "p-4", "p-2");
        /// // result is "text-blue-600 p-2"
        /// </code>
        /// </example>
        public static string Merge(params string[] classes)
        {
            var classGroups = new Dictionary<string, string>();

            foreach (var cls in classes)
            {
                if (string.IsNullOrWhiteSpace(cls))
                    continue;

                // Check if the class contains any of the known prefixes
                var matchingPrefix = KnownPrefixes.FirstOrDefault(prefix => cls.StartsWith(prefix));

                if (!string.IsNullOrEmpty(matchingPrefix))
                {
                    // Remove the prefix from the class
                    var classWithoutPrefix = cls.Substring(matchingPrefix.Length);
                    classGroups[matchingPrefix] = matchingPrefix + classWithoutPrefix; // Store or replace the class in its group
                }
                else
                {
                    // For classes without known prefixes, use the class as the key
                    classGroups[cls] = cls;
                }
            }

            return string.Join(" ", classGroups.Values);
        }
    }
}
