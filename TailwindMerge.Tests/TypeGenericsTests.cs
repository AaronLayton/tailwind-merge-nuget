using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;
using System.ComponentModel.DataAnnotations;

namespace TailwindMerge.Tests;

public class TypeGenericsTests
{
    [Fact]
    public void ExtendTailwindMergeTypeGenericsWorkCorrectly()
    {
        //var tailwindMerge1 = TailwindMerge.ExtendTailwindMerge(new TailwindMergeOptions
        //{
        //    Extend = new TailwindMergeExtendOptions
        //    {
        //        Theme = new TailwindMergeThemeOptions
        //        {
        //            Spacing = new[] { "my-space" },
        //            // TODO: Handle ts-expect-error
        //            // plll = ['something'],
        //        },
        //        ClassGroups = new TailwindMergeClassGroupsOptions
        //        {
        //            Px = new[] { "px-foo" },
        //            // TODO: Handle ts-expect-error
        //            // pxx = ['pxx-foo'],
        //        },
        //        ConflictingClassGroups = new TailwindMergeConflictingClassGroupsOptions
        //        {
        //            Px = new[] { "p" },
        //            // TODO: Handle ts-expect-error
        //            // pxx = ['p'],
        //        },
        //        ConflictingClassGroupModifiers = new TailwindMergeConflictingClassGroupModifiersOptions
        //        {
        //            P = new[]
        //            {
        //                "px",
        //                // TODO: Handle ts-expect-error
        //                // 'prr',
        //            },
        //        },
        //    },
        //});

        //Assert.Equal("", tailwindMerge1(""));

        //var tailwindMerge2 = TailwindMerge.ExtendTailwindMerge<TailwindMergeTest1, TailwindMergeTest2, TailwindMergeTest3>(new TailwindMergeOptions
        //{
        //    Extend = new TailwindMergeExtendOptions
        //    {
        //        Theme = new TailwindMergeThemeOptions
        //        {
        //            Spacing = new[] { "my-space" },
        //            // TODO: Handle ts-expect-error
        //            // plll = ['something'],
        //            Test3 = new[] { "bar" },
        //        },
        //        ClassGroups = new TailwindMergeClassGroupsOptions
        //        {
        //            Px = new[] { "px-foo" },
        //            // TODO: Handle ts-expect-error
        //            // pxx = ['pxx-foo'],
        //            Test1 = new[] { "foo" },
        //            Test2 = new[] { "bar" },
        //        },
        //        ConflictingClassGroups = new TailwindMergeConflictingClassGroupsOptions
        //        {
        //            Px = new[] { "p" },
        //            // TODO: Handle ts-expect-error
        //            // pxx = ['p'],
        //            Test1 = new[] { "test2" },
        //        },
        //        ConflictingClassGroupModifiers = new TailwindMergeConflictingClassGroupModifiersOptions
        //        {
        //            P = new[]
        //            {
        //                "px",
        //                // TODO: Handle ts-expect-error
        //                // 'prr',
        //                "test2",
        //                "test1",
        //            },
        //        },
        //    },
        //});

        //Assert.Equal("", tailwindMerge2(""));

        //var tailwindMerge3 = TailwindMerge.ExtendTailwindMerge((v) => v, TailwindMerge.GetDefaultConfig);

        //Assert.Equal("", tailwindMerge3(""));
    }

    [Fact]
    public void FromThemeTypeGenericsWorkCorrectly()
    {
        //Assert.IsType<Delegate>(TailwindMerge.FromTheme<TailwindMergeTest4>("test4"));

        //// TODO: Handle ts-expect-error
        //// fromTheme('spacing');
        //// fromTheme<'test5' | 'test6'>('test6');
        //// fromTheme<string>('anything');
        //// fromTheme<never, 'only-this'>('only-this');
        //// fromTheme<'or-this', 'only-this'>('or-this' as 'only-this' | 'or-this');
        //// TODO: Handle ts-expect-error
        //// fromTheme('test5');
        //// TODO: Handle ts-expect-error
        //// fromTheme('test5' | 'spacing');
        //// TODO: Handle ts-expect-error
        //// fromTheme<never, 'only-this'>('something-else');
        //// TODO: Handle ts-expect-error
        //// fromTheme<never, 'only-this'>('something-else' | 'only-this');
    }

    [Fact]
    public void MergeConfigsTypeGenericsWorkCorrectly()
    {
        //var config1 = TailwindMerge.MergeConfigs<TailwindMergeFoo, TailwindMergeBar, TailwindMergeBaz>(new TailwindMergeOptions
        //{
        //    CacheSize = 50,
        //    Prefix = "tw-",
        //    Separator = ":",
        //    Theme = new TailwindMergeThemeOptions
        //    {
        //        Hi = new[] { "ho" },
        //        ThemeToOverride = new[] { "to-override" },
        //    },
        //    ClassGroups = new TailwindMergeClassGroupsOptions
        //    {
        //        FooKey = new[] { new TailwindMergeFooKey { FooKey = new[] { "one", "two" } } },
        //        Bla = new[] { new TailwindMergeBla { Bli = new[] { "blub", "blublub" } } },
        //        GroupToOverride = new[] { "this", "will", "be", "overridden" },
        //        GroupToOverride2 = new[] { "this", "will", "not", "be", "overridden" },
        //    },
        //    ConflictingClassGroups = new TailwindMergeConflictingClassGroupsOptions
        //    {
        //        ToOverride = new[] { "groupToOverride" },
        //    },
        //    ConflictingClassGroupModifiers = new TailwindMergeConflictingClassGroupModifiersOptions
        //    {
        //        Hello = new[] { "world" },
        //        ToOverride = new[] { "groupToOverride-2" },
        //    },
        //}, new TailwindMergeOptions
        //{
        //    Separator = "-",
        //    Prefix = null,
        //    Override = new TailwindMergeOverrideOptions
        //    {
        //        Theme = new TailwindMergeThemeOptions
        //        {
        //            Baz = new string[] { },
        //            // TODO: Handle ts-expect-error
        //            // nope = [],
        //        },
        //        ClassGroups = new TailwindMergeClassGroupsOptions
        //        {
        //            Foo = new string[] { },
        //            Bar = new string[] { },
        //            // TODO: Handle ts-expect-error
        //            // hiii = [],
        //        },
        //        ConflictingClassGroups = new TailwindMergeConflictingClassGroupsOptions
        //        {
        //            Foo = new[]
        //            {
        //                "bar",
        //                // TODO: Handle ts-expect-error
        //                // 'lol',
        //            },
        //        },
        //        ConflictingClassGroupModifiers = new TailwindMergeConflictingClassGroupModifiersOptions
        //        {
        //            Bar = new[] { "foo" },
        //            // TODO: Handle ts-expect-error
        //            // lel = ['foo'],
        //        },
        //    },
        //    Extend = new TailwindMergeExtendOptions
        //    {
        //        ClassGroups = new TailwindMergeClassGroupsOptions
        //        {
        //            Foo = new string[] { },
        //            Bar = new string[] { },
        //            // TODO: Handle ts-expect-error
        //            // hiii = [],
        //        },
        //        ConflictingClassGroups = new TailwindMergeConflictingClassGroupsOptions
        //        {
        //            Foo = new[]
        //            {
        //                "bar",
        //                // TODO: Handle ts-expect-error
        //                // 'lol',
        //            },
        //        },
        //        ConflictingClassGroupModifiers = new TailwindMergeConflictingClassGroupModifiersOptions
        //        {
        //            Bar = new[] { "foo" },
        //            // TODO: Handle ts-expect-error
        //            // lel = ['foo'],
        //        },
        //    },
        //});

        //Assert.IsType<TailwindMergeOptions>(config1);

        //var config2 = TailwindMerge.MergeConfigs<TailwindMergeVery, TailwindMergeStrict>(TailwindMerge.GetDefaultConfig(), new TailwindMergeOptions());

        //Assert.IsType<TailwindMergeOptions>(config2);

        //var config3 = TailwindMerge.MergeConfigs<TailwindMergeSingleArg>(TailwindMerge.GetDefaultConfig(), new TailwindMergeOptions());

        //Assert.IsType<TailwindMergeOptions>(config3);
    }
}
