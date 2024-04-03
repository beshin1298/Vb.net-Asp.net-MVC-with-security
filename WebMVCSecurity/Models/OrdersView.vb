Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("OrdersView")>
Partial Public Class OrdersView
    Public Property id As Integer

    Public Property product_id As Integer

    Public Property quantity As Integer

    <Required>
    <StringLength(128)>
    Public Property user_id As String

    Public Property date_create As Date?
End Class
