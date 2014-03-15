Imports System.Runtime

<TestClass()> Public Class PlayerTests
  Public Property Target() As Player

  <TestInitialize()> Public Sub BeforeEachTest()
    Target = New Player()
  End Sub

  <TestMethod()> Public Sub PlayerStartsWith30Health()
    Const expected As Integer = 30

    Dim actual As Integer = Target.Health

    Assert.AreEqual(expected, actual)
  End Sub

  <TestMethod()> Public Sub PlayerStartsWith0Mana()
    Const expected As Integer = 0

    Dim actual As Integer = Target.Mana

    Assert.AreEqual(expected, actual)
  End Sub


  <TestMethod()> Public Sub PlayerHasADeck()
    Assert.IsTrue(Target.Deck IsNot Nothing)
  End Sub

  <TestMethod()> Public Sub PlayersHandStartsWith3Cards()
    Const expected As Integer = 3

    Dim actual = Target.Hand.Count

    Assert.AreEqual(expected, actual)
  End Sub

  <TestMethod()> Public Sub PlayersManaIsNeverGreaterThan10()
    Const limit As Integer = 10

    For i As Integer = 0 To 20
      Target.StartTurn()

      Assert.IsTrue(Target.Mana <= limit)
    Next
  End Sub

  <TestMethod()> Public Sub PlayerIncreasesManaEachTurnBy1()
    Const limit As Integer = 10

    Dim previousMana = Target.Mana
    While Target.Mana < limit
      Target.StartTurn()

      Dim expected As Integer = previousMana + 1
      Dim actual As Integer = Target.Mana

      previousMana = Target.Mana

      Assert.AreEqual(expected, actual)
    End While
  End Sub

End Class