---
title: "Out Variables Under the Hood"
date: 2018-01-14T21:43:00+01:00
description: "Let's take a look on how C# 7.0 Out Variables work under the hood."
categories: []
keywords: ["under-the-hood", "out-variables"]
slug: ""
aliases: []
toc: false
draft: false
---
# C# 7.0 Out Variables
Have you read the [Epilogue of the Sharpen's 2017 World Tour]({{< ref "sharpens-2017-world-tour.md#epilogue" >}}) yet? :-) If yes, you know already that the soon coming Sharpen v0.3.0 will support [C# 7.0 out variables](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#out-variables). 

Starting from C# 7.0, we can declare `out` variables in the argument list of a method call. Thus, our beloved `int.TryParse()` calls:

    int result;
    if ( int.TryParse(input, out result) )

 can now look like this (notice the `int` keyword right after the `out`):

    if ( int.TryParse(input, out int result) )

We can even use `var`s and let the compiler infer the type:

    if ( int.TryParse(input, out var result) )

But for sure the most interesting feature is the possibility to [ignore (discard)](https://docs.microsoft.com/en-us/dotnet/csharp/discards) the values of the out parameters in case we do not need them:

    if ( int.TryParse(input, out _) )

How out variables work in the background? What kind of code the C# compiler generates? How does it differ from the usual code in which we declare the out variables upfront?

# SharpLab
To answer these questions (and actually all under-the-hood kind of questions) we will utilize [SharpLab](https://sharplab.io/). SharpLab is an extremely useful tool for everyone who wants to know C# better. (I plan to write a separate blog post on SharpLab so stay tuned ;-) For the purpose of this post we will utilize SharpLab's feature of showing the compilation result as an equivalent C# code.

To use this feature, simply select the *Results C#* on the top of the SharpLab's right panel:

![SharpLab - showing the compilation result as an equivalent C# code](/images/blog/out-variables-under-the-hood/sharplab-showing-the-compilation-result-as-an-equivalent-csharp-code.png)

The equivalent C# code is more or less one-to-one translation of the underlying IL construct to C#. In other words, it removes all the syntax sugar and higher level C# features, like in this case, out variables.

So let us utilize SharpLab and see how the out variables look under the hood.

# A Single Out Variable Under the Hood
Let's assume that we have a method with a single out variable:

    bool GetSingleOutValue(out int value)

Let's call the method in all three way, classically by declaring the out variable upfront, and by using the out variables:

    void ClassicalWay()
    {
        int value;
        GetSingleOutValue(out value);
    }

    void WithOutVariable()
    {
        GetSingleOutValue(out int value);
    }

    void WithOutVariableAndTypeInference()
    {
        GetSingleOutValue(out var value);
    }

Here is what the compiler will generate:

    void ClassicalWay()
    {
        int num;
        this.GetSingleOutValue(out num);
    }

    void WithOutVariable()
    {
        int num;
        this.GetSingleOutValue(out num);
    }

    void WithOutVariableAndTypeInference()
    {
        int num;
        this.GetSingleOutValue(out num);
    }

[Try this example on your own on SharpLab.](https://sharplab.io/#v2:D4AjIAQJhBxBTALoglgOwOYGV0YDbwDyArogGoCGex8AsAFDggDeDTTEAzCAEYD2fPHCQ5MBEuSo0AFH1Ih0iEADcp8AJRt2YVo23tV1eCAC8IAAwBuLfvAQA7CEQAnGtb3aAvgxvsukABYQAGE8CgBncJQAYyoAdQoAT2lND3ZdWyZFFTV3TPAERFF8IlJKI1l5Qxp1PP1vel8ObggguJREAAsJSmcUCh4CFKbwDPzhItxxMrVKpWzqjTqvHzTmwJB2rp6KPoGCAEE0ABMAFUSAB3gASTQAM3hneDRo+GG10ZHtQuLpyQq5EpVM4ckZal8QA0If5WpsOp0ACIocKxZzHd62Mb5H5TUr/GSAkAAfXBHzADSYDSAA)

**The compiler output is completely the same in all three cases which is not surprising at all. Out variables, used like this, are merely a syntax sugar around the "classical usage".**

The interesting question is, what happens in the case of discarding the out value.

    void WithDiscard()
    {
        GetSingleOutValue(out _);
    }

Although the caller does not need the out value, the `GetSingleOutValue()` methods still needs an out variable. It needs it in order to be called properly and in order to be able to execute its internal code, of course. So, again not surprisingly at all, also in this case the compiler will generate the same calling code:

    void WithDiscard()
    {
        int num;
        this.GetSingleOutValue(out num);
    }

The `num` variable serves in this case as a "placeholder" for the discarded out value.

# Multiple Discarded Out Variables Under the Hood
The interesting question is what the compiler does if we discard multiple out variables of the same type.

Let's assume that we have a method with two out variables of the same type:

    bool GetSeveralOutValues(out int first, out int second)

Let's now call the method by discarding both values:

    GetSeveralOutValues(out _, out _);

Since the out values are not used, one could come to an idea that the compiler could optimize the call and create just a single "placeholder" and pass it as parameter twice. We anyway do not care about the output and the value of the "placeholder" after the call.

    int num;
    this.GetSeveralOutValues(out num, out num);

Compiler however does not do such optimization. It rather creates a "placeholder" for each argument:

    int num;
    int num2;
    this.GetSeveralOutValues(out num, out num2);

[Try this example on your own on SharpLab.](https://sharplab.io/#v2:D4AQTABA4gpgLnAlgOwOYGUYDcYCcCGANgPICucAakaTAM4CwAUAN5MTsQgDMEARgPb9C0eJhwES5KoRq0AFP3IQUcCADNEuWnAA0ERapURaMAMb9kAEwCUbDq0Ycn6zdogBeCAAYA3HefGZhaWHt5+jgGcAOwQcLg04U4Avkz+nDwgACwQACKItKb4uJYoqABC/HAAFtKycrYR7A6RInBieERklNR0CkoA+noGEP3WiRwpjJNAA)

If we give it a thought it will immediately be clear why such "optimization" is in general not possible. Yes, the caller is not interested in the returned values, but in general case, those values could be used within the method itself. Moreover, the method contract can assume that the two arguments point to two different variables. We must not forget that **assigning a value to an out variable inside of the method actually assigns the value to the original variable that was passed as an argument**.

To illustrate this case, let's use the following method:

    int GetSeveralOutValues(out int first, out int second)
    {
        first = 1;
        second = 2;
        return first + second;
    }

When called like this, the method will return 3:

    int num;
    int num2;
    this.GetSeveralOutValues(out num, out num2);

However, if we apply the suggested "optimization":

    int num;
    this.GetSeveralOutValues(out num, out num);

the method will return 4! Assigning `2` to `second` will at the same time change the `first` because in reality they are pointing to the same value - `num`.

**To sum it up, in case of out variables, the compiler will generate exactly the same code that we would otherwise write manually.**

How about out variables in your own code. Do you use them already? In particular, did you have a case in your code where discards turned out to be useful?