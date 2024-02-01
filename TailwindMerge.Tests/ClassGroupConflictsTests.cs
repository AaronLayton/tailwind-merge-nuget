using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class ClassGroupConflictsTests
{
    [Fact]
    public void MergesClassesFromSameGroupCorrectly()
    {
        Assert.Equal("overflow-x-hidden", TW.Merge("overflow-x-auto overflow-x-hidden"));
        Assert.Equal("basis-auto", TW.Merge("basis-full basis-auto"));
        Assert.Equal("w-fit", TW.Merge("w-full w-fit"));
        Assert.Equal("overflow-x-scroll", TW.Merge("overflow-x-auto overflow-x-hidden overflow-x-scroll"));
        Assert.Equal("hover:overflow-x-hidden overflow-x-scroll", TW.Merge("overflow-x-auto hover:overflow-x-hidden overflow-x-scroll"));
        Assert.Equal("hover:overflow-x-auto overflow-x-scroll", TW.Merge("overflow-x-auto hover:overflow-x-hidden hover:overflow-x-auto overflow-x-scroll"));
        Assert.Equal("col-span-full", TW.Merge("col-span-1 col-span-full"));
    }

    [Fact]
    public void MergesClassesFromFontVariantNumericSectionCorrectly()
    {
        Assert.Equal("lining-nums tabular-nums diagonal-fractions", TW.Merge("lining-nums tabular-nums diagonal-fractions"));
        Assert.Equal("tabular-nums diagonal-fractions", TW.Merge("normal-nums tabular-nums diagonal-fractions"));
        Assert.Equal("normal-nums", TW.Merge("tabular-nums diagonal-fractions normal-nums"));
        Assert.Equal("proportional-nums", TW.Merge("tabular-nums proportional-nums"));
    }
}