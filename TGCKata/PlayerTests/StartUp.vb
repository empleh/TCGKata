Namespace PlayerTests
  <TestClass()> Public Class StartUp
    Public Property Target() As Player

    <TestInitialize()> Public Sub BeforeEachTest()
      Target = New Player()
    End Sub

    <TestMethod()> Public Sub PlayerStartsWith30Health()
      Const expected As Integer = 30

      Dim actual As Integer = Target.Health

      Assert.AreEqual(expected, actual)
    End Sub

    <TestMethod()> Public Sub PlayerStartsWith0ManaSlots()
      Const expected As Integer = 0

      Dim actual As Integer = Target.ManaSlots

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

    <TestMethod()> Public Sub PlayerStatusStartsAsNotActive()
      Const expected As Player.PlayerStatus = Player.PlayerStatus.NotActive

      Dim actual As Player.PlayerStatus = Target.Status

      Assert.AreEqual(expected, actual)
    End Sub
  End Class
End Namespace