Imports System.ComponentModel.DataAnnotations

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
