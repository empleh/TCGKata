Namespace GameTests
  <TestClass()> Public Class GameRules
    Private _player1 As Player
    Private _player2 As Player

    Private Property Target() As Game

    <TestInitialize()> Public Sub BeforeEachTest()
      _player1 = New Player
      _player2 = New Player

      Target() = New Game(_player1, _player2)
    End Sub

    <TestMethod()>
    Public Sub WhenPlayer1HealthDropsTo0Player2Wins()
      Dim expected As Player = _player2

      Target.DealDamage(_player2, _player1, _player1.Health)

      Dim actual As Player = Target.Winner

      Assert.AreEqual(expected, actual)
    End Sub

    <TestMethod()>
    Public Sub WhenPlayer1HealthDropsBelow0Player2Wins()
      Dim expected As Player = _player2

      Target.DealDamage(_player2, _player1, _player1.Health + 30)

      Dim actual as Player = Target.Winner

      Assert.AreEqual(expected, actual)
    End Sub

    <TestMethod()>
    Public Sub IfBothPlayersHavePositiveHealthNoWinner()
      Dim actual As Player = Target.Winner

      Assert.IsNull(actual)
    End Sub


  End Class
End Namespace

Public Class Game
  Public Property Player1() As Player
  Public Property Player2() As Player

  Public Property Winner() As Player

  Public Sub New(firstPlayer As Player,
                 secondPlayer As Player)
    Player1 = firstPlayer
    Player2 = secondPlayer
  End Sub

  Public Sub DealDamage(ByVal attackingPlayer As Player, ByVal receivingPlayer As Player, ByVal damageAmount As Integer)
    receivingPlayer.ReceiveDamage(damageAmount)

    If receivingPlayer.Health <= 0 Then
      Me.Winner = attackingPlayer
    End If
  End Sub
End Class