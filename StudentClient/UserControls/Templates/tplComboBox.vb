Namespace UserControls

    Public Class tplComboBox
        Inherits ComboBox

#Region "Comments"

        ' All Combobox's Derived From This Class Will Inherit The Property Values Specified In The Constructor.

        ' This Should Be Considered As A Sort Of CSS File.

#End Region

#Region "Constructor"

        Public Sub New()
            Me.Size = New Size(180, 24)
            Me.Margin = New Padding(10, 7, 0, 0)
            Me.DropDownStyle = ComboBoxStyle.DropDownList
        End Sub

#End Region

    End Class

End Namespace
