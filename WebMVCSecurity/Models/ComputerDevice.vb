Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial


<Table("ComputerDevice")>
Partial Public Class ComputerDevice
    Public Property id As Integer?

    <Required>
    <StringLength(128)>
    <DisplayName("Device name")>
    Public Property name As String

    <Required>
    <DisplayName("Quantity")>
    Public Property quantity As Integer

    <Required>
    <DisplayName("Import Date")>
    Public Property import_date As Date

    <Required>
    <DisplayName("Deleted")>
    Public Property include_deleted As Boolean
    Public Property sort As Integer
End Class
