using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class ConflictsAcrossClassGroupsTests
{
    private readonly TailwindMerge _TW;

    public ConflictsAcrossClassGroupsTests()
    {
        _TW = new TailwindMerge();
    }

    [Fact]
    public void HandlesConflictsAcrossClassGroupsCorrectly()
    {
        Assert.Equal("inset-1 inset-x-1", _TW.Merge("inset-1 inset-x-1"));
        Assert.Equal("inset-1", _TW.Merge("inset-x-1 inset-1"));
        Assert.Equal("inset-1", _TW.Merge("inset-x-1 left-1 inset-1"));
        Assert.Equal("inset-1 left-1", _TW.Merge("inset-x-1 inset-1 left-1"));
        Assert.Equal("inset-1", _TW.Merge("inset-x-1 right-1 inset-1"));
        Assert.Equal("inset-x-1", _TW.Merge("inset-x-1 right-1 inset-x-1"));
        Assert.Equal("inset-x-1 right-1 inset-y-1", _TW.Merge("inset-x-1 right-1 inset-y-1"));
        Assert.Equal("inset-x-1 inset-y-1", _TW.Merge("right-1 inset-x-1 inset-y-1"));
        Assert.Equal("hover:left-1 inset-1", _TW.Merge("inset-x-1 hover:left-1 inset-1"));
    }

    [Fact]
    public void RingAndShadowClassesDoNotCreateConflict()
    {
        Assert.Equal("ring shadow", _TW.Merge("ring shadow"));
        Assert.Equal("ring-2 shadow-md", _TW.Merge("ring-2 shadow-md"));
        Assert.Equal("shadow ring", _TW.Merge("shadow ring"));
        Assert.Equal("shadow-md ring-2", _TW.Merge("shadow-md ring-2"));
    }

    [Fact]
    public void TouchClassesDoCreateConflictsCorrectly()
    {
        Assert.Equal("touch-pan-right", _TW.Merge("touch-pan-x touch-pan-right"));
        Assert.Equal("touch-pan-x", _TW.Merge("touch-none touch-pan-x"));
        Assert.Equal("touch-none", _TW.Merge("touch-pan-x touch-none"));
        Assert.Equal("touch-pan-x touch-pan-y touch-pinch-zoom", _TW.Merge("touch-pan-x touch-pan-y touch-pinch-zoom"));
        Assert.Equal("touch-pan-x touch-pan-y touch-pinch-zoom", _TW.Merge("touch-manipulation touch-pan-x touch-pan-y touch-pinch-zoom"));
        Assert.Equal("touch-auto", _TW.Merge("touch-pan-x touch-pan-y touch-pinch-zoom touch-auto"));
    }

    [Fact]
    public void LineClampClassesDoCreateConflictsCorrectly()
    {
        Assert.Equal("line-clamp-1", _TW.Merge("overflow-auto inline line-clamp-1"));
        Assert.Equal("line-clamp-1 overflow-auto inline", _TW.Merge("line-clamp-1 overflow-auto inline"));
    }
}
