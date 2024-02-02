using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class ColoursTests
{
    private readonly TailwindMerge _TW;

    public ColoursTests()
    {
        _TW = new TailwindMerge();
    }

    [Fact]
    public void HandlesColorConflictsProperly()
    {
        Assert.Equal("bg-hotpink", _TW.Merge("bg-grey-5 bg-hotpink"));
        Assert.Equal("hover:bg-hotpink", _TW.Merge("hover:bg-grey-5 hover:bg-hotpink"));
        Assert.Equal("stroke-[hsl(350_80%_0%)] stroke-[10px]", _TW.Merge("stroke-[hsl(350_80%_0%)] stroke-[10px]"));
    }
}