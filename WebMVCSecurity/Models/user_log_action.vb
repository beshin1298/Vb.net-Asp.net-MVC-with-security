Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Partial Public Class user_log_action
    <Key>
    Public Property id As Integer

    <Required>
    <StringLength(128)>
    Public Property user_id As String

    <Column(TypeName:="text")>
    <Required>
    Public Property action_name As String

    <Column(TypeName:="date")>
    Public Property action_time As Date
End Class
