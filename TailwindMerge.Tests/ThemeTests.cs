using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;
using System.ComponentModel.DataAnnotations;

namespace TailwindMerge.Tests;

public class ThemeTests
{
    [Fact]
    public void ThemeScaleCanBeExtended()
    {
        //var tailwindMerge = ExtendTailwindMerge(new
        //{
        //    extend = new
        //    {
        //        theme = new
        //        {
        //            spacing = new[] { "my-space" },
        //            margin = new[] { "my-margin" }
        //        }
        //    }
        //});

        //Assert.Equal("p-my-space p-my-margin", tailwindMerge("p-3 p-my-space p-my-margin"));
        //Assert.Equal("m-my-margin", tailwindMerge("m-3 m-my-space m-my-margin"));
    }

    [Fact]
    public void ThemeObjectCanBeExtended()
    {
        //var tailwindMerge = ExtendTailwindMerge<object, string>(new
        //{
        //    extend = new
        //    {
        //        theme = new
        //        {
        //            my_theme = new[] { "hallo", "hello" }
        //        },
        //        classGroups = new
        //        {
        //            px = new[] { new { px = new[] { FromTheme<string>("my-theme") } } }
        //        }
        //    }
        //});

        //Assert.Equal("p-3 p-hello p-hallo", tailwindMerge("p-3 p-hello p-hallo"));
        //Assert.Equal("px-hallo", tailwindMerge("px-3 px-hello px-hallo"));
    }
}
