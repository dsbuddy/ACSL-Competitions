Public Class Form1
    Dim start, fin, car, road, dist As Integer
    Dim gas, cost, time As Double
    Dim finalcost As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Input As Array = TextBox1.Text.Split(",")
        Dim hour, min, finmin As Integer
        Dim finhour, fintime As String
        If Input(0) = "A" Then
            start = 0
        ElseIf Input(0) = "B" Then
            start = 450
        ElseIf Input(0) = "C" Then
            start = 590
        ElseIf Input(0) = "D" Then
            start = 710
        ElseIf Input(0) = "E" Then
            start = 1030
        ElseIf Input(0) = "F" Then
            start = 1280
        ElseIf Input(0) = "G" Then
            MsgBox("The Start Point is not valid.  Try Again!")
        End If
        If Input(1) = "B" Then
            fin = 140
        ElseIf Input(1) = "C" Then
            fin = 590
        ElseIf Input(1) = "D" Then
            fin = 710
        ElseIf Input(1) = "E" Then
            fin = 1030
        ElseIf Input(1) = "F" Then
            fin = 1280
        ElseIf Input(1) = "G" Then
            fin = 1360
        End If
        dist = fin - start
        If Input(2) = "C" Then
            car = 28
        ElseIf Input(2) = "M" Then
            car = 25
        ElseIf Input(2) = "F" Then
            car = 22
        ElseIf Input(2) = "V" Then
            car = 20
        End If
        If Input(3) = "I" Then
            road = 65
        ElseIf Input(3) = "H" Then
            road = 60
        ElseIf Input(3) = "M" Then
            road = 55
        ElseIf Input(3) = "S" Then
            road = 45
        End If
        time = Math.Round((dist / road), 2)
        gas = Input(4)
        cost = Math.Round(((dist / car) * gas), 2)
        finalcost = cost.ToString("C2")
        hour = dist \ road
        finhour = hours(hour)
        min = minutes(dist, road)
        finmin = hours(min)
        fintime = finhour & ":" & min 'time label
        Label1.Text = dist.ToString & "," & fintime & "," & finalcost
    End Sub
    Private Function minutes(dist As Integer, road As Integer) As Integer
        Return Math.Round(((dist / road - dist \ road) * 60))
    End Function
    Private Function hours(hour As Integer) As String
        If hour = 9 Or hour = 8 Or hour = 7 Or hour = 6 Or hour = 5 Or hour = 4 Or hour = 3 Or hour = 2 Or hour = 1 Or hour = 0 Then Return "0" & hour.ToString Else Return hour.ToString
    End Function
End Class
