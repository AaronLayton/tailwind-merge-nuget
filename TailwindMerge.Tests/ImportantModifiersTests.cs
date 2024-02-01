using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class ImportantModifierTests
{
    [Fact]
    public void MergesTailwindClassesWithImportantModifierCorrectly()
    {
        Assert.Equal("!font-bold", TW.Merge("!font-medium !font-bold"));
        Assert.Equal("!font-bold font-thin", TW.Merge("!font-medium !font-bold font-thin"));
        Assert.Equal("!-inset-x-px", TW.Merge("!right-2 !-inset-x-px"));
        Assert.Equal("focus:!block", TW.Merge("focus:!inline focus:!block"));
    }
}