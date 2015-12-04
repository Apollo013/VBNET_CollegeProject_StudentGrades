Public NotInheritable Class Grades

#Region "Comments"

    ' This Is A Static Class That Calculates The Grade Value For A Given Exam Mark.
    ' Possible Return Values Are Either 'Fail', 'Pass', Merit' or 'Distinction'.

    ' It Also Provides A Function For Returning An Array(Of String) Containing Possible Grade Values.

#End Region

#Region "Properties"

    ''' <summary>
    ''' 'Fail' Grade Value
    ''' </summary>
    ''' <value></value>
    ''' <returns>String - "Fail"</returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property Fail As String
        Get
            Return "Fail"
        End Get
    End Property

    ''' <summary>
    ''' 'Pass' Grade Value
    ''' </summary>
    ''' <value></value>
    ''' <returns>String - "Pass"</returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property Pass As String
        Get
            Return "Pass"
        End Get
    End Property

    ''' <summary>
    ''' 'Merit' Grade Value
    ''' </summary>
    ''' <value></value>
    ''' <returns>String - "Merit"</returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property Merit As String
        Get
            Return "Merit"
        End Get
    End Property

    ''' <summary>
    ''' 'Distinction' Grade Value
    ''' </summary>
    ''' <value></value>
    ''' <returns>String - "Distinction"</returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property Distinction As String
        Get
            Return "Distinction"
        End Get
    End Property

#End Region

#Region "Methods"

    ''' <summary>
    ''' Determines The Grade Value For Exam Mark.
    ''' </summary>
    ''' <returns>Either 'Fail', 'Pass', Merit' or 'Distinction'.</returns>
    ''' <remarks></remarks>
    Public Shared Function GetGrade(ByVal _mark As Double) As String
        If _mark > 79 Then
            Return Distinction
        ElseIf _mark > 64 Then
            Return Merit
        ElseIf _mark > 49 Then
            Return Pass
        Else
            Return Fail
        End If
    End Function

    ''' <summary>
    ''' Gets A String Array Of Grade Names
    ''' </summary>
    ''' <returns>An Array(Of String) Containing Grade Names</returns>
    ''' <remarks></remarks>
    Public Shared Function ToArray() As String()
        Dim gradeArray As String() = {Fail, Pass, Merit, Distinction}
        Return gradeArray
    End Function

    ''' <summary>
    ''' Converts A Singular Grade To Its Plural Equivalent.
    ''' </summary>
    ''' <returns>A String Containing The Pluralised Version Of A Grade.</returns>
    ''' <remarks></remarks>
    Public Shared Function ToPlural(ByVal _grade As String) As String

        If _grade = Fail Then
            Return Fail & "s"
        ElseIf _grade = Pass Then
            Return Pass & "es"
        ElseIf _grade = Merit Then
            Return Merit & "s"
        ElseIf _grade = Distinction Then
            Return Distinction & "s"
        Else
            Return "Grade Not Recognised"
        End If

    End Function

#End Region

End Class
