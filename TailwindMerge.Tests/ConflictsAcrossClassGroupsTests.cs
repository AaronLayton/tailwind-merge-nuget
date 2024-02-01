using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class ConflictsAcrossClassGroupsTests
{
    [Fact]
    public void HandlesConflictsAcrossClassGroupsCorrectly()
    {
        Assert.Equal("inset-1 inset-x-1", TW.Merge("inset-1 inset-x-1"));
        Assert.Equal("inset-1", TW.Merge("inset-x-1 inset-1"));
        Assert.Equal("inset-1", TW.Merge("inset-x-1 left-1 inset-1"));
        Assert.Equal("inset-1 left-1", TW.Merge("inset-x-1 inset-1 left-1"));
        Assert.Equal("inset-1", TW.Merge("inset-x-1 right-1 inset-1"));
        Assert.Equal("inset-x-1", TW.Merge("inset-x-1 right-1 inset-x-1"));
        Assert.Equal("inset-x-1 right-1 inset-y-1", TW.Merge("inset-x-1 right-1 inset-y-1"));
        Assert.Equal("inset-x-1 inset-y-1", TW.Merge("right-1 inset-x-1 inset-y-1"));
        Assert.Equal("hover:left-1 inset-1", TW.Merge("inset-x-1 hover:left-1 inset-1"));
    }

    [Fact]
    public void RingAndShadowClassesDoNotCreateConflict()
    {
        Assert.Equal("ring shadow", TW.Merge("ring shadow"));
        Assert.Equal("ring-2 shadow-md", TW.Merge("ring-2 shadow-md"));
        Assert.Equal("shadow ring", TW.Merge("shadow ring"));
        Assert.Equal("shadow-md ring-2", TW.Merge("shadow-md ring-2"));
    }

    [Fact]
    public void TouchClassesDoCreateConflictsCorrectly()
    {
        Assert.Equal("touch-pan-right", TW.Merge("touch-pan-x touch-pan-right"));
        Assert.Equal("touch-pan-x", TW.Merge("touch-none touch-pan-x"));
        Assert.Equal("touch-none", TW.Merge("touch-pan-x touch-none"));
        Assert.Equal("touch-pan-x touch-pan-y touch-pinch-zoom", TW.Merge("touch-pan-x touch-pan-y touch-pinch-zoom"));
        Assert.Equal("touch-pan-x touch-pan-y touch-pinch-zoom", TW.Merge("touch-manipulation touch-pan-x touch-pan-y touch-pinch-zoom"));
        Assert.Equal("touch-auto", TW.Merge("touch-pan-x touch-pan-y touch-pinch-zoom touch-auto"));
    }

    [Fact]
    public void LineClampClassesDoCreateConflictsCorrectly()
    {
        Assert.Equal("line-clamp-1", TW.Merge("overflow-auto inline line-clamp-1"));
        Assert.Equal("line-clamp-1 overflow-auto inline", TW.Merge("line-clamp-1 overflow-auto inline"));
    }
}
