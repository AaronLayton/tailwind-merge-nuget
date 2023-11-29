namespace TailwindMerge
{
    /// <summary>
    /// Provides methods for merging Tailwind CSS classes.
    /// </summary>
    public static class TW
{
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
            {
                continue;
            }

            var parts = cls.Split(new char[] { '-' }, 2);
            var key = parts[0];  // Group classes by the prefix (before the first hyphen)

            if (parts.Length > 1) 
            {
                classGroups[key] = cls;  // Store or replace the class in its group
            }
            else
            {
                // Handle classes without a hyphen, assuming they don't belong to any group
                if (!classGroups.ContainsKey(cls))
                {
                    classGroups[cls] = cls;
                }
            }
        }

        return string.Join(" ", classGroups.Values);
    }
}
}
