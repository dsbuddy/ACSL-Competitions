Public Class Form1
    Dim input, inD1, outD1, inD2, outD2 As String
    Dim twD1, twD2, wtsD1, wtfD1, wtsD2, wtfD2 As Double


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim locD1, dayD1, locD2, dayD2 As Integer
        Dim pay As Double
        Dim pay1 As Double
        Dim pay2 As Double


        input = TextBox1.Text
        locD1 = input.Substring(0, 3)
        dayD1 = input.Substring(4, 1)
        inD1 = input.Substring(6, 1)
        outD1 = input.Substring(8, 1)
        locD2 = input.Substring(10, 3)
        dayD2 = input.Substring(14, 1)
        inD2 = input.Substring(16, 1)
        outD2 = input.Substring(18, 1)

        If inD1 <= "9" Then wtsD1 = 0.5 * inD1 + 8.5 Else wtsD1 = 0.5 * Asc(inD1) - 19
        If outD1 <= "9" Then wtfD1 = 0.5 * outD1 + 8.5 Else wtfD1 = 0.5 * Asc(outD1) - 19
        twD1 = wtfD1 - wtsD1

        If inD2 <= "9" Then wtsD2 = 0.5 * inD2 + 8.5 Else wtsD2 = 0.5 * Asc(inD2) - 19
        If outD2 <= "9" Then wtfD2 = 0.5 * outD2 + 8.5 Else wtfD2 = 0.5 * Asc(outD2) - 19
        twD2 = wtfD2 - wtsD2

        
        If locD1 < 200 Then
            If twD1 <= 5 Then pay1 = 10 * twD1 Else pay1 = 15 * (twD1 - 5) + 50 'nested conditional statement
        ElseIf locD1 < 300 Then
            If twD1 <= 6 Then pay1 = 7.5 * twD1 Else pay1 = 15 * (twD1 - 6) + 45
        ElseIf locD1 < 400 Then
            If twD1 <= 4 Then pay1 = 9.25 * twD1 Else pay1 = 10.5 * (twD1 - 4) + 37
        ElseIf locD1 < 500 Then
            If dayD1 = 1 Or dayD1 = 7 Then pay1 = 13.5 * twD1 Else pay1 = 6.75 * twD1
        ElseIf locD1 < 600 Then
            If twD1 <= 6 Then pay1 = 8 * twD1 Else pay1 = 12 * (twD1 - 6) + 48
        End If

        If locD2 < 200 Then
            If twD2 <= 5 Then pay2 = 10 * twD2 Else pay2 = 15 * (twD2 - 5) + 50 'nested conditional statement
        ElseIf locD2 < 300 Then
            If twD2 <= 6 Then pay2 = 7.5 * twD2 Else pay2 = 15 * (twD2 - 6) + 45
        ElseIf locD2 < 400 Then
            If twD2 <= 4 Then pay2 = 9.25 * twD2 Else pay2 = 10.5 * (twD2 - 4) + 37
        ElseIf locD2 < 500 Then
            If dayD2 = 1 Or dayD2 = 7 Then pay2 = 13.5 * twD2 Else pay2 = 6.75 * twD2
        ElseIf locD2 < 600 Then
            If twD2 <= 6 Then pay2 = 8 * twD2 Else pay2 = 12 * (twD2 - 6) + 48
        End If

        pay = pay1 + pay2

        TextBox1.Text = ""
        Label1.Text = "Pay: $" & Math.Round(pay, 2, MidpointRounding.AwayFromZero)

        'Then pay = pay + 10*hours

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
