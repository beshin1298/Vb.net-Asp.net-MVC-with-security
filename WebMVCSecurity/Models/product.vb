
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema


<Table("product")>
Partial Public Class product
    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property product_id As Integer

    <Required>
    <StringLength(50)>
    Public Property name As String
    <Range(1, 1000)>
    <Required>
    Public Property quantity As Integer

    Public Property category_id As Integer

    Public Property image As String


    <Range(1, 1000)>
    <Required>
    Public Property price As Integer

    Public Overridable Property category As category

    Public Overridable Property CartView As ICollection(Of CartView)
    Public Overridable Property Comments As ICollection(Of comment)
    Public Overridable Property odersView As ICollection(Of OrdersView)
End Class
