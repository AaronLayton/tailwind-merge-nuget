using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class ArbitraryValuesTests
{

    private readonly TailwindMerge _TW;

    public ArbitraryValuesTests()
    {
        _TW = new TailwindMerge();
    }

    [Fact]
    public void HandlesSimpleConflictsWithArbitraryValuesCorrectly()
    {
        Assert.Equal("m-[10px]", _TW.Merge("m-[2px] m-[10px]"));
        Assert.Equal("m-[10dvh]", _TW.Merge("m-[2px] m-[11svmin] m-[12in] m-[13lvi] m-[14vb] m-[15vmax] m-[16mm] m-[17%] m-[18em] m-[19px] m-[10dvh]"));
        Assert.Equal("h-[16cqmax]", _TW.Merge("h-[10px] h-[11cqw] h-[12cqh] h-[13cqi] h-[14cqb] h-[15cqmin] h-[16cqmax]"));
        Assert.Equal("z-[99]", _TW.Merge("z-20 z-[99]"));
        Assert.Equal("m-[10rem]", _TW.Merge("my-[2px] m-[10rem]"));
        Assert.Equal("cursor-[grab]", _TW.Merge("cursor-pointer cursor-[grab]"));
        Assert.Equal("m-[calc(100%-var(--arbitrary))]", _TW.Merge("m-[2px] m-[calc(100%-var(--arbitrary))]"));
        Assert.Equal("m-[length:var(--mystery-var)]", _TW.Merge("m-[2px] m-[length:var(--mystery-var)]"));
        Assert.Equal("opacity-[0.025]", _TW.Merge("opacity-10 opacity-[0.025]"));
        Assert.Equal("scale-[1.7]", _TW.Merge("scale-75 scale-[1.7]"));
        Assert.Equal("brightness-[1.75]", _TW.Merge("brightness-90 brightness-[1.75]"));
        Assert.Equal("min-h-[0]", _TW.Merge("min-h-[0.5px] min-h-[0]"));
        // Add more assertions here as needed
    }

    [Fact]
    public void HandlesArbitraryLengthConflictsWithLabelsAndModifiersCorrectly()
    {
        Assert.Equal("hover:m-[length:var(--c)]", _TW.Merge("hover:m-[2px] hover:m-[length:var(--c)]"));
        Assert.Equal("focus:hover:m-[length:var(--c)]", _TW.Merge("hover:focus:m-[2px] focus:hover:m-[length:var(--c)]"));
        Assert.Equal("border-b border-[color:rgb(var(--color-gray-500-rgb)/50%))]", _TW.Merge("border-b border-[color:rgb(var(--color-gray-500-rgb)/50%))]"));
        Assert.Equal("border-[color:rgb(var(--color-gray-500-rgb)/50%))] border-b", _TW.Merge("border-[color:rgb(var(--color-gray-500-rgb)/50%))] border-b"));
        Assert.Equal("border-b border-some-coloooor", _TW.Merge("border-b border-[color:rgb(var(--color-gray-500-rgb)/50%))] border-some-coloooor"));
    }

    [Fact]
    public void HandlesComplexArbitraryValueConflictsCorrectly()
    {
        Assert.Equal("grid-rows-2", _TW.Merge("grid-rows-[1fr,auto] grid-rows-2"));
        Assert.Equal("grid-rows-3", _TW.Merge("grid-rows-[repeat(20,minmax(0,1fr))] grid-rows-3"));
    }

    [Fact]
    public void HandlesAmbiguousArbitraryValuesCorrectly()
    {
        Assert.Equal("mt-[calc(theme(fontSize.4xl)/1.125)]", _TW.Merge("mt-2 mt-[calc(theme(fontSize.4xl)/1.125)]"));
        Assert.Equal("p-[calc(theme(fontSize.4xl)/1.125)_10px]", _TW.Merge("p-2 p-[calc(theme(fontSize.4xl)/1.125)_10px]"));
        // Add more assertions here as needed
    }
}
