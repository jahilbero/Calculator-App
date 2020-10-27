Public Class Form1

    Dim n1, n2 As Double
    Dim oprClickCount As Integer = 0
    Dim isOPrClick As Boolean = False
    Dim isEqualClick As Boolean = False
    Dim opr As String




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each c As Control In Controls

            If c.GetType() = GetType(Button) Then
                If Not c.Text.Equals("reset") Then
                    AddHandler c.Click, AddressOf Btn_Click
                End If
            End If
        Next
    End Sub


    Private Sub Btn_Click(sender As Object, e As EventArgs)
        Dim button As Button = sender


        If Not IsOperator(button) Then
            If isOPrClick Then
                n1 = Double.Parse(TextBox1.Text)
                TextBox1.Text = ""
            End If
            If Not TextBox1.Text.Contains(".") Then
                If TextBox1.Text.Equals("0") AndAlso Not button.Text.Equals(".") Then
                    TextBox1.Text = button.Text
                    isOPrClick = False
                Else
                    TextBox1.Text += button.Text
                    isOPrClick = False
                End If

            ElseIf Not button.Text.Equals(".") Then
            TextBox1.Text += button.Text
            isOPrClick = False
            End If
        Else
            If oprClickCount = 0 Then
                oprClickCount += 1
                n1 = Double.Parse(TextBox1.Text)
                opr = button.Text
                isOPrClick = True


            Else
                If Not button.Text.Equals("=") Then
                    If Not isEqualClick Then
                        n2 = Double.Parse(TextBox1.Text)
                        TextBox1.Text = Convert.ToString(Calculate(opr, n1, n2))
                        n2 = Double.Parse(TextBox1.Text)
                        opr = button.Text
                        isOPrClick = True
                        isEqualClick = False

                    Else
                        isEqualClick = False
                        opr = button.Text
                    End If

                Else
                    n2 = Double.Parse(TextBox1.Text)
                    TextBox1.Text = Convert.ToString(Calculate(opr, n1, n2))
                    n1 = Double.Parse(TextBox1.Text)
                    isOPrClick = True
                    isEqualClick = True
                End If

            End If

        End If




    End Sub


    Function IsOperator(ByVal btn As Button) As Boolean
        Dim btnText As String
        btnText = btn.Text
        If (btnText.Equals("+") Or btnText.Equals("-") Or btnText.Equals("/") Or btnText.Equals("X") Or btnText.Equals("=")) Then
            Return True
        Else
            Return False

        End If
    End Function

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        TextBox1.Text = ""
    End Sub

    Function Calculate(ByVal opr As String, ByVal num1 As Double, ByVal num2 As Double) As Double

        Dim result As Double
        result = 0

        Select Case opr
            Case "+"
                result = num1 + num2
            Case "-"
                result = num1 - num2
            Case "X"
                result = num1 * num2
            Case "/"
                If num2 <> 0 Then
                    result = num1 / num2
                End If

        End Select
        Return result
    End Function

End Class
