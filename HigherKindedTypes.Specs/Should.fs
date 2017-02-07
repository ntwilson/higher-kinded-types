namespace HigherKindedTypes.Specs

module Should =
  open NUnit.Framework

  let shouldBe expected actual = 
    Assert.AreEqual (expected, actual)