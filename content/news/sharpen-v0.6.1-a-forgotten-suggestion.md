---
title: "Sharpen v0.6.1 - A Forgotten Suggestion"
date: 2018-10-08T20:00:00+01:00
description: "Await task instead of calling Task.Result ;-)"
categories: []
keywords: ["sharpen", "release"]
slug: ""
aliases: []
toc: false
draft: false
---
# Forgotten Suggestion and Improved Display

[Sharpen 0.6.1](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen) has just been released, this time featuring only one new suggestion - "Await task instead of calling Task.Result." It is embarrassing to admit, but it's true - in a rush to publish [Sharpen 0.6.0]({{< ref "sharpen-v0.6.0-async-and-await.md" >}}) before the [High-Performance ASP.NET workshop](https://2018.webcampzg.org/workshops/high-performance-aspnet-core/) at the [WebCamp Zagreb conference](https://2018.webcampzg.org/) I completely overlooked this important suggestion.

While adding and trying out that suggestion I also noticed that the location in code on which the suggestion applies is not optimally presented. Basically, the display of the issue more or less always looked the same:

![Sharpen Await task instead of waiting Task.Result - Bad display](/images/news/sharpen-v0.6.1-a-forgotten-suggestion/sharpen-await-task-instead-of-waiting-task-result-bad-display.png)

So I've improved the affected code display by showing the enclosing statement:

![Sharpen Await task instead of waiting Task.Result - Good display](/images/news/sharpen-v0.6.1-a-forgotten-suggestion/sharpen-await-task-instead-of-waiting-task-result-good-display.png)

This applies to all other "Await ABC instead of calling XYZ" suggestions as well.

# Release Content
{{< release "0.6.1" >}}

As always, I would like to thank all the runners of the [Sharpen Endgame](https://github.com/sharpenrocks/Sharpen/wiki/Endgame-for-v0.6.1) and to invite all of you reading these lines to participate in the next run.

Finally, give Sharpen v0.6.1 a try on your own. As always, I'm curious about findings in your code ;-) Feel called to share them in the comments below.

