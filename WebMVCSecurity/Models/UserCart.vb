Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("UserCart")>
Partial Public Class UserCart
    <Key>
    <Column(Order:=0)>
    Public Property cart_id As Integer

    <Key>
    <Column(Order:=1)>
    Public Property user_id As String
End Class
