using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class ImportantModifierTests
{
    private readonly TailwindMerge _TW;

    public ImportantModifierTests()
    {
        _TW = new TailwindMerge();
    }

    [Fact]
    public void MergesTailwindClassesWithImportantModifierCorrectly()
    {
        Assert.Equal("!font-bold", _TW.Merge("!font-medium !font-bold"));
        Assert.Equal("!font-bold font-thin", _TW.Merge("!font-medium !font-bold font-thin"));
        Assert.Equal("!-inset-x-px", _TW.Merge("!right-2 !-inset-x-px"));
        Assert.Equal("focus:!block", _TW.Merge("focus:!inline focus:!block"));
    }
}