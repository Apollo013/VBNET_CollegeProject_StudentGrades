Namespace UserControls

    Public Class tplButton
        Inherits Button

#Region "Comments"

        ' All Buttons Derived From This Class Will Inherit The Property Values Specified In The Constructor.
        ' A Tooltip Can Also Be Created For The Button Simply By Assigning A Value To The 'ToolTip' Property.

        ' This Should Be Considered As A Sort Of CSS File.

#End Region

#Region "Properties"

        Private _ToolTip As String
        ''' <summary>
        ''' Sets or Gets The Button Tooltip.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ToolTip() As String
            Get
                Return _ToolTip
            End Get
            Set(ByVal value As String)
                _ToolTip = value
                ' Create A New Tooltip For The Control.
                Dim toolTip As New ToolTip
                With toolTip
                    .IsBalloon = True
                    .SetToolTip(Me, _ToolTip)
                End With
            End Set
        End Property

#End Region

#Region "Contructor"

        ''' <summary>
        ''' 'tplButton' Class Constructor.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()

            With Me
                .Cursor = Cursors.Hand
                .FlatStyle = Windows.Forms.FlatStyle.Flat
                .FlatAppearance.BorderSize = 0
                .FlatAppearance.MouseOverBackColor = Color.Transparent
                .Margin = New Padding(4, 0, 4, 0)
                .MinimumSize = New Size(40, 33)
                .Size = New Size(42, 33)
                .TabStop = True
                .TextImageRelation = Windows.Forms.TextImageRelation.ImageBeforeText
            End With

        End Sub

#End Region

    End Class

End Namespace
