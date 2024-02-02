namespace TailwindMerge.Utilities
{
    public class ThemeGetter
    {
        public string Key { get; }

        public ThemeGetter(string key)
        {
            Key = key;
        }

        public List<object> Execute(Dictionary<string, dynamic> theme)
        {
            return theme.TryGetValue(Key, out var value) ? value : new List<object>();
        }
    }
}
