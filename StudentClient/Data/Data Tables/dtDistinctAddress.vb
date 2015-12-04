Namespace DAL

    Public Class dtDistinctAddress
        Inherits DataTable

#Region "Comments"

        ' This Table Simply Holds A List Of 'Distinct' Student Addresses Used For Filtering Records.
        ' It Is NOT Added To Any DataSet.

        ' When This Table Is Instantiated, It Simply Adds A Single Column To Itself.

        ' The 'Fill' Method For This Can Be Located In The 'adprStudent' Class.

#End Region

#Region "Data Column"

        Private _AddressColumn As DataColumn
        ''' <summary>
        ''' Students Address Data Column.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A 'String' DataColumn Object.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property AddressColumn() As DataColumn
            Get
                If _AddressColumn Is Nothing Then
                    _AddressColumn = New DataColumn()

                    With _AddressColumn
                        .ColumnName = StudentDataNames.Address
                        .DataType = GetType(String)
                        .MaxLength = 50
                    End With

                End If
                Return _AddressColumn
            End Get
        End Property

#End Region

#Region "Constructor"

        ''' <summary>
        ''' 'dtDistinctAddress' Class Constructor.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            MyBase.TableName = "DistinctAddresses"
            MyBase.Columns.Add(Me.AddressColumn)
        End Sub

#End Region

    End Class

End Namespace
