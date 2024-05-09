Imports System.ComponentModel.DataAnnotations

Partial Public Class AspNetUserClaims
    Public Property Id As Integer

    <Required>
    <StringLength(128)>
    Public Property UserId As String

    Public Property ClaimType As String

    Public Property ClaimValue As String
End Class
