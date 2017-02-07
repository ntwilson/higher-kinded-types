namespace HigherKindedTypes

/// <summary> 
/// This is the "typeclass implementation" for <c>Option</c> that is meant to be used with the 
/// <c>HigherKindedType</c> system.  It provides static members to switch between normal 
/// types and <c>HigherKindedTypes</c>, as well as all the static functions that the 
/// Option "typeclass implementation" would implement (such as the <c>map</c> function from the 
/// <c>Functor</c> interface).
/// </summary>
type Option private () = 
  static member ToHigherKindedType (x : 'a option) = HigherKindedType<Option, 'a> (x, new Option())
  static member FromHigherKindedType (x : HigherKindedType<Option, 'a>) = x.Value :?> 'a option

  interface Functor<Option> with 
    member this.Map (f : 'a -> 'b) (x : HigherKindedType<Option, 'a>) = 
      Option.map f (Option.FromHigherKindedType x) |> Option.ToHigherKindedType