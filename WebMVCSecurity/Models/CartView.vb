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

    <Range(1, 1000)>
    <Required>
    Public Property quantity As Integer

    Public Overridable Property Product As product
End Class
