using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TailwindMerge
{
    /// <summary>
    /// Provides methods for merging Tailwind CSS classes.
    /// </summary>
    public class Validators
    {
        private static readonly Regex ArbitraryValueRegex = new Regex(@"^\[(?:([a-z-]+):)?(.+)\]$", RegexOptions.IgnoreCase);
        private static readonly Regex FractionRegex = new Regex(@"^\d+\/\d+$");
        private static readonly HashSet<string> StringLengths = new HashSet<string> { "px", "full", "screen" };
        private static readonly Regex TshirtUnitRegex = new Regex(@"^(\d+(\.\d+)?)?(xs|sm|md|lg|xl)$");
        private static readonly Regex LengthUnitRegex = new Regex(
            @"\d+(%|px|r?em|[sdl]?v([hwib]|min|max)|pt|pc|in|cm|mm|cap|ch|ex|r?lh|cq(w|h|i|b|min|max))|\b(calc|min|max|clamp)\(.+\)|^0$");
        private static readonly Regex ShadowRegex = new Regex(@"^-?((\d+)?\.?(\d+)[a-z]+|0)_-?((\d+)?\.?(\d+)[a-z]+|0)");
        private static readonly Regex ImageRegex = new Regex(
            @"^(url|image|image-set|cross-fade|element|(repeating-)?(linear|radial|conic)-gradient)\(.+\)$");

        public static bool IsLength(string value)
        {
            return IsNumber(value) || StringLengths.Contains(value) || FractionRegex.IsMatch(value);
        }

        public static bool IsArbitraryLength(string value)
        {
            return GetIsArbitraryValue(value, "length", IsLengthOnly);
        }

        public static bool IsNumber(string value)
        {
            return !string.IsNullOrEmpty(value) && double.TryParse(value, out _);
        }

        public static bool IsArbitraryNumber(string value)
        {
            return GetIsArbitraryValue(value, "number", IsNumber);
        }

        public static bool IsInteger(string value)
        {
            return !string.IsNullOrEmpty(value) && int.TryParse(value, out _);
        }

        public static bool IsPercent(string value)
        {
            return value.EndsWith("%") && IsNumber(value[..^1]);
        }

        public static bool IsArbitraryValue(string value)
        {
            return ArbitraryValueRegex.IsMatch(value);
        }

        public static bool IsTshirtSize(string value)
        {
            return TshirtUnitRegex.IsMatch(value);
        }

        private static readonly HashSet<string> SizeLabels = new HashSet<string> { "length", "size", "percentage" };

        public static bool IsArbitrarySize(string value)
        {
            return GetIsArbitraryValue(value, SizeLabels, IsNever);
        }

        public static bool IsArbitraryPosition(string value)
        {
            return GetIsArbitraryValue(value, "position", IsNever);
        }

        private static readonly HashSet<string> ImageLabels = new HashSet<string> { "image", "url" };

        public static bool IsArbitraryImage(string value)
        {
            return GetIsArbitraryValue(value, ImageLabels, IsImage);
        }

        public static bool IsArbitraryShadow(string value)
        {
            return GetIsArbitraryValue(value, string.Empty, IsShadow);
        }

        public static bool IsAny()
        {
            return true;
        }

        private static bool GetIsArbitraryValue(string value, object label, Func<string, bool> testValue)
        {
            var match = ArbitraryValueRegex.Match(value);

            if (match.Success)
            {
                if (!string.IsNullOrEmpty(match.Groups[1].Value))
                {
                    if (label is string strLabel)
                        return match.Groups[1].Value == strLabel;
                    if (label is HashSet<string> setLabel)
                        return setLabel.Contains(match.Groups[1].Value);
                }

                return testValue(match.Groups[2].Value);
            }

            return false;
        }

        private static bool IsLengthOnly(string value)
        {
            return LengthUnitRegex.IsMatch(value);
        }

        private static bool IsNever(string value)
        {
            return false;
        }

        private static bool IsShadow(string value)
        {
            return ShadowRegex.IsMatch(value);
        }

        private static bool IsImage(string value)
        {
            return ImageRegex.IsMatch(value);
        }
    }
}