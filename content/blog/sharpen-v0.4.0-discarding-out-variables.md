---
title: "Sharpen v0.4.0 - Discarding Out Variables"
date: 2018-05-14T21:38:53+01:00
description: "Having unused out variables in your code? Let the Sharpen v0.4.0 remove them for you ;-)"
categories: []
keywords: ["sharpen", "release"]
slug: ""
aliases: [/news/sharpen-v0.4.0-discarding-out-variables/]
toc: false
draft: false
---
# Discarding Out Variables

[Sharpen 0.4.0](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen) has just been published, featuring a few new suggestions, notably the [C# 7.0 possibility to discard out variables](https://docs.microsoft.com/en-us/dotnet/csharp/discards#calls-to-methods-with-out-parameters). This feature can significantly reduce clutter in your code if you have to deal with (most likely badly designed ;-)) API that exposes methods with several out variables when not all of them are always required.

To demonstrate such a case, let's take a look at a [concrete example taken from the NHibernate project](https://github.com/nhibernate/nhibernate-core/blob/a407afba873ef168a6808e5d4c950bc136206279/src/NHibernate/Dialect/Oracle8iDialect.cs#L382):

![Discarding out variables in NHibernate](/images/blog/sharpen-v0.4.0-discarding-out-variables/sharpen-discarding-out-variables-in-nhibernate.png )

Here is the implementation of the `ExtractColumnOrAliasNames` as it is now:

    string ExtractColumnOrAliasNames(SqlString select)
    {
        List<SqlString> columnsOrAliases;
        Dictionary<SqlString, SqlString> aliasToColumn;
        Dictionary<SqlString, SqlString> columnToAlias;
        ExtractColumnOrAliasNames(select, out columnsOrAliases, out aliasToColumn, out columnToAlias);
    
        return StringHelper.Join(",", columnsOrAliases);
    }

And here is the same method written in C# 7.0 with the help of [out variables](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out-parameter-modifier) and the [discarded out variables](https://docs.microsoft.com/en-us/dotnet/csharp/discards#calls-to-methods-with-out-parameters):

    string ExtractColumnOrAliasNames(SqlString select)
    {
        ExtractColumnOrAliasNames(select, out var columnsOrAliases, out _, out _);
    
        return StringHelper.Join(",", columnsOrAliases);
    }


As you can see, the resulting code is much more shorter and readable. To use the Sharpen's terminology - much more sharper :-)

# Ensuring Quality With Unit Tests and Running the Endgame

## Unit Tests

Sharpen is becoming more and more complex and it has reached the point at which having intense testing, both automatic and manual, starts paying off. I'm happy to say that starting with this version, Sharpen got [its first unit tests](https://github.com/sharpenrocks/Sharpen/blob/1a592b514b273648bc597ca722abb838cb35da71/src/Sharpen.Engine.Tests.Unit/SharpenSuggestions/CSharp70/OutVariables/UseOutVariablesInMethodInvocationsTests.cs#L10). It is a modest start, but still a milestone. Up to now, the very detailed [smoke tests](https://github.com/sharpenrocks/Sharpen/tree/master/tests/smoke) played to an extend the role of unit tests. What I want to say is that smoke tests cover much more then only basic happy paths. They tend to go into very detail, but of course they are not automated. In the upcoming versions I plan to port the existing smoke tests to unit tests. There is a concept for a simple and efficient unit testing infrastructure that will ensure quick porting of the existing smoke tests into unit tests. The concept is at the moment not applied in the [unit tests provided in this version](https://github.com/sharpenrocks/Sharpen/blob/1a592b514b273648bc597ca722abb838cb35da71/src/Sharpen.Engine.Tests.Unit/SharpenSuggestions/CSharp70/OutVariables/UseOutVariablesInMethodInvocationsTests.cs#L10).

It is worth saying that unit tests will not replace smoke tests. The existing and the future smoke tests will still play a major role in the development and of course smoke testing, as explained in the smoke test's [README.md](https://github.com/sharpenrocks/Sharpen/blob/master/tests/smoke/README.md).

## Running the Endgame

In addition to unit tests, starting from this version, Sharpen will have the "Running the Endgame" as a part of its quality assurance. Sharpen's "Running the Endgame" has been heavily inspired with the same "ritual" done by the [Visual Studio Code development team](https://github.com/Microsoft/vscode/wiki/Running-the-Endgame). At the moment, [Sharpen's version of the "Endgame"](https://github.com/sharpenrocks/Sharpen/wiki/Running-the-Endgame) is much simpler than the VS Code's one.

I am grateful to my friends, Sharpen supporters and early adopters, who volunteered to run the first Endgame. In the alphabetical order: [Andrej Matijević](https://twitter.com/andrej00004), Berislav Nižić, [Hrvoje Hudoletnjak](https://twitter.com/hhrvoje), and Robert Kurtanjek. Thank you guys! Your help and support is greatly appreciated.

It made me happy to see them sending me screenshots of the Sharpen result analysis of their own large projects, although I didn't ask them for that :-) It was great to see it visually, Sharpen running in different version of Visual Studio, under different color themes, etc. Here are two of the screenshots:

![Running Sharpen analysis in a concrete project 01](/images/blog/sharpen-v0.4.0-discarding-out-variables/running-sharpen-analysis-in-a-concrete-project-01.png)

![Running Sharpen analysis in a concrete project 02](/images/blog/sharpen-v0.4.0-discarding-out-variables/running-sharpen-analysis-in-a-concrete-project-02.png)

The overview of this first Endgame is available on [Sharpen's wiki](https://github.com/sharpenrocks/Sharpen/wiki/Endgame-for-v0.4.0). If you want to participate in the Endgame as a "runner" for the upcoming Sharpen versions, please let me know. I will be happy and honored to invite you to the game :-)

# Release Content
{{< release "0.4.0" >}}

Give Sharpen v0.4.0 a try on your own. As always, I'm curious about findings in your code ;-) Feel called to share them in the comments below.