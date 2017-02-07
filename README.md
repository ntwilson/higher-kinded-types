# higher-kinded-types

Allows for higher-kinded generic types in F# (a.k.a. 'M<'T>) through the use of some compiler tricks.

Inspired by https://github.com/palladin/Higher/.  This library attempts to be more accessible 
to those less familiar with the subject, but is far less mature in it's capabilities

## usage
```F#
open HigherKindedTypes
...
let avg x y = (x + y) / 2.
let pairwiseAverage xs ys = 
  Collection.zip xs ys
  |> Functor.map avg

let lstXs = [1. .. 3.]
let lstYs = [3. .. 5.]

let ans = //ans is List<double> at compile-time
  pairwiseAverage (lstXs |> List.toHigherKindedType) (lstYs |> List.toHigherKindedType)
  |> List.fromHigherKindedType

let arXs = [|1. .. 3.|]
let arYs = [|3. .. 5.|]

let ans = //ans is Array<double> at compile-time
  pairwiseAverage (lstXs |> Array.toHigherKindedType) (lstYs |> Array.toHigherKindedType)
  |> Array.fromHigherKindedType
```

## methodology
