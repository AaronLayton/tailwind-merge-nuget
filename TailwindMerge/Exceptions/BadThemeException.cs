using System;

namespace TailwindMerge.Exceptions
{
    public class BadThemeException : Exception
    {
        public TailwindMergeConfig Config { get; }

        public BadThemeException(string message, TailwindMergeConfig config)
            : base(message)
        {
            Config = config;
        }
    }
}
