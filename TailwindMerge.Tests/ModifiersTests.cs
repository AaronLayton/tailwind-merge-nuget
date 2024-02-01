using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class ModifiersTests
{
    [Fact]
    public void ConflictsAcrossPrefixModifiers()
    {
        Assert.Equal("hover:inline", TW.Merge("hover:block hover:inline"));
        Assert.Equal("hover:block hover:focus:inline", TW.Merge("hover:block hover:focus:inline"));
        Assert.Equal("hover:block focus:hover:inline", TW.Merge("hover:block hover:focus:inline focus:hover:inline"));
        Assert.Equal("focus-within:block", TW.Merge("focus-within:inline focus-within:block"));
    }

    [Fact]
    public void ConflictsAcrossPostfixModifiers()
    {
        Assert.Equal("text-lg/8", TW.Merge("text-lg/7 text-lg/8"));
        Assert.Equal("text-lg/none leading-9", TW.Merge("text-lg/none leading-9"));
        Assert.Equal("text-lg/none", TW.Merge("leading-9 text-lg/none"));
        Assert.Equal("w-1/2", TW.Merge("w-full w-1/2"));

        //var customTwMerge = CreateTailwindMerge(() => new
        //{
        //    cacheSize = 10,
        //    separator = ":",
        //    theme = new object(),
        //    classGroups = new
        //    {
        //        foo = new[] { "foo-1/2", "foo-2/3" },
        //        bar = new[] { "bar-1", "bar-2" },
        //        baz = new[] { "baz-1", "baz-2" }
        //    },
        //    conflictingClassGroups = new object(),
        //    conflictingClassGroupModifiers = new
        //    {
        //        baz = new[] { "bar" }
        //    }
        //});

        //Assert.Equal("foo-2/3", customTwMerge("foo-1/2 foo-2/3"));
        //Assert.Equal("bar-2", customTwMerge("bar-1 bar-2"));
        //Assert.Equal("bar-1 baz-1", customTwMerge("bar-1 baz-1"));
        //Assert.Equal("bar-2", customTwMerge("bar-1/2 bar-2"));
        //Assert.Equal("bar-1/2", customTwMerge("bar-2 bar-1/2"));
        //Assert.Equal("baz-1/2", customTwMerge("bar-1 baz-1/2"));
    }
}
