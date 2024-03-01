Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("product")>
Partial Public Class product
    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property product_id As Integer

    <Required>
    <StringLength(50)>
    Public Property name As String

    Public Property quantity As Integer

    Public Property category_id As Integer

    Public Property image As String

    Public Overridable Property category As category
End Class
