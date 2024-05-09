Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("category")>
Partial Public Class category
    Public Sub New()
        product = New HashSet(Of product)()
    End Sub

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property category_id As Integer

    <Required>
    <StringLength(50)>
    Public Property name As String

    Public Overridable Property product As ICollection(Of product)
End Class
