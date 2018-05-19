Public Class Form1
    Dim preAns As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        preAns = TextBox1.Text
        TextBox1.Text = ""
    End Sub
    Private Function Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim input() As String = TextBox2.Text.Split(",")
        If errCheck(input) Then
            TextBox3.Text = "NONE"
            Return 0
        End If

        For i As Integer = 0 To input.Length - 1
            input(i) = toBinary(input(i))
        Next
        Dim final As String = Input(0)

        For i As Integer = 0 To input.Length - 2
            If combine(final, input(i + 1)) <> "0" Then
                final = combine(final, input(i + 1))
            Else
                TextBox3.Text = "NONE"
                Return 0
            End If
        Next
        If Not (final.Contains("1")) Then
            Return 0
            TextBox3.Text = "NONE"
        End If

        final = final & " " & intToLet(final)
        TextBox3.Text = final
        Return 0
    End Function

    Private Function toBinary(num As Integer)
        Dim out As String = ""
        For i As Integer = 3 To 0 Step -1
            If num >= 2 ^ i Then
                num = num - (2 ^ i)
                out = out & 1
            Else
                out = out & 0
            End If
        Next
        Return out
    End Function

    Private Function intToLet(ans As String)
        Dim finAns As String = ""
        For i = 0 To 3
            If ans.Substring(i, 1) <> "x" Then
                If ans.Substring(i, 1) = 0 Then
                    finAns = finAns & Chr(i + 97)
                Else
                    finAns = finAns & Chr(i + 65)
                End If
            Else
                finAns += ""
            End If
        Next i
        Return finAns
    End Function

    Private Function combine(int1 As String, int2 As String)
        Dim mergeStr As String = ""
        Dim count As Integer = 0
        For i = 0 To 3
            If int1.Substring(i, 1) <> int2.Substring(i, 1) Then
                mergeStr = mergeStr & "x"
                count += 1
            Else
                mergeStr = mergeStr & int1.Substring(i, 1)
            End If
        Next i
        If count >= 3 Then Return "0"
        Return mergeStr
    End Function

    Private Function errCheck(input)
        For i As Integer = 0 To input.length - 1
            If Not (preAns.Contains(input(i))) Then Return 1
        Next
        Return 0
    End Function
End Class