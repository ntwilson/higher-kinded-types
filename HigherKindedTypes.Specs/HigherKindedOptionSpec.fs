namespace HigherKindedTypes.Specs

open NUnit.Framework

[<TestFixture>]
module HigherKindedListSpec =
  open Should
  open HigherKindedTypes

  [<Test>]
  let ``can switch between normal types and higher kinded types`` () =
    let a = Some 1

    let a' = Option.ToHigherKindedType a

    let shouldBeOfHigherKindedType (x : HigherKindedType<'M, 'a>) = ()

    a' |> shouldBeOfHigherKindedType

    Option.FromHigherKindedType a'
    |> shouldBe a

  [<Test>]
  let ``is a functor`` () =
    Some 1 |> Option.ToHigherKindedType
    |> Functor.map ((+) 5)
    |> Option.FromHigherKindedType
    |> shouldBe (Some 6)
