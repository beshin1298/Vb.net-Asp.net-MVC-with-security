Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class AspNetUserRoles
    <Key>
    <Column(Order:=0)>
    Public Property UserId As String

    <Key>
    <Column(Order:=1)>
    Public Property RoleId As String

    Public Overridable Property AspNetRoles As AspNetRoles
    Public Overridable Property User As AspNetUsers


End Class
