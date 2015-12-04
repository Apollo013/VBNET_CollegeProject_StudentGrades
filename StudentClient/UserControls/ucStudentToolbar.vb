Imports DAL

Namespace UserControls

    Public Class ucStudentToolbar
        Inherits FlowLayoutPanel

#Region "Comments"

        ' This Is Where The Bulk Of The Processing Occurs In Relation To Updating, Searching And Navigating.

        ' The DataSet, DataAdapter and Binding Source Are Created Here Along With All Other Button And Combo Controls.

        ' In The 'Search Properties' Region, The 'SearchValue' Property Set Method, Assigns Any New Value To A Property
        ' Of The Same Name In The 'adprStudent' Data Adpater Object Which Triggers A New Search.

        ' Similary, The 'CurrentSearchOption' Property Determines What 'SELECT' Command The Adapter Is To Use.

        ' All Control Creation And Event Handlers In Relation To Updating, Navigating, Searching And Exiting Are
        ' Located In Their Respective Regions.

        ' The 'Class Methods' Region Has One Member That Checks If The DataSet Has Any Changes Before Exiting or Changing The Search Criteria.

#End Region

#Region "Data Object References"

        ''' <summary>
        ''' A Reference To The Student Data Set That Caches The Student Data Table.
        ''' </summary>
        ''' <remarks></remarks>
        Private studentDataSet As dsStudent

        ''' <summary>
        ''' A Reference To The Binding Source Object That Is Bound To The Student Data Grid.
        ''' </summary>
        ''' <remarks></remarks>
        Private studentBindingSource As BindingSource

        ''' <summary>
        ''' A Reference To The Student Data Adapter Responsible For Updates And Table Population.
        ''' </summary>
        ''' <remarks></remarks>
        Private studentDataAdapter As adprStudent

        ''' <summary>
        ''' A Reference To The DataGridView Used To Display Student Records.
        ''' </summary>
        ''' <remarks></remarks>
        Private _studentDataGrid As ucStudentDataGrid

#End Region

#Region "Constructor & Initialisers"

        ''' <summary>
        ''' Toolbar Constructor
        ''' </summary>
        ''' <param name="parmStudentDataSet">A Reference To The Student Data Set Object (dsStudent).</param>
        ''' <param name="parmStudentBindingSource">A Reference To A Binding Source Object (BindingSource).</param>
        ''' <param name="parmStudentDataAdapter">A Reference To The Student Data Adapter Object (adprStudent).</param>
        ''' <param name="parmStudentDataGrid">A Reference To The Student Data Grid Object (ucStudentDataGrid).</param>
        ''' <remarks></remarks>
        Public Sub New(ByRef parmStudentDataSet As dsStudent, ByRef parmStudentBindingSource As BindingSource, _
                       ByRef parmStudentDataAdapter As adprStudent, ByRef parmStudentDataGrid As ucStudentDataGrid)

            MyBase.New()
            With Me
                .studentDataSet = parmStudentDataSet
                .studentBindingSource = parmStudentBindingSource
                .studentDataAdapter = parmStudentDataAdapter
                ._studentDataGrid = parmStudentDataGrid
                .SuspendLayout()
                .Init()
                .InitControls()
                .ResumeLayout()
            End With
        End Sub

        ''' <summary>
        ''' Initialises The Toolbar Component.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Init()
            With Me
                .Name = "StudentToolbar"
                .Dock = DockStyle.Top
                .MinimumSize = New Size(0, 0)
                .Size = New Size(0, 36)
            End With
        End Sub

        ''' <summary>
        ''' Initialises Child Controls And Adds Them To The Toolbar.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub InitControls()
            ' Add Child Controls To The Toolbar.
            With Me.Controls
                .AddRange(New Control() _
                          {Me.btnExit,
                           New tplDivider(DividerType.VerticalButtonDivider),
                           Me.btnAdd,
                           Me.btnDelete,
                           New tplDivider(DividerType.VerticalButtonDivider),
                           Me.btnSave,
                           New tplDivider(DividerType.VerticalButtonDivider),
                           Me.btnMoveFirst,
                           Me.btnMovePrevious,
                           Me.btnMoveNext,
                           Me.btnMoveLast,
                           New tplDivider(DividerType.VerticalButtonDivider),
                           Me.cboSearchOption})
            End With
            ' Trigger A New Search.
            _cboSearchOption.SelectedIndex = 0
        End Sub

#End Region

#Region "Update Controls And Event Handlers"

#Region "Add Button Control"

        Private _btnAdd As tplButton
        ''' <summary>
        ''' Gets A Button Control For Creating A New Student Record.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property btnAdd() As tplButton
            Get
                If _btnAdd Is Nothing Then
                    _btnAdd = New tplButton()

                    With _btnAdd
                        .Name = "btnAdd"
                        .Image = CType(My.Resources.AddNew, Image)
                        .ToolTip = "Add A New Record"
                        .TabIndex = 1
                    End With

                    AddHandler Me._btnAdd.Click, AddressOf Me.Add
                End If
                Return _btnAdd
            End Get
        End Property

        ''' <summary>
        ''' Adds A New Student Record And Begins Edit. 
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Add()
            ' Add A New Row.
            studentBindingSource.AddNew()

            ' Move To The 'First Name' Column And Begin Edit.
            _studentDataGrid.CurrentCell = _
                            Me._studentDataGrid(1, _studentDataGrid.NewRowIndex - 1)

            _studentDataGrid.BeginEdit(True)
        End Sub

#End Region

#Region "Delete Button Control"

        Private _btnDelete As tplButton
        ''' <summary>
        ''' Gets A Button Control For Deleting A Data Grid Row.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property btnDelete() As tplButton
            Get
                If _btnDelete Is Nothing Then
                    _btnDelete = New tplButton()

                    With _btnDelete
                        .Name = "btnDelete"
                        .Image = CType(My.Resources.Delete, Image)
                        .ToolTip = "Delete Record"
                        .TabIndex = 2
                    End With

                    AddHandler Me._btnDelete.Click, AddressOf Me.Delete
                End If
                Return _btnDelete
            End Get
        End Property

        ''' <summary>
        ''' Deletes A Student Row From The Data Grid View. 
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Delete()
            studentBindingSource.RemoveCurrent()
        End Sub

#End Region

#Region "Save Button Control"

        Private _btnSave As tplButton
        ''' <summary>
        ''' Gets A Button Control For Persisting Changes To The Students Database.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property btnSave() As tplButton
            Get
                If _btnSave Is Nothing Then
                    _btnSave = New tplButton()

                    With _btnSave
                        .Name = "btnSave"
                        .Image = CType(My.Resources.Devices_media_floppy_icon, Image)
                        .ToolTip = "Save Changes"
                        .TabIndex = 3
                    End With

                    AddHandler Me._btnSave.Click, AddressOf Me.Save
                End If
                Return _btnSave
            End Get
        End Property

        ''' <summary>
        ''' Persists Changes To The Students Database. 
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Save()
            studentBindingSource.EndEdit()

            ' Persist Any Changes To The Database.
            If studentDataAdapter.UpdateAll() Then
                studentDataSet.AcceptChanges()
            End If
        End Sub

#End Region

#End Region

#Region "Navigation Controls And Event Handlers"

#Region "Move First Button Control"

        Private _btnMoveFirst As tplButton
        ''' <summary>
        ''' Gets A Button Control For Moving To The First Record.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property btnMoveFirst() As tplButton
            Get
                If _btnMoveFirst Is Nothing Then
                    _btnMoveFirst = New tplButton

                    With _btnMoveFirst
                        .Name = "btnMoveFirst"
                        .Image = CType(My.Resources.Gnome_Go_First_32, Image)
                        .ToolTip = "Move To First Record"
                        .TabIndex = 4
                    End With

                    AddHandler Me._btnMoveFirst.Click, AddressOf Me.MoveFirst
                End If
                Return _btnMoveFirst
            End Get
        End Property

        ''' <summary>
        ''' Moves To The First Row In A DataGrid.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub MoveFirst()
            studentBindingSource.MoveFirst()
        End Sub

#End Region

#Region "Move Previous Button Control"

        Private _btnMovePrevious As tplButton
        ''' <summary>
        ''' Gets A Button Control For Moving To The Previous Record.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property btnMovePrevious() As tplButton
            Get
                If _btnMovePrevious Is Nothing Then
                    _btnMovePrevious = New tplButton()

                    With _btnMovePrevious
                        .Name = "btnMovePrevious"
                        .Image = CType(My.Resources.Gnome_Go_Previous_32, Image)
                        .ToolTip = "Move To Previous Record"
                        .TabIndex = 5
                    End With

                    AddHandler _btnMovePrevious.Click, AddressOf MovePrevious
                End If
                Return _btnMovePrevious
            End Get
        End Property

        ''' <summary>
        ''' Moves To The Previous Row In A DataGrid.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub MovePrevious()
            studentBindingSource.MovePrevious()
        End Sub

#End Region

#Region "Move Next Button Control"

        Private _btnMoveNext As tplButton
        ''' <summary>
        ''' Gets A Button Control For Moving To The Next Record.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property btnMoveNext() As tplButton
            Get
                If _btnMoveNext Is Nothing Then
                    _btnMoveNext = New tplButton()

                    With _btnMoveNext
                        .Name = "btnMoveNext"
                        .Image = CType(My.Resources.Gnome_Go_Next_32, Image)
                        .ToolTip = "Move To Next Record"
                        .TabIndex = 6
                    End With

                    AddHandler _btnMoveNext.Click, AddressOf MoveNext
                End If
                Return _btnMoveNext
            End Get
        End Property

        ''' <summary>
        ''' Moves To The Next Row In A DataGrid.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub MoveNext()
            studentBindingSource.MoveNext()
        End Sub

#End Region

#Region "Move Last Button Control"

        Private _btnMoveLast As tplButton
        ''' <summary>
        ''' Gets A Button Control For Moving To Last Record.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property btnMoveLast() As tplButton
            Get
                If _btnMoveLast Is Nothing Then
                    _btnMoveLast = New tplButton()

                    With _btnMoveLast
                        .Name = "btnNavLast"
                        .Image = CType(My.Resources.Gnome_Go_Last_32, Image)
                        .ToolTip = "Move To Last Record"
                        .TabIndex = 7
                    End With

                    AddHandler _btnMoveLast.Click, AddressOf MoveLast
                End If
                Return _btnMoveLast
            End Get
        End Property

        ''' <summary>
        ''' Moves To The Next Row In A DataGrid.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub MoveLast()
            studentBindingSource.MoveLast()
        End Sub

#End Region

#End Region

#Region "Search Controls And Event Handlers"

#Region "Search Properties"

        Private _SearchValue As String = "a"
        ''' <summary>
        ''' Gets or Sets The Search Criteria Used For Filtering Student Records.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SearchValue() As String
            Get
                Return _SearchValue
            End Get
            Set(ByVal value As String)
                If _SearchValue <> value Then
                    _SearchValue = value

                    ' Tell The Data Adapter What We Are Searching For.
                    ' i.e. A Name, Address, Class Name or Grade.
                    studentDataAdapter.CurrentSearchOption = _CurrentSearchOption

                    ' Now Tell The Data Adapter The Value We Are Searching For.
                    ' This Will Then Trigger A New Search.
                    studentDataAdapter.CurrentSearchValue = value
                End If
            End Set
        End Property

        Private _CurrentSearchOption As SearchOptions = SearchOptions.SearchOff
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
                If _CurrentSearchOption <> value Then
                    _CurrentSearchOption = value
                End If
            End Set
        End Property

#End Region

#Region "Search Option ComboBox Control"

        Private _cboSearchOption As tplComboBox
        ''' <summary>
        ''' Gets A ComboBox Control That Allows A User To Choose What To Search For.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property cboSearchOption() As tplComboBox
            Get
                If _cboSearchOption Is Nothing Then
                    _cboSearchOption = New tplComboBox()

                    With _cboSearchOption
                        .Items.AddRange(New String() {"Search By Name",
                                                      "Search By Address",
                                                      "Search By Class",
                                                      "Search By Grade"})
                        .Name = "cboSearchOption"
                        .TabIndex = 8
                    End With

                    AddHandler _cboSearchOption.SelectedIndexChanged, _
                        AddressOf SearchOptionChanged
                End If
                Return _cboSearchOption
            End Get
        End Property

        ''' <summary>
        ''' 'SelectedIndexChanged' Event Handler For '_cboSearchOption'. 
        ''' </summary>
        ''' <remarks>Changes The 'SELECT' Command and Displays The Appropriate Search Controls.</remarks>
        Private Sub SearchOptionChanged()

            ' Firstly, Check If There Are Changes That Need To Be Committed.
            If Me.ChangesCommitted Then

                ' Secondly, Make Sure A New Selection Was Made.
                If _cboSearchOption.SelectedIndex <> _CurrentSearchOption Then

                    ' Change The 'SELECT' Command To Be Used By The Data Adapter.
                    Me.CurrentSearchOption = _cboSearchOption.SelectedIndex

                    ' Display The Appropriate Controls.
                    Me.DisplaySearchValueControl()

                End If
            Else
                ' The User Was Offered To Save Changes But Choose To Cancel,
                ' Meaning We Need To Re-Display The Original Selection.
                ' (The User Had To First Make The Change Before We Could Actually Test If Was Legal.)
                _cboSearchOption.SelectedIndex = _CurrentSearchOption
            End If

        End Sub

        ''' <summary>
        ''' Displays The Appropriate Search Controls.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub DisplaySearchValueControl()

            If _CurrentSearchOption = SearchOptions.SearchByName Then
                ' Hide ComboBox, Unhide TextBox and Button.
                Me.txtSearchValue.Visible = True
                Me.btnSearch.Visible = True
                Me.cboSearchValue.Visible = False

                ' Trigger A New Search.
                TextBoxSearchValueChanged(Me, New KeyEventArgs(Keys.Enter))
            Else
                ' UnHide ComboBox, Hide TextBox and Button.
                Me.cboSearchValue.Visible = True
                Me.txtSearchValue.Visible = False
                Me.btnSearch.Visible = False

                ' Trigger A New Search.
                Me.ComboSearchValueChanged()
            End If

        End Sub

#End Region

#Region "Search Value ComboBox Control"

        Private _cboSearchValue As tplComboBox
        ''' <summary>
        ''' Gets A ComboBox Used For Searching Students By Address, Class or Grade.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property cboSearchValue() As tplComboBox
            Get
                ' Create The Control If It Does Not Already Exist.
                If _cboSearchValue Is Nothing Then
                    _cboSearchValue = New tplComboBox

                    With _cboSearchValue
                        .Name = "cboSearchValue"
                        .Size = New Size(340, 24)
                        .TabIndex = 11
                        .Visible = False
                    End With

                    AddHandler _cboSearchValue.SelectionChangeCommitted, _
                                        AddressOf Me.ComboSearchValueChanged

                    Me.Controls.Add(_cboSearchValue)
                End If

                ' Assign The Appropriate DataMemeber and DataSource Objects.
                ' We Must First Clear These Properties.
                With _cboSearchValue
                    .DisplayMember = Nothing
                    .DataSource = Nothing

                    If Me.CurrentSearchOption = SearchOptions.SearchByAddress Then
                        .DisplayMember = StudentDataNames.Address
                        .DataSource = studentDataAdapter.GetDistinctAddresses

                    ElseIf Me.CurrentSearchOption = SearchOptions.SearchByClass Then
                        .DisplayMember = StudentDataNames.ClassName
                        .DataSource = studentDataAdapter.GetDistinctClasses

                    Else
                        .DataSource = Grades.ToArray
                    End If
                End With

                Return _cboSearchValue
            End Get
        End Property

        ''' <summary>
        ''' Initiates A Search For Students Either By Address, Class or Grade.
        ''' </summary>
        ''' <remarks>'SelectionChangeCommitted' Event Handler For '_cboSearchValue'</remarks>
        Private Sub ComboSearchValueChanged()

            ' Only Trigger A New Search If A New Search Value Was Entered.
            If _SearchValue <> _cboSearchValue.Text Then

                ' Only Trigger A New Search If All Changes Have Been Committed.
                If Me.ChangesCommitted Then

                    ' Trigger New Search.
                    Me.SearchValue = _cboSearchValue.Text

                Else
                    ' The User Was Offered To Save Changes But Choose To Cancel,
                    ' Meaning We Need To Re-Display The Original Selection.
                    ' (The User Had To First Make The Change Before We Could Actually Test If Was Legal.)
                    _cboSearchValue.Text = _SearchValue
                End If

            End If

        End Sub

#End Region

#Region "Name Search TextBox Control"

        Private _txtSearchValue As TextBox
        ''' <summary>
        ''' Gets A TextBox Control Used For Searching Student Records By Name.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property txtSearchValue() As TextBox
            Get
                ' Create The Control If It Does Not Already Exist.
                If _txtSearchValue Is Nothing Then
                    _txtSearchValue = New TextBox

                    With _txtSearchValue
                        .AcceptsReturn = True
                        .Anchor = AnchorStyles.Right + AnchorStyles.Top + AnchorStyles.Left
                        .BorderStyle = Windows.Forms.BorderStyle.FixedSingle
                        .Margin = New Padding(10, 7, 0, 0)
                        .MinimumSize = New Size(0, 0)
                        .Name = "txtNameSearch"
                        .Size = New Size(300, 27)
                        .TabIndex = 9
                        .TabStop = True
                        .TextAlign = HorizontalAlignment.Left
                    End With

                    AddHandler _txtSearchValue.KeyDown, AddressOf Me.TextBoxSearchValueChanged

                    Me.Controls.Add(_txtSearchValue)
                End If

                ' Always Start Afresh, This Will Force 'All' Students To Be Displayed.
                _txtSearchValue.Text = String.Empty

                Return _txtSearchValue
            End Get
        End Property

        ''' <summary>
        ''' Initiates A Search For Students By Name.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>'KeyDown' Event Handler For _txtSearchValue.</remarks>
        Private Sub TextBoxSearchValueChanged(sender As Object, e As System.Windows.Forms.KeyEventArgs)

            ' Only Trigger A New Search If The Enter Key Was Pressed.
            If e.KeyCode.Equals(Keys.Enter) Then

                ' Prevent That Annoying 'Ding' Wave File From Sounding Out When The Enter Key Is Pressed.
                e.SuppressKeyPress = True

                ' Only Trigger A New Search If A New Search Value Was Entered.
                If _SearchValue <> _txtSearchValue.Text.Trim Then

                    ' Only Trigger A New Search If All Changes Have Been Committed.
                    If Me.ChangesCommitted Then

                        ' Trigger New Search.
                        Me.SearchValue = _txtSearchValue.Text.Trim

                        ' Clear Any Leading or Trailing Spaces.
                        _txtSearchValue.Text = _txtSearchValue.Text.Trim

                    Else
                        ' The User Was Offered To Save Changes But Choose To Cancel,
                        ' Meaning We Need To Re-Display The Original Selection.
                        ' (The User Had To First Make The Change Before We Could Actually Test If Was Legal.)
                        _txtSearchValue.Text = _SearchValue
                    End If
                End If

            End If

        End Sub

#End Region

#Region "Name Search Button Control"

        Private _btnSearch As tplButton
        ''' <summary>
        ''' Gets A Button Control Used For Searching Student Records By Name.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property btnSearch() As tplButton
            Get
                If _btnSearch Is Nothing Then
                    _btnSearch = New tplButton

                    With _btnSearch
                        .Image = My.Resources.Search_button_green_32
                        .Name = "btnSearchButton"
                        .TabIndex = 10
                        .ToolTip = "Search"
                    End With

                    AddHandler _btnSearch.Click, AddressOf Search

                    Me.Controls.Add(_btnSearch)
                End If
                Return _btnSearch
            End Get
        End Property

        ''' <summary>
        ''' Initiates A Search For A Student By Name.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>'Click' Event Handler For '_btnNameSearch'.</remarks>
        Private Sub Search(sender As Object, e As System.EventArgs)
            ' Call The 'KeyDown' Event Handler For The _txtSearchValue Control.
            TextBoxSearchValueChanged(sender, New KeyEventArgs(Keys.Enter))
        End Sub

#End Region

#End Region

#Region "Exit Control And Event Handler"

        Private _btnExit As tplButton
        ''' <summary>
        ''' Gets A Button Control For Exiting A Form Or Application.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property btnExit() As tplButton
            Get
                If _btnExit Is Nothing Then
                    _btnExit = New tplButton()

                    With _btnExit
                        .Image = CType(My.Resources.exit_32, Image)
                        .Name = "btnExit"
                        .TabIndex = 0
                        .ToolTip = "Exit Application"
                    End With

                    AddHandler Me._btnExit.Click, AddressOf Me.Close
                End If
                Return _btnExit
            End Get
        End Property

        ''' <summary>
        ''' Closes The Application.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Close()
            ' Check That We Don't Have Any Changes That Need To Be Committed Before Exiting.
            If Me.ChangesCommitted = True Then
                Application.Exit()
            End If
        End Sub

#End Region

#Region "Class Methods"

        ''' <summary>
        ''' Checks If The DataSet Has Changes And Offers To Save Them.
        ''' </summary>
        ''' <returns>True If The DataSet Has No Changes, False Otherwise.</returns>
        ''' <remarks></remarks>
        Public Function ChangesCommitted() As Boolean

            ' If There Are Changes To The DataSet, The User Will Be Prompted To Save Them.

            ' Three Options Will Be Made Available; Yes, No or Cancel.

            ' Whether The User Selects Yes or No, A Decision Has Being Made Either Way And We Return True.

            ' If The User Cancels However, We Return False, Which Will Allow Us To Abort All Pending Actions 
            ' And Let The User To Review Any Changes Made To Student Records.

            If studentDataSet.HasChanges Then
                Dim result As Integer = MessageBox.Show("Do you want to save your changes first ?", _
                                                        "Ofiaich Students", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If result = MsgBoxResult.Yes Then
                    ' Save All Changes.
                    Me.Save()
                    Return True
                ElseIf result = MsgBoxResult.No Then
                    ' Cancel All Changes.
                    studentDataSet.RejectChanges()
                    studentDataSet.AcceptChanges()
                    Return True
                Else
                    ' User Cancelled.
                    Return False
                End If
            Else
                ' There Are No Changes.
                Return True
            End If

        End Function

#End Region

    End Class

End Namespace
