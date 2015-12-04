Namespace DAL

    Public Class dtStudent
        Inherits DataTable

#Region "Comments"

        ' Student Data Table Which is used for caching student information from the database
        ' This Is The Only Table Added To The Student DataSet.

#End Region

#Region "Data Columns"

        Private _IDColumn As DataColumn
        ''' <summary>
        ''' Student ID.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A data column representing the ID column in our database.</returns>
        ''' <remarks>This is also our Primary Key.</remarks>
        Public ReadOnly Property IDColumn() As DataColumn
            Get
                If _IDColumn Is Nothing Then
                    _IDColumn = New DataColumn()

                    With _IDColumn
                        .AutoIncrement = True
                        .AutoIncrementSeed = 1
                        .AutoIncrementStep = 1
                        .AllowDBNull = False
                        .ColumnName = StudentDataNames.ID
                        .DataType = GetType(Integer)
                        .Unique = True
                    End With

                End If
                Return _IDColumn
            End Get
        End Property

        Private _FirstNameColumn As DataColumn
        ''' <summary>
        ''' Students first name.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A data column representing the First name column in our database.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property FirstNameColumn() As DataColumn
            Get
                If _FirstNameColumn Is Nothing Then
                    _FirstNameColumn = New DataColumn()

                    With _FirstNameColumn
                        .AllowDBNull = False
                        .ColumnName = StudentDataNames.FirstName
                        .DataType = GetType(String)
                        .DefaultValue = "Required"
                        .MaxLength = 30
                    End With

                End If
                Return _FirstNameColumn
            End Get
        End Property

        Private _LastNameColumn As DataColumn
        ''' <summary>
        ''' Students last name.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A data column representing the Last Name column in our database.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property LastNameColumn() As DataColumn
            Get
                If _LastNameColumn Is Nothing Then
                    _LastNameColumn = New DataColumn()

                    With _LastNameColumn
                        .AllowDBNull = False
                        .ColumnName = StudentDataNames.LastName
                        .DataType = GetType(String)
                        .DefaultValue = "Required"
                        .MaxLength = 30
                    End With

                End If
                Return _LastNameColumn
            End Get
        End Property

        Private _PhoneNumberColumn As DataColumn
        ''' <summary>
        ''' Students Phone Number.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A data column representing the Phone Number column in our database.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property PhoneNumberColumn() As DataColumn
            Get
                If _PhoneNumberColumn Is Nothing Then
                    _PhoneNumberColumn = New DataColumn()

                    With _PhoneNumberColumn
                        .ColumnName = StudentDataNames.PhoneNumber
                        .DataType = GetType(String)
                        .MaxLength = 20
                    End With

                End If
                Return _PhoneNumberColumn
            End Get
        End Property

        Private _AddressColumn As DataColumn
        ''' <summary>
        ''' Students Address.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A data column representing the Address column in our database.</returns>
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

        Private _EmailColumn As DataColumn
        ''' <summary>
        ''' Students Email Address.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A data column representing the Email column in our database.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property EmailColumn() As DataColumn
            Get
                If _EmailColumn Is Nothing Then
                    _EmailColumn = New DataColumn()

                    With _EmailColumn
                        .ColumnName = StudentDataNames.Email
                        .DataType = GetType(String)
                        .MaxLength = 255
                    End With

                End If
                Return _EmailColumn
            End Get
        End Property

        Private _ChristmasColumn As DataColumn
        ''' <summary>
        ''' Students mark for Christmas exam.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A data column representing the Christmas column in our database.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ChristmasColumn() As DataColumn
            Get
                If _ChristmasColumn Is Nothing Then
                    _ChristmasColumn = New DataColumn()

                    With _ChristmasColumn
                        .ColumnName = StudentDataNames.Christmas
                        .DataType = GetType(Integer)
                        .DefaultValue = 0
                    End With

                End If
                Return _ChristmasColumn
            End Get
        End Property

        Private _SummerColumn As DataColumn
        ''' <summary>
        ''' Students mark for Summer exam.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A data column representing the Summer column in our database.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property SummerColumn() As DataColumn
            Get
                If _SummerColumn Is Nothing Then
                    _SummerColumn = New DataColumn()

                    With _SummerColumn
                        .ColumnName = StudentDataNames.Summer
                        .DataType = GetType(Integer)
                        .DefaultValue = 0
                    End With

                End If
                Return _SummerColumn
            End Get
        End Property

        Private _ClassColumn As DataColumn
        ''' <summary>
        ''' Students Class name.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A data column representing the Class column in our database.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ClassColumn() As DataColumn
            Get
                If _ClassColumn Is Nothing Then
                    _ClassColumn = New DataColumn()

                    With _ClassColumn
                        .AllowDBNull = False
                        .ColumnName = StudentDataNames.ClassName
                        .DataType = GetType(String)
                        .DefaultValue = "Required"
                        .MaxLength = 30
                    End With

                End If
                Return _ClassColumn
            End Get
        End Property

        Private _OverallTotal As DataColumn
        ''' <summary>
        ''' Overall student mark (weighted)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property OverallTotal() As DataColumn
            Get
                If _OverallTotal Is Nothing Then
                    _OverallTotal = New DataColumn()

                    With _OverallTotal
                        .ColumnName = StudentDataNames.OverallTotal
                        .DataType = GetType(Double)
                        .DefaultValue = 0
                        .ReadOnly = True
                    End With

                End If
                Return _OverallTotal
            End Get
        End Property

        Private _Grade As DataColumn
        ''' <summary>
        ''' Overall Student Grade For The Year.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Grade() As DataColumn
            Get
                If _Grade Is Nothing Then
                    _Grade = New DataColumn()

                    With _Grade
                        .ColumnName = StudentDataNames.Grade
                        .DataType = GetType(String)
                        .DefaultValue = Grades.Fail
                    End With

                End If
                Return _Grade
            End Get
        End Property

#End Region

#Region "Constructor & Initialisers"

        ''' <summary>
        ''' Table Constructor.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()

            ' Name This Data Table
            MyBase.TableName = StudentDataNames.TableName
            Me.InitControls()

        End Sub

        ''' <summary>
        ''' Initialises and Adds Data Columns To The Table.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub InitControls()
            'Add Data Columns.
            With MyBase.Columns
                .Add(Me.IDColumn)
                .Add(Me.FirstNameColumn)
                .Add(Me.LastNameColumn)
                .Add(Me.PhoneNumberColumn)
                .Add(Me.AddressColumn)
                .Add(Me.EmailColumn)
                .Add(Me.ChristmasColumn)
                .Add(Me.SummerColumn)
                .Add(Me.ClassColumn)
                .Add(Me.OverallTotal)
                .Add(Me.Grade)
            End With

            ' Add the primary key.
            Dim primaryKey() As DataColumn = New DataColumn() {IDColumn}
            MyBase.PrimaryKey = primaryKey
        End Sub

#End Region

#Region "Validation & Calculation Methods"

        ''' <summary>
        ''' Calculates The Grade For Each Student.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub Calculate(sender As Object, _
                              e As System.Data.DataColumnChangeEventArgs) _
                              Handles Me.ColumnChanged

            Dim xmasMark As Integer = 0
            Dim summerMark As Integer = 0

            If e.Column.ColumnName = StudentDataNames.Christmas Or _
                e.Column.ColumnName = StudentDataNames.Summer Then

                xmasMark = e.Row.Item(StudentDataNames.Christmas)
                summerMark = e.Row.Item(StudentDataNames.Summer)

                e.Row.SetField(StudentDataNames.OverallTotal, (summerMark + xmasMark) / 2)

                e.Row.SetField(StudentDataNames.Grade, _
                               Grades.GetGrade(e.Row.Item(StudentDataNames.OverallTotal)))
            End If

        End Sub

        ''' <summary>
        ''' Validation.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub Validate(sender As Object,
                             e As System.Data.DataColumnChangeEventArgs) _
                             Handles Me.ColumnChanging

            'Set Error On FirstName Column If It Does Not Contain A Value.
            If e.Column.ColumnName = StudentDataNames.FirstName Then
                If String.IsNullOrEmpty(CType(e.ProposedValue, String)) Then
                    e.Row.SetColumnError(StudentDataNames.FirstName, _
                                         "A First Name Must Be Specified.")
                Else
                    e.Row.SetColumnError(StudentDataNames.FirstName, Nothing)
                End If
            End If

            'Set Error On LastName Column If It Does Not Contain A Value.
            If e.Column.ColumnName = StudentDataNames.LastName Then
                If String.IsNullOrEmpty(CType(e.ProposedValue, String)) Then
                    e.Row.SetColumnError(StudentDataNames.LastName, _
                                         "A Last Name Must Be Specified.")
                Else
                    e.Row.SetColumnError(StudentDataNames.LastName, Nothing)
                End If
            End If

            'Set Error On Class Column If It Does Not Contain A Value.
            If e.Column.ColumnName = StudentDataNames.ClassName Then
                If String.IsNullOrEmpty(CType(e.ProposedValue, String)) Then
                    e.Row.SetColumnError(StudentDataNames.ClassName, _
                                         "A Class Name Must Be Specified.")
                Else
                    e.Row.SetColumnError(StudentDataNames.ClassName, Nothing)
                End If
            End If

            ' Set Error Message For The Entire Row.
            If e.Row.HasErrors Then
                e.Row.RowError = "Student Record Has Errors."
            Else
                e.Row.RowError = ""
            End If

        End Sub

#End Region

#Region "Custom Event"

        ''' <summary>
        ''' Custom Event To Be Raised Whenever The Student Table Changes.
        ''' </summary>
        ''' <remarks></remarks>
        Public Event TableChangedEvent(ByVal SearchOption As SearchOptions)

        ''' <summary>
        ''' Raises TableChangedEvent.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub StudentTableChanged(ByVal SearchOption As SearchOptions)
            RaiseEvent TableChangedEvent(SearchOption)
        End Sub

#End Region


    End Class

End Namespace
