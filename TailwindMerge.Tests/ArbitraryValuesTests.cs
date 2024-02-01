using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class ArbitraryValuesTests
{
    [Fact]
    public void HandlesSimpleConflictsWithArbitraryValuesCorrectly()
    {
        Assert.Equal("m-[10px]", TW.Merge("m-[2px] m-[10px]"));
        Assert.Equal("m-[10dvh]", TW.Merge("m-[2px] m-[11svmin] m-[12in] m-[13lvi] m-[14vb] m-[15vmax] m-[16mm] m-[17%] m-[18em] m-[19px] m-[10dvh]"));
        Assert.Equal("h-[16cqmax]", TW.Merge("h-[10px] h-[11cqw] h-[12cqh] h-[13cqi] h-[14cqb] h-[15cqmin] h-[16cqmax]"));
        Assert.Equal("z-[99]", TW.Merge("z-20 z-[99]"));
        Assert.Equal("m-[10rem]", TW.Merge("my-[2px] m-[10rem]"));
        Assert.Equal("cursor-[grab]", TW.Merge("cursor-pointer cursor-[grab]"));
        Assert.Equal("m-[calc(100%-var(--arbitrary))]", TW.Merge("m-[2px] m-[calc(100%-var(--arbitrary))]"));
        Assert.Equal("m-[length:var(--mystery-var)]", TW.Merge("m-[2px] m-[length:var(--mystery-var)]"));
        Assert.Equal("opacity-[0.025]", TW.Merge("opacity-10 opacity-[0.025]"));
        Assert.Equal("scale-[1.7]", TW.Merge("scale-75 scale-[1.7]"));
        Assert.Equal("brightness-[1.75]", TW.Merge("brightness-90 brightness-[1.75]"));
        Assert.Equal("min-h-[0]", TW.Merge("min-h-[0.5px] min-h-[0]"));
        // Add more assertions here as needed
    }

    [Fact]
    public void HandlesArbitraryLengthConflictsWithLabelsAndModifiersCorrectly()
    {
        Assert.Equal("hover:m-[length:var(--c)]", TW.Merge("hover:m-[2px] hover:m-[length:var(--c)]"));
        Assert.Equal("focus:hover:m-[length:var(--c)]", TW.Merge("hover:focus:m-[2px] focus:hover:m-[length:var(--c)]"));
        Assert.Equal("border-b border-[color:rgb(var(--color-gray-500-rgb)/50%))]", TW.Merge("border-b border-[color:rgb(var(--color-gray-500-rgb)/50%))]"));
        Assert.Equal("border-[color:rgb(var(--color-gray-500-rgb)/50%))] border-b", TW.Merge("border-[color:rgb(var(--color-gray-500-rgb)/50%))] border-b"));
        Assert.Equal("border-b border-some-coloooor", TW.Merge("border-b border-[color:rgb(var(--color-gray-500-rgb)/50%))] border-some-coloooor"));
    }

    [Fact]
    public void HandlesComplexArbitraryValueConflictsCorrectly()
    {
        Assert.Equal("grid-rows-2", TW.Merge("grid-rows-[1fr,auto] grid-rows-2"));
        Assert.Equal("grid-rows-3", TW.Merge("grid-rows-[repeat(20,minmax(0,1fr))] grid-rows-3"));
    }

    [Fact]
    public void HandlesAmbiguousArbitraryValuesCorrectly()
    {
        Assert.Equal("mt-[calc(theme(fontSize.4xl)/1.125)]", TW.Merge("mt-2 mt-[calc(theme(fontSize.4xl)/1.125)]"));
        Assert.Equal("p-[calc(theme(fontSize.4xl)/1.125)_10px]", TW.Merge("p-2 p-[calc(theme(fontSize.4xl)/1.125)_10px]"));
        // Add more assertions here as needed
    }
}
