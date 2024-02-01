using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;


public class ContentUtilitiesTests
{
    [Fact]
    public void MergesContentUtilitiesCorrectly()
    {
        Assert.Equal("content-[attr(data-content)]", TW.Merge("content-['hello'] content-[attr(data-content)]"));
    }
}
