namespace HigherKindedTypes

type Collection<'M> =
  inherit Functor<'M>

  abstract member Filter : ('a -> bool) -> HigherKindedType<'M, 'a> -> HigherKindedType<'M, 'a>
  abstract member Zip : HigherKindedType<'M, 'a> -> HigherKindedType<'M, 'b> -> HigherKindedType<'M, 'a*'b>

module Collection =
  let filter predicate (x : HigherKindedType<'M, 'a> when 'M :> Collection<'M>) = 
    x.TypeFunctions.Filter predicate x
  let zip (left : HigherKindedType<'M, 'a> when 'M :> Collection<'M>) right = 
    left.TypeFunctions.Zip left right
