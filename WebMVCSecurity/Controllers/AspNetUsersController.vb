Imports System.Data.Entity
Imports System.Net
Imports Microsoft.AspNet.Identity

Namespace Controllers
    Public Class AspNetUsersController
        Inherits System.Web.Mvc.Controller

        Private db As New DatabaseContext

        ' GET: AspNetUsers
        Function Index() As ActionResult
            Return View(db.AspNetUsers.ToList())
        End Function

        ' GET: AspNetUsers/Details/5
        Function Details(ByVal id As String) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim aspNetUsers As AspNetUsers = db.AspNetUsers.Find(id)
            If IsNothing(aspNetUsers) Then
                Return HttpNotFound()
            End If
            Return View(aspNetUsers)
        End Function

        ' GET: AspNetUsers/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: AspNetUsers/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")> ByVal aspNetUsers As AspNetUsers) As ActionResult
            If ModelState.IsValid Then
                db.AspNetUsers.Add(aspNetUsers)
                db.SaveChanges()
                StoreActionEvent("Create userId: " + aspNetUsers.Id)
                Return RedirectToAction("Index")
            End If
            StoreActionEvent("create userId: " + aspNetUsers.Id)
            Return View(aspNetUsers)
        End Function

        ' GET: AspNetUsers/Edit/5
        Function Edit(ByVal id As String) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim aspNetUsers As AspNetUsers = db.AspNetUsers.Find(id)
            If IsNothing(aspNetUsers) Then
                Return HttpNotFound()
            End If
            Return View(aspNetUsers)
        End Function

        ' POST: AspNetUsers/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")> ByVal aspNetUsers As AspNetUsers) As ActionResult
            If ModelState.IsValid Then
                db.Entry(aspNetUsers).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            StoreActionEvent("Edit userId: " + aspNetUsers.Id)
            Return View(aspNetUsers)
        End Function

        ' GET: AspNetUsers/Delete/5
        Function Delete(ByVal id As String) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim aspNetUsers As AspNetUsers = db.AspNetUsers.Find(id)
            If IsNothing(aspNetUsers) Then
                Return HttpNotFound()
            End If
            Return View(aspNetUsers)
        End Function

        ' POST: AspNetUsers/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As String) As ActionResult
            Dim aspNetUsers As AspNetUsers = db.AspNetUsers.Find(id)
            db.AspNetUsers.Remove(aspNetUsers)
            db.SaveChanges()
            StoreActionEvent("Delete userId: " + id)
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
        Sub StoreActionEvent(actionEvent As String)
            Dim userId = User.Identity.GetUserId()
            Dim userLog As user_log_action
            userLog = New user_log_action With {
                    .user_id = userId,
                    .action_name = actionEvent,
                    .action_time = DateTime.Now
                }
            db.UserLogAction.Add(userLog)
            db.SaveChanges()
        End Sub
    End Class
End Namespace
