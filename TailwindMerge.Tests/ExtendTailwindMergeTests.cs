using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class ExtendTailwindMergeTests
{
    [Fact]
    public void ExtendTailwindMergeWorksCorrectlyWithSingleConfig()
    {
        //var tailwindMerge = ExtendTailwindMerge<string>.Extend<string>(new ExtendTailwindMergeOptions<string>
        //{
        //    CacheSize = 20,
        //    Extend = new ExtendOptions<string>
        //    {
        //        ClassGroups = new ClassGroupsOptions<string>
        //        {
        //            FooKey = new[] { new { FooKey = new[] { "bar", "baz" } } },
        //            FooKey2 = new[] { new { FooKey = new[] { "qux", "quux" } }, "other-2" },
        //            OtherKey = new[] { "nother", "group" }
        //        },
        //        ConflictingClassGroups = new ConflictingClassGroupsOptions<string>
        //        {
        //            FooKey = new[] { "otherKey" },
        //            OtherKey = new[] { "fooKey", "fooKey2" }
        //        }
        //    }
        //});

        //Assert.Equal("", tailwindMerge(""));
        //Assert.Equal("my-modifier:fooKey-baz", tailwindMerge("my-modifier:fooKey-bar my-modifier:fooKey-baz"));
        //Assert.Equal("other-modifier:fooKey-baz", tailwindMerge("other-modifier:fooKey-bar other-modifier:fooKey-baz"));
        //Assert.Equal("fooKey-bar", tailwindMerge("group fooKey-bar"));
        //Assert.Equal("group", tailwindMerge("fooKey-bar group"));
        //Assert.Equal("group other-2", tailwindMerge("group other-2"));
        //Assert.Equal("group", tailwindMerge("other-2 group"));
        //Assert.Equal("p-20", tailwindMerge("p-10 p-20"));
        //Assert.Equal("focus:hover:p-20", tailwindMerge("hover:focus:p-10 focus:hover:p-20"));
    }

    [Fact]
    public void ExtendTailwindMergeWorksCorrectlyWithMultipleConfigs()
    {
        //var tailwindMerge = ExtendTailwindMerge<string>.Extend<string>(
        //    new ExtendTailwindMergeOptions<string>
        //    {
        //        CacheSize = 20,
        //        Extend = new ExtendOptions<string>
        //        {
        //            ClassGroups = new ClassGroupsOptions<string>
        //            {
        //                FooKey = new[] { new { FooKey = new[] { "bar", "baz" } } },
        //                FooKey2 = new[] { new { FooKey = new[] { "qux", "quux" } }, "other-2" },
        //                OtherKey = new[] { "nother", "group" }
        //            },
        //            ConflictingClassGroups = new ConflictingClassGroupsOptions<string>
        //            {
        //                FooKey = new[] { "otherKey" },
        //                OtherKey = new[] { "fooKey", "fooKey2" }
        //            }
        //        }
        //    },
        //    config => new ExtendTailwindMergeOptions<string>
        //    {
        //        CacheSize = config.CacheSize,
        //        ClassGroups = new ClassGroupsOptions<string>
        //        {
        //            SecondConfigKey = new[] { "hi-there", "hello" }
        //        }
        //    });

        //Assert.Equal("", tailwindMerge(""));
        //Assert.Equal("my-modifier:fooKey-baz", tailwindMerge("my-modifier:fooKey-bar my-modifier:fooKey-baz"));
        //Assert.Equal("other-modifier:hello", tailwindMerge("other-modifier:hi-there other-modifier:hello"));
        //Assert.Equal("fooKey-bar", tailwindMerge("group fooKey-bar"));
        //Assert.Equal("group", tailwindMerge("fooKey-bar group"));
        //Assert.Equal("group other-2", tailwindMerge("group other-2"));
        //Assert.Equal("group", tailwindMerge("other-2 group"));
        //Assert.Equal("p-20", tailwindMerge("p-10 p-20"));
        //Assert.Equal("focus:hover:p-20", tailwindMerge("hover:focus:p-10 focus:hover:p-20"));
    }

    [Fact]
    public void ExtendTailwindMergeWorksCorrectlyWithFunctionConfig()
    {
        //var tailwindMerge = ExtendTailwindMerge<string>.Extend<string>(config => new ExtendTailwindMergeOptions<string>
        //{
        //    CacheSize = 20,
        //    ClassGroups = new ClassGroupsOptions<string>
        //    {
        //        FooKey = new[] { new { FooKey = new[] { "bar", "baz" } } },
        //        FooKey2 = new[] { new { FooKey = new[] { "qux", "quux" } }, "other-2" },
        //        OtherKey = new[] { "nother", "group" }
        //    },
        //    ConflictingClassGroups = new ConflictingClassGroupsOptions<string>
        //    {
        //        FooKey = new[] { "otherKey" },
        //        OtherKey = new[] { "fooKey", "fooKey2" }
        //    }
        //});

        //Assert.Equal("", tailwindMerge(""));
        //Assert.Equal("my-modifier:fooKey-baz", tailwindMerge("my-modifier:fooKey-bar my-modifier:fooKey-baz"));
        //Assert.Equal("other-modifier:fooKey-baz", tailwindMerge("other-modifier:fooKey-bar other-modifier:fooKey-baz"));
        //Assert.Equal("fooKey-bar", tailwindMerge("group fooKey-bar"));
        //Assert.Equal("group", tailwindMerge("fooKey-bar group"));
        //Assert.Equal("group other-2", tailwindMerge("group other-2"));
        //Assert.Equal("group", tailwindMerge("other-2 group"));
        //Assert.Equal("p-20", tailwindMerge("p-10 p-20"));
        //Assert.Equal("focus:hover:p-20", tailwindMerge("hover:focus:p-10 focus:hover:p-20"));
    }

    [Fact]
    public void ExtendTailwindMergeOverridesAndExtendsCorrectly()
    {
        //var tailwindMerge = ExtendTailwindMerge<string>.Extend<string>(new ExtendTailwindMergeOptions<string>
        //{
        //    CacheSize = 20,
        //    Override = new OverrideOptions<string>
        //    {
        //        ClassGroups = new ClassGroupsOptions<string>
        //        {
        //            Shadow = new[] { "shadow-100", "shadow-200" },
        //            CustomKey = new[] { "custom-100" }
        //        },
        //        ConflictingClassGroups = new ConflictingClassGroupsOptions<string>
        //        {
        //            P = new[] { "px" }
        //        }
        //    },
        //    Extend = new ExtendOptions<string>
        //    {
        //        ClassGroups = new ClassGroupsOptions<string>
        //        {
        //            Shadow = new[] { "shadow-300" },
        //            CustomKey = new[] { "custom-200" },
        //            FontSize = new[] { "text-foo" }
        //        },
        //        ConflictingClassGroups = new ConflictingClassGroupsOptions<string>
        //        {
        //            M = new[] { "h" }
        //        }
        //    }
        //});

        //Assert.Equal("shadow-lg shadow-200", tailwindMerge("shadow-lg shadow-100 shadow-200"));
        //Assert.Equal("custom-200", tailwindMerge("custom-100 custom-200"));
        //Assert.Equal("text-foo", tailwindMerge("text-lg text-foo"));
        //Assert.Equal("py-3 p-3", tailwindMerge("px-3 py-3 p-3"));
        //Assert.Equal("p-3 px-3 py-3", tailwindMerge("p-3 px-3 py-3"));
        //Assert.Equal("m-2", tailwindMerge("mx-2 my-2 h-2 m-2"));
        //Assert.Equal("m-2 mx-2 my-2 h-2", tailwindMerge("m-2 mx-2 my-2 h-2"));
    }
}
