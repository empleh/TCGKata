Namespace PlayerTests
  <TestClass()> Public Class Rules
    Public Property Target() As Player

    <TestInitialize()> Public Sub BeforeEachTest()
      Target = New Player()
    End Sub

    <TestMethod()> Public Sub PlayersManaIsNeverGreaterThan10()
      Const limit As Integer = 10

      For i As Integer = 0 To 15
        Target.StartTurn()

        Assert.IsTrue(Target.ManaSlots <= limit)
      Next
    End Sub

    <TestMethod()> Public Sub PlayerIncreasesManaEachTurnBy1()
      Const limit As Integer = 10

      Dim previousMana = Target.ManaSlots
      While Target.ManaSlots < limit
        Target.StartTurn()

        Dim expected As Integer = previousMana + 1
        Dim actual As Integer = Target.ManaSlots

        previousMana = Target.ManaSlots

        Assert.AreEqual(expected, actual)
      End While
    End Sub

    <TestMethod()> Public Sub PlayerStatusIsActiveAfterStartTurnButBeforeEndTurn()
      Const expected As Player.PlayerStatus = Player.PlayerStatus.Active

      Target.StartTurn()
      Dim actual As Player.PlayerStatus = Target.Status
      Target.EndTurn()

      Assert.AreEqual(expected, actual)
    End Sub

    <TestMethod()> Public Sub PlayerStatusIsNotActiveAfterEndTurn()
      Const expected As Player.PlayerStatus = Player.PlayerStatus.NotActive

      Target.StartTurn()
      Target.EndTurn()

      Dim actual As Player.PlayerStatus = Target.Status

      Assert.AreEqual(expected, actual)
    End Sub

    <TestMethod()> Public Sub PlayerManaMatchesManaSlotsAfterStartTurn()

      For i As Integer = 1 To 15
        Target.StartTurn()

        Dim expected As Integer = Target.ManaSlots
        Dim actual As Integer = Target.Mana

        Assert.AreEqual(expected, actual)

        Target.EndTurn()
      Next
    End Sub

    <TestMethod()>
    Public Sub PlayerDraws1CardAtTheStartOfEachTurn()

      Dim previousHandCount As Integer = Target.Hand.Count
      For i As Integer = 1 To 10
        Dim expected As Integer = previousHandCount + 1

        Target.StartTurn()
        Dim actual As Integer = Target.Hand.Count

        Assert.AreEqual(expected, actual)

        Target.EndTurn()
        previousHandCount = Target.Hand.Count
      Next

    End Sub
  End Class
End Namespace