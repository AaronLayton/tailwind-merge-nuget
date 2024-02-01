using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;
using System.ComponentModel.DataAnnotations;

namespace TailwindMerge.Tests;

public class StandaloneClassesTests
{
    [Fact]
    public void MergesStandaloneClassesFromSameGroupCorrectly()
    {
        Assert.Equal("block", TW.Merge("inline block"));
        Assert.Equal("hover:inline", TW.Merge("hover:block hover:inline"));
        Assert.Equal("hover:block", TW.Merge("hover:block hover:block"));
        Assert.Equal("inline focus:inline hover:block hover:focus:block", TW.Merge("inline hover:inline focus:inline hover:block hover:focus:block"));
        Assert.Equal("line-through", TW.Merge("underline line-through"));
        Assert.Equal("no-underline", TW.Merge("line-through no-underline"));
    }
}
