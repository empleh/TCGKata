Public Class Deck
  Public Property Cards() As List(Of Card)

  Public Sub New()
    Cards = New List(Of Card)()

    Cards.AddRange((From value In ({0, 0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 8})
                    Select New Card(value)))
  End Sub

  Public Function Draw() As Card
    Dim card As Card = Cards.First()

    Cards.Remove(card)
    Return card
  End Function

  Public Sub Shuffle()
    Dim numberOfShuffles As Integer = New Random().Next(10, 100)

    For i As Integer = 0 To numberOfShuffles
      RandomizeCardOrder()
    Next
  End Sub

  Private Sub RandomizeCardOrder()

  End Sub
End Class