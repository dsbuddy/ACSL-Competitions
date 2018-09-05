Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label1.Text = f1(clear(TextBox1.Text))
        Label2.Text = f2(TextBox2.Text)
        Label3.Text = f3(TextBox3.Text)
        Label4.Text = f4(clear(TextBox4.Text))
        Label5.Text = f5(clear(TextBox5.Text))
    End Sub
    Private Function clear(input As String) As String
        Return input.Substring(2, input.Length - 3)
    End Function
    Private Function f1(input As String) As String
        Return "'(" & StrReverse(input) & ")"
    End Function
    Private Function f2(input As String) As String
        Dim letters(input.Length) As String
        Dim temp As Integer = 1
        Dim str As String = ""
        letters = (TextBox2.Text.Substring(2, TextBox2.Text.Length - 3) & " *").Split(" ")
        For i As Integer = 1 To letters.Length - 1
            If letters(i) = letters(i - 1) Then
                temp = temp + 1
            Else
                str = str & "(" & temp & " " & letters(i - 1) & ")"
                temp = 1
            End If
        Next
        Return "'(" & str & ")"
    End Function
    Private Function f3(input As String) As String
        Dim letters(input.Length) As String
        Dim temp As Integer = 1
        Dim str As String = ""
        letters = (TextBox3.Text.Substring(2, TextBox3.Text.Length - 3) & " *").Split(" ")
        For i As Integer = 1 To letters.Length - 1
            If letters(i) = letters(i - 1) Then
                temp = temp + 1
            ElseIf temp = 1 Then
                str = str & letters(i - 1)
                temp = 1
            Else
                str = str & "(" & temp & " " & letters(i - 1) & ")"
                temp = 1
            End If
        Next
        Return "'(" & str & ")"
    End Function
    Private Function f4(input As String) As String
        Dim var As Integer = input.Substring(input.LastIndexOf(")") + 1)
        Dim str As String = "'("
        Dim atoms() As String = ((input.Substring(0, input.LastIndexOf(")") + 1)).Split(")("))
        For x As Integer = 0 To atoms.Length - 1 Step var
            str = str & atoms(x) & ")"
        Next
        Return str & var & ")"
    End Function
    Private Function f5(input As String) As String
        Dim var As Integer = input.Substring(input.LastIndexOf(")") + 1)
        Dim str As String = "'("
        If var = ((input.Length + 1) Mod 5) = 0 Then
            str = str & input.Substring(0, (var * 5)) & ")'(" & input.Substring(var * 5) & ")"
        Else
            str = str & input.Substring(0, (var * 5)) & ")'(" & input.Substring((var * 5)) & ")"
        End If
        Return str
    End Function

    '     ___  ___   _____   
    '    /   |/   | |  _  \  
    '   / /|   /| | | |_| |  
    '  / / |__/ | | |  _  /    _
    ' / /       | | | | \ \   / \
    '/_/        |_| |_|  \_\  \_/


    ' _____       ___   _       _       _   __   _       ___   __   _  
    '/  ___|     /   | | |     | |     | | |  \ | |     /   | |  \ | | 
    '| |        / /| | | |     | |     | | |   \| |    / /| | |   \| | 
    '| |       / / | | | |     | |     | | | |\   |   / / | | | |\   | 
    '| |___   / /  | | | |___  | |___  | | | | \  |  / /  | | | | \  | 
    '\_____| /_/   |_| |_____| |_____| |_| |_|  \_| /_/   |_| |_|  \_| 


    ' _____   _   _   _   _____        _   _____        _____   _   _   _____  
    '|_   _| | | | | | | /  ___/      | | /  ___/      |_   _| | | | | | ____| 
    '  | |   | |_| | | | | |___       | | | |___         | |   | |_| | | |__   
    '  | |   |  _  | | | \___  \      | | \___  \        | |   |  _  | |  __|  
    '  | |   | | | | | |  ___| |      | |  ___| |        | |   | | | | | |___  
    '  |_|   |_| |_| |_| /_____/      |_| /_____/        |_|   |_| |_| |_____| 


    '     ___   _____   _____   _   _       ___   _            _     _   _____   _____    _____   _   _____   __   _  
    '    /   | /  ___| |_   _| | | | |     /   | | |          | |   / / | ____| |  _  \  /  ___/ | | /  _  \ |  \ | | 
    '   / /| | | |       | |   | | | |    / /| | | |          | |  / /  | |__   | |_| |  | |___  | | | | | | |   \| | 
    '  / / | | | |       | |   | | | |   / / | | | |          | | / /   |  __|  |  _  /  \___  \ | | | | | | | |\   | 
    ' / /  | | | |___    | |   | |_| |  / /  | | | |___       | |/ /    | |___  | | \ \   ___| | | | | |_| | | | \  | 
    '/_/   |_| \_____|   |_|   \_____/ /_/   |_| |_____|      |___/     |_____| |_|  \_\ /_____/ |_| \_____/ |_|  \_| 

End Class