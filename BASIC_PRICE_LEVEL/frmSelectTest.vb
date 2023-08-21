Public Class frmSelectTest

    Private Sub frmSelectTest_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmSelectTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Dim i As Integer = D.CurrentRow.Index
        With frmBasicPriceLvl
            Dim ii As Integer = .D.CurrentRow.Index
            .D("IMH_CODE", ii).Value = D("IMH_CODE", i).Value
            .D("IMH_DESC", ii).Value = D("IMH_DESC", i).Value
        End With
        Me.Dispose()
    End Sub

End Class