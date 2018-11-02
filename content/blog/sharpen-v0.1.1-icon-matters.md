---
title: "Sharpen v0.1.1 - Icon Matters"
date: 2017-11-23T00:00:01-00:00
description: "Icon Matters. It matters so much that it even deserves its own (micro)release ;-)"
categories: []
keywords: ["sharpen", "release"]
slug: ""
aliases: [/news/sharpen-v0.1.1-icon-matters/]
toc: false
draft: false
---
# Forgotten Detail
Immediately after shipping the [Sharpen v0.1.0]({{< ref "sharpen-v0.1.0-just-ship-it.md" >}}) I've noticed that I've forgotten a slight detail. The information about the logo was missing in the [VSIX package manifest](https://docs.microsoft.com/de-de/visualstudio/extensibility/vsix-extension-schema-2-0-reference). In particular, the optional `<Icon>` element wasn't specified. And as the documentation clearly states it

> If no `Icon` element is specified, the UI uses a default.

And the default icon looks, well... like this :-(

![Visual Studio Extension Default Icon](/images/news/sharpen-v0.1.1-icon-matters/visual-studio-extension-default-icon.png)

Yes, I've crafted the Sharpen's logo in less then 10 minutes. Those of you who follow [Sharpen on Twitter](https://twitter.com/sharpenrocks) are already aware of that:

{{< tweet 934588421854650370 >}}

And yes, while crafting it I completely ignored the advice to [choose the logo wisely](https://www.inc.com/issie-lapowsky/why-company-logo-matters.html). I simply made it.

I'm sure the creators of the default Visual Studio Extension icon put much more effort into crafting it, then I put into Sharpen's logo.

But still, I couldn't stand having that icon presenting Sharpen on the Marketplace and in the Visual Studio "Extensions and Updates" dialog.

I didn't expect to ship the version 0.1.1 so early :-) but I simply had to fix this forgotten detail. Icon matters. It matters so much that it deserves its own (micro)release :-)

And voilà the Sharpen v0.1.1 is there, [available on the Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen), featuring more or less only the proper Sharpen's logo.

# Release Content
{{< release "0.1.1" >}} The only notable difference to v0.1.0 is the logo.