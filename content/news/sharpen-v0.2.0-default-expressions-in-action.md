---
title: "Sharpen v0.2.0 - Default Expressions in Action"
date: 2017-12-14T00:00:00-00:00
description: "Sharpen v0.2.0 is there :-) Featuring C# 7.1 default expressions."
categories: []
keywords: ["sharpen", "release"]
slug: ""
aliases: []
toc: false
draft: false
---
# Defining Sharpen's Release Priorities
Defining Sharpen's release and feature priorities is not going to be an easy task. That fact was clear to me from the very first day I started working on Sharpen. In this early stage of the project literally every feature is equally needed and equally important:

- **Adding more analyzers** to get suggestions for more C# language features.
- **Providing recommendations** for those suggestions. Without recommendations, Sharpen will hardly differ from other static analysis tools that blindly suggest usage of a feature, just because it can be used.
- **Creating built-in C# documentation.** Learning is, after all, Sharpen's main purpose!
- **Implementing refactoring.** The fact that [10,000+ places in my code]({{< ref "sharpen-v0.1.0-just-ship-it.md" >}}) would benefit of a new C# feature only frustrates me, if I cannot apply those feature automatically.
- **Building a state-of-the art UX.** Displaying thousands of results in a single tree view is fine for the moment but definitely not satisfying even on a mid-term.

And these are just a few of the major development directions.

Luckily, in this very early stage of the project I can simplify the prioritization process. At the moment I primarily focus on those features that will help make my talk on [Losing Weight With C# 7+](https://github.com/ironcev/public-talks/tree/master/LosingWeightWithCSharp7%2B) as practical and tangible as possible. And thus, the release 0.2.0, following my talk, fully focus on adding analyzers for [C# 7.1 default expressions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/default-value-expressions).

# Default Expressions
So, Sharpen v0.2.0 is there, available for [download on the Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen) :-)

It brings three new suggestions, namely:

- Use default expression in optional constructor parameters
- Use default expression in optional method parameters
- Use default expression in return statements

These are in practice the three most prominent places where the default values are used.

As always I was curious of the findings in the real-life code. And for sure (this time without a surprise) there were many findings worth showcasing. Just to give you a glimpse of the new feature, here are the default expression related findings in the [NHibernate](http://nhibernate.info/) code:

![Sharpen results for default expressions usages in NHibernate](/images/news/sharpen-v0.2.0-default-expressions-in-action/sharpen-results-default-expressions-in-nhibernate.png)

Here is on of the interesting findings. Async methods in NHibernate follow the usual pattern of accepting an optional [CancellationToken](https://msdn.microsoft.com/en-us/library/system.threading.cancellationtoken(v=vs.110).aspx) parameter. And since the `CancellationToken` is a `struct`, the only way to provide the default value, prior to C# 7.1, was to write `default(CancellationToken)`. With C# 7.1 this simply narrows down to `default`. I would personally love to see NHibernate's code loosing a bit of weight in this area :-)

This is just one of several interesting findings related to default expressions. I plan to share generally interesting Sharpen findings via a series of blog posts called "Sharpen Weekly". Stay tuned ;-)

# Release Content
{{< release "0.2.0" >}}

[Download Sharpen v0.2.0 from the Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen) and give it a try on your own. I'm curios how interesting your findings will be :-)