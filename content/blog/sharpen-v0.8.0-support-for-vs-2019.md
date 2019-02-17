---
title: "Sharpen v0.8.0 - Support for VS 2019"
date: 2019-02-17T08:00:00+01:00
description: "Just on time! Sharpen v0.8.0 is out, bringing support for Visual Studio 2019."
categories: []
keywords: ["sharpen", "release"]
slug: ""
aliases: []
toc: false
draft: false
---
# Support for VS 2019

[Sharpen 0.8.0](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen) has just been released, bringing support for Visual Studio 2019.

On the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen), there is a single installation file for both VS 2017 and VS 2019. The installation will detect the VS versions installed on your computer and let you choose the versions to which Sharpen should be added. In the case of selecting both versions, the final confirmation dialog will look similar to this one.

![Sharpen installation supports VS 2017 and VS 2019](/images/blog/sharpen-v0.8.0-support-for-vs-2019/sharpen-installation-supports-vs2017-and-vs2019.png)

Aside from adding support for VS 2019 Sharpen now also [loads asynchronously](https://blogs.msdn.microsoft.com/visualstudio/2018/05/16/improving-the-responsiveness-of-critical-scenarios-by-updating-auto-load-behavior-for-extensions/). It means that it does not block the initial loading of Visual Studio anymore.

I would especially like to thank [@MC01DA](https://github.com/MC01DA) and [@LeoJHarris](https://github.com/LeoJHarris) for reporting two issues connected to VS 2019 ([#19](https://github.com/sharpenrocks/Sharpen/issues/19) and [#21](https://github.com/sharpenrocks/Sharpen/issues/21)).

Having Sharpen installable in VS 2019 is just the first step toward supporting C# 8.0. Visual Studio 2019 launches quite soon, on April 2nd. Until the launch date, I want to have at least the major C# 8.0 features supported by Sharpen. It’s a tough plan, but I am excited about it and looking forward to it :-)

# Release Content
{{< release "0.8.0" >}}

I would like to thank all the runners of the [Sharpen Endgame](https://github.com/sharpenrocks/Sharpen/wiki/Endgame-for-v0.8.0) and to invite all of you reading these lines to participate in the next run.

Finally, give Sharpen v0.8.0 a try on your own. As always, I'm curious about findings in your code ;-) Feel called to share them in the comments below.