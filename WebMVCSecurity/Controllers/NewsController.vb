Imports System.Data.Entity
Imports System.Net
Imports Microsoft.AspNet.Identity

Namespace Controllers
    Public Class NewsController
        Inherits System.Web.Mvc.Controller

        Private db As New DatabaseContext

        ' GET: News
        Function Index() As ActionResult
            Return View(db.News.ToList())
        End Function

        ' GET: News/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim news As news = db.News.Find(id)
            If IsNothing(news) Then
                Return HttpNotFound()
            End If
            Return View(news)
        End Function

        ' GET: News/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: News/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="id,title,text,imageTitle")> ByVal news As news) As ActionResult
            If ModelState.IsValid Then
                news.releaseDate = DateTime.Now
                db.News.Add(news)
                db.SaveChanges()
                StoreActionEvent("create news : " + news.title)
                Return RedirectToAction("Index")
            End If
            Return View(news)
        End Function

        ' GET: News/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim news As news = db.News.Find(id)
            If IsNothing(news) Then
                Return HttpNotFound()
            End If
            Return View(news)
        End Function

        ' POST: News/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="id,title,text,imageTitle")> ByVal news As news) As ActionResult
            If ModelState.IsValid Then
                db.Entry(news).State = EntityState.Modified
                db.SaveChanges()
                StoreActionEvent("Edit news id: " + news.id)
                Return RedirectToAction("Index")
            End If
            Return View(news)
        End Function

        ' GET: News/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim news As news = db.News.Find(id)
            If IsNothing(news) Then
                Return HttpNotFound()
            End If
            Return View(news)
        End Function

        ' POST: News/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim news As news = db.News.Find(id)
            db.News.Remove(news)
            db.SaveChanges()
            StoreActionEvent("Delete news id: " + id)
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
