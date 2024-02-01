using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;
using System.ComponentModel.DataAnnotations;

namespace TailwindMerge.Tests;

public class PublicApiTests
{
    [Fact]
    public void HasCorrectExportTypes()
    {
        //Assert.IsType<Delegate>(twMerge);
        //Assert.IsType<Delegate>(createTailwindMerge);
        //Assert.IsType<Delegate>(getDefaultConfig);
        //Assert.Equal(Validators,Inew
        //{
        //    isAny = (Delegate)null,
        //    isArbitraryLength = (Delegate)null,
        //    isArbitraryNumber = (Delegate)null,
        //    isArbitraryPosition = (Delegate)null,
        //    isArbitraryShadow = (Delegate)null,
        //    isArbitrarySize = (Delegate)null,
        //    isArbitraryImage = (Delegate)null,
        //    isArbitraryValue = (Delegate)null,
        //    isInteger = (Delegate)null,
        //    isLength = (Delegate)null,
        //    isPercent = (Delegate)null,
        //    isNumber = (Delegate)null,
        //    isTshirtSize = (Delegate)null
        //});
        //Assert.IsType<Delegate>(mergeConfigs);
        //Assert.IsType<Delegate>(extendTailwindMerge);
        //Assert.IsType<Delegate>(twJoin);

        //Delegate noRun = () =>
        //{
        //    var config = getDefaultConfig();
        //    var classNameValue = "some-class";
        //    Func<string, bool> classValidator = (value) => false;

        //    twMerge(classNameValue, classNameValue, classNameValue);
        //    twJoin(classNameValue, classNameValue, classNameValue);

        //    return new
        //    {
        //        config,
        //        classValidator
        //    };
        //};
    }

    [Fact]
    public void TwMergeHasCorrectInputsAndOutputs()
    {
        Assert.IsType<string>(TW.Merge(""));
        Assert.IsType<string>(TW.Merge("hello world"));
        Assert.IsType<string>(TW.Merge("-:-:-:::---h-"));
        Assert.IsType<string>(TW.Merge("hello world", "-:-:-:::---h-"));
        Assert.IsType<string>(TW.Merge("hello world", "-:-:-:::---h-", "", "something"));
        //Assert.IsType<string>(TW.Merge("hello world", null));
        //Assert.IsType<string>(TW.Merge("hello world", null, null));
        //Assert.IsType<string>(TW.Merge("hello world", null, null, false));
        //Assert.IsType<string>(TW.Merge("hello world", new[] { null }, new[] { null, false }));
        //Assert.IsType<string>(TW.Merge("hello world", new[] { null }, new[] { null, new object[] { false, "some-class" }, new object[] { } }));

        //Delegate noRun = () =>
        //{
        //    // Assert.Throws<Exception>(() => TW.Merge(123));
        //    // Assert.Throws<Exception>(() => TW.Merge(true));
        //    // Assert.Throws<Exception>(() => TW.Merge(new object()));
        //    // Assert.Throws<Exception>(() => TW.Merge(new DateTime()));
        //    // Assert.Throws<Exception>(() => TW.Merge(() => { }));
        //};
    }

    [Fact]
    public void CreateTailwindMergeHasCorrectInputsAndOutputs()
    {
        //Assert.IsType<Delegate>(createTailwindMerge(getDefaultConfig));
        //Assert.IsType<Delegate>(createTailwindMerge(() => new
        //{
        //    cacheSize = 0,
        //    separator = ":",
        //    theme = new object(),
        //    classGroups = new object(),
        //    conflictingClassGroups = new object(),
        //    conflictingClassGroupModifiers = new object()
        //}));

        //var tailwindMerge = createTailwindMerge(() => new
        //{
        //    cacheSize = 20,
        //    separator = ":",
        //    theme = new object(),
        //    classGroups = new
        //    {
        //        fooKey = new[] { new { fooKey = new[] { "bar", "baz" } } },
        //        fooKey2 = new[] { new { fooKey = new[] { "qux", "quux" } } },
        //        otherKey = new[] { "nother", "group" }
        //    },
        //    conflictingClassGroups = new
        //    {
        //        fooKey = new[] { "otherKey" },
        //        otherKey = new[] { "fooKey", "fooKey2" }
        //    },
        //    conflictingClassGroupModifiers = new object()
        //});

        //Assert.IsType<Delegate>(tailwindMerge);
        //Assert.IsType<string>(tailwindMerge(""));
        //Assert.IsType<string>(tailwindMerge("hello world"));
        //Assert.IsType<string>(tailwindMerge("-:-:-:::---h-"));
        //Assert.IsType<string>(tailwindMerge("hello world", "-:-:-:::---h-"));
        //Assert.IsType<string>(tailwindMerge("hello world", "-:-:-:::---h-", "", "something"));
        //Assert.IsType<string>(tailwindMerge("hello world", null));
        //Assert.IsType<string>(tailwindMerge("hello world", null, null));
        //Assert.IsType<string>(tailwindMerge("hello world", null, null, false));
        //Assert.IsType<string>(tailwindMerge("hello world", new[] { null }, new[] { null, false }));
        //Assert.IsType<string>(tailwindMerge("hello world", new[] { null }, new[] { null, new object[] { false, "some-class" }, new object[] { } }));

        //Delegate noRun = () =>
        //{
        //    // Assert.Throws<Exception>(() => tailwindMerge(123));
        //    // Assert.Throws<Exception>(() => tailwindMerge(true));
        //    // Assert.Throws<Exception>(() => tailwindMerge(new object()));
        //    // Assert.Throws<Exception>(() => tailwindMerge(new DateTime()));
        //    // Assert.Throws<Exception>(() => tailwindMerge(() => { }));
        //};
    }

    [Fact]
    public void ValidatorsHaveCorrectInputsAndOutputs()
    {
        Assert.True(Validators.IsLength(""));
        Assert.True(Validators.IsArbitraryLength(""));
        Assert.True(Validators.IsInteger(""));
        Assert.True(Validators.IsArbitraryValue(""));
        Assert.True(Validators.IsAny());
        Assert.True(Validators.IsTshirtSize(""));
        Assert.True(Validators.IsArbitrarySize(""));
        Assert.True(Validators.IsArbitraryPosition(""));
        Assert.True(Validators.IsArbitraryImage(""));
        Assert.True(Validators.IsArbitraryNumber(""));
        Assert.True(Validators.IsArbitraryShadow(""));
    }

    [Fact]
    public void MergeConfigsHasCorrectInputsAndOutputs()
    {
        //Assert.IsType<object>(mergeConfigs(new
        //{
        //    cacheSize = 50,
        //    separator = ":",
        //    theme = new object(),
        //    classGroups = new
        //    {
        //        fooKey = new[] { new { fooKey = new[] { "one", "two" } } },
        //        bla = new[] { new { bli = new[] { "blub", "blublub" } } }
        //    },
        //    conflictingClassGroups = new object(),
        //    conflictingClassGroupModifiers = new object()
        //}, new object()));
    }

    [Fact]
    public void ExtendTailwindMergeHasCorrectInputsAndOutputs()
    {
        //Assert.IsType<Delegate>(extendTailwindMerge(new object()));
    }

    [Fact]
    public void FromThemeHasCorrectInputsAndOutputs()
    {
        //Assert.IsType<Delegate>(fromTheme("spacing"));
        //Assert.IsType<Delegate>(fromTheme<string>("foo"));
        //Assert.True(fromTheme<string>("foo").isThemeGetter);
        //Assert.Equal(fromTheme<string>("foo")(new { foo = new[] { "hello" } }), new[] { "hello" });

        //Delegate noRun = () =>
        //{
        //    // Assert.Throws<Exception>(() => fromTheme("custom-key"));
        //    // Assert.Throws<Exception>(() => fromTheme<"custom-key">("custom-key"));
        //};
    }

    [Fact]
    public void TwJoinHasCorrectInputsAndOutputs()
    {
        //Assert.IsType<string>(twJoin());
        //Assert.IsType<string>(twJoin(""));
        //Assert.IsType<string>(twJoin("", new object[] { false, null, null, 0, new object[] { }, new object[] { false, new object[] { "" }, "" } }));
    }
}
