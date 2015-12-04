Imports System.Data.OleDb

Namespace DAL

    Public Class adprStudent

#Region "Comments"

        ' This Class Is Responsible For Retrieving Records From And Updating To, The StudentRecord Database Table.
        ' It Is Also Responsible For Retrieving Distinct Addresses and Classes, Used For Filtering Student Records.

        ' All 'Parameters' ALWAYS Return A 'NEW' OLEDBParameter.

        ' This Class Is Referenced and Instantiated By The 'ucStudentToolbar' User Control.

        ' The Constructor Receives, By Reference,  A 'dtStudent' Object (Student DataTable).

        ' The 'ucStudentToolbar' Component Has Two Properties, 'SearchValue' and 'CurrentSearchOption',
        ' Which Sets Two Properties Of The Same Name In This Class.
        ' When 'SearchValue' Is Set, It Calls The 'Fill' Method.

        ' After Updating Or Filling The Student DataTable, A 'dtStudent' Method ('StudentTableChanged') Is
        ' Called Which Raises The 'TableChangedEvent'. An Event Handler For This Is Located In The 'ucStudentTotals' 
        ' Component Which Triggers A Recalculation Of All Totals and Averages.

#End Region

#Region "Parameters"

        Private _parmID As OleDbParameter
        ''' <summary>
        ''' Students ID Parameter
        ''' </summary>
        ''' <value></value>
        ''' <returns>An OLEDBParameter for Student ID.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property parmID() As OleDbParameter
            Get
                _parmID = New OleDbParameter

                With _parmID
                    .ParameterName = StudentDataNames.ID
                    .OleDbType = OleDbType.Integer
                    .Direction = ParameterDirection.Input
                    .SourceColumn = StudentDataNames.ID
                End With

                Return _parmID
            End Get
        End Property

        Private _parmFirstName As OleDbParameter
        ''' <summary>
        ''' Students First Name Parameter
        ''' </summary>
        ''' <value></value>
        ''' <returns>An OLEDBParameter for Students First Name.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property parmFirstName() As OleDbParameter
            Get
                _parmFirstName = New OleDbParameter

                With _parmFirstName
                    .ParameterName = StudentDataNames.FirstName
                    .OleDbType = OleDbType.VarWChar
                    .Direction = ParameterDirection.Input
                    .SourceColumn = StudentDataNames.FirstName
                End With

                Return _parmFirstName
            End Get
        End Property

        Private _parmLastName As OleDbParameter
        ''' <summary>
        ''' Students Last Name Parameter.
        ''' </summary>
        ''' <value></value>
        ''' <returns>An OLEDBParameter for Students Last Name.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property parmLastName() As OleDbParameter
            Get
                _parmLastName = New OleDbParameter

                With _parmLastName
                    .ParameterName = StudentDataNames.LastName
                    .OleDbType = OleDbType.VarWChar
                    .Direction = ParameterDirection.Input
                    .SourceColumn = StudentDataNames.LastName
                End With

                Return _parmLastName
            End Get
        End Property

        Private _parmPhoneNumber As OleDbParameter
        ''' <summary>
        ''' Students Phone Number Parameter.
        ''' </summary>
        ''' <value></value>
        ''' <returns>An OLEDBParameter for Students Phone Number.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property parmPhoneNumber() As OleDbParameter
            Get
                _parmPhoneNumber = New OleDbParameter

                With _parmPhoneNumber
                    .ParameterName = StudentDataNames.PhoneNumber
                    .OleDbType = OleDbType.VarWChar
                    .Direction = ParameterDirection.Input
                    .SourceColumn = StudentDataNames.PhoneNumber
                End With

                Return _parmPhoneNumber
            End Get
        End Property

        Private _parmAddress As OleDbParameter
        ''' <summary>
        ''' Students Address Parameter.
        ''' </summary>
        ''' <value></value>
        ''' <returns>An OLEDBParameter for Students Address.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property parmAddress() As OleDbParameter
            Get
                _parmAddress = New OleDbParameter

                With _parmAddress
                    .ParameterName = StudentDataNames.Address
                    .OleDbType = OleDbType.VarWChar
                    .Direction = ParameterDirection.Input
                    .SourceColumn = StudentDataNames.Address
                End With

                Return _parmAddress
            End Get
        End Property

        Private _parmEmail As OleDbParameter
        ''' <summary>
        ''' Students Email Parameter.
        ''' </summary>
        ''' <value></value>
        ''' <returns>An OLEDBParameter for Students Email.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property parmEmail() As OleDbParameter
            Get
                _parmEmail = New OleDbParameter

                With _parmEmail
                    .ParameterName = StudentDataNames.Email
                    .OleDbType = OleDbType.VarWChar
                    .Direction = ParameterDirection.Input
                    .SourceColumn = StudentDataNames.Email
                End With

                Return _parmEmail
            End Get
        End Property

        Private _parmChristmas As OleDbParameter
        ''' <summary>
        ''' Students Christmas Mark Parameter.
        ''' </summary>
        ''' <value></value>
        ''' <returns>An OLEDBParameter for Students Christmas Mark.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property parmChristmas() As OleDbParameter
            Get
                _parmChristmas = New OleDbParameter

                With _parmChristmas
                    .ParameterName = StudentDataNames.Christmas
                    .OleDbType = OleDbType.Integer
                    .Direction = ParameterDirection.Input
                    .SourceColumn = StudentDataNames.Christmas
                End With

                Return _parmChristmas
            End Get
        End Property

        Private _parmSummer As OleDbParameter
        ''' <summary>
        ''' Students Summer Mark Parameter.
        ''' </summary>
        ''' <value></value>
        ''' <returns>An OLEDBParameter for Students Summer Mark.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property parmSummer() As OleDbParameter
            Get
                _parmSummer = New OleDbParameter

                With _parmSummer
                    .ParameterName = StudentDataNames.Summer
                    .OleDbType = OleDbType.Integer
                    .Direction = ParameterDirection.Input
                    .SourceColumn = StudentDataNames.Summer
                End With

                Return _parmSummer
            End Get
        End Property

        Private _parmClass As OleDbParameter
        ''' <summary>
        ''' Students Class Parameter.
        ''' </summary>
        ''' <value></value>
        ''' <returns>An OLEDBParameter for Students Class.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property parmClass() As OleDbParameter
            Get
                _parmClass = New OleDbParameter

                With _parmClass
                    .ParameterName = StudentDataNames.ClassName
                    .OleDbType = OleDbType.VarWChar
                    .Direction = ParameterDirection.Input
                    .SourceColumn = StudentDataNames.ClassName
                End With

                Return _parmClass
            End Get
        End Property

#End Region

#Region "Properties"

        Private _studentAdapter As OleDbDataAdapter
        ''' <summary>
        ''' Students Data Adapter
        ''' </summary>
        ''' <value></value>
        ''' <returns>An OleDbDataAdapter Object</returns>
        ''' <remarks></remarks>
        Protected Friend ReadOnly Property StudentAdapter() As OleDbDataAdapter
            Get
                If _studentAdapter Is Nothing Then
                    _studentAdapter = New OleDbDataAdapter
                End If
                Return _studentAdapter
            End Get
        End Property

        Private _studentConnection As OleDbConnection
        ''' <summary>
        ''' Connection Object For Connecting To The Students Database.
        ''' </summary>
        ''' <value></value>
        ''' <returns>An OleDbConnection Object</returns>
        ''' <remarks></remarks>
        Friend ReadOnly Property StudentConnection As OleDbConnection
            Get
                If _studentConnection Is Nothing Then
                    _studentConnection = New OleDbConnection(My.Settings.StudentsConnectionString)
                End If
                Return _studentConnection
            End Get
        End Property

        Private _studentDataTable As dtStudent
        ''' <summary>
        ''' Gets or Sets A Reference To The Student Data Table.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property StudentDataTable() As dtStudent
            Get
                Return _studentDataTable
            End Get
            Set(ByVal value As dtStudent)
                _studentDataTable = value
            End Set
        End Property

        Private _CurrentSearchValue As String
        ''' <summary>
        ''' Gets or Sets The Search Criteria Used For Filtering Student Records.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CurrentSearchValue() As String
            Get
                Return _CurrentSearchValue
            End Get
            Set(ByVal value As String)
                _CurrentSearchValue = value
                Me.Fill()
            End Set
        End Property

        Private _CurrentSearchOption As SearchOptions
        ''' <summary>
        ''' Gets or Sets The Current Search Option.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CurrentSearchOption() As SearchOptions
            Get
                Return _CurrentSearchOption
            End Get
            Set(value As SearchOptions)
                _CurrentSearchOption = value
            End Set
        End Property

#End Region

#Region "Constructor & Initialisers"

        ''' <summary>
        ''' Class Constructor.
        ''' </summary>
        ''' <param name="dataTable">A Reference To The Student Data Table</param>
        ''' <remarks></remarks>
        Public Sub New(ByRef dataTable As dtStudent)
            Me._studentDataTable = dataTable
            Me.Init()
        End Sub

        ''' <summary>
        ''' Initialies The Data Adapter Commands.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Init()
            ' Assign Default Select Command.
            ' This Will Change Depending On What We Are Searching For.
            Me.StudentAdapter.SelectCommand = Me.CommandFillAll

            ' The Update Commands Remain Static Throughout
            Me.StudentAdapter.UpdateCommand = Me.CommandUpdate
            Me.StudentAdapter.InsertCommand = Me.CommandInsert
            Me.StudentAdapter.DeleteCommand = Me.CommandDelete
        End Sub

#End Region

#Region "Commands"

        ''' <summary>
        ''' Creates A New Update Command.
        ''' </summary>
        ''' <returns>An OleDbCommand Object.</returns>
        ''' <remarks></remarks>
        Private Function CommandUpdate() As OleDbCommand
            Dim cmdUpdate As New OleDbCommand

            With cmdUpdate
                .Connection = Me.StudentConnection
                .CommandType = CommandType.Text
                .CommandText = "UPDATE " & _
                               StudentDataNames.TableName & _
                               " SET [" & _
                               StudentDataNames.FirstName & "] = ?, [" & _
                               StudentDataNames.LastName & "] = ?, " & _
                               StudentDataNames.PhoneNumber & " = ?, " & _
                               StudentDataNames.Address & " = ?, " & _
                               StudentDataNames.Email & " = ?, " & _
                               StudentDataNames.Christmas & " = ?, " & _
                               StudentDataNames.Summer & " = ?, " & _
                               StudentDataNames.ClassName & " = ?  " & _
                               "WHERE " & _
                               StudentDataNames.ID & " = ?"
                .Parameters.AddRange(New OleDbParameter() {Me.parmFirstName,
                                                           Me.parmLastName,
                                                           Me.parmPhoneNumber,
                                                           Me.parmAddress,
                                                           Me.parmEmail,
                                                           Me.parmChristmas,
                                                           Me.parmSummer,
                                                           Me.parmClass,
                                                           Me.parmID})
            End With

            Return cmdUpdate
        End Function

        ''' <summary>
        ''' Creates A New Insert Command.
        ''' </summary>
        ''' <returns>An OleDbCommand Object.</returns>
        ''' <remarks></remarks>
        Private Function CommandInsert() As OleDbCommand
            Dim cmdInsert = New OleDbCommand

            With cmdInsert
                .Connection = Me.StudentConnection
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO " & _
                               StudentDataNames.TableName & " ([" & _
                               StudentDataNames.FirstName & "], [" & _
                               StudentDataNames.LastName & "], " & _
                               StudentDataNames.PhoneNumber & ", " & _
                               StudentDataNames.Address & ", " & _
                               StudentDataNames.Email & ", " & _
                               StudentDataNames.Christmas & ", " & _
                               StudentDataNames.Summer & ", " & _
                               StudentDataNames.ClassName & ") VALUES (?, ?, ?, ?, ?, ?, ?, ?)"
                .Parameters.AddRange(New OleDbParameter() {Me.parmFirstName,
                                                           Me.parmLastName,
                                                           Me.parmPhoneNumber,
                                                           Me.parmAddress,
                                                           Me.parmEmail,
                                                           Me.parmChristmas,
                                                           Me.parmSummer,
                                                           Me.parmClass})
            End With

            Return cmdInsert
        End Function

        ''' <summary>
        ''' Creates A New Delete Command.
        ''' </summary>
        ''' <returns>An OleDbCommand Object.</returns>
        ''' <remarks></remarks>
        Private Function CommandDelete() As OleDbCommand
            Dim cmdDelete = New OleDbCommand

            With cmdDelete
                .Connection = Me.StudentConnection
                .CommandType = CommandType.Text
                .CommandText = "DELETE FROM " & _
                                StudentDataNames.TableName & _
                                " WHERE " & _
                                StudentDataNames.ID & " = ?"
                .Parameters.Add(Me.parmID)
            End With

            Return cmdDelete
        End Function

        ''' <summary>
        ''' Creates A Command For Retrieving 'ALL' Records From The StudentRecord Table.
        ''' </summary>
        ''' <returns>An OleDbCommand Object.</returns>
        ''' <remarks></remarks>
        Private Function CommandFillAll() As OleDbCommand
            Dim cmdSelect = New OleDbCommand()

            With cmdSelect
                .Connection = Me.StudentConnection
                .CommandType = CommandType.Text
                .CommandText = "SELECT " & _
                               StudentDataNames.ID & ", [" & _
                               StudentDataNames.FirstName & "], [" & _
                               StudentDataNames.LastName & "], " & _
                               StudentDataNames.PhoneNumber & ", " & _
                               StudentDataNames.Address & ", " & _
                               StudentDataNames.Email & ", " & _
                               StudentDataNames.Christmas & ", " & _
                               StudentDataNames.Summer & ", " & _
                               StudentDataNames.ClassName & ", ((" & _
                               StudentDataNames.Christmas & " + " & _
                               StudentDataNames.Summer & ") / 2) AS " & _
                               StudentDataNames.OverallTotal & ", '' AS " & _
                               StudentDataNames.Grade & _
                               " FROM " & _
                               StudentDataNames.TableName
            End With

            Return cmdSelect
        End Function

        ''' <summary>
        ''' Creates A Command For Filtering Students By Name.
        ''' </summary>
        ''' <returns>An OleDbCommand Object.</returns>
        ''' <remarks>Filters Both The First Name And The Last Name</remarks>
        Private Function CommandName() As OleDbCommand
            ' Filter By First Name AND Last Name.
            Dim cmdSelect = New OleDbCommand()

            With cmdSelect
                .Connection = Me.StudentConnection
                .CommandType = CommandType.Text
                .CommandText = "SELECT " & _
                               StudentDataNames.ID & ", [" & _
                               StudentDataNames.FirstName & "], [" & _
                               StudentDataNames.LastName & "], " & _
                               StudentDataNames.PhoneNumber & ", " & _
                               StudentDataNames.Address & ", " & _
                               StudentDataNames.Email & ", " & _
                               StudentDataNames.Christmas & ", " & _
                               StudentDataNames.Summer & ", " & _
                               StudentDataNames.ClassName & ", ((" & _
                               StudentDataNames.Christmas & " + " & _
                               StudentDataNames.Summer & ") / 2) AS " & _
                               StudentDataNames.OverallTotal & ", '' AS " & _
                               StudentDataNames.Grade & _
                               " FROM " & _
                               StudentDataNames.TableName & _
                               " WHERE ([" & _
                               StudentDataNames.FirstName & _
                               "] LIKE '" & Me.CurrentSearchValue & "%' OR [" & _
                               StudentDataNames.LastName & _
                               "] LIKE '" & Me.CurrentSearchValue & "%')"
            End With

            Return cmdSelect
        End Function

        ''' <summary>
        ''' Creates A Command For Filtering Students By Address.
        ''' </summary>
        ''' <returns>An OleDbCommand Object.</returns>
        ''' <remarks></remarks>
        Private Function CommandAddress() As OleDbCommand
            Dim cmdSelect = New OleDbCommand()

            With cmdSelect
                .Connection = Me.StudentConnection
                .CommandType = CommandType.Text
                .CommandText = "SELECT " & _
                                StudentDataNames.ID & ", [" & _
                                StudentDataNames.FirstName & "], [" & _
                                StudentDataNames.LastName & "], " & _
                                StudentDataNames.PhoneNumber & ", " & _
                                StudentDataNames.Address & ", " & _
                                StudentDataNames.Email & ", " & _
                                StudentDataNames.Christmas & ", " & _
                                StudentDataNames.Summer & ", " & _
                                StudentDataNames.ClassName & ", ((" & _
                                StudentDataNames.Christmas & " + " & _
                                StudentDataNames.Summer & ") / 2) AS " & _
                                StudentDataNames.OverallTotal & ", '' AS " & _
                                StudentDataNames.Grade & _
                                " FROM " & _
                                StudentDataNames.TableName & _
                                " WHERE " & _
                                StudentDataNames.Address & " = '" & Me.CurrentSearchValue & "'"
            End With

            Return cmdSelect
        End Function

        ''' <summary>
        ''' Creates A Command For Filtering Students By Class.
        ''' </summary>
        ''' <returns>An OleDbCommand Object.</returns>
        ''' <remarks></remarks>
        Private Function CommandClass() As OleDbCommand
            Dim cmdSelect = New OleDbCommand()

            With cmdSelect
                .Connection = Me.StudentConnection
                .CommandType = CommandType.Text
                .CommandText = "SELECT " & _
                               StudentDataNames.ID & ", [" & _
                               StudentDataNames.FirstName & "], [" & _
                               StudentDataNames.LastName & "], " & _
                               StudentDataNames.PhoneNumber & ", " & _
                               StudentDataNames.Address & ", " & _
                               StudentDataNames.Email & ", " & _
                               StudentDataNames.Christmas & ", " & _
                               StudentDataNames.Summer & ", " & _
                               StudentDataNames.ClassName & ", ((" & _
                               StudentDataNames.Christmas & " + " & _
                               StudentDataNames.Summer & ") / 2) AS " & _
                               StudentDataNames.OverallTotal & ", '' AS " & _
                               StudentDataNames.Grade & _
                               " FROM " & _
                               StudentDataNames.TableName & _
                               " WHERE " & _
                               StudentDataNames.ClassName & " = '" & Me.CurrentSearchValue & "'"
            End With

            Return cmdSelect
        End Function

        ''' <summary>
        ''' Creates A Command For Retrieving Distinct Classes.
        ''' </summary>
        ''' <returns>An OleDBCommand Object.</returns>
        ''' <remarks></remarks>
        Private Function CommandDistinctClassess() As OleDbCommand
            Dim command As New OleDbCommand

            With command
                .Connection = Me.StudentConnection
                .CommandType = CommandType.Text
                .CommandText = "SELECT DISTINCT (" & _
                                StudentDataNames.ClassName & ") " & _
                                "FROM " & _
                                StudentDataNames.TableName
            End With

            Return command
        End Function

        ''' <summary>
        ''' Creates A Command For Retrieving Distinct Addresses.
        ''' </summary>
        ''' <returns>An OleDBCommand Object.</returns>
        ''' <remarks></remarks>
        Private Function CommandDistinctAddresses() As OleDbCommand
            Dim command As New OleDbCommand

            With command
                .Connection = Me.StudentConnection
                .CommandType = CommandType.Text
                .CommandText = "SELECT DISTINCT " & _
                                StudentDataNames.Address & _
                                " FROM " & _
                                StudentDataNames.TableName
            End With

            Return command
        End Function

#End Region

#Region "Update & Fill Methods"

        ''' <summary>
        ''' Assigns The Appropriate 'SELECT' Command.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetCommand()

            If Me.CurrentSearchOption = SearchOptions.SearchByAddress Then
                Me.StudentAdapter.SelectCommand = Me.CommandAddress()
            ElseIf Me.CurrentSearchOption = SearchOptions.SearchByClass Then
                Me.StudentAdapter.SelectCommand = Me.CommandClass()
            ElseIf Me.CurrentSearchOption = SearchOptions.SearchByGrade Then
                Me.StudentAdapter.SelectCommand = Me.CommandFillAll
            ElseIf Me.CurrentSearchOption = SearchOptions.SearchByName Then
                If String.IsNullOrEmpty(Me.CurrentSearchValue) Then
                    Me.StudentAdapter.SelectCommand = Me.CommandFillAll()
                Else
                    Me.StudentAdapter.SelectCommand = Me.CommandName()
                End If
            Else
                MessageBox.Show("Invalid Search Criteria", "Data Adapter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        End Sub

        ''' <summary>
        ''' Updates All Changes Made To The Student DataTable Object
        ''' </summary>
        ''' <returns>True if Successfull, Otherwise False</returns>
        ''' <remarks></remarks>
        Public Function UpdateAll() As Boolean
            ' Return Value
            Dim rt As Boolean = False

            Try
                ' Persist Changes To Database.
                Me.StudentAdapter.Update(Me.StudentDataTable)

                ' Raise The 'StudentTableChanged' Event 
                ' To Force A Recalculation Of Totals And Averages.
                Me.StudentDataTable.StudentTableChanged(Me.CurrentSearchOption)

                ' Refill The Table
                Me.Fill()

                ' Indicate That The Update Was Successful.
                rt = True
            Catch ex As Exception
                MessageBox.Show(ex.ToString, _
                                "Error Updating Students Table.", _
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Return rt
        End Function

        ''' <summary>
        '''  Calls The Approriate 'Fill' Method.
        ''' </summary>
        ''' <remarks></remarks>
        Private Function Fill() As Integer

            ' There Are Two Possible Fill Methods That Can Be Called, 'FillStudentsByGrade' or 'FillStudents'.

            ' 'FillStudents' Is Used In All Ocassions Except One, When We Are Searching For Students For A Particular Grade.

            ' This Is Because 'Grade' Is Not Actually Part Of The Database Table And ThereFore Requires Some Extra Processing.

            Me.SetCommand()

            If Me.CurrentSearchOption = SearchOptions.SearchByGrade Then
                Return FillStudentsByGrade()
            Else
                Return FillStudents()
            End If

        End Function

        ''' <summary>
        ''' Fills The Student Data Table According To The Specified Search Criteria.
        ''' </summary>
        ''' <returns>A 32-bit Integer Value Representing The Row Count In The Data Table.</returns>
        ''' <remarks></remarks>
        Private Function FillStudents() As Integer
            Try
                ' Always Clear Any Existing Rows First.
                Me.StudentDataTable.Clear()

                ' Fill the Data Table
                Me.StudentAdapter.Fill(Me.StudentDataTable)

                ' Assign Grades For Each Student.
                Me.AssignGrades(Me.StudentDataTable)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error Filling Student Records: " &
                                             _CurrentSearchValue, _
                                             MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ' Commit All Changes To The Student Data Table.
                Me.StudentDataTable.AcceptChanges()
                ' Raise The 'StudentTableChanged' Event 
                ' To Force A Recalculation Of Totals And Averages.
                Me.StudentDataTable.StudentTableChanged(Me.CurrentSearchOption)
            End Try

            ' Return The Number Of Rows In The Table.
            Return Me.StudentDataTable.Rows.Count
        End Function

        ''' <summary>
        ''' Fills The Student Data Table By Grade.
        ''' </summary>
        ''' <returns>A 32-bit Integer Value Representing The Row Count In The Data Table.</returns>
        ''' <remarks></remarks>
        Private Function FillStudentsByGrade() As Integer
            ' This Is Slightly Different From The Main 'Fill' Method.
            ' This Is Because 'Grade' Is Not Actually Part Of The Database Table 
            ' And ThereFore Requires Some Extra Processing.

            ' Create A Temporary Table
            Dim tempTable As New dtStudent

            Try
                ' Always Clear Any Existing Rows First.
                Me.StudentDataTable.Clear()

                ' Fill The Temporary Data Table.
                Me.StudentAdapter.Fill(tempTable)

                ' Assign Grades For Each Student.
                Me.AssignGrades(tempTable)

                ' Search Rows That Match The Criteria In The Temporary Table And 
                ' Add Them To The Student Data Table.
                For Each row As DataRow In tempTable.Rows
                    If row.Item(StudentDataNames.Grade) = Me.CurrentSearchValue Then
                        Me.StudentDataTable.ImportRow(row)
                    End If
                Next
            Catch ex As Exception
                MessageBox.Show(ex.ToString, _
                                "Error Filling Student Records By Class: " & _
                                Me.CurrentSearchValue, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ' Commit All Changes To The Student Data Table.
                Me.StudentDataTable.AcceptChanges()
                ' Raise The 'StudentTableChanged' Event 
                ' To Force A Recalculation Of Totals And Averages.
                Me.StudentDataTable.StudentTableChanged(Me.CurrentSearchOption)
            End Try

            ' Return The Number Of Rows In The Table.
            Return Me.StudentDataTable.Rows.Count
        End Function

        ''' <summary>
        ''' Assigns the Grade For Each Student.
        ''' </summary>
        ''' <param name="dataTable">Student Data Table</param>
        ''' <remarks></remarks>
        Private Sub AssignGrades(ByRef dataTable As dtStudent)

            For Each r As DataRow In dataTable.Rows
                r.Item(StudentDataNames.Grade) = _
                    Grades.GetGrade(r.Item(StudentDataNames.OverallTotal))
            Next

        End Sub

        ''' <summary>
        ''' Retrieves A Table Of Distinct Classes.
        ''' </summary>
        ''' <returns>A Table Of Distinct Student Classes.</returns>
        ''' <remarks></remarks>
        Public Function GetDistinctClasses() As dtDistinctClass
            Me.StudentAdapter.SelectCommand = Me.CommandDistinctClassess
            Dim dataTable As New dtDistinctClass
            Me.StudentAdapter.Fill(dataTable)

            ' Change Class Names To UpperCase.
            For Each row As DataRow In dataTable.Rows
                row.Item(StudentDataNames.ClassName) = row.Item(StudentDataNames.ClassName).ToString.ToUpper
            Next

            Return dataTable
        End Function

        ''' <summary>
        ''' Retrieves A Table Of Distinct Addresses.
        ''' </summary>
        ''' <returns>A Table Of Distinct Student Addresses.</returns>
        ''' <remarks></remarks>
        Public Function GetDistinctAddresses() As dtDistinctAddress
            Me.StudentAdapter.SelectCommand = Me.CommandDistinctAddresses
            Dim dataTable As New dtDistinctAddress
            Me.StudentAdapter.Fill(dataTable)
            Return dataTable
        End Function

#End Region

    End Class

End Namespace

