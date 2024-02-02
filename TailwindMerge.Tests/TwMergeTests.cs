using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;
using System.ComponentModel.DataAnnotations;

namespace TailwindMerge.Tests;

public class TwMergeTests
{
    private readonly TailwindMerge _TW;

    public TwMergeTests()
    {
        _TW = new TailwindMerge();
    }

    [Fact]
    public void TwMerge_Test()
    {
        Assert.Equal("mix-blend-multiply", _TW.Merge("mix-blend-normal mix-blend-multiply"));
        Assert.Equal("h-min", _TW.Merge("h-10 h-min"));
        Assert.Equal("stroke-black stroke-1", _TW.Merge("stroke-black stroke-1"));
        Assert.Equal("stroke-[3]", _TW.Merge("stroke-2 stroke-[3]"));
        Assert.Equal("outline-black outline-1", _TW.Merge("outline-black outline-1"));
        Assert.Equal("grayscale-[50%]", _TW.Merge("grayscale-0 grayscale-[50%]"));
        Assert.Equal("grow-[2]", _TW.Merge("grow grow-[2]"));
        //Assert.Equal("grow-[2]", _TW.Merge("grow", null, false, new object[] { new object[] { "grow-[2]" } }));
    }
}
