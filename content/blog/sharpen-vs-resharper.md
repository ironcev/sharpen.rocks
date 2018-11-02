---
title: "Sharpen vs ReSharper"
date: 2018-05-30T03:40:00+01:00
description: "What makes Sharpen different then ReSharper?"
categories: []
keywords: ["sharpen", "resharper"]
slug: ""
aliases: [/news/sharpen-vs-resharper/]
toc: false
draft: false
---
# Facing the Question of Difference
Ever since I released [the very first embarrassing version of Sharpen]({{< ref "sharpen-v0.1.0-just-ship-it.md" >}}) I got confronted with the question "How is Sharpen different then ReSharper?" I liked the question primarily because I love ReSharper. The question was telling me that people do use ReSharper and that they are aware of its capabilities when it comes to the support of new C# language features.

I liked the question because it also helped me to sharpen Sharpen's vision. Sharpen is not ReSharper, but what is it? Why do I believe that it's needed and useful? The ever repeating question of difference between the two helped me to fortify my belief that we need a tool like Sharpen, a tool that will help us to learn new C# features better and faster by applying them critically to our existing code.

But this blog post is not about "why Sharpen?" It is about the difference between Sharpen and ReSharper so let's dive deeper into that topic.

That question of difference between the two was coming to me repeatedly and is still coming. I didn't feel the urge of answering it publicly until [series0ne](https://twitter.com/series0ne) didn't ask it publicly in his twitt:

{{< tweet 935424333937369088 >}}

And so here I am, answering the question (six month after it was asked, shame on me!).

# The Difference

Sharpen and ReSharper fulfill different purposes and cover different use cases. I find them to be complementary. This comparison gives a summary of their major differences:

![Sharpen vs ReSharper](/images/blog/sharpen-vs-resharper/sharpen-vs-resharper.png)

Let's explore those differences in more detail.

## Learning vs Productivity and Quality Tool

Both tools offer refactoring, which is an obvious overlap. (Actually, to be precise, in its current version 0.5.0 Sharpen still do not offer its own refactoring, but this is a planned feature and a big part of [Sharpen's vision](/).) But Sharpen's and ReSharper's refactoring is used for different purposes. ReSharper focuses on developer's productivity and [its refactoring serves developer's productivity and quality](https://www.jetbrains.com/resharper/features/code_refactoring.html).

On the other hand, Sharpen utilize refactoring to bring awareness of new C# features and to intelligently introduce them into an existing code base. In other words, ReSharper focuses on productivity, while Sharpen focuses on learning. To give a full picture, we have to say that Sharpen indirectly also increases developer's productivity and code quality. Proposed new language features often bring better expressiveness that affects coding productivity. Removing unnecessary clutter from code or [replacing parts of code with safer equivalents]({{< ref "sharpen-v0.5.0-nameof-expressions-in-exceptions-and-dependency-properties.md" >}}) directly affects code quality.

## Only New C# Features vs General Static Analysis

ReSharper offers [a broad range of static analysis](https://www.jetbrains.com/resharper/features/code_analysis.html) while Sharpen focuses only on usages of new C# features. Having narrow focus enables Sharpen to excel in this area and over time outperform ReSharper's suggestions that cover new language features.

Sharpen's suggestions are also more precise and always bring a context around them. This gives developers an opportunity to create a mental map of areas in which a particular language feature is useful.

Just as an example, while ReSharper will always say "inconsistent body style: use expression body":

![ReSharper - inconsistent body style: use expression body](/images/blog/sharpen-vs-resharper/resharper-inconsistent-body-style-use-expression-body.png)

Sharpen will break this suggestion into several in order to provide meaningful context and if necessary detailed documentation for every particular case:

![Sharpen - use expression-body suggestions](/images/blog/sharpen-vs-resharper/sharpen-use-expression-body-suggestions.png)

## On Demand vs Continuous Usage

ReSharper runs 24 / 7. Once installed, it becomes an integral part of overall Visual Studio coding experience. When you get use to it, it becomes difficult to imagine programming without it. Unlike that, Sharpen is meant to be used occasionally and started on demand.

Yes, you heard it right. Sharpen does not offer any suggestions in the editor while typing and it never will. Running the analysis must be a conscious, separate act. Act performed in order to learn, to recognize refactoring potential, to plan switching the code base to new C# features.

This being said, one of my major motivations to develop Sharpen was supporting my talks and workshops. Demonstrating new C# features on artificial code samples is not nearly that powerful and didactically advanced as demonstrating them on real-life code - *your* own code.

We start Sharpen analysis because we want to learn out of its result. We want to get a complete overview where our projects are when it comes to new C# features. We want to plan adopting those features ones we fully understand them.

We do not start ReSharper. It always runs. We use it to navigate through our code, to refactor it, to save us from unnecessary typing, to run unit tests, to name just a few of [many ReSharper features](https://www.jetbrains.com/resharper/features/).

## Strong Focus on Learning and Critical Usage of Language Features

ReSharper does not put any efforts in explaining its suggestions. How many times did you search Internet on your own to understand what some particular suggestion mean? Some of them are documented on ReSharper website, but not all.

ReSharper implicitly assumes that programmers already know what its suggestions are about, including those related to new language features.

On top of that, ReSharper is not very selective in proposing the suggestions. If the "language opportunity" is there, it will be proposed even if it might result in a code of poorer quality, e.g. a less readable and less understandable code. Yes, one can say it is up to developer to judge if a suggestion should be accepted or not. But out of mine and not only mine experience, and we will come to this later, suggestions are sometimes (often?) accepted non-critically, just because "ReSharper said it".

Sharpen comes with high-quality documentation on language features and its suggestions. (Actually, to be precise, in its current version 0.5.0 Sharpen still do not bring the documentation, but this is a planned feature and a big part of [Sharpen's vision](/).) On top of them, for each suggestion that might result in code of poorer quality, Sharpen displays so called recommendations that explain why eventually *not* to apply the proposed suggestion. (Recommendations are not available in the version 0.5.0 but needless to say are integral part of [Sharpen's vision](/).) The purpose of recommendations is to foster critical usage of language features and developing feeling for well written code.

## Improving Architecture vs Improving Local Code

Introduction of language features that bring "local" improvements in the code is already very important and useful and both ReSharper and Sharpen support them. I call such improvements, improvements on the language level. The abovementioned usage of expression-bodied members is an example of such an improvement. But new versions of C# offer us much more. They offer us opportunity to improve the code on a larger scale. That's why I prefer the term architectural level. For example async-await can replace obsolete asynchronous patterns or self-made attempts to master asynchronous programming. Such a replacement will in general case not be supported by automatic refactoring. But it can be given as a suggestion and linked to rich documentation that provides a feasible migration path.

## Free and Open vs Payed and Closed

Sharpen is free and open source while ReSharper is payed and closed source. Although not being a functional difference it is for sure a difference worth mentioning.

# Understanding vs Blindly Following

After [series0ne](https://twitter.com/series0ne) twitted his question we had a short private discussion on the topic. Out of it, I want to quote the following words coming from series0ne, emphasis mine:

> Unfortunately I’m one of minority that dislikes Resharper. I feel that it adds too much noise to Visual Studio, degrades performance, *and actually leads developers to blindly follow Resharper’s refactoring suggestions, rather than actually understand why Resharper is suggesting something, and even worse, not understanding the problem they’re trying to solve*.

The noise and performance claims deserve a blog post on their own, but they are out of topic of this one. The emphasized part of the quote, the one about blindly following ReSharper's suggestions is an opinion, or better to say experience, I fully share with series0ne.

I've seen it way to many times. Developers "blindly follow ReSharper's refactoring suggestions" and same as series0ne I tend to attribute that to the tool itself. ReSharper has a kind of invisible authority. For me this is an undeniable fact simply because I witnessed it way to many times to consider it to be a coincidence. "Why did I do it? Well... ReSharper suggested it."

Applying ReSharper's suggestions is literally effortless, which is of course an absolute prerequisite for a great productivity tool. But effortless usage of a suggestion one does not understand or even do not notice that it just got applied is a huge issue for me.

The blind following is a mélange of the invisible authority and effortless usage of a non-understood suggestion.

One can say that the responsibility is not on the tool but on the developer. It is hard to negate this statement. I have plenty of examples where developers actively advocated a more conscious usage of ReSharper or argued against standard ReSharper settings. But still, we have to accept the fact that not all developers posses that level of awareness. I understand that it is hard to design a *productivity tool* that should take care of suboptimal tool usage coming out of lack of knowledge and experience.

If ReSharper had any kind of constraints or attempted to warn the user of a potential misuse of the tool, this would only produce harm for those users who use the tool properly and with full awareness.

Here is where I see Sharpen as being complementary to ReSharper. Sharpen is primarily about learning and understanding, and not about immediate productive coding. Using Sharpen means stepping back from coding an taking time for learning. It means getting a view on the existing code through the eyes of modern C# compilers. It means taking time to discuss and plan refactoring.

Sharpen can allow itself to recommend to users not to apply a suggestion and then let them take time to understand why not. This approach - slow and with awareness - comes directly out of [Sharpen's vision](/).

This remark closes for me the topic of the difference(s) between Sharpen and ReSharper. It is your turn now :-) How do you see these differences? Are you a ReSharper user already? A "blind" or a "conscious" one? Or it depends? Do you see any benefits of having Sharpen next to ReSharper? Feel free to share your thoughts in the comments below. Your opinions and views are highly appreciated.