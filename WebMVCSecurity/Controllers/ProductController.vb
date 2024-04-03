Imports System.Data.Entity
Imports System.Net
Imports Microsoft.AspNet.Identity

Namespace Models

    Public Class ProductController
        Inherits System.Web.Mvc.Controller

        Private db As New DatabaseContext

        ' GET: Product
        <Authorize(Roles:="Admin")>
        Function Index() As ActionResult
            Dim product = db.product.Include(Function(p) p.category)
            Return View(product.ToList())
        End Function

        ' GET: Product/Details/5
        <AllowAnonymous>
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
        <Authorize(Roles:="Admin")>
        Function Create() As ActionResult
            ViewBag.category_id = New SelectList(db.category, "category_id", "name")
            Return View()
        End Function

        ' POST: Product/Create
        <HttpPost()>
        <Authorize(Roles:="Admin")>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="product_id,name,quantity,price,category_id,image")> ByVal product As product) As ActionResult

            If ModelState.IsValid Then
                db.product.Add(product)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.category_id = New SelectList(db.category, "category_id", "name", product.category_id)
            Return View(product)
        End Function

        ' GET: Product/Edit/5
        <Authorize(Roles:="Admin")>
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
        <Authorize(Roles:="Admin")>
        Function Edit(<Bind(Include:="product_id,name,quantity,category_id,image, price")> ByVal product As product) As ActionResult
            If ModelState.IsValid Then
                db.Entry(product).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.category_id = New SelectList(db.category, "category_id", "name", product.category_id)
            Return View(product)
        End Function

        ' GET: Product/Delete/5
        <Authorize(Roles:="Admin")>
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
        <Authorize(Roles:="Admin")>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim product As product = db.product.Find(id)
            db.product.Remove(product)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        <HttpPost()>
        <ActionName("Search")>
        <ValidateAntiForgeryToken()>
        Function Search(SearchString As String) As ActionResult
            Dim listProducts As List(Of product) = Nothing

            If Not String.IsNullOrEmpty(SearchString) Then
                listProducts = (From products In db.product Where products.name.ToLower().Contains(SearchString.ToLower())).ToList()
            Else
                listProducts = db.product.ToList()
            End If

            Return View("Index", listProducts)
        End Function

        <HttpPost()>
        <ActionName("Comment")>
        <ValidateAntiForgeryToken()>
        <Authorize()>
        Function PostComment(ByVal productId As Integer?, ByVal commentString As String) As ActionResult
            If (Not String.IsNullOrEmpty(commentString) Or productId IsNot Nothing) Then
                Dim userId As String = User.Identity.GetUserId()
                If userId Is Nothing Then
                    Return RedirectToAction("Login")
                End If

                Dim commentObj As New comment With {
                    .userId = userId,
                    .product_id = productId,
                    .commentString = commentString
                }
                db.Comment.Add(commentObj)
                db.SaveChanges()
                Return RedirectToAction("Details", New With {.id = productId})


            End If

        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
