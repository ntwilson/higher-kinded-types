namespace HigherKindedTypes.Specs

open NUnit.Framework

[<TestFixture>]
module HigherKindedListSpec =
  open Should
  open HigherKindedTypes

  [<Test>]
  let ``can switch between normal types and higher kinded types`` () =
    let a = Some 1

    let a' = Option.toHigherKindedType a

    let shouldBeOfHigherKindedType (x : HigherKindedType<'M, 'a>) = ()

    a' |> shouldBeOfHigherKindedType

    Option.fromHigherKindedType a'
    |> shouldBe a

  [<Test>]
  let ``is a functor`` () =
    Some 1 |> Option.toHigherKindedType
    |> Functor.map ((+) 5)
    |> Option.fromHigherKindedType
    |> shouldBe (Some 6)
