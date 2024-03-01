
Imports System.Data.Entity

Imports System.Net


Namespace Controllers
    Public Class AspNetUserRolesController
        Inherits System.Web.Mvc.Controller

        Private db As New DatabaseContext

        ' GET: AspNetUserRoles
        Function Index() As ActionResult
            Dim aspNetUserRoles = db.AspNetUserRoles.Include(Function(a) a.AspNetRoles)
            Return View(aspNetUserRoles.ToList())
        End Function

        ' GET: AspNetUserRoles/Details/5
        Function Details(ByVal id As String) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim aspNetUserRoles As AspNetUserRoles = db.AspNetUserRoles.Find(id)
            If IsNothing(aspNetUserRoles) Then
                Return HttpNotFound()
            End If
            Return View(aspNetUserRoles)
        End Function

        ' GET: AspNetUserRoles/Create
        Function Create() As ActionResult
            ViewBag.RoleId = New SelectList(db.AspNetRoles, "Id", "Name")
            Return View()
        End Function

        ' POST: AspNetUserRoles/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="UserId,RoleId")> ByVal aspNetUserRoles As AspNetUserRoles) As ActionResult
            If ModelState.IsValid Then
                db.AspNetUserRoles.Add(aspNetUserRoles)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.RoleId = New SelectList(db.AspNetRoles, "Id", "Name", aspNetUserRoles.RoleId)
            Return View(aspNetUserRoles)
        End Function

        ' GET: AspNetUserRoles/Edit/5
        Function Edit(ByVal id As String) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim aspNetUserRoles As AspNetUserRoles = db.AspNetUserRoles.SingleOrDefault(Function(e) e.UserId = id)
            If IsNothing(aspNetUserRoles) Then
                Return HttpNotFound()
            End If
            ViewBag.RoleId = New SelectList(db.AspNetRoles, "Id", "Name", aspNetUserRoles.RoleId)
            ViewBag.Users = New SelectList(db.AspNetUsers, "Id", "UserName", aspNetUserRoles.UserId)
            Return View(aspNetUserRoles)
        End Function

        ' POST: AspNetUserRoles/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="UserId,RoleId")> ByVal aspNetUserRoles As AspNetUserRoles) As ActionResult

            If ModelState.IsValid Then
                db.Entry(aspNetUserRoles).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.RoleId = New SelectList(db.AspNetRoles, "Id", "Name", aspNetUserRoles.RoleId)
            Return View(aspNetUserRoles)
        End Function

        ' GET: AspNetUserRoles/Delete/5
        Function Delete(ByVal id As String, ByVal roleId As Integer) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim aspNetUserRoles As AspNetUserRoles = (From userRoles In db.AspNetUserRoles Where userRoles.UserId = id And userRoles.RoleId = roleId).SingleOrDefault()
            If IsNothing(aspNetUserRoles) Then
                Return HttpNotFound()
            End If
            Return View(aspNetUserRoles)
        End Function

        ' POST: AspNetUserRoles/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As String, ByVal roleId As Integer) As ActionResult
            Dim aspNetUserRoles As AspNetUserRoles = (From userRoles In db.AspNetUserRoles Where userRoles.UserId = id And userRoles.RoleId = roleId).SingleOrDefault()
            db.AspNetUserRoles.Remove(aspNetUserRoles)
            db.SaveChanges()
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
