Imports DAL

Namespace UserControls

    Public Class ucStudentDataGrid
        Inherits DataGridView

#Region "Comments"

        ' This Is The DataGridView Used To Display Student Records.

        ' The Constructor Takes A BindingSource Object As An Arguement and Uses It To Bind To The Student Table.

        ' Besides The Contructor and Init Methods, There Is Only One Other Method That Moves To The First Name Column When A New Row Is Added.

#End Region

#Region "Column Properties"

        Private _dgcID As DataGridViewTextBoxColumn
        ''' <summary>
        ''' Gets A Datagrid Column For Students ID.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A New Readonly TextBox Column For Students ID.</returns>
        ''' <remarks></remarks>
        ''' 
        Private ReadOnly Property dgcID() As DataGridViewTextBoxColumn
            Get
                _dgcID = New DataGridViewTextBoxColumn

                With _dgcID
                    .DataPropertyName = StudentDataNames.ID
                    .HeaderText = "ID"
                    .Name = StudentDataNames.ID
                    .ReadOnly = True
                    .Resizable = DataGridViewTriState.False
                    .ToolTipText = "Students Unique Identifier (Readonly)"
                    .Width = 40
                End With

                Return _dgcID
            End Get
        End Property

        Private _dgcFirstName As DataGridViewTextBoxColumn
        ''' <summary>
        ''' Gets A Datagrid Column For Students First Name.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A New TextBox Column For Students First Name.</returns>
        ''' <remarks></remarks>
        ''' 
        Private ReadOnly Property dgcFirstName() As DataGridViewTextBoxColumn
            Get
                _dgcFirstName = New DataGridViewTextBoxColumn

                With _dgcFirstName
                    .DataPropertyName = StudentDataNames.FirstName
                    .HeaderText = "First Name"
                    .Name = StudentDataNames.FirstName
                    .ToolTipText = "Students First Name"
                    .Width = 100
                End With

                Return _dgcFirstName
            End Get
        End Property

        Private _dgcLastName As DataGridViewTextBoxColumn
        ''' <summary>
        ''' Gets A Datagrid Column For Students Last Name.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A New TextBox Column For Students Last Name.</returns>
        ''' <remarks></remarks>
        ''' 
        Private ReadOnly Property dgcLastName() As DataGridViewTextBoxColumn
            Get
                _dgcLastName = New DataGridViewTextBoxColumn

                With _dgcLastName
                    .DataPropertyName = StudentDataNames.LastName
                    .HeaderText = "Last Name"
                    .Name = StudentDataNames.LastName
                    .ToolTipText = "Students Last Name"
                    .Width = 100
                End With

                Return _dgcLastName
            End Get
        End Property

        Private _dgcAddress As DataGridViewTextBoxColumn
        ''' <summary>
        ''' Gets A Datagrid Column For Students Address.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A New TextBox Column For Students Address.</returns>
        ''' <remarks></remarks>        
        Private ReadOnly Property dgcAddress() As DataGridViewTextBoxColumn
            Get
                _dgcAddress = New DataGridViewTextBoxColumn

                With _dgcAddress
                    .DataPropertyName = StudentDataNames.Address
                    .HeaderText = "Address"
                    .Name = StudentDataNames.Address
                    .ToolTipText = "Students Home Address"
                    .Width = 100
                End With

                Return _dgcAddress
            End Get
        End Property

        Private _dgcPhone As DataGridViewTextBoxColumn
        ''' <summary>
        ''' Gets A Datagrid Column For Students Phone Number.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A New TextBox Column For Students Phone Number.</returns>
        ''' <remarks></remarks>
        Private ReadOnly Property dgcPhone() As DataGridViewTextBoxColumn
            Get
                _dgcPhone = New DataGridViewTextBoxColumn

                With _dgcPhone
                    .DataPropertyName = StudentDataNames.PhoneNumber
                    .HeaderText = "Phone Number"
                    .Name = StudentDataNames.PhoneNumber
                    .ToolTipText = "Students Phone Nunmber"
                    .Width = 110
                End With

                Return _dgcPhone
            End Get
        End Property

        Private _dgcEmail As DataGridViewTextBoxColumn
        ''' <summary>
        ''' Gets A Datagrid Column For Students Email.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A New TextBox Column For Students Email.</returns>
        ''' <remarks></remarks>
        Private ReadOnly Property dgcEmail() As DataGridViewTextBoxColumn
            Get
                _dgcEmail = New DataGridViewTextBoxColumn

                With _dgcEmail
                    .DataPropertyName = StudentDataNames.Email
                    .HeaderText = "Email"
                    .Name = StudentDataNames.Email
                    .Width = 180
                    .MinimumWidth = 170
                    .ToolTipText = "Students Email Address"
                End With

                Return _dgcEmail
            End Get
        End Property

        Private _dgcClass As DataGridViewTextBoxColumn
        ''' <summary>
        ''' Gets A Datagrid Column For Students Class.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A New TextBox Column For Students Class.</returns>
        ''' <remarks></remarks>
        Private ReadOnly Property dgcClass() As DataGridViewTextBoxColumn
            Get
                _dgcClass = New DataGridViewTextBoxColumn

                With _dgcClass
                    .DataPropertyName = StudentDataNames.ClassName
                    .HeaderText = "Class"
                    .Name = StudentDataNames.ClassName
                    .ToolTipText = "Students Class Name"
                    .Width = 70
                End With

                Return _dgcClass
            End Get
        End Property

        Private _dgcChristmasMark As DataGridViewTextBoxColumn
        ''' <summary>
        ''' Gets A Datagrid Column For Students Christmas Mark.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A New TextBox Column For Students Christmas Mark.</returns>
        ''' <remarks></remarks>
        Private ReadOnly Property dgcChristmasMark() As DataGridViewTextBoxColumn
            Get
                _dgcChristmasMark = New DataGridViewTextBoxColumn

                With _dgcChristmasMark
                    .DataPropertyName = StudentDataNames.Christmas
                    .HeaderText = "Christmas %"
                    .Name = StudentDataNames.Christmas
                    .ToolTipText = "Mark Earned For Christmas Exam"
                    .Width = 70
                End With

                Return _dgcChristmasMark
            End Get
        End Property

        Private _dgcSummerMark As DataGridViewTextBoxColumn
        ''' <summary>
        ''' Gets A Datagrid Column For Students Summer Mark.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A New TextBox Column For Students Summer Mark.</returns>
        ''' <remarks></remarks>
        Private ReadOnly Property dgcSummerMark() As DataGridViewTextBoxColumn
            Get
                _dgcSummerMark = New DataGridViewTextBoxColumn

                With _dgcSummerMark
                    .DataPropertyName = StudentDataNames.Summer
                    .HeaderText = "Summer %"
                    .Name = StudentDataNames.Summer
                    .ToolTipText = "Mark Earned For Summer Exam"
                    .Width = 70
                End With

                Return _dgcSummerMark
            End Get
        End Property

        Private _dgcOverallMark As DataGridViewTextBoxColumn
        ''' <summary>
        ''' Gets A Datagrid Column For Students Overall Mark.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A New TextBox Column For Students Overall Mark.</returns>
        ''' <remarks></remarks>
        ''' 
        Private ReadOnly Property dgcOverallMark() As DataGridViewTextBoxColumn
            Get
                _dgcOverallMark = New DataGridViewTextBoxColumn

                With _dgcOverallMark
                    .DataPropertyName = StudentDataNames.OverallTotal
                    .HeaderText = "Overall %"
                    .Name = StudentDataNames.OverallTotal
                    .ReadOnly = True
                    .ToolTipText = "Overall Mark For Year (ReadOnly)"
                    .Width = 70
                End With

                Return _dgcOverallMark
            End Get
        End Property

        Private _dgcGrade As DataGridViewTextBoxColumn
        ''' <summary>
        ''' Gets A Datagrid Column For Students Grade.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A New TextBox Column For Students Grade.</returns>
        ''' <remarks></remarks>
        Private ReadOnly Property dgcGrade() As DataGridViewTextBoxColumn
            Get
                _dgcGrade = New DataGridViewTextBoxColumn

                With _dgcGrade
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DataPropertyName = StudentDataNames.Grade
                    .HeaderText = "Grade"
                    .Name = StudentDataNames.Grade
                    .ReadOnly = True
                    .ToolTipText = "Overall Grade For Student (ReadOnly)"
                End With

                Return _dgcGrade
            End Get
        End Property

#End Region

#Region "Constructor & Initialisers"

        ''' <summary>
        ''' 'ucStudentDataGrid' Class Constructor.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByRef _bs As BindingSource)
            With Me
                .DataSource = _bs
                .Init()
                .InitControls()
            End With
        End Sub

        ''' <summary>
        ''' Initialises The DataGrid Component.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Init()
            With Me
                .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
                .Anchor = AnchorStyles.Left + _
                          AnchorStyles.Top + _
                          AnchorStyles.Right + _
                          AnchorStyles.Bottom
                .AutoGenerateColumns = False
                .BackgroundColor = Color.White
                .BorderStyle = Windows.Forms.BorderStyle.None
                .GridColor = Color.WhiteSmoke
                .Location = New Point(0, 120)
                .MinimumSize = New Size(0, 0)
                .MultiSelect = False
                .RowTemplate.Height = 26
                .RowTemplate.MinimumHeight = 26
                .Size = New Size(1050, 570)
            End With
        End Sub

        ''' <summary>
        ''' Initialises And Adds Data Columns Plus Formats Cells.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub InitControls()
            With Me.Columns
                .AddRange(New DataGridViewColumn() _
                          {dgcID,
                           dgcFirstName,
                           dgcLastName,
                           dgcAddress,
                           dgcPhone,
                           dgcEmail,
                           dgcClass,
                           dgcChristmasMark,
                           dgcSummerMark,
                           dgcOverallMark,
                           dgcGrade})
            End With

            ' Pad All Columns From ID to Class and Also The Grade Column, 
            ' 6 Points From The Left.
            For i As Integer = 0 To Me.Columns.Count - 5
                Me.Columns(i).DefaultCellStyle.Padding = New Padding(6, 0, 0, 0)
            Next
            Me.Columns(StudentDataNames.Grade).DefaultCellStyle.Padding = _
                                                                New Padding(6, 0, 0, 0)

            ' Center Align Overall, Christmas and Summer Marks
            Me.Columns(StudentDataNames.OverallTotal).DefaultCellStyle.Alignment = _
                                                DataGridViewContentAlignment.MiddleCenter

            Me.Columns(StudentDataNames.Christmas).DefaultCellStyle.Alignment = _
                                                DataGridViewContentAlignment.MiddleCenter

            Me.Columns(StudentDataNames.Summer).DefaultCellStyle.Alignment = _
                                                DataGridViewContentAlignment.MiddleCenter

            ' Format Overall Column To Display 2 Decimal Places.
            Me.Columns(StudentDataNames.OverallTotal).DefaultCellStyle.Format = "N2"

        End Sub

#End Region

    End Class

End Namespace
