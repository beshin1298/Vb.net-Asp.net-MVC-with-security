Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class AspNetRoles
    Public Sub New()
        AspNetUserRoles = New HashSet(Of AspNetUserRoles)()
    End Sub

    Public Property Id As String

    <Required>
    <StringLength(256)>
    Public Property Name As String

    Public Overridable Property AspNetUserRoles As ICollection(Of AspNetUserRoles)
End Class
