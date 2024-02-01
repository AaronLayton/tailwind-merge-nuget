using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class PerSideBorderColorsTests
{
    [Fact]
    public void MergesClassesWithPerSideBorderColorsCorrectly()
    {
        Assert.Equal("border-t-other-blue", TW.Merge("border-t-some-blue border-t-other-blue"));
        Assert.Equal("border-some-blue", TW.Merge("border-t-some-blue border-some-blue"));
    }
}
