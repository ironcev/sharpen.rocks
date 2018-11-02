---
title: "Sharpen v0.6.0 - Async and Await"
date: 2018-10-03T20:00:00+01:00
description: "Improve your code performance with Sharpen v0.6.0 Async and Await suggestions."
categories: []
keywords: ["sharpen", "release"]
slug: ""
aliases: [/news/sharpen-v0.6.0-async-and-await/]
toc: false
draft: false
---
# Async, Await, and a Rainy Day in New York

[Sharpen 0.6.0](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen) has just been released, featuring six new suggestions, all of them related to [C# 5.0 Async and Await feature](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/). Here is a glimpse of what you might get when you run an analysis on your own code:

![Sharpen Async and Await suggestions](/images/news/sharpen-v0.6.0-async-and-await/sharpen-async-await-suggestions.png)

Like all the previous Sharpen releases this one was also driven by two primary drivers- [a public talk and travel]({{< ref "sharpens-2017-world-tour.md" >}}). Proper usage of Async and Await was a part of the conference workshop titled [High-Performance ASP.NET Core](https://2018.webcampzg.org/workshops/high-performance-aspnet-core/), that [Dobriša Adamec](https://www.linkedin.com/in/dadamec/) and I held at [WebCamp Zagreb Conference](https://2018.webcampzg.org/).

Sharpen is all about learning C# in a realistic, real-life environment. That’s why I wanted to have support for Async and Await ready before the conference. Luckily, a business trip to the US shortly before the conference provided me with two intercontinental flights which I spend programming the Async and Await support. This was more than enough to gain good momentum in implementing the suggestions. A rainy day in New York contributed as well. There are plenty of things one may do in New York on a rainy day. Working on Sharpen in a coffee shop somewhere in Manhattan was my first choice :-)

## A Common Misuse

[C# 5.0 Async and Await](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/) are there since 2012, and it is common to see them in everyday code, especially in the web development. Still, out of my experience:

- they are not used in all the places where their use would be beneficial
- sometimes they are misused

And this is not only my experience. An [ICSE](http://www.icse-conferences.org/) distinguished paper titled [A Study and Toolkit for Asynchronous Programming in C#](https://www.ideals.illinois.edu/bitstream/handle/2142/45837/okur-2014-icse.pdf?sequence=5&isAllowed=y) published in 2014 tries to answer the question "Why is async/await Commonly Misused?". The study is four years old, but I tend to believe that its results would be similar if it were conducted nowadays:

> We have seen extensive misuse of the async/await keywords in the projects in our code corpus. Different authors, both from Microsoft and others, have documented these potential misuses extensively. This raises the question: Why is the misuse so extensive? Are developers just uninformed, or are they unaware of risks or performance characteristics of async/await?

Sharpen tackles both of the points listed above. It points out some places in the code that could benefit from introducing asynchronous programming. Such an introduction would most likely mean a lot of refactoring in code and in general case should be questioned. Thus, Sharpen’s suggestion starts with the word consider - "consider awaiting equivalent asynchronous method."

On the other hand, having synchronous IO calls in `async` methods instead of awaiting their asynchronous equivalents is an obvious mistake. Thus, Sharpen gives a clear hint to "await equivalent asynchronous method."

# Real-Life Examples

Running the analysis on real-life projects, not surprisingly, confirmed both of the points. Here is the result of analyzing a seven-years-old web application consisting of more than 70 projects.

![Sharpen Async and Await suggestions on a real-life project](/images/news/sharpen-v0.6.0-async-and-await/sharpen-async-await-suggestions-on-a-real-life-project.png)

As you can see, there are plenty of places where blocking, synchronous IO calls sneaked into `async` methods. It turned out that some of the suggestions to consider using Async and Await were also very valuable.

# To be Continued

These six suggestions are just the first set of suggestions related to asynchronous programming. More suggestions will be added in the future, mostly related to replacing the outdated asynchronous patterns, like, e.g. the [Asynchronous Programming Model (APM)](https://docs.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/asynchronous-programming-model-apm), with Async and Await.

# Release Content
{{< release "0.6.0" >}}

As always, I would like to thank all the runners of the [Sharpen Endgame](https://github.com/sharpenrocks/Sharpen/wiki/Endgame-for-v0.6.0) and to invite all of you reading these lines to participate in the next run.

Finally, give Sharpen v0.6.0 a try on your own. As always, I'm curious about findings in your code ;-) Feel called to share them in the comments below.

