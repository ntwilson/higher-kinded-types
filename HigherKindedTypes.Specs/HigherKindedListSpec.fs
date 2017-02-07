namespace HigherKindedTypes.Specs

open NUnit.Framework

[<TestFixture>]
module ListSpec = 
  open Should
  open HigherKindedTypes

  [<Test>]
  let ``can switch between normal and higher kinded type`` () =
    let a = [1]
    let a' = List.toHigherKindedType a

    let shouldBeOfHigherKindedTypeAndConvertable (x : HigherKindedType<List, 'a>) = 
        x |> List.fromHigherKindedType
        |> shouldBe a

    a' |> shouldBeOfHigherKindedTypeAndConvertable

  [<Test>]
  let ``is a functor`` () =
    [1] |> List.toHigherKindedType
    |> Functor.map ((+) 5)
    |> List.fromHigherKindedType
    |> shouldBe [6]

  [<Test>]
  let ``provides active patterns for switching between normal and higher kinded types`` () =
    let operateOnHigherLevel (LowerKindedList lst) =
      lst |> Functor.map ((+) 5)

    let (HigherKindedList result) = operateOnHigherLevel [1]
    result |> shouldBe [6]


  [<Test>]
  let ``is a collection`` () =
    let doCollectionOperations xs =
      xs 
      |> Collection.zip xs
      |> Collection.filter (fun (left, right) -> left <= 5)
      |> Functor.map (fun (left, right) -> (left + 5, right - 5))
    
    List.toHigherKindedType [ 1 .. 10 ]
    |> doCollectionOperations
    |> List.fromHigherKindedType
    |> shouldBe 
        ([1 .. 5] |> List.map (fun x -> (x + 5, x - 5)))
