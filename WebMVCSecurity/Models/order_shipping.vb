Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Partial Public Class order_shipping
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property id As Integer

    <Required>
    <StringLength(128)>
    Public Property user_id As String

    Public Property oders_id As Integer

    Public Property date_create As Date

    Public Property status As Integer

    Public Property shipper_id As Integer?

    <Column(TypeName:="text")>
    <Required>
    Public Property shipping_address As String

    Public Property date_received As Date

    <Column(TypeName:="text")>
    <Required>
    Public Property customer_name As String

End Class
