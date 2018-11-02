---
title: "Sharpen v0.1.0 - Just Ship It!"
date: 2017-11-23T00:00:00-00:00
description: "If you are not embarrassed by the first version of your product, you've launched too late."
categories: []
keywords: ["sharpen", "release"]
slug: ""
aliases: [/news/sharpen-v0.1.0-just-ship-it/]
toc: false
draft: false
---
# Pride and Embarrassment
Proud and embarrassed at the same time, I'm happy to announce that the Sharpen v0.1.0 just got shipped and is available for [download on the Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen) :-)
 
[Reid Hoffman](https://en.wikipedia.org/wiki/Reid_Hoffman) famously wrote:

![If you are not embarrassed by the first version of your product, you've launched too late](/images/blog/sharpen-v0.1.0-just-ship-it/if-you-are-not-embarrassed-by-the-first-version-of-your-product-youve-launched-too-late.png)

Considering that I'am embarrassed with its first incarnation, Sharpen obviously didn't launch too late :-) And I hope it didn't launch [too early](https://www.inc.com/neil-patel/why-i-totally-disagree-with-just-ship-it-startup-mentality.html) either.

Why embarrassed and proud at the same time?

Embarrassed because the version 0.1.0 is still light years away from the Sharpen's vision. It hardly gives even a slight glimpse of features listed on the [Sharpen's homepage](http://sharpen.rocks):

- **Faster Learning of New C# Features**<br/>
Yes, v0.1.0 "points to places in real-life production code, your code!, where new C# features should be used." But it does that for just a very limited number of C# 6.0 and C# 7.0 features.

- **Critical Approach to New C# Features**<br/>
Recommendations are still not there and will not be there for some time...

- **Consistent Usage of C# Features**<br/>
... and the same is with the user configuration...

- **Code Refactorings on Arbitrary Scale**<br/>
... and with the refactorings...

- **Improving the Design on a Larger Scope**<br/>
... and with that "intelligent heuristics that recognizes potential improvements of your code base on a larger scope"...

- **Extensive Documentation on C# Language**<br/>
...and with the built-in extensive documentation on C# language features.

Surely enough reasons to be embarrassed.

But at the same time I'm proud on this first release. The v0.1.0 served me more then well while giving my talk on [Losing Weight With C# 7+](https://github.com/ironcev/public-talks/tree/master/LosingWeightWithCSharp7%2B) in [Graz, Austria](https://www.meetup.com/MicrosoftDeveloperGraz/events/243975926/) and [Zagreb, Croatia](https://www.meetup.com/devugzg/events/244521212/). It made introduction of at least some C# 7+ features more tangible.

The version 0.1.0 has also sparkled interesting discussions with my friends and colleagues on the topic of effective learning of new C# features.

Last but not least it has given first interesting results and insights. I was always puzzled with a question how much an average, few-year-old C# program, could benefit of new C# features. In other words, on how many places in the existing code can we *meaningfully* apply new C# features and get smaller, simpler, more expressive and more readable code.

As soon as the first Sharpen suggestions were implemented I ran them on one of such "average" projects, average for the company I work for:

![An average C# project](/images/blog/sharpen-v0.1.0-just-ship-it/average-csharp-project.png)

Intuitively I expected thousand-something findings. But not tens of thousands! Here are the Sharpen v0.1.0 results for that average C# project:

![Sharpen results for an average C# project](/images/blog/sharpen-v0.1.0-just-ship-it/sharpen-results-for-an-average-csharp-project.png)

The results for open source C# projects were no less surprising. Here are the Sharpen v0.1.0 results for [NHibernate](http://nhibernate.info/):

![Sharpen results for NHibernate](/images/blog/sharpen-v0.1.0-just-ship-it/sharpen-results-for-nhibernate.png)

Of course, not all of those 10,000+ places are the places where we want to use the features. My manual inspection of the findings says that roughly 30% of them are places where we actually do not want to apply a certain suggestion. Exactly on these 30% I expect Sharpen recommendations to one day give a clear *No!* to a language feature.

I can only guess how big the number of findings will be once when many more C# features are going to be covered by the Sharpen analysis.

# Release Content
So, what is exactly in the embarrassing v0.1.0? {{< release "0.1.0" >}} Here is the summary of the major changes:

- Several suggestions related to the usage of [expression bodied members](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members)

- The analysis which works for the whole solution.

- Display of the results in a tree view that orders the findings by the C# version and suggestion.

[Download Sharpen v0.1.0 from the Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ironcev.sharpen) and give it a try on your own. I'm curious how surprising your findings will be :-)