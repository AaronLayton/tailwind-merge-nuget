using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;
using System.ComponentModel.DataAnnotations;

namespace TailwindMerge.Tests;

public class TwMergeTests
{
    [Fact]
    public void TwMerge_Test()
    {
        Assert.Equal("mix-blend-multiply", TW.Merge("mix-blend-normal mix-blend-multiply"));
        Assert.Equal("h-min", TW.Merge("h-10 h-min"));
        Assert.Equal("stroke-black stroke-1", TW.Merge("stroke-black stroke-1"));
        Assert.Equal("stroke-[3]", TW.Merge("stroke-2 stroke-[3]"));
        Assert.Equal("outline-black outline-1", TW.Merge("outline-black outline-1"));
        Assert.Equal("grayscale-[50%]", TW.Merge("grayscale-0 grayscale-[50%]"));
        Assert.Equal("grow-[2]", TW.Merge("grow grow-[2]"));
        //Assert.Equal("grow-[2]", TW.Merge("grow", null, false, new object[] { new object[] { "grow-[2]" } }));
    }
}
