Namespace PlayerTests
  <TestClass()> Public Class PlayTests
    Private Property Target As Player

    <TestInitialize()>
    Public Sub BeforeEachTest()
      Target() = New Player()
    End Sub

    <TestMethod()>
    Public Sub WhenPlayerTriesToPlayACardWithMoreManaThanTheyHaveItThrowsAnException()
      Const expected As String = "Player does NOT have enough Mana to play that Card"
      Try
        Target.StartTurn()
        Target.Play(Target.Hand.Max(Function(c) c.Mana))
        Target.EndTurn()
      Catch ex As Exception
        Dim actual As String = ex.Message
        Assert.AreEqual(expected, actual)
      End Try
    End Sub

    <TestMethod()>
    Public Sub ExceptionIsThrowIfPlayerTriesToPlayACardNotInTheirHand()
      Const expected as String = "Player does NOT have that card in Hand"

      Try
        Target.StartTurn()
        Target.Play(9)
        Target.EndTurn()
      Catch ex As Exception
        Dim actual As String = ex.Message

        Assert.AreEqual(expected, actual)
      End Try
    End Sub
  End Class
End Namespace