Namespace DAL

    Public NotInheritable Class StudentDataNames

#Region "Comments"

        ' This Is A Static Class That Simply Provides The Column Names Contained In The 'StudentRecord' Database Table.

        ' We Will Have To Refer To These Names In Our 'SELECT' Statements, Paramter and DataColumn Naming.

        ' The Whole Aim Of This Is To Reduce Errors And Placing These In One Location Means That They Only 
        ' Have To Be Changed In One Place If They Are Wrong.

        ' This Should Provide For Consistency, Reliability and Productivity.

#End Region

#Region "Properties"

        ''' <summary>
        ''' Gets The Name Of The Student Database Data Table.
        ''' </summary>
        ''' <value></value>
        ''' <returns>'StudentRecord'</returns>
        ''' <remarks></remarks>
        Public Shared ReadOnly Property TableName() As String
            Get
                Return "StudentRecord"
            End Get
        End Property

        ''' <summary>
        ''' Gets The Name Of The Student ID Column Name.
        ''' </summary>
        ''' <value></value>
        ''' <returns>'ID'</returns>
        ''' <remarks></remarks>
        Public Shared ReadOnly Property ID() As String
            Get
                Return "ID"
            End Get
        End Property

        ''' <summary>
        ''' Gets The Name Of The Student First Name Column Name.
        ''' </summary>
        ''' <value></value>
        ''' <returns>'First name'</returns>
        ''' <remarks></remarks>
        Public Shared ReadOnly Property FirstName() As String
            Get
                Return "First name"
            End Get
        End Property

        ''' <summary>
        ''' Gets The Name Of The Student Last Name Column Name.
        ''' </summary>
        ''' <value></value>
        ''' <returns>Last Name</returns>
        ''' <remarks></remarks>
        Public Shared ReadOnly Property LastName() As String
            Get
                Return "Last Name"
            End Get
        End Property

        ''' <summary>
        ''' Gets The Name Of The Student Phone Number Column Name.
        ''' </summary>
        ''' <value></value>
        ''' <returns>'phoneNumber'</returns>
        ''' <remarks></remarks>
        Public Shared ReadOnly Property PhoneNumber() As String
            Get
                Return "phoneNumber"
            End Get
        End Property

        ''' <summary>
        ''' Gets The Name Of The Student Address Column Name.
        ''' </summary>
        ''' <value></value>
        ''' <returns>'Address'</returns>
        ''' <remarks></remarks>
        Public Shared ReadOnly Property Address() As String
            Get
                Return "Address"
            End Get
        End Property

        ''' <summary>
        ''' Gets The Name Of The Student Email Column Name.
        ''' </summary>
        ''' <value></value>
        ''' <returns>'Email'</returns>
        ''' <remarks></remarks>
        Public Shared ReadOnly Property Email() As String
            Get
                Return "Email"
            End Get
        End Property

        ''' <summary>
        ''' Gets The Name Of The Student Christmas Column Name.
        ''' </summary>
        ''' <value></value>
        ''' <returns>'Christmas'</returns>
        ''' <remarks></remarks>
        Public Shared ReadOnly Property Christmas() As String
            Get
                Return "Christmas"
            End Get
        End Property

        ''' <summary>
        ''' Gets The Name Of The Student Summer Column Name.
        ''' </summary>
        ''' <value></value>
        ''' <returns>'Summer'</returns>
        ''' <remarks></remarks>
        Public Shared ReadOnly Property Summer() As String
            Get
                Return "Summer"
            End Get
        End Property

        ''' <summary>
        ''' Gets The Name Of The Student Class Column Name.
        ''' </summary>
        ''' <value></value>
        ''' <returns>'Class'</returns>
        ''' <remarks></remarks>
        Public Shared ReadOnly Property ClassName() As String
            Get
                Return "Class"
            End Get
        End Property

        ''' <summary>
        ''' This Is A Custom Column Not Part Of The StudentRecord Database Table.
        ''' </summary>
        ''' <value></value>
        ''' <returns>'OverallTotal'</returns>
        ''' <remarks></remarks>
        Public Shared ReadOnly Property OverallTotal() As String
            Get
                Return "OverallTotal"
            End Get
        End Property

        ''' <summary>
        ''' This Is A Custom Column Not Part Of The StudentRecord Database Table.
        ''' </summary>
        ''' <value></value>
        ''' <returns>'Grade'</returns>
        ''' <remarks></remarks>
        Public Shared ReadOnly Property Grade() As String
            Get
                Return "Grade"
            End Get
        End Property

#End Region

    End Class

End Namespace
