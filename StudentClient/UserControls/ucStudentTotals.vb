Imports DAL

Namespace UserControls

    Public Class ucStudentTotals
        Inherits FlowLayoutPanel

#Region "Comments"

        ' This Class Calculates And Displays The Totals And Averages Based On What Student Records Are Currently Being Viewed.

        ' The Constructor Takes, By Reference, A 'dtStudent' Student Data Table Object As An Arguement. 
        ' (As Does The 'adprStudent' Data Adpater Object).

        ' In The 'Constructor & Initialisers' Region, The Method 'InitControls' Is An Event Handler For The 
        ' Custom Event, 'TableChangedEvent' In The Student Data Table.

        ' This Event Is Raised By The Student Data Adapter, 'adprStudent', Whenever The Student Table Has Changed.
        ' This Occurs Whenever Changes Are Saved Or The Table Is Re-Populated.

        ' This Event Takes A Single Argument Of Type 'SearchOptions', Which Is An Enum Located In The 'Helpers' Folder.
        ' This Decides What Averages To Recalculate and Display.

        ' There Are Three Different Calculation Groups Depending On How The Information Has Being Filtered.
        ' (1) Display Overall, Grade & Class, Totals & Averages.
        ' (2) Display Overall & Grade, Totals & Averages.
        ' (3) Display Overall & Class, Totals & Averages.

        ' (Overall) Calculates The Overall Averages For Christmas, Summer and Overall Marks. 
        '           This Is Always Calculated.

        ' (Grade)   Calculates, As A Percentage Of 100, How Many Students Failed, Passed, Earned Merits Or Distinctions.
        '           This Is Not Calculated If We Are Filtering Student Records By A Specific Grade.
        '           This Is Because Only One Calculation Will Be Made And It Will Always Be 100%.

        ' (Class)   Calculates The Average Overall Mark For Each Class.
        '           This Is Not Calculated If We Are Filtering Student Records By A Specific Class.
        '           This Is Because Only One Calculation Will Be Made And It Will Always Be 100%.

        ' LINQ Queries Are Used To Perform The Calculations.

#End Region

#Region "UI Objects"

        Private _Spacer As Label
        ''' <summary>
        ''' Gets A Blank Label To Act As A Spacer Between The Diferent Average Headers.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Spacer() As Label
            Get
                _Spacer = New Label

                With _Spacer
                    .MinimumSize = New Size(0, 0)
                    .Size = New Size(150, 15)
                    .Text = ""
                End With

                Return _Spacer
            End Get
        End Property

        Private _GroupHeader As TextBox
        ''' <summary>
        ''' Gets A TextBox With Text That Describes The Type Of Averages Being Displayed.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property GroupHeader() As TextBox
            Get
                _GroupHeader = New TextBox

                With _GroupHeader
                    .Font = New Font("Arial", 8.25!, _
                                     System.Drawing.FontStyle.Bold, _
                                     System.Drawing.GraphicsUnit.Point, _
                                     CType(0, Byte))
                    .MinimumSize = New Size(0, 0)
                    .ReadOnly = True
                    .Size = New Size(206, 26)
                    .TabStop = False
                    .Visible = True
                End With

                Return _GroupHeader
            End Get
        End Property

        Private _DetailHeader As TextBox
        ''' <summary>
        ''' Gets A TextBox With Text That Desribes The Value Being Displayed.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DetailHeader() As TextBox
            Get
                _DetailHeader = New TextBox

                With _DetailHeader
                    .BackColor = Color.White
                    .MinimumSize = New Size(0, 0)
                    .ReadOnly = True
                    .Size = New Size(130, 26)
                    .TabStop = False
                End With

                Return _DetailHeader
            End Get
        End Property

        Private _DetailValue As TextBox
        ''' <summary>
        ''' Gets A TextBox Used For Displaying A Total or Average Calculation.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DetailValue() As TextBox
            Get
                _DetailValue = New TextBox

                With _DetailValue
                    .MinimumSize = New Size(0, 0)
                    .Size = New Size(70, 26)
                    .TabStop = False
                    .ReadOnly = True
                    .BackColor = Color.White
                End With

                Return _DetailValue
            End Get
        End Property

#End Region

#Region "Declarations"

        ''' <summary>
        ''' Reference To The Student Data Table.
        ''' </summary>
        ''' <remarks></remarks>
        Private WithEvents _studentDataTable As dtStudent

        ''' <summary>
        ''' Gets The Numbers Of Rows In The Student Data Table.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Count() As Integer
            Get
                Return _studentDataTable.Rows.Count
            End Get
        End Property

#End Region

#Region "Constructor & Initialisers"

        ''' <summary>
        ''' 'ucStudentTotals' Class Constructor.
        ''' </summary>
        ''' <param name="dataTable"></param>
        ''' <remarks></remarks>
        Public Sub New(ByRef dataTable As dtStudent)
            With Me
                ._studentDataTable = dataTable
                .Init()
                .InitControls(SearchOptions.SearchByName)
            End With
        End Sub

        ''' <summary>
        ''' Initialises This Component.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Init()
            With Me
                .Dock = DockStyle.Right
                .MinimumSize = New Size(0, 0)
                .Size = New Size(232, 570)
                .VScroll = True
            End With
        End Sub

        ''' <summary>
        ''' Calls The Appropriate Calculation Methods.
        ''' </summary>
        ''' <param name="SearchOption">Determines What Totals And Averages Are To Be Displayed.</param>
        ''' <remarks>This Is The Event Handler For The 'TableChangedEvent' In The Student Data Table.</remarks>
        Public Sub InitControls(ByVal SearchOption As SearchOptions) _
                             Handles _studentDataTable.TableChangedEvent

            ' Clear All Current Child Controls.
            Me.Controls.Clear()

            If Me.Count > 0 Then
                If SearchOption = SearchOptions.SearchByName Or _
                    SearchOption = SearchOptions.SearchByAddress Then
                    ' Display Overall, Grade & Class, Totals & Averages.
                    Me.CalculateOverAll()
                    Me.CalculateGrades()
                    Me.CalculateClasses()
                ElseIf SearchOption = SearchOptions.SearchByClass Then
                    ' Display Overall & Grade, Totals & Averages.
                    Me.CalculateOverAll()
                    Me.CalculateGrades()
                ElseIf SearchOption = SearchOptions.SearchByGrade Then
                    ' Display Overall & Class, Totals & Averages.
                    Me.CalculateOverAll()
                    Me.CalculateClasses()
                End If
            End If

        End Sub

#End Region

#Region "Calculations"

        ''' <summary>
        ''' Calculates Overall Totals and Averages.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CalculateOverAll()

            ' LINQ Query That Grabs Christmas, Summer And Overall Marks.
            Dim qry = From row In _studentDataTable
                      Select OverAll = (CDbl(row.Item(StudentDataNames.OverallTotal))), _
                      Xmas = CDbl(row.Item(StudentDataNames.Christmas)), _
                      Summer = CDbl(row.Item(StudentDataNames.Summer))

            ' Output Header.
            Me.AddHeader("Overall")

            ' Output Details .
            Me.AddDetail("Students", Me.Count)
            Me.AddDetail("Overall Average", _
                         Aggregate oa In qry Select oa.OverAll Into Average())
            Me.AddDetail("Christmas Average", _
                         Aggregate xa In qry Select xa.Xmas Into Average())
            Me.AddDetail("Summer Average", _
                         Aggregate sa In qry Select sa.Summer Into Average())

        End Sub

        ''' <summary>
        ''' Calculates Grade Percentages.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CalculateGrades()

            ' Output Header.
            Me.AddHeader("Student Grades")

            ' Grab DISTINCT Grade Names From The Data Table.
            ' We Make Use Of The 'Grades.ToArray' Function To Order The Output.
            ' (Grades Is A Static Class In The 'Helpers' Folder.)
            Dim qry = (From grade As String In Grades.ToArray
                       Join student In _studentDataTable
                       On grade.ToString Equals student.Item(StudentDataNames.Grade)
                       Select g = student.Item(StudentDataNames.Grade)).Distinct

            ' Output How Many Students Fall Under Each Grade And Output The Value.
            For Each grd As String In qry
                Me.AddDetail(Grades.ToPlural(grd.ToString), GradePercentage(grd.ToString))
            Next

        End Sub

        ''' <summary>
        ''' Calculates How Many Students Fall Under A Particular Grade.
        ''' </summary>
        ''' <param name="gradename"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GradePercentage(ByVal gradename As String) As Double

            ' A) Get All Records That Meet A Certain Grade.
            ' B) Count Them.
            ' C) Divide The Count By The Total Number Of Records.
            ' D) Multiply By 100 (Why ?, When Formatting As A Percentage, 
            '    VB Divides A Numeric Value By 100 ?)

            Return ((From student In _studentDataTable
                     Where student.Item(StudentDataNames.Grade) = gradename
                     Select student).Count / Me.Count) * 100

        End Function

        ''' <summary>
        ''' Calculates Average Marks For Each Class.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CalculateClasses()

            ' LINQ Query That Implements ORDER BY, GROUP, AVERAGE
            ' To Get Overall, Christmas & Summer Averages For Each Class.
            Dim qry = From student In _studentDataTable
                      Order By student.Item(StudentDataNames.ClassName)
                      Group student By ClassName = _
                            student.Item(StudentDataNames.ClassName) _
                      Into OverallAverage = _
                            Average(CDbl(student.Item(StudentDataNames.OverallTotal)))
                      Select ClassName, OverallAverage

            ' Add A Header.
            Me.AddHeader("Average Class Mark")

            ' Now Output Each Group In The Query.
            ' Convert Class Name To Upper Case.
            For Each group In qry
                Me.AddDetail(group.ClassName.ToString.ToUpper, group.OverallAverage)
            Next

        End Sub

#End Region

#Region "Output"

        ''' <summary>
        ''' Adds A TextBox Header Describing The Group Of Totals and Averages Being Displayed.
        ''' </summary>
        ''' <param name="parmHeaderText">A String Value Describing The Group Of Totals and Averages Being Displayed.</param>
        ''' <remarks></remarks>
        Private Sub AddHeader(ByVal parmHeaderText As String)
            ' Assign The Text That Describes The Type Of Averages Being Displayed.
            Me.GroupHeader.Text = parmHeaderText

            ' Display The Controls.
            Me.Controls.AddRange(New Control() {Me.Spacer, _GroupHeader})
        End Sub

        ''' <summary>
        ''' Adds A Detail That Displays Values As A Percentage.
        ''' </summary>
        ''' <param name="parmDetailName">A String Value That Desribes The Percentage Value Being Displayed.</param>
        ''' <param name="parmDetailValue">A Double Value Containing The Percentage Value To Display.</param>
        ''' <remarks></remarks>
        Private Sub AddDetail(ByVal parmDetailName As String,
                              ByVal parmDetailValue As Double)

            ' Assign The Text To Be Displayed.
            Me.DetailHeader.Text = parmDetailName
            Me.DetailValue.Text = String.Format("{0,8:P2}", parmDetailValue / 100)

            ' Display The Controls.
            Me.Controls.AddRange(New Control() {_DetailHeader, _DetailValue})

        End Sub

        ''' <summary>
        ''' Adds A Detail That Displays Values As A Number.
        ''' </summary>
        ''' <param name="parmDetailName">A String Value That Desribes The Percentage Value Being Displayed.</param>
        ''' <param name="parmDetailValue">An Integer Value Containing The 'Total' Value To Display.</param>
        ''' <remarks></remarks>
        Private Sub AddDetail(ByVal parmDetailName As String,
                              ByVal parmDetailValue As Integer)

            ' Assign The Text To Be Displayed.
            Me.DetailHeader.Text = parmDetailName
            Me.DetailValue.Text = parmDetailValue.ToString

            ' Display The Controls.
            Me.Controls.AddRange(New Control() {_DetailHeader, _DetailValue})

        End Sub

#End Region

    End Class

End Namespace
