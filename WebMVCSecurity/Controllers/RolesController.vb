Imports System.Net
Imports System.Web.Mvc

Namespace Controllers
    <Authorize(Roles:="Admin")>
    Public Class RolesController
        Inherits Controller

        ' GET: Roles
        Private db As DatabaseContext = New DatabaseContext()
        Function Index() As ActionResult
            Dim listRoles As List(Of AspNetRoles) = db.AspNetRoles.ToList()
            Return View(listRoles)
        End Function

        ' GET: Roles/Details/5
        Function Details(ByVal id As Integer) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim role As AspNetRoles = db.AspNetRoles.Find(id)
            If IsNothing(role) Then
                Return HttpNotFound()
            End If
            Return View(role)

        End Function

        ' GET: Roles/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Roles/Create
        <HttpPost()>
        Function Create(ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add insert logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Roles/Edit/5
        Function Edit(ByVal id As String) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim role As AspNetRoles = db.AspNetRoles.SingleOrDefault(Function(e) e.Id = id)
            If IsNothing(role) Then
                Return HttpNotFound()
            End If
            Return View(role)
        End Function

        ' POST: Roles/Edit/5
        <HttpPost()>
        Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Roles/Delete/5
        Function Delete(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Roles/Delete/5
        <HttpPost()>
        Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add delete logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace