Imports System.ComponentModel.DataAnnotations

Partial Public Class AspNetUsers
    Public Property Id As String

    <StringLength(256)>
    <Required>
    Public Property Email As String

    Public Property EmailConfirmed As Boolean

    Public Property PasswordHash As String

    Public Property SecurityStamp As String

    Public Property PhoneNumber As String

    Public Property PhoneNumberConfirmed As Boolean

    Public Property TwoFactorEnabled As Boolean

    Public Property LockoutEndDateUtc As Date?

    Public Property LockoutEnabled As Boolean

    Public Property AccessFailedCount As Integer

    <Required>
    <StringLength(256)>
    Public Property UserName As String
    Public Overridable Property AspNetUserRoles As ICollection(Of AspNetUserRoles)

End Class
