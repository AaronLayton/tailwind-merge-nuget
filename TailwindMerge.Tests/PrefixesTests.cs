using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class PrefixesTest
{
    [Fact]
    public void PrefixWorkingCorrectly()
    {
        //var twMerge = TailwindMerge.ExtendTailwindMerge(new TailwindMergeOptions
        //{
        //    Prefix = "tw-"
        //});

        //Assert.Equal("tw-hidden", twMerge("tw-block tw-hidden"));
        //Assert.Equal("block hidden", twMerge("block hidden"));

        //Assert.Equal("tw-p-2", twMerge("tw-p-3 tw-p-2"));
        //Assert.Equal("p-3 p-2", twMerge("p-3 p-2"));

        //Assert.Equal("!tw-inset-0", twMerge("!tw-right-0 !tw-inset-0"));

        //Assert.Equal("focus:hover:!tw-inset-0", twMerge("hover:focus:!tw-right-0 focus:hover:!tw-inset-0"));
    }
}
