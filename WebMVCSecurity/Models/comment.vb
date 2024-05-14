Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("comment")>
Partial Public Class comment
    Public Property id As Integer

    <Required>
    <StringLength(128)>
    Public Property userId As String

    <Column("comment")>
    <Required>
    Public Property commentString As String

    <Column("productId")>
    Public Property product_id As Integer
    Public Property dateComment As Date

    Public Overridable Property product As product
    Public Overridable Property user As AspNetUsers
End Class
