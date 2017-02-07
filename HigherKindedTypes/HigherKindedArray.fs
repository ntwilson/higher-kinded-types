namespace HigherKindedTypes

/// <summary> 
/// This is the "typeclass implementation" for <c>Array</c> that is meant to be used with the 
/// <c>HigherKindedType</c> system.  It provides static members to switch between normal 
/// types and <c>HigherKindedTypes</c>, as well as all the static functions that the 
/// Array "typeclass implementation" would implement (such as the <c>map</c> function from the 
/// <c>Functor</c> interface).
/// </summary>
type Array private () = 
  static member toHigherKindedType (x : 'a[]) = HigherKindedType<Array, 'a> (x, new Array())
  static member fromHigherKindedType (x : HigherKindedType<Array, 'a>) = x.Value :?> 'a[]


  interface Functor<Array> with
    member this.Map (f : 'a -> 'b) (x : HigherKindedType<Array, 'a>) =
      Array.map f (Array.fromHigherKindedType x) |> Array.toHigherKindedType

  interface Collection<Array> with
    member this.Zip (left : HigherKindedType<Array, 'a>) (right : HigherKindedType<Array, 'b>) =
      Array.zip (Array.fromHigherKindedType left) (Array.fromHigherKindedType right) 
      |> Array.toHigherKindedType

    member this.Filter (predicate : 'a -> bool) (xs : HigherKindedType<Array, 'a>) =
      Array.filter predicate (Array.fromHigherKindedType xs) |> Array.toHigherKindedType

[<AutoOpen>]
module ArrayActivePatterns = 
  let (|HigherKindedArray|) (x:HigherKindedType<Array, 'a>) = Array.fromHigherKindedType x
  let (|LowerKindedArray|) (x:'a[]) = Array.toHigherKindedType x
