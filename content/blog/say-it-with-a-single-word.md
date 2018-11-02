---
title: "Say It With a Single Word"
date: 2018-01-13T22:56:00+01:00
description: "Expression bodied members and default expressions can shorten our code a lot. Sometimes even to just a single word ;-)"
categories: []
keywords: ["sharpen-weekly", "expression-bodied-members", "default-expressions"]
slug: ""
aliases: []
toc: false
draft: false
---
# Expression Bodied Members and Default Expressions, Hand in Hand
Immediately after [implementing the C# 7.1 default expressions in Sharpen]({{< ref "sharpen-v0.2.0-default-expressions-in-action.md" >}}) I ran them on the [NHibernate](http://nhibernate.info/) code. And here is one of my absolutely favorite findings.

![NHibernate - Say It With a Single Word - Default Expression](/images/blog/say-it-with-a-single-word/sharpen-weekly-nhibernate-say-it-with-a-single-word.png)

The [`EmptyMapClass<TKey, TValue>` class](https://github.com/nhibernate/nhibernate-core/blob/3747daf1265f4802015dff5370f658586b2d51bb/src/NHibernate/Util/CollectionHelper.cs#L55) contains the following indexer:

    public TValue this[TKey key]
    {
        get { return default(TValue); }
        set { /* Omitted for brevity. */ }
    }

After applying both the [C# 7.0 expression bodied members for getters](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members#property-get-statements) and the [C# 7.1 default expressions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/default-value-expressions) the getter strips down to a single word only!

    public TValue this[TKey key]
    {
        get => default;
        set { /* Omitted for brevity. */ }
    }

Why do I like this example so much? For me, **it demonstrates, almost symbolically, the elegance and expressiveness of the modern C#**. We have much less to type and to read. Sometimes, just a single word. It is up to the compiler to figure out the "missing parts".

What do *you* think of this small real-life example found by the help of Sharpen? Are you thrilled about it the same way I am, or you see it as a hard-to-digest syntax sugar? ;-) The comments are below, waiting for your opinion :-)