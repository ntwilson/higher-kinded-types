namespace HigherKindedTypes

/// <summary>
/// Represents the generic type <c>'M&lt;'a></c>.  
/// Since F# natively doesn't support this concept, we use the type 
/// <c>HigherKindedType&lt;'M, 'a></c> in its place.  This would allow you to express
/// generics where the "wrapper" type and the "wrapped" type are treated independently - 
/// such as in a functor, where <c>map</c> would have the signature: 
/// <para><c>('a -> 'b) -> 'M&lt;'a> -> 'M&lt;'b></c></para>
/// <para>This can now be expressed as: </para>
/// <para><c>('a -> 'b) -> HigherKindedType&lt;'M, 'a> -> HigherKindedType&lt;'M, 'b></c></para>
/// </summary>
type HigherKindedType<'M, 'a> (value : obj, typeFunctions: 'M) = 
  /// <summary> 
  /// The represented value of the HigherKindedType, the actual value of the <c>'M&lt;'a></c> 
  /// <para>Since it is not a representable type in F#, it needs to be cast back to <c>'M&lt;'a></c>
  /// before use.  The typical pattern is to define a static member 
  /// <c>'M.FromHigherKindedType</c> (in addition to member <c>'M.ToHigherKindedType</c>)</para>
  /// <para> (note that the above is not valid code.  It would need to be a concrete example,
  /// such as <c>List.FromHigherKindedType</c>, or <c>Option.ToHigherKindedType</c>)</para>
  /// </summary>
  member this.Value = value
  /// <summary>
  /// The static functions operable on all types of <c>'M&lt;_></c> 
  /// <para>If <c>'M</c> is constrained to implement the <c>Functor</c> interface, 
  /// for example, this would contain the <c>map</c> function </para>
  /// </summary>
  member this.TypeFunctions = typeFunctions
