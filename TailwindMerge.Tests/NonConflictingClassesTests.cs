using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class NonConflictingClassesTests
{
    private readonly TailwindMerge _TW;

    public NonConflictingClassesTests()
    {
        _TW = new TailwindMerge();
    }

    [Fact]
    public void MergesNonConflictingClassesCorrectly()
    {
        Assert.Equal("border-t border-white/10", _TW.Merge("border-t border-white/10"));
        Assert.Equal("border-t border-white", _TW.Merge("border-t border-white"));
        Assert.Equal("text-3.5xl text-black", _TW.Merge("text-3.5xl text-black"));
    }
}
