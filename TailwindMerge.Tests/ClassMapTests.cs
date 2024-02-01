using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class ClassMapTests
{
    [Fact]
    public void ClassMap_HasCorrectClassGroupsAtFirstPart()
    {
        //var classMap = CreateClassMap(GetDefaultConfig());

        //var classGroupsByFirstPart = classMap.NextPart
        //    .ToDictionary(
        //        kvp => kvp.Key,
        //        kvp => kvp.Value.SelectMany(getClassGroupsInClassPart).OrderBy(group => group).ToList()
        //    );

        //Assert.Null(classMap.ClassGroupId);
        //Assert.Empty(classMap.Validators);
        //Assert.Equal(new Dictionary<string, List<string>>
        //{
        //    { "absolute", new List<string> { "position" } },
        //    { "accent", new List<string> { "accent" } },
        //    { "align", new List<string> { "vertical-align" } },
        //    { "animate", new List<string> { "animate" } },
        //    { "antialiased", new List<string> { "font-smoothing" } },
        //    { "appearance", new List<string> { "appearance" } },
        //    { "aspect", new List<string> { "aspect" } },
        //    { "auto", new List<string> { "auto-cols", "auto-rows" } },
        //    { "backdrop", new List<string>
        //        {
        //            "backdrop-blur",
        //            "backdrop-brightness",
        //            "backdrop-contrast",
        //            "backdrop-filter",
        //            "backdrop-grayscale",
        //            "backdrop-hue-rotate",
        //            "backdrop-invert",
        //            "backdrop-opacity",
        //            "backdrop-saturate",
        //            "backdrop-sepia"
        //        }
        //    },
        //    { "basis", new List<string> { "basis" } },
        //    { "bg", new List<string>
        //        {
        //            "bg-attachment",
        //            "bg-blend",
        //            "bg-clip",
        //            "bg-color",
        //            "bg-image",
        //            "bg-opacity",
        //            "bg-origin",
        //            "bg-position",
        //            "bg-repeat",
        //            "bg-size"
        //        }
        //    },
        //    { "block", new List<string> { "display" } },
        //    { "blur", new List<string> { "blur" } },
        //    { "border", new List<string>
        //        {
        //            "border-collapse",
        //            "border-color",
        //            "border-color-b",
        //            "border-color-l",
        //            "border-color-r",
        //            "border-color-t",
        //            "border-color-x",
        //            "border-color-y",
        //            "border-opacity",
        //            "border-spacing",
        //            "border-spacing-x",
        //            "border-spacing-y",
        //            "border-style",
        //            "border-w",
        //            "border-w-b",
        //            "border-w-e",
        //            "border-w-l",
        //            "border-w-r",
        //            "border-w-s",
        //            "border-w-t",
        //            "border-w-x",
        //            "border-w-y"
        //        }
        //    },
        //    { "bottom", new List<string> { "bottom" } },
        //    { "box", new List<string> { "box", "box-decoration" } },
        //    { "break", new List<string> { "break", "break-after", "break-before", "break-inside" } },
        //    { "brightness", new List<string> { "brightness" } },
        //    { "capitalize", new List<string> { "text-transform" } },
        //    { "caption", new List<string> { "caption" } },
        //    { "caret", new List<string> { "caret-color" } },
        //    { "clear", new List<string> { "clear" } },
        //    { "col", new List<string> { "col-end", "col-start", "col-start-end" } },
        //    { "collapse", new List<string> { "visibility" } },
        //    { "columns", new List<string> { "columns" } },
        //    { "container", new List<string> { "container" } },
        //    { "content", new List<string> { "align-content", "content" } },
        //    { "contents", new List<string> { "display" } },
        //    { "contrast", new List<string> { "contrast" } },
        //    { "cursor", new List<string> { "cursor" } },
        //    { "decoration", new List<string> { "text-decoration-color", "text-decoration-style", "text-decoration-thickness" } },
        //    { "delay", new List<string> { "delay" } },
        //    { "diagonal", new List<string> { "fvn-fraction" } },
        //    { "divide", new List<string>
        //        {
        //            "divide-color",
        //            "divide-opacity",
        //            "divide-style",
        //            "divide-x",
        //            "divide-x-reverse",
        //            "divide-y",
        //            "divide-y-reverse"
        //        }
        //    },
        //    { "drop", new List<string> { "drop-shadow" } },
        //    { "duration", new List<string> { "duration" } },
        //    { "ease", new List<string> { "ease" } },
        //    { "end", new List<string> { "end" } },
        //    { "fill", new List<string> { "fill" } },
        //    { "filter", new List<string> { "filter" } },
        //    { "fixed", new List<string> { "position" } },
        //    { "flex", new List<string> { "display", "flex", "flex-direction", "flex-wrap" } },
        //    { "float", new List<string> { "float" } },
        //    { "flow", new List<string> { "display" } },
        //    { "font", new List<string> { "font-family", "font-weight" } },
        //    { "forced", new List<string> { "forced-color-adjust" } },
        //    { "from", new List<string> { "gradient-from", "gradient-from-pos" } },
        //    { "gap", new List<string> { "gap", "gap-x", "gap-y" } },
        //    { "grayscale", new List<string> { "grayscale" } },
        //    { "grid", new List<string> { "display", "grid-cols", "grid-flow", "grid-rows" } },
        //    { "grow", new List<string> { "grow" } },
        //    { "h", new List<string> { "h" } },
        //    { "hidden", new List<string> { "display" } },
        //    { "hue", new List<string> { "hue-rotate" } },
        //    { "hyphens", new List<string> { "hyphens" } },
        //    { "indent", new List<string> { "indent" } },
        //    { "inline", new List<string> { "display" } },
        //    { "inset", new List<string> { "inset", "inset-x", "inset-y" } },
        //    { "invert", new List<string> { "invert" } },
        //    { "invisible", new List<string> { "visibility" } },
        //    { "isolate", new List<string> { "isolation" } },
        //    { "italic", new List<string> { "font-style" } },
        //    { "items", new List<string> { "align-items" } },
        //    { "justify", new List<string> { "justify-content", "justify-items", "justify-self" } },
        //    { "leading", new List<string> { "leading" } },
        //    { "left", new List<string> { "left" } },
        //    { "line", new List<string> { "line-clamp", "text-decoration" } },
        //    { "lining", new List<string> { "fvn-figure" } },
        //    { "list", new List<string> { "display", "list-image", "list-style-position", "list-style-type" } },
        //    { "lowercase", new List<string> { "text-transform" } },
        //    { "m", new List<string> { "m" } },
        //    { "max", new List<string> { "max-h", "max-w" } },
        //    { "mb", new List<string> { "mb" } },
        //    { "me", new List<string> { "me" } },
        //    { "min", new List<string> { "min-h", "min-w" } },
        //    { "mix", new List<string> { "mix-blend" } },
        //    { "ml", new List<string> { "ml" } },
        //    { "mr", new List<string> { "mr" } },
        //    { "ms", new List<string> { "ms" } },
        //    { "mt", new List<string> { "mt" } },
        //    { "mx", new List<string> { "mx" } },
        //    { "my", new List<string> { "my" } },
        //    { "no", new List<string> { "text-decoration" } },
        //    { "normal", new List<string> { "fvn-normal", "text-transform" } },
        //    { "not", new List<string> { "font-style", "sr" } },
        //    { "object", new List<string> { "object-fit", "object-position" } },
        //    { "oldstyle", new List<string> { "fvn-figure" } },
        //    { "opacity", new List<string> { "opacity" } },
        //    { "order", new List<string> { "order" } },
        //    { "ordinal", new List<string> { "fvn-ordinal" } },
        //    { "origin", new List<string> { "transform-origin" } },
        //    { "outline", new List<string> { "outline-color", "outline-offset", "outline-style", "outline-w" } },
        //    { "overflow", new List<string> { "overflow", "overflow-x", "overflow-y" } },
        //    { "overline", new List<string> { "text-decoration" } },
        //    { "overscroll", new List<string> { "overscroll", "overscroll-x", "overscroll-y" } },
        //    { "p", new List<string> { "p" } },
        //    { "pb", new List<string> { "pb" } },
        //    { "pe", new List<string> { "pe" } },
        //    { "pl", new List<string> { "pl" } },
        //    { "place", new List<string> { "place-content", "place-items", "place-self" } },
        //    { "placeholder", new List<string> { "placeholder-color", "placeholder-opacity" } },
        //    { "pointer", new List<string> { "pointer-events" } },
        //    { "pr", new List<string> { "pr" } },
        //    { "proportional", new List<string> { "fvn-spacing" } },
        //    { "ps", new List<string> { "ps" } },
        //    { "pt", new List<string> { "pt" } },
        //    { "px", new List<string> { "px" } },
        //    { "py", new List<string> { "py" } },
        //    { "relative", new List<string> { "position" } },
        //    { "resize", new List<string> { "resize" } },
        //    { "right", new List<string> { "right" } },
        //    { "ring", new List<string> { "ring-color", "ring-offset-color", "ring-offset-w", "ring-opacity", "ring-w", "ring-w-inset" } },
        //    { "rotate", new List<string> { "rotate" } },
        //    { "rounded", new List<string>
        //        {
        //            "rounded",
        //            "rounded-b",
        //            "rounded-bl",
        //            "rounded-br",
        //            "rounded-e",
        //            "rounded-ee",
        //            "rounded-es",
        //            "rounded-l",
        //            "rounded-r",
        //            "rounded-s",
        //            "rounded-se",
        //            "rounded-ss",
        //            "rounded-t",
        //            "rounded-tl",
        //            "rounded-tr"
        //        }
        //    },
        //    { "row", new List<string> { "row-end", "row-start", "row-start-end" } },
        //    { "saturate", new List<string> { "saturate" } },
        //    { "scale", new List<string> { "scale", "scale-x", "scale-y" } },
        //    { "scroll", new List<string>
        //        {
        //            "scroll-behavior",
        //            "scroll-m",
        //            "scroll-mb",
        //            "scroll-me",
        //            "scroll-ml",
        //            "scroll-mr",
        //            "scroll-ms",
        //            "scroll-mt",
        //            "scroll-mx",
        //            "scroll-my",
        //            "scroll-p",
        //            "scroll-pb",
        //            "scroll-pe",
        //            "scroll-pl",
        //            "scroll-pr",
        //            "scroll-ps",
        //            "scroll-pt",
        //            "scroll-px",
        //            "scroll-py"
        //        }
        //    },
        //    { "select", new List<string> { "select" } },
        //    { "self", new List<string> { "align-self" } },
        //    { "sepia", new List<string> { "sepia" } },
        //    { "shadow", new List<string> { "shadow", "shadow-color" } },
        //    { "shrink", new List<string> { "shrink" } },
        //    { "size", new List<string> { "size" } },
        //    { "skew", new List<string> { "skew-x", "skew-y" } },
        //    { "slashed", new List<string> { "fvn-slashed-zero" } },
        //    { "snap", new List<string> { "snap-align", "snap-stop", "snap-strictness", "snap-type" } },
        //    { "space", new List<string> { "space-x", "space-x-reverse", "space-y", "space-y-reverse" } },
        //    { "sr", new List<string> { "sr" } },
        //    { "stacked", new List<string> { "fvn-fraction" } },
        //    { "start", new List<string> { "start" } },
        //    { "static", new List<string> { "position" } },
        //    { "sticky", new List<string> { "position" } },
        //    { "stroke", new List<string> { "stroke", "stroke-w" } },
        //    { "subpixel", new List<string> { "font-smoothing" } },
        //    { "table", new List<string> { "display", "table-layout" } },
        //    { "tabular", new List<string> { "fvn-spacing" } },
        //    { "text", new List<string> { "font-size", "text-alignment", "text-color", "text-opacity", "text-overflow", "text-wrap" } },
        //    { "to", new List<string> { "gradient-to", "gradient-to-pos" } },
        //    { "top", new List<string> { "top" } },
        //    { "touch", new List<string> { "touch", "touch-pz", "touch-x", "touch-y" } },
        //    { "tracking", new List<string> { "tracking" } },
        //    { "transform", new List<string> { "transform" } },
        //    { "transition", new List<string> { "transition" } },
        //    { "translate", new List<string> { "translate-x", "translate-y" } },
        //    { "truncate", new List<string> { "text-overflow" } },
        //    { "underline", new List<string> { "text-decoration", "underline-offset" } },
        //    { "uppercase", new List<string> { "text-transform" } },
        //    { "via", new List<string> { "gradient-via", "gradient-via-pos" } },
        //    { "visible", new List<string> { "visibility" } },
        //    { "w", new List<string> { "w" } },
        //    { "whitespace", new List<string> { "whitespace" } },
        //    { "will", new List<string> { "will-change" } },
        //    { "z", new List<string> { "z" } }
        //}, new DictionaryComparer<string, List<string>>());
    }


    //private IEnumerable<string> getClassGroupsInClassPart(ClassPartObject classPart)
    //{
    //    var classGroups = new List<string>();

    //    if (classPart.ClassGroupId != null)
    //    {
    //        classGroups.Add(classPart.ClassGroupId);
    //    }

    //    foreach (var validator in classPart.Validators)
    //    {
    //        classGroups.Add(validator.ClassGroupId);
    //    }

    //    foreach (var nextClassPart in classPart.NextPart)
    //    {
    //        classGroups.AddRange(getClassGroupsInClassPart(nextClassPart));
    //    }

    //    return classGroups;
    //}
}
