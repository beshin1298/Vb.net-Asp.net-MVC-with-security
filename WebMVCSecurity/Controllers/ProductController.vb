Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports WebMVCSecurity

Namespace Models
    Public Class ProductController
        Inherits System.Web.Mvc.Controller

        Private db As New DatabaseContext

        ' GET: Product
        Function Index() As ActionResult
            Dim product = db.product.Include(Function(p) p.category)
            Return View(product.ToList())
        End Function

        ' GET: Product/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim product As product = db.product.Find(id)
            If IsNothing(product) Then
                Return HttpNotFound()
            End If
            Return View(product)
        End Function

        ' GET: Product/Create
        Function Create() As ActionResult
            ViewBag.category_id = New SelectList(db.category, "category_id", "name")
            Return View()
        End Function

        ' POST: Product/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="product_id,name,quantity,category_id,image")> ByVal product As product) As ActionResult
            If ModelState.IsValid Then
                db.product.Add(product)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.category_id = New SelectList(db.category, "category_id", "name", product.category_id)
            Return View(product)
        End Function

        ' GET: Product/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim product As product = db.product.Find(id)
            If IsNothing(product) Then
                Return HttpNotFound()
            End If
            ViewBag.category_id = New SelectList(db.category, "category_id", "name", product.category_id)
            Return View(product)
        End Function

        ' POST: Product/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="product_id,name,quantity,category_id,image")> ByVal product As product) As ActionResult
            If ModelState.IsValid Then
                db.Entry(product).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.category_id = New SelectList(db.category, "category_id", "name", product.category_id)
            Return View(product)
        End Function

        ' GET: Product/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim product As product = db.product.Find(id)
            If IsNothing(product) Then
                Return HttpNotFound()
            End If
            Return View(product)
        End Function

        ' POST: Product/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim product As product = db.product.Find(id)
            db.product.Remove(product)
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
