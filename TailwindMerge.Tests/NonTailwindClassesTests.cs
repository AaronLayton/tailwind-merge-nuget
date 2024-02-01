using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class NonTailwindClassesTest
{
    [Fact]
    public void DoesNotAlterNonTailwindClasses()
    {
        Assert.Equal("non-tailwind-class block", TW.Merge("non-tailwind-class inline block"));
        Assert.Equal("block inline-1", TW.Merge("inline block inline-1"));
        Assert.Equal("block i-inline", TW.Merge("inline block i-inline"));
        Assert.Equal("focus:block focus:inline-1", TW.Merge("focus:inline focus:block focus:inline-1"));
    }
}
