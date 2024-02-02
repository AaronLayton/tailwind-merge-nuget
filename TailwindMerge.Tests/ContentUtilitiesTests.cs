using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;


public class ContentUtilitiesTests
{
    private readonly TailwindMerge _TW;

    public ContentUtilitiesTests()
    {
        _TW = new TailwindMerge();
    }

    [Fact]
    public void MergesContentUtilitiesCorrectly()
    {
        Assert.Equal("content-[attr(data-content)]", _TW.Merge("content-['hello'] content-[attr(data-content)]"));
    }
}
