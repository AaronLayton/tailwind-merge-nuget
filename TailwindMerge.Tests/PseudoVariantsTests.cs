using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class PseudoVariantsTests
{
    private readonly TailwindMerge _TW;

    public PseudoVariantsTests()
    {
        _TW = new TailwindMerge();
    }

    [Fact]
    public void HandlesPseudoVariantsConflictsProperly()
    {
        Assert.Equal("empty:p-3", _TW.Merge("empty:p-2 empty:p-3"));
        Assert.Equal("hover:empty:p-3", _TW.Merge("hover:empty:p-2 hover:empty:p-3"));
        Assert.Equal("read-only:p-3", _TW.Merge("read-only:p-2 read-only:p-3"));
    }

    [Fact]
    public void HandlesPseudoVariantGroupConflictsProperly()
    {
        Assert.Equal("group-empty:p-3", _TW.Merge("group-empty:p-2 group-empty:p-3"));
        Assert.Equal("peer-empty:p-3", _TW.Merge("peer-empty:p-2 peer-empty:p-3"));
        Assert.Equal("group-empty:p-2 peer-empty:p-3", _TW.Merge("group-empty:p-2 peer-empty:p-3"));
        Assert.Equal("hover:group-empty:p-3", _TW.Merge("hover:group-empty:p-2 hover:group-empty:p-3"));
        Assert.Equal("group-read-only:p-3", _TW.Merge("group-read-only:p-2 group-read-only:p-3"));
    }
}
