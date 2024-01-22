using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TailwindMerge.Utilities;

namespace TailwindMerge
{
    /// <summary>
    /// Provides methods for merging Tailwind CSS classes.
    /// </summary>
    public class DefaultConfig
    {
         public DefaultConfig()
        {
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

            
        }

        public static string[] GetOverscroll() => new[] { "auto", "contain", "none" };
        public static string[] GetOverflow() => new[] { "auto", "hidden", "clip", "visible", "scroll" };
        public static object[] GetSpacingWithAutoAndArbitrary() => new object[] { "auto", new Func<string, bool>(Validators.IsArbitraryValue), new Func<string, bool>(Validators.IsLength) };


        public static object[] GetSpacingWithArbitrary() => new object[] { Validators.IsArbitraryValue, Validators.IsLength };

        public static object[] GetLengthWithEmptyAndArbitrary() => new object[] { "", Validators.IsLength, Validators.IsArbitraryLength };

        public static object[] GetNumberWithAutoAndArbitrary() => new object[] { "auto", Validators.IsNumber, Validators.IsArbitraryValue };

        public static string[] GetPositions() => new[] { "bottom", "center", "left", "left-bottom", "left-top", "right", "right-bottom", "right-top", "top" };
        public static string[] GetLineStyles() => new[] { "solid", "dashed", "dotted", "double", "none" };
        public static string[] GetBlendModes() => new[] { "normal", "multiply", "screen", "overlay", "darken", "lighten", "color-dodge", "color-burn", "hard-light", "soft-light", "difference", "exclusion", "hue", "saturation", "color", "luminosity", "plus-lighter" };
        public static string[] GetAlign() => new[] { "start", "end", "center", "between", "around", "evenly", "stretch" };
        public static object[] GetZeroAndEmpty() => new object[] { "", "0", Validators.IsArbitraryValue };

        public static string[] GetBreaks() => new[] { "auto", "avoid", "all", "avoid-page", "page", "left", "right", "column" };
        public static Func<string, bool>[] GetNumber() => new Func<string, bool>[] { Validators.IsNumber, Validators.IsArbitraryNumber };


        public static Func<string, bool>[] GetNumberAndArbitrary() => new Func<string, bool>[] { Validators.IsNumber, Validators.IsArbitraryValue };


    }
}