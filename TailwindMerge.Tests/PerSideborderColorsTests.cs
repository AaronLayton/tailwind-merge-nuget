using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class PerSideBorderColorsTests
{
    private readonly TailwindMerge _TW;

    public PerSideBorderColorsTests()
    {
        _TW = new TailwindMerge();
    }

    [Fact]
    public void MergesClassesWithPerSideBorderColorsCorrectly()
    {
        Assert.Equal("border-t-other-blue", _TW.Merge("border-t-some-blue border-t-other-blue"));
        Assert.Equal("border-some-blue", _TW.Merge("border-t-some-blue border-some-blue"));
    }
}
