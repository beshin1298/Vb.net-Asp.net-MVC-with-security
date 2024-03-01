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
        Function Create(ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add insert logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Category/Edit/5
        Function Edit(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Category/Edit/5
        <HttpPost()>
        Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Category/Delete/5
        Function Delete(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Category/Delete/5
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