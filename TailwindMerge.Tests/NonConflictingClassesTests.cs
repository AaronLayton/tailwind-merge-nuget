using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class NonConflictingClassesTests
{
    [Fact]
    public void MergesNonConflictingClassesCorrectly()
    {
        Assert.Equal("border-t border-white/10", TW.Merge("border-t border-white/10"));
        Assert.Equal("border-t border-white", TW.Merge("border-t border-white"));
        Assert.Equal("text-3.5xl text-black", TW.Merge("text-3.5xl text-black"));
    }
}
