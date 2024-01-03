using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
    }
}