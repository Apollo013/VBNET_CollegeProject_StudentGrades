Namespace UserControls

    ''' <summary>
    ''' Options For The Type Of Divider To Create.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum DividerType
        HorizontalPanelDivider = 0
        VerticalButtonDivider = 1
    End Enum

    Public Class tplDivider
        Inherits GroupBox

#Region "Comments"

        ' Divider That Is Used To Seperate Panel Controls In The 'frmStudent' Class.
        ' The Divider Itself Is Just A GroupBox.

        ' The Constructor Takes An Arguement Of Type 'DividerType' Which Determines
        ' Whether To Create A Vertical or Horizontal Divider.

        ' Cosmetic Only.

#End Region

#Region "Constructor"

        ''' <summary>
        ''' 'tplDivider' Class Constructor.
        ''' </summary>
        ''' <param name="_DividerType"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal _DividerType As DividerType)

            With Me
                .MinimumSize = New Size(0, 0)
            End With

            If _DividerType = DividerType.HorizontalPanelDivider Then
                Me.Create_HorizontalPanelDivider()
            ElseIf _DividerType = DividerType.VerticalButtonDivider Then
                Me.Create_VerticalButtonDivider()
            End If

        End Sub

#End Region

#Region "Create Methods"

        ''' <summary>
        ''' Creates A Divider That Stretches Across The Form Horizontally.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Create_HorizontalPanelDivider()
            With Me
                .Size = New Size(1400, 2)
                .Dock = DockStyle.Top
            End With
        End Sub

        ''' <summary>
        ''' Creates A Vertical Divider That Sperates Button Controls.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Create_VerticalButtonDivider()
            With Me
                .Size = New Size(2, 24)
            End With
        End Sub

#End Region

    End Class

End Namespace
