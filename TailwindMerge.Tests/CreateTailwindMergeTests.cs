using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class CreateTailwindMergeTests
{
    [Fact]
    public void CreateTailwindMergeWorksWithSingleConfigFunction()
    {
        //var TW.Merge = CreateTailwindMerge(() => new
        //{
        //    cacheSize = 20,
        //    separator = ":",
        //    theme = new object(),
        //    classGroups = new
        //    {
        //        fooKey = new[] { new { fooKey = new[] { "bar", "baz" } } },
        //        fooKey2 = new[] { new { fooKey = new[] { "qux", "quux" } }, "other-2" },
        //        otherKey = new[] { "nother", "group" }
        //    },
        //    conflictingClassGroups = new
        //    {
        //        fooKey = new[] { "otherKey" },
        //        otherKey = new[] { "fooKey", "fooKey2" }
        //    },
        //    conflictingClassGroupModifiers = new object()
        //});

        //Assert.Equal("", TW.Merge(""));
        //Assert.Equal("my-modifier:fooKey-baz", TW.Merge("my-modifier:fooKey-bar my-modifier:fooKey-baz"));
        //Assert.Equal("other-modifier:fooKey-baz", TW.Merge("other-modifier:fooKey-bar other-modifier:fooKey-baz"));
        //Assert.Equal("fooKey-bar", TW.Merge("group fooKey-bar"));
        //Assert.Equal("group", TW.Merge("fooKey-bar group"));
        //Assert.Equal("group other-2", TW.Merge("group other-2"));
        //Assert.Equal("group", TW.Merge("other-2 group"));

        //// eslint-disable-next-line @typescript-eslint/no-unused-vars
        //void NoRun()
        //{
        //    CreateTailwindMerge((config) =>
        //    {
        //        return config;
        //    });
        //}
    }

    [Fact]
    public void CreateTailwindMergeWorksWithMultipleConfigFunctions()
    {
        //var TW.Merge = CreateTailwindMerge(
        //    () => new
        //    {
        //        cacheSize = 20,
        //        separator = ":",
        //        theme = new object(),
        //        classGroups = new
        //        {
        //            fooKey = new[] { new { fooKey = new[] { "bar", "baz" } } },
        //            fooKey2 = new[] { new { fooKey = new[] { "qux", "quux" } }, "other-2" },
        //            otherKey = new[] { "nother", "group" }
        //        },
        //        conflictingClassGroups = new
        //        {
        //            fooKey = new[] { "otherKey" },
        //            otherKey = new[] { "fooKey", "fooKey2" }
        //        },
        //        conflictingClassGroupModifiers = new object()
        //    },
        //    (config) => new
        //    {
        //        config,
        //        classGroups = new
        //        {
        //            config.classGroups,
        //            helloFromSecondConfig = new[] { "hello-there" }
        //        },
        //        conflictingClassGroups = new
        //        {
        //            config.conflictingClassGroups,
        //            fooKey = (config.conflictingClassGroups.fooKey ?? new string[0]).Concat(new[] { "helloFromSecondConfig" }).ToArray()
        //        }
        //    });

        //Assert.Equal("", TW.Merge(""));
        //Assert.Equal("my-modifier:fooKey-baz", TW.Merge("my-modifier:fooKey-bar my-modifier:fooKey-baz"));
        //Assert.Equal("other-modifier:fooKey-baz", TW.Merge("other-modifier:fooKey-bar other-modifier:fooKey-baz"));
        //Assert.Equal("fooKey-bar", TW.Merge("group fooKey-bar"));
        //Assert.Equal("group", TW.Merge("fooKey-bar group"));
        //Assert.Equal("group other-2", TW.Merge("group other-2"));
        //Assert.Equal("group", TW.Merge("other-2 group"));
        //Assert.Equal("second:nother", TW.Merge("second:group second:nother"));
        //Assert.Equal("fooKey-bar hello-there", TW.Merge("fooKey-bar hello-there"));
        //Assert.Equal("fooKey-bar", TW.Merge("hello-there fooKey-bar"));
    }

}
