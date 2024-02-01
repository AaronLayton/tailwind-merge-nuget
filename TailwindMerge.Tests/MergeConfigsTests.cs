using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class MergeConfigsTests
{
    [Fact]
    public void MergeConfigs_HasCorrectBehavior()
    {
        //var result = MergeConfigs.MergeConfigs(
        //    new MergeConfigs.Config
        //    {
        //        CacheSize = 50,
        //        Prefix = "tw-",
        //        Separator = ":",
        //        Theme = new MergeConfigs.Theme
        //        {
        //            Hi = new[] { "ho" },
        //            ThemeToOverride = new[] { "to-override" }
        //        },
        //        ClassGroups = new MergeConfigs.ClassGroups
        //        {
        //            FooKey = new[] { new MergeConfigs.FooKey { FooKey = new[] { "one", "two" } } },
        //            Bla = new[] { new MergeConfigs.Bla { Bli = new[] { "blub", "blublub" } } },
        //            GroupToOverride = new[] { "this", "will", "be", "overridden" },
        //            GroupToOverride2 = new[] { "this", "will", "not", "be", "overridden" }
        //        },
        //        ConflictingClassGroups = new MergeConfigs.ConflictingClassGroups
        //        {
        //            ToOverride = new[] { "groupToOverride" }
        //        },
        //        ConflictingClassGroupModifiers = new MergeConfigs.ConflictingClassGroupModifiers
        //        {
        //            Hello = new[] { "world" },
        //            ToOverride = new[] { "groupToOverride-2" }
        //        }
        //    },
        //    new MergeConfigs.Config
        //    {
        //        Separator = "-",
        //        Prefix = null,
        //        Override = new MergeConfigs.Override
        //        {
        //            Theme = new MergeConfigs.Theme
        //            {
        //                ThemeToOverride = new[] { "overridden" }
        //            },
        //            ClassGroups = new MergeConfigs.ClassGroups
        //            {
        //                GroupToOverride = new[] { "I", "overrode", "you" },
        //                GroupToOverride2 = null
        //            },
        //            ConflictingClassGroups = new MergeConfigs.ConflictingClassGroups
        //            {
        //                ToOverride = new[] { "groupOverridden" }
        //            },
        //            ConflictingClassGroupModifiers = new MergeConfigs.ConflictingClassGroupModifiers
        //            {
        //                ToOverride = new[] { "overridden-2" }
        //            }
        //        },
        //        Extend = new MergeConfigs.Extend
        //        {
        //            ClassGroups = new MergeConfigs.ClassGroups
        //            {
        //                FooKey = new[] { new MergeConfigs.FooKey { FooKey = new[] { "bar", "baz" } } },
        //                FooKey2 = new[] { new MergeConfigs.FooKey { FooKey = new[] { "qux", "quux" } } },
        //                OtherKey = new[] { "nother", "group" },
        //                GroupToOverride = new[] { "extended" }
        //            },
        //            ConflictingClassGroups = new MergeConfigs.ConflictingClassGroups
        //            {
        //                FooKey = new[] { "otherKey" },
        //                OtherKey = new[] { "fooKey", "fooKey2" }
        //            },
        //            ConflictingClassGroupModifiers = new MergeConfigs.ConflictingClassGroupModifiers
        //            {
        //                Hello = new[] { "world2" }
        //            }
        //        }
        //    }
        //);

        //Assert.Equal(new MergeConfigs.Config
        //{
        //    CacheSize = 50,
        //    Prefix = "tw-",
        //    Separator = "-",
        //    Theme = new MergeConfigs.Theme
        //    {
        //        Hi = new[] { "ho" },
        //        ThemeToOverride = new[] { "overridden" }
        //    },
        //    ClassGroups = new MergeConfigs.ClassGroups
        //    {
        //        FooKey = new[]
        //        {
        //            new MergeConfigs.FooKey { FooKey = new[] { "one", "two" } },
        //            new MergeConfigs.FooKey { FooKey = new[] { "bar", "baz" } }
        //        },
        //        Bla = new[] { new MergeConfigs.Bla { Bli = new[] { "blub", "blublub" } } },
        //        FooKey2 = new[] { new MergeConfigs.FooKey { FooKey = new[] { "qux", "quux" } } },
        //        OtherKey = new[] { "nother", "group" },
        //        GroupToOverride = new[] { "I", "overrode", "you", "extended" },
        //        GroupToOverride2 = new[] { "this", "will", "not", "be", "overridden" }
        //    },
        //    ConflictingClassGroups = new MergeConfigs.ConflictingClassGroups
        //    {
        //        ToOverride = new[] { "groupOverridden" },
        //        FooKey = new[] { "otherKey" },
        //        OtherKey = new[] { "fooKey", "fooKey2" }
        //    },
        //    ConflictingClassGroupModifiers = new MergeConfigs.ConflictingClassGroupModifiers
        //    {
        //        Hello = new[] { "world", "world2" },
        //        ToOverride = new[] { "overridden-2" }
        //    }
        //}, result);
    }
}
