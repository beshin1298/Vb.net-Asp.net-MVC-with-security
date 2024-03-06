Imports System.Data.Entity
Imports System.Net
Imports System.Web.Mvc


Namespace Controllers
    <Authorize(Roles:="Admin")>
    Public Class CategoryController
        Inherits Controller

        ' GET: Category
        Private db As DatabaseContext = New DatabaseContext()
        Function Index() As ActionResult
            Dim listCategory As List(Of category) = db.category.ToList()
            Return View(listCategory)
        End Function

        ' GET: Category/Details/5
        Function Details(ByVal id As Integer) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim category As category = db.category.Find(id)
            If IsNothing(category) Then
                Return HttpNotFound()
            End If
            Return View(category)

        End Function

        ' GET: Category/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Category/Create
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="category_id,name")> ByVal category As category) As ActionResult
            If ModelState.IsValid Then
                db.category.Add(category)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(category)
        End Function

        ' GET: Category/Edit/5
        Function Edit(ByVal id As Integer) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim category As category = db.category.Find(id)
            If IsNothing(category) Then
                Return HttpNotFound()
            End If
            Return View(category)
        End Function

        ' POST: Category/Edit/5
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="category_id,name")> ByVal category As category) As ActionResult
            If ModelState.IsValid Then
                db.Entry(category).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(category)
        End Function

        ' GET: Category/Delete/5
        Function Delete(ByVal id As Integer) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim category As category = db.category.Find(id)
            If IsNothing(category) Then
                Return HttpNotFound()
            End If
            Return View(category)
        End Function

        ' POST: Category/Delete/5
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Dim category As category = db.category.Find(id)

            Try
                db.category.Remove(category)
                db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As Exception
                TempData("ErrorMessage") = "Có lỗi xảy ra."
                Return View("Delete")
            Finally
                db.Dispose()
            End Try
        End Function
        <HttpPost()>
        <ActionName("Search")>
        <ValidateAntiForgeryToken()>
        Function Search(SearchString As String) As ActionResult
            Dim listCategories As List(Of category) = Nothing

            If Not String.IsNullOrEmpty(SearchString) Then
                listCategories = (From category In db.category Where category.name.ToLower().Contains(SearchString.ToLower())).ToList()
            Else
                listCategories = db.category.ToList()
            End If

            Return View("Index", listCategories)
        End Function
    End Class
End Namespace