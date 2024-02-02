using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;
using System.ComponentModel.DataAnnotations;

namespace TailwindMerge.Tests;

public class StandaloneClassesTests
{
    private readonly TailwindMerge _TW;

    public StandaloneClassesTests()
    {
        _TW = new TailwindMerge();
    }

    [Fact]
    public void MergesStandaloneClassesFromSameGroupCorrectly()
    {
        Assert.Equal("block", _TW.Merge("inline block"));
        Assert.Equal("hover:inline", _TW.Merge("hover:block hover:inline"));
        Assert.Equal("hover:block", _TW.Merge("hover:block hover:block"));
        Assert.Equal("inline focus:inline hover:block hover:focus:block", _TW.Merge("inline hover:inline focus:inline hover:block hover:focus:block"));
        Assert.Equal("line-through", _TW.Merge("underline line-through"));
        Assert.Equal("no-underline", _TW.Merge("line-through no-underline"));
    }
}
