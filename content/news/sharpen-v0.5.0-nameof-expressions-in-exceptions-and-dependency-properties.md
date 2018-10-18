---
title: "Sharpen v0.5.0 - Nameof Expressions in Exceptions and Dependency Properties"
date: 2018-05-27T20:00:00+01:00
description: "Clean up messy code with the help of Sharpen v0.5.0 and nameof expressions."
categories: []
keywords: ["sharpen", "release"]
slug: ""
aliases: []
toc: false
draft: false
---
# C# 6.0 `nameof` Expressions

[Sharpen 0.5.0](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen) has just been released, featuring two new suggestions, both related to [C# 6.0 `nameof` expressions](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/nameof). 

In his [MSDN article on new C# 6.0 features](https://msdn.microsoft.com/en-us/magazine/dn802602.aspx) Mark Michaelis had a remark on `nameof` expressions feature saying that:

> It provides great opportunity to clean up messy code.

Indeed! There are many occasions where we need C# identifiers to be represented as strings in our code. Here are the most prominent ones:

- Parameter names in argument exceptions. E.g. `throw new ArgumentNullException("someParameter")`
- Property names in raising `OnPropertyChanged` events. E.g. `PropertyChanged(this, new PropertyChangedEventArgs("SomeProperty")`
- Property names in dependency property declarations. E.g. `DependencyProperty.Register("SomeProperty", typeof(int), ...)`
- Property names in Html extensions. E.g. `@Html.TextBox("SomeProperty")`
- Method names in logging. E.g. `Log("SomeMethod", "...")`

Having hardcoded strings in code as in the examples given above brings the risk of a mismatch in case of refactoring. Besides, it lacks IntelliSense support. ([ReSharper](https://www.jetbrains.com/resharper/) tackles well both of the issues, but is a payed tool and in my experience not a standard part of developers toolboxes.)

When LINQ appeared it offered an acceptable alternative to hardcoded strings that brought both IntelliSense and refactoring support - extracting identifier names from expression trees.

Many APIs appeared that offered a possibility to specify identifiers via suitable LINQ expressions. For example

    @Html.TextBoxFor(x => x.SomeProperty)

Yet, this approach came with run-time costs and wasn't always really practical, like e.g. in the case of parameter names in argument exceptions.

[C# 6.0 `nameof` expressions](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/nameof) solve all these issues. Over time Sharpen will support all of the cases mentioned above, as well as "hand-made" solutions and idioms based on LINQ expressions. Here is where I see the strength of Sharpen compared to generic static analysis tools. Sharpen has a goal to collect and understand existing patterns over time widely adopted in the community, to recognize them in code and to suggest usage of modern alternatives.

# `nameof` Expressions in Argument Exceptions and Dependency Property Declarations

[Sharpen 0.5.0](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen) supports two of the most prominent use cases described above:

- Usage of parameter names in argument exceptions.
- Usage of property names in dependency property declarations.

As always, it was interesting to see how often these cases appear in real-life code. Our standard sample project, [NHibernate](http://nhibernate.info/), is not a WPF project so we didn't expect any dependency property declarations to be found. On the other hand, hard coded parameter names in argument expressions appear in NHibernate code many times:

![Use C# 6.0 nameof expression for throwing argument expressions in NHibernate](/images/news/sharpen-v0.5.0-nameof-expressions-in-exceptions-and-dependency-properties/use-csharp-6-nameof-expression-for-throwing-argument-exceptions-in-nhibernate.png )

Another analysis run on a large WPF based desktop application demonstrated a huge potential for usage of `nameof` expressions in dependency property declarations:

![C# 6.0 nameof expression in a large desktop application](/images/news/sharpen-v0.5.0-nameof-expressions-in-exceptions-and-dependency-properties/csharp-6-nameof-expression-in-a-large-desktop-application.png )

# Release Content
{{< release "0.5.0" >}}

I would like to thank all the runners of the [Sharpen v0.5.0 Endgame](https://github.com/sharpenrocks/Sharpen/wiki/Endgame-for-v0.5.0) and to invite all of you reading these lines to participate in the next run.

Finally, give Sharpen v0.5.0 a try on your own. As always, I'm curious about findings in your code ;-) Feel called to share them in the comments below.