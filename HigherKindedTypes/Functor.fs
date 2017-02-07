namespace HigherKindedTypes

/// <summary> any HigherKindedType that defines a <c>map</c> function </summary>
type Functor<'M> =
  abstract member Map : ('a -> 'b) -> HigherKindedType<'M, 'a> -> HigherKindedType<'M, 'b>

module Functor = 
  let map (f : 'a -> 'b) (x : HigherKindedType<'M, 'a> when 'M :> Functor<'M>) = 
    x.TypeFunctions.Map f x

