<TestClass()> Public Class DeckTests
  Private Property Target() As Deck

  <TestInitialize()> Public Sub BeforeEachTest()
    Target = New Deck()

  End Sub

  <TestMethod()> Public Sub DeckStartsWith20Cards()
    Const expected As Integer = 20

    Dim actual = Target.Cards.Count

    Assert.AreEqual(expected, actual)
  End Sub

  <TestMethod()> Public Sub DeckHasCardsWithDefinedManaLevels()
    Dim expected = ({0, 0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 8})

    Dim actual = Target.Cards.Select(Function(c) c.Mana).ToList()

    CollectionAssert.AreEquivalent(expected, actual)
  End Sub

End Class