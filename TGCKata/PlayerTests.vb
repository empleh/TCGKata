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

End Class