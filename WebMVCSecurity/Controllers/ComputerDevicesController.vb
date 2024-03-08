Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Globalization
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Microsoft.Ajax.Utilities
Imports WebMVCSecurity

Namespace Controllers
    <Authorize(Roles:="Admin")>
    Public Class ComputerDevicesController
        Inherits System.Web.Mvc.Controller

        Private db As New DatabaseContext

        ' GET: ComputerDevices
        Function Index() As ActionResult
            Dim searchString As String = Session("searchName")
            Dim includeDeleted As Boolean = Session("deletedSearch")
            Dim listDevices As List(Of ComputerDevice) = Nothing
            If includeDeleted = True Then
                If String.IsNullOrEmpty(searchString) Then
                    listDevices = db.ComputerDevice.ToList()
                ElseIf String.IsNullOrEmpty(searchString) = False Then
                    listDevices = (From c In db.ComputerDevice Where c.name.ToString().ToLower().Contains(searchString.ToLower())).ToList()
                End If
            ElseIf includeDeleted = False Then
                If String.IsNullOrEmpty(searchString) Then
                    listDevices = (From c In db.ComputerDevice Where c.include_deleted = False).ToList()
                ElseIf String.IsNullOrEmpty(searchString) = False Then
                    listDevices = (From c In db.ComputerDevice Where c.include_deleted = False And c.name.ToString().ToLower().Contains(searchString.ToLower())).ToList()

                End If

            End If

            Return View(listDevices)
        End Function


        ' GET: ComputerDevices/Create
        Function Create() As ActionResult
            Return View()
        End Function


        ' POST: ComputerDevices/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim computerDevice As ComputerDevice = db.ComputerDevice.Find(id)
            db.ComputerDevice.Remove(computerDevice)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        <HttpPost()>
        <ActionName("Save")>
        Function SaveData(ByVal computerDevices As List(Of ComputerDevice)) As ActionResult
            Dim maxSort As Integer = getMaxSort()

            computerDevices.ToList().ForEach(Function(item)
                                                 If item.id IsNot Nothing Then
                                                     Dim res As ComputerDevice = db.ComputerDevice.Find(item.id)
                                                     If res IsNot Nothing Then
                                                         res.name = item.name
                                                         res.quantity = item.quantity
                                                         res.import_date = item.import_date
                                                         res.sort = item.sort
                                                         res.include_deleted = item.include_deleted
                                                         db.Entry(res).State = EntityState.Modified
                                                     Else
                                                         Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                                                     End If
                                                 Else
                                                     maxSort += 1
                                                     item.sort = maxSort
                                                     db.ComputerDevice.Add(item) ' Use Add method
                                                 End If
                                             End Function)

            db.SaveChanges() ' Save changes after processing all items
            Return View("Index", computerDevices)
        End Function

        Function getMaxSort()
            Dim max As Integer = db.ComputerDevice.ToList().Max(Function(item) item.sort)
            Return max
        End Function

        <HttpPost()>
        <ActionName("Add-Column")>
        Function AddColumn(ByVal computerDevices As List(Of ComputerDevice)) As ActionResult
            Return View("Index", computerDevices)

        End Function
        <HttpPost()>
        <ActionName("Search")>
        Function Search(ByVal searchString As String, ByVal includeDeleted As Boolean)
            Session("searchName") = searchString
            Session("deletedSearch") = includeDeleted
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
