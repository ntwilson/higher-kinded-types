namespace HigherKindedTypes

/// <summary> 
/// This is the "typeclass implementation" for <c>List</c> that is meant to be used with the 
/// <c>HigherKindedType</c> system.  It provides static members to switch between normal 
/// types and <c>HigherKindedTypes</c>, as well as all the static functions that the 
/// List "typeclass implementation" would implement (such as the <c>map</c> function from the 
/// <c>Functor</c> interface).
/// </summary>
type List private () = 
  static member toHigherKindedType (x : 'a list) = HigherKindedType<List, 'a> (x, new List())
  static member fromHigherKindedType (x : HigherKindedType<List, 'a>) = x.Value :?> 'a list


  interface Functor<List> with
    member this.Map (f : 'a -> 'b) (x : HigherKindedType<List, 'a>) =
      List.map f (List.fromHigherKindedType x) |> List.toHigherKindedType

  interface Collection<List> with
    member this.Zip (left : HigherKindedType<List, 'a>) (right : HigherKindedType<List, 'b>) =
      List.zip (List.fromHigherKindedType left) (List.fromHigherKindedType right) 
      |> List.toHigherKindedType

    member this.Filter (predicate : 'a -> bool) (xs : HigherKindedType<List, 'a>) =
      List.filter predicate (List.fromHigherKindedType xs) |> List.toHigherKindedType

[<AutoOpen>]
module ListActivePatterns = 
  let (|HigherKindedList|) (x:HigherKindedType<List, 'a>) = List.fromHigherKindedType x
  let (|LowerKindedList|) (x:'a list) = List.toHigherKindedType x
