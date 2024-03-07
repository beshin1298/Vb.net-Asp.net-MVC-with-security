Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports WebMVCSecurity

Namespace Controllers
    Public Class ComputerDevicesController
        Inherits System.Web.Mvc.Controller

        Private db As New DatabaseContext

        ' GET: ComputerDevices
        Function Index() As ActionResult
            Dim listDevices As List(Of ComputerDevice) = (From c In db.ComputerDevice Where c.include_deleted = False Order By c.sort).ToList()
            Return View(listDevices)
        End Function

        ' GET: ComputerDevices/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim computerDevice As ComputerDevice = db.ComputerDevice.Find(id)
            If IsNothing(computerDevice) Then
                Return HttpNotFound()
            End If
            Return View(computerDevice)
        End Function

        ' GET: ComputerDevices/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: ComputerDevices/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="id,name,quantity,import_date,include_deleted,sort")> ByVal computerDevice As ComputerDevice) As ActionResult
            If ModelState.IsValid Then
                db.ComputerDevice.Add(computerDevice)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(computerDevice)
        End Function

        ' GET: ComputerDevices/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim computerDevice As ComputerDevice = db.ComputerDevice.Find(id)
            If IsNothing(computerDevice) Then
                Return HttpNotFound()
            End If
            Return View(computerDevice)
        End Function

        ' POST: ComputerDevices/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="id,name,quantity,import_date,include_deleted,sort")> ByVal computerDevice As ComputerDevice) As ActionResult
            If ModelState.IsValid Then
                db.Entry(computerDevice).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(computerDevice)
        End Function

        ' GET: ComputerDevices/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim computerDevice As ComputerDevice = db.ComputerDevice.Find(id)
            If IsNothing(computerDevice) Then
                Return HttpNotFound()
            End If
            Return View(computerDevice)
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
        <ActionName("Action")>
        Function SaveData(ByVal computerDevices As List(Of ComputerDevice)) As ActionResult
            If Request.Form("action").Equals("increase") Then
                Dim device As ComputerDevice = New ComputerDevice With {.id = Nothing, .import_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}
                computerDevices.Add(device)
                Return View("Index", computerDevices)
            End If
        End Function

        <HttpPost()>
        <ActionName("Search")>
        Function Search(ByVal searchString As String, ByVal includeDeleted As Boolean)
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
            Return View("Index", listDevices)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
