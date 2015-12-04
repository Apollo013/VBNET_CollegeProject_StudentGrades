Namespace DAL

    Public Class dtDistinctClass
        Inherits DataTable

#Region "Comments"

        ' This Table Simply Holds A List Of 'Distinct' Student Classes Used For Filtering Student Records.
        ' It Is NOT Added To Any DataSet.

        ' When This Table Is Instantiated, It Simply Adds A Single Column To Itself.

        ' The 'Fill' Method For This Can Be Located In The 'adprStudent' Class.

#End Region

#Region "Data Column"

        Private _ClassColumn As DataColumn
        ''' <summary>
        ''' Students Class name.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A 'String' DataColumn Object.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ClassColumn() As DataColumn
            Get
                If _ClassColumn Is Nothing Then
                    _ClassColumn = New DataColumn(StudentDataNames.ClassName, GetType(String))
                    With _ClassColumn
                        .AllowDBNull = False
                        .MaxLength = 30
                    End With
                End If
                Return _ClassColumn
            End Get
        End Property

#End Region

#Region "Constructor"

        ''' <summary>
        ''' 'dtDistinctClass' Class Constructor.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            MyBase.TableName = "DistinctClasses"
            MyBase.Columns.Add(Me.ClassColumn)
        End Sub

#End Region

    End Class

End Namespace

