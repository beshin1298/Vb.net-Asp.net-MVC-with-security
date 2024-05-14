Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Partial Public Class news
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property id As Integer

    <Column(TypeName:="text")>
    <Required>
    Public Property title As String

    <Column(TypeName:="text")>
    <Required>
    <AllowHtml>
    Public Property text As String

    <Column("date", TypeName:="date")>
    Public Property releaseDate As Date

    <Column(TypeName:="text")>
    <Required>
    Public Property imageTitle As String
End Class
