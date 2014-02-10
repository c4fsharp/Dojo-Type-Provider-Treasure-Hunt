"Type Provider Treasure Hunt" Dojo
==================================

This Dojo introduces F# type providers using those from the [F# Data library](http://fsharp.github.io/FSharp.Data/).

The goal of the Dojo is to find 7 secret words to find a secret phrase! To find each word, you need to solve a simple
data access task using type providers - such as read XML document, perform JSON-based REST request or read data from
the WorldBank; then perform simple processing to find the right word in the result and find the secret phrase!
The Dojo comes with a script file containing 7 tasks - to make this a bit harder, the words are not in the original
order, so you need to get most of them to find the secret phrase.

## How to run the Dojo

The Dojo comes with a guided script with samples that can be adjusted. Some of the tasks are fairly easy, some require
a bit more F# skills. The Dojo works best if the audience collaborates to solve the puzzle - split into groups and work
on the different words in parallel, then put the results together! If you split into 7 groups, you can solve the puzzle
in about 1 hour. With more time, each group can find multiple words.

## Building and running the sample

The sampe solution uses NuGet restore to get the `FSharp.Data.dll` automatically. Open `TypeProviders-Dojo.sln` and 
Build the solution once - this will download F# Data into `packages` folder and you can then open `Script.fsx` and 
go through the script in F# Interactive (the build is only needed to restore the packages).

Alternatively, you can download ZIP release from [F# Data](http://fsharp.github.io/FSharp.Data/) web site, open
`Script.fsx` directly and update the path there.

Have fun!