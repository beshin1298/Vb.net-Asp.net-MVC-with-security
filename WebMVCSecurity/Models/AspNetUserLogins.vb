Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class AspNetUserLogins
    <Key>
    <Column(Order:=0)>
    Public Property LoginProvider As String

    <Key>
    <Column(Order:=1)>
    Public Property ProviderKey As String

    <Key>
    <Column(Order:=2)>
    Public Property UserId As String
End Class
