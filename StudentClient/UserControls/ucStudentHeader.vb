Namespace UserControls

    Public Class ucStudentHeader
        Inherits Panel

#Region "Comments"

        ' Upper Most Part Of The Students Form That Displays The Ofiaich Name & Crest.

#End Region

#Region "UI Objects"

        ''' <summary>
        ''' Gets A Picture Box With The Ofiaich Logo.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property OfiaichBanner() As PictureBox
            Get
                Return New PictureBox With _
                           {.Image = My.Resources.OfiaichBanner,
                            .Dock = DockStyle.Left,
                            .Margin = New Padding(5, 0, 0, 0),
                            .MinimumSize = New Size(0, 0),
                            .Size = New Size(800, 80),
                            .SizeMode = PictureBoxSizeMode.StretchImage}
            End Get
        End Property

        ''' <summary>
        ''' Gets A Picture Box With The Ofiaich Crest.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property OfiaichCrest() As PictureBox
            Get
                Return New PictureBox With _
                           {.Image = My.Resources.small_ofi_crest,
                            .Dock = DockStyle.Right}
            End Get
        End Property

#End Region

#Region "Constructor & Initialisers"

        ''' <summary>
        ''' Constructor
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            With Me
                .SuspendLayout()
                .Init()
                .InitControls()
                .ResumeLayout()
            End With
        End Sub

        ''' <summary>
        ''' Initialise This Component.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Init()
            With Me
                .Name = "HeaderSection"
                .Dock = DockStyle.Top
                .BackColor = Color.Black
                .MinimumSize = New Size(0, 0)
                .Size = New Size(0, 80)
            End With
        End Sub

        ''' <summary>
        ''' Initialises And Adds Child Controls To The UI.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub InitControls()
            With Me.Controls
                .AddRange(New Control() {Me.OfiaichBanner, Me.OfiaichCrest})
            End With
        End Sub

#End Region

    End Class

End Namespace
