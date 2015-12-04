Imports DAL
Imports UserControls

Namespace Views

    Public Class frmStudent
        Inherits System.Windows.Forms.Form

#Region "Comments"

        ' Main Form For Viewing And Updating Student Records.

        ' This Form Simply Creates And Adds Four Controls, A Header, ToolStrip, DataGrid And A Totals Panel.

        ' No Processing Of Student Information Occurs In This Class.

        ' There Is Only One Class Method That Checks If There Any Changes That Need Saving Before Exiting The Application.

#End Region

#Region "UI Objects"

        ''' <summary>
        ''' Header Displaying Ofiaich Name And Crest.
        ''' </summary>
        ''' <remarks></remarks>
        Private studentHeader As ucStudentHeader

        ''' <summary>
        ''' Toolstrip That Contains The Update and Search Controls.
        ''' </summary>
        ''' <remarks></remarks>
        Private studentToolbar As ucStudentToolbar

        ''' <summary>
        ''' DataGridView Used To Display Student Records.
        ''' </summary>
        ''' <remarks></remarks>
        Private studentDataGrid As ucStudentDataGrid

        ''' <summary>
        ''' Panel Used To Display Totals And Averages.
        ''' </summary>
        ''' <remarks></remarks>
        Private studentTotals As ucStudentTotals

#End Region

#Region "Data Objects"

        Private _studentDataSet As dsStudent
        ''' <summary>
        ''' Gets A StudentDataSet Object.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property studentDataSet() As dsStudent
            Get
                If _studentDataSet Is Nothing Then
                    _studentDataSet = New dsStudent
                End If
                Return _studentDataSet
            End Get
        End Property

        Private _studentBindingSource As BindingSource
        ''' <summary>
        ''' Gets A New Binding Source For Binding The Student DataSet To The DataGrid.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property studentBindingSource() As BindingSource
            Get
                If _studentBindingSource Is Nothing Then
                    ' Pass The Arguements For The DataSource and DataMemeber Objects.
                    _studentBindingSource = New BindingSource(Me.studentDataSet, _
                                                              StudentDataNames.TableName)
                End If
                Return _studentBindingSource
            End Get
        End Property

        Private _studentDataAdapter As adprStudent
        ''' <summary>
        ''' Gets A Data Adapter Object For Retrieving and Updating Student Records.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property studentDataAdapter() As adprStudent
            Get
                If _studentDataAdapter Is Nothing Then
                    _studentDataAdapter = New adprStudent(Me.studentDataSet.StudentTable)
                End If

                Return _studentDataAdapter
            End Get
        End Property

#End Region

#Region "Constructor & Initialisers"

        ''' <summary>
        ''' Constructor For The 'Main' Student Form.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            MyBase.New()
            With Me
                .SuspendLayout()
                .Init()
                .InitControls()
                .ResumeLayout()
            End With
        End Sub

        ''' <summary>
        ''' Initialises This Component.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Init()
            With Me
                .ClientSize = New Size(1300, 690)
                .Icon = CType(My.Resources.graduated, Icon)
                .Name = "frmStudent"
                .Text = "Ofiaich Students"
                .StartPosition = FormStartPosition.CenterScreen
            End With
        End Sub

        ''' <summary>
        ''' Initialises Child Controls And Adds Them To The UI.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub InitControls()
            ' Initialise UI and Data Objects.
            studentHeader = New ucStudentHeader

            studentDataGrid = New ucStudentDataGrid(Me.studentBindingSource)

            studentTotals = New ucStudentTotals(Me.studentDataSet.StudentTable)

            _studentDataAdapter = New adprStudent(Me.studentDataSet.StudentTable)

            studentToolbar = New ucStudentToolbar(Me.studentDataSet, _
                                                  Me.studentBindingSource, _
                                                  _studentDataAdapter, _
                                                  Me.studentDataGrid)
            ' And Add Them To The Form.
            Me.Controls.AddRange(New Control() {studentTotals,
                                     studentDataGrid,
                                     New tplDivider(DividerType.HorizontalPanelDivider),
                                     studentToolbar,
                                     New tplDivider(DividerType.HorizontalPanelDivider),
                                     studentHeader})
        End Sub

#End Region

#Region "Event Handlers"

        ''' <summary>
        ''' Checks If There Any Changes That Need Saving Before Exiting The Application.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub ClosingForm(sender As Object, _
                                           e As FormClosingEventArgs) _
                                           Handles Me.FormClosing

            If Not studentToolbar.ChangesCommitted Then
                e.Cancel = True
            End If

        End Sub

#End Region

    End Class

End Namespace
