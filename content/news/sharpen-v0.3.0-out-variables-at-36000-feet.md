---
title: "Sharpen v0.3.0 - Out Variables at 36,000 Feet"
date: 2018-01-16T21:38:53+01:00
description: "Sharpen v0.3.0 has landed! Bringing us C# 7.1 out variables developed at 36,000 feet ;-)"
categories: []
keywords: ["sharpen", "release"]
slug: ""
aliases: []
toc: false
draft: false
---
# Developing at 36,000 Feet

> JUnit has had many authors, but it began with Kent Beck and Eric Gamma together on a plane to Atlanta. Kent wanted to learn Java, and Eric wanted to learn about Kent’s Smalltalk testing framework. "What could be more natural to a couple of geeks in cramped quarters than to pull out our laptops and start coding?" After three hours of high-altitude work, they had written the basics of JUnit.<br/>
[Robert C. Martin](https://en.wikipedia.org/wiki/Robert_C._Martin), Clean Code - A Handbook of Agile Software Craftsmanship

[Kent](https://en.wikipedia.org/wiki/Kent_Beck) and [Eric](https://en.wikipedia.org/wiki/Erich_Gamma) had only three hours at their disposal to build the foundations of [JUnit](http://junit.org). I was much more fortunate. My flight from Paris to Guadeloupe took more then eight hours. "What could be more natural to a <s>couple of geeks</s> geek in cramped quarters than to pull out <s>our laptops</s> his laptop and start coding?" :-)

And that's exactly what I did. I knew that my "high-altitude work" will for sure be coding suggestions for [C# 7.0 out variables](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#out-variables). So I opened plenty of [Roslyn API Browser](https://docs.microsoft.com/dotnet/api/?view=roslyn-dotnet)'s help pages upfront just before boarding the plane. They served me as an offline help while inspecting usages of out variables. On 36,000 feet and without Internet connection.

A few hours after we reached our cruising altitude, somewhere high over the Atlantic ocean, the first usable version of the "Use out variables in method invocations" suggestion was born :-)

![C# Out Variables at 36000 Feet](/images/news/sharpen-v0.3.0-out-variables-at-36000-feet/sharpen-csharp-out-variables-at-36000-feet.jpg)

# Better Done Then Perfect

Analyzing places where out variables could be used proved out not to be so easy. There are many corner cases in which `out` keyword is used but out variables cannot be used. A bullet-proof analysis must properly cover all of them. Some of those corner cases are very likely to happen. For example, a potential out variable must be declared locally. It cannot be a class field or a parameter of an enclosing method like in the example below:

    void VariableThatIsNotDeclaredLocally(int i)
    {
        int.TryParse("123", out i);
    }

Some of the corner cases are very unlikely, though, like in the following example:

    void VariableThatIsALambdaParameter()
    {
        Func<int, bool> a = i => int.TryParse("123", out i);
    }

Moreover, the data flow of a potential out variable has to be analyzed in detail. For example, they must not be used between their declaration and the method call, where they are passed as out variable. In the case below, the variable `i` is a candidate for the out variable in `int.TryParse()` call:

    void VariableIsNotUsedBeforeMethodInvocation()
    {
        int i;
        Console.WriteLine("Hello!");
        // Some other code that does not use "i".
        int.TryParse("123", out i);
    }

But in this case it is not, because it is used in the `Console.WriteLine()` before `int.TryParse()` is called.

    void VariableIsUsedBeforeMethodInvocation()
    {
        int i = 0;
        Console.WriteLine(i);
        int.TryParse("123", out i);
    }

These and similar cases were covered in the "36,000 feet" version of the suggestion. But, some cases less likely to occur were not. In the below example, the variable `i` cannot be declared as an out variable in the `int.TryParse()` call. I'll leave it to you to figure out why ;-)

    void VariableIsUsedOutOfScopeOfTheMethodInvocation(bool input)
    {
        int i;
        if (input)
        {
            int.TryParse("123", out i);
        }
        else
        {
            i = 1;
        }
    }

Covering all the quirky cases that crossed my mind would take me some more development time. And the existing implementation already proved to be very useful in a vast number of real-life cases. So I faced the classical dilemma. Ship the feature once when it's perfect, or ship it immediately, as non-perfect, but still very usable?

As often in such cases, I follow the advice given on the photo that a friend once sent to me in an effort to cure my perfectionism :-)

![Done is better than perfect](/images/news/sharpen-v0.3.0-out-variables-at-36000-feet/done-is-better-than-perfect.jpg)

And so, Sharpen v0.3.0 is there, available for [download on the Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen) :-) Featuring non-perfect out variable suggestion and a better grouping of suggestions in the Sharpen Result view. Enjoy it!

# Release Content
{{< release "0.3.0" >}}

Give Sharpen v0.3.0 a try on your own. As always, I'm curios about findings in your code ;-) Feel called to share them in the comments below.