Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("CartView")>
Partial Public Class CartView
    <Key> <Column(Order:=0)>
    Public Property product_id As Integer

    <Key> <Column(Order:=1)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property cart_id As Integer

    Public Property quantity As Integer
End Class
