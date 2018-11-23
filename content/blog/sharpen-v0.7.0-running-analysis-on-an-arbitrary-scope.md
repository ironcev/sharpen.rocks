---
title: "Sharpen v0.7.0 - Running Analysis on an Arbitrary Scope"
date: 2018-11-18T20:00:00+01:00
description: "Run Sharpen analysis on an arbitrary scope."
categories: []
keywords: ["sharpen", "release"]
slug: ""
aliases: []
toc: false
draft: false
---
# "Analyze with Sharpen" Context Menu Item

[Sharpen 0.7.0](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen) has just been released, bringing a long-requested possibility to run an analysis on an arbitrary scope - a single file, folder, or project, or a  selection of files, folders, or projects.

The scope selection can be done in the Solution Explorer in a usual way, by using the `Shift` and `Up`, `Down`, `PgUp`, and `PgDown` keys or the `Shift` and `Ctrl` keys in combination with left mouse clicks. Once you select the desired scope, you can now run the analysis on that scope by using the "Analyze with Sharpen" option on the context menu.

![Analyze with Sharpen context menu item](/images/blog/sharpen-v0.7.0-running-analysis-on-an-arbitrary-scope/analyze-with-sharpen-context-menu-item.gif)

The "Analyze with Sharpen" menu option is also available on the context menu of the currently edited file.

![Analyze with Sharpen on the currently edited file](/images/blog/sharpen-v0.7.0-running-analysis-on-an-arbitrary-scope/analyze-with-sharpen-on-the-currently-edited-file.png)

# UX Matters

This is the first minor version of Sharpen that does not bring any new C# suggestions but instead focuses solely on usability. And that with a good reason. The possibility to run an analysis on an arbitrary scope was the number one UX feature requested in all the personal feedback I got so far. This feature also helps internally, during the development of new C# suggestions. Usually, during the development of new suggestions it is needed to run the analysis only on those parts of the [Smoke Tests Solution](https://github.com/sharpenrocks/Sharpen/tree/master/tests/smoke) that are related to the suggestions under development.

# Release Content
{{< release "0.7.0" >}}

I would like to thank all the runners of the [Sharpen Endgame](https://github.com/sharpenrocks/Sharpen/wiki/Endgame-for-v0.7.0) and to invite all of you reading these lines to participate in the next run.

Finally, give Sharpen v0.7.0 a try on your own. As always, I'm curious about findings in your code ;-) Feel called to share them in the comments below.

