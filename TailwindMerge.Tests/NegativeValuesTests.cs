using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class NegativeValuesTests
{
    private readonly TailwindMerge _TW;

    public NegativeValuesTests()
    {
        _TW = new TailwindMerge();
    }

    [Fact]
    public void HandlesNegativeValueConflictsCorrectly()
    {
        Assert.Equal("-m-5", _TW.Merge("-m-2 -m-5"));
        Assert.Equal("-top-2000", _TW.Merge("-top-12 -top-2000"));
    }

    [Fact]
    public void HandlesConflictsBetweenPositiveAndNegativeValuesCorrectly()
    {
        Assert.Equal("m-auto", _TW.Merge("-m-2 m-auto"));
        Assert.Equal("-top-69", _TW.Merge("top-12 -top-69"));
    }

    [Fact]
    public void HandlesConflictsAcrossGroupsWithNegativeValuesCorrectly()
    {
        Assert.Equal("inset-x-1", _TW.Merge("-right-1 inset-x-1"));
        Assert.Equal("focus:hover:inset-x-1", _TW.Merge("hover:focus:-right-1 focus:hover:inset-x-1"));
    }
}
