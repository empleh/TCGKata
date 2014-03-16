Public Class Player
  Public Property Health() As Integer = 30

  Private Const ManaLimit As Integer = 10
  Public Property ManaSlots() As Integer = 0
  Public Property Mana() As Integer

  Public Property Deck() As Deck

  Public Property Hand() As List(Of Card)

  Public Property Status() As PlayerStatus

  Public Enum PlayerStatus
    Active
    NotActive
  End Enum

  Public Sub New()
    Deck = New Deck()
    Deck.Shuffle()

    Hand = New List(Of Card)({Deck.Draw(), Deck.Draw(), Deck.Draw()})

    Status = PlayerStatus.NotActive
  End Sub

  Public Sub StartTurn()
    Me.Status = PlayerStatus.Active

    If Me.ManaSlots < ManaLimit Then
      Me.ManaSlots += 1
    End If

    Me.Mana = Me.ManaSlots

    Me.Hand.Add(Me.Deck.Draw())
  End Sub

  Public Sub EndTurn()
    Me.Status = PlayerStatus.NotActive
  End Sub

  Public Sub Play(ByVal i As Integer)
    Dim selectedCard As Card = Me.Hand.FirstOrDefault(Function(c) c.Mana = i)

    If selectedCard Is Nothing Then
      Throw New ArgumentException("Player does NOT have that card in Hand")
    End If

    If selectedCard.Mana > Me.Mana Then
      Throw New ArgumentException("Player does NOT have enough Mana to play that Card")
    End If
  End Sub

  Public Sub ReceiveDamage(ByVal damageAmount As Integer)
    Me.Health -= damageAmount
  End Sub
End Class