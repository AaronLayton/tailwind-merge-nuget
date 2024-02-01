using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;
using System.ComponentModel.DataAnnotations;

namespace TailwindMerge.Tests;

public class SeparatorsTests
{
    [Fact]
    public void SingleCharacterSeparatorWorkingCorrectly()
    {
        //var twMerge = TailwindMerge.ExtendTailwindMerge(new TailwindMergeOptions
        //{
        //    Separator = "_"
        //});

        //Assert.Equal("hidden", twMerge("block hidden"));
        //Assert.Equal("p-2", twMerge("p-3 p-2"));
        //Assert.Equal("!inset-0", twMerge("!right-0 !inset-0"));
        //Assert.Equal("focus_hover_!inset-0", twMerge("hover_focus_!right-0 focus_hover_!inset-0"));
        //Assert.Equal("hover:focus:!right-0 focus:hover:!inset-0", twMerge("hover:focus:!right-0 focus:hover:!inset-0"));
    }

    [Fact]
    public void MultipleCharacterSeparatorWorkingCorrectly()
    {
        //var twMerge = TailwindMerge.ExtendTailwindMerge(new TailwindMergeOptions
        //{
        //    Separator = "__"
        //});

        //Assert.Equal("hidden", twMerge("block hidden"));
        //Assert.Equal("p-2", twMerge("p-3 p-2"));
        //Assert.Equal("!inset-0", twMerge("!right-0 !inset-0"));
        //Assert.Equal("focus__hover__!inset-0", twMerge("hover__focus__!right-0 focus__hover__!inset-0"));
        //Assert.Equal("hover:focus:!right-0 focus:hover:!inset-0", twMerge("hover:focus:!right-0 focus:hover:!inset-0"));
    }
}
