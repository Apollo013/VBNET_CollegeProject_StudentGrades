Namespace DAL

    Public Class dsStudent
        Inherits DataSet

#Region "Comments"

        ' The Class Has One DataTable Property 'StudentTable', And One Constructor.
        ' The Construtor Adds The Table To The DataSet - Thats It !

#End Region

#Region "Property"

        Private WithEvents _studentTable As dtStudent
        ''' <summary>
        ''' Gets A 'dtStudent' DataTable Object.
        ''' </summary>
        Friend ReadOnly Property StudentTable() As dtStudent
            Get
                If _studentTable Is Nothing Then
                    _studentTable = New dtStudent
                End If
                Return _studentTable
            End Get
        End Property

#End Region

#Region "Constructor"

        ''' <summary>
        ''' 'dsStudent' Class Constructor.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            Me.DataSetName = "StudentDataSet"
            MyBase.Tables.Add(Me.StudentTable)
        End Sub

#End Region

    End Class

End Namespace
