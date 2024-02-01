using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;
using System.ComponentModel.DataAnnotations;

namespace TailwindMerge.Tests;

public class TailwindCssVersionsTests
{
    [Fact]
    public void SupportsTailwindCssV33Features()
    {
        Assert.Equal("text-red text-lg/8", TW.Merge("text-red text-lg/7 text-lg/8"));
        Assert.Equal(
            "start-1 end-1 ps-1 pe-1 ms-1 me-1 rounded-s-md rounded-e-md rounded-ss-md rounded-ee-md",
            TW.Merge(
                "start-0 start-1",
                "end-0 end-1",
                "ps-0 ps-1 pe-0 pe-1",
                "ms-0 ms-1 me-0 me-1",
                "rounded-s-sm rounded-s-md rounded-e-sm rounded-e-md",
                "rounded-ss-sm rounded-ss-md rounded-ee-sm rounded-ee-md"
            )
        );
        Assert.Equal(
            "inset-0 p-0 m-0 rounded-s",
            TW.Merge("start-0 end-0 inset-0 ps-0 pe-0 p-0 ms-0 me-0 m-0 rounded-ss rounded-es rounded-s")
        );
        Assert.Equal("hyphens-manual", TW.Merge("hyphens-auto hyphens-manual"));
        Assert.Equal(
            "from-[12.5%] via-[12.5%] to-[12.5%]",
            TW.Merge("from-0% from-10% from-[12.5%] via-0% via-10% via-[12.5%] to-0% to-10% to-[12.5%]")
        );
        Assert.Equal("from-0% from-red", TW.Merge("from-0% from-red"));
        Assert.Equal(
            "list-image-[var(--value)]",
            TW.Merge("list-image-none list-image-[url(./my-image.png)] list-image-[var(--value)]")
        );
        Assert.Equal("caption-bottom", TW.Merge("caption-top caption-bottom"));
        Assert.Equal("line-clamp-[10]", TW.Merge("line-clamp-2 line-clamp-none line-clamp-[10]"));
        Assert.Equal("delay-0 duration-0", TW.Merge("delay-150 delay-0 duration-150 duration-0"));
        Assert.Equal("justify-stretch", TW.Merge("justify-normal justify-center justify-stretch"));
        Assert.Equal("content-stretch", TW.Merge("content-normal content-center content-stretch"));
        Assert.Equal("whitespace-break-spaces", TW.Merge("whitespace-nowrap whitespace-break-spaces"));
    }

    [Fact]
    public void SupportsTailwindCssV34Features()
    {
        Assert.Equal("h-dvh w-dvw", TW.Merge("h-svh h-dvh w-svw w-dvw"));
        Assert.Equal(
            "has-[[data-potato]]:p-2 group-has-[:checked]:flex",
            TW.Merge("has-[[data-potato]]:p-1 has-[[data-potato]]:p-2 group-has-[:checked]:grid group-has-[:checked]:flex")
        );
        Assert.Equal("text-pretty", TW.Merge("text-wrap text-pretty"));
        Assert.Equal("size-10 w-12", TW.Merge("w-5 h-3 size-10 w-12"));
        Assert.Equal(
            "grid-cols-subgrid grid-rows-subgrid",
            TW.Merge("grid-cols-2 grid-cols-subgrid grid-rows-5 grid-rows-subgrid")
        );
        Assert.Equal("min-w-px max-w-px", TW.Merge("min-w-0 min-w-50 min-w-px max-w-0 max-w-50 max-w-px"));
        Assert.Equal("forced-color-adjust-auto", TW.Merge("forced-color-adjust-none forced-color-adjust-auto"));
        Assert.Equal("appearance-auto", TW.Merge("appearance-none appearance-auto"));
        Assert.Equal("float-end clear-end", TW.Merge("float-start float-end clear-start clear-end"));
        Assert.Equal("*:p-20 hover:*:p-20", TW.Merge("*:p-10 *:p-20 hover:*:p-10 hover:*:p-20"));
    }
}
