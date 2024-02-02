using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class NonTailwindClassesTest
{
    private readonly TailwindMerge _TW;

    public NonTailwindClassesTest()
    {
        _TW = new TailwindMerge();
    }

    [Fact]
    public void DoesNotAlterNonTailwindClasses()
    {
        Assert.Equal("non-tailwind-class block", _TW.Merge("non-tailwind-class inline block"));
        Assert.Equal("block inline-1", _TW.Merge("inline block inline-1"));
        Assert.Equal("block i-inline", _TW.Merge("inline block i-inline"));
        Assert.Equal("focus:block focus:inline-1", _TW.Merge("focus:inline focus:block focus:inline-1"));
    }
}
