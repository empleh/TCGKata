Public Class Player
  Public Property Health() As Integer = 30

  Private Const ManaLimit As Integer = 10
  Public Property Mana() As Integer = 0

  Public Property Deck() As Deck

  Public Property Hand() As List(Of Card)


  Public Sub New()
    Deck = New Deck()
    Deck.Shuffle()

    Hand = New List(Of Card)({Deck.Draw(), Deck.Draw(), Deck.Draw()})
  End Sub

  Public Sub StartTurn()
    If Me.Mana < ManaLimit Then
      Me.Mana += 1
    End If
  End Sub
End Class