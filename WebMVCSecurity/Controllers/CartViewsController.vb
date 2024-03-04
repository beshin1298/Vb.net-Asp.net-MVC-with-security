Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.WebPages
Imports Antlr.Runtime.Misc
Imports Microsoft.AspNet.Identity

Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.AspNetCore.Identity
Imports WebMVCSecurity

Namespace Controllers
    <Authorize>
    Public Class CartViewsController
        Inherits System.Web.Mvc.Controller

        Private db As New DatabaseContext

        ' GET: CartViews
        Function Index() As ActionResult
            Dim userId = User.Identity.GetUserId()
            Dim cart As UserCart = db.UserCart.FirstOrDefault(Function(e) e.user_id = userId)
            Dim cartId = cart.cart_id

            Dim listItemInCart = (From c In db.CartView Where c.cart_id = cartId).ToList()

            Return View(listItemInCart)
        End Function

        ' GET: CartViews/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cartView As CartView = db.CartView.Find(id)
            If IsNothing(cartView) Then
                Return HttpNotFound()
            End If
            Return View(cartView)
        End Function

        ' GET: CartViews/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: CartViews/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ActionName("AddToCart")>
        Function Create(ByVal cartView As CartView) As ActionResult
            Dim userId = User.Identity.GetUserId()
            Dim cart As UserCart = db.UserCart.FirstOrDefault(Function(e) e.user_id = userId)
            Dim cartId = cart.cart_id
            If Not cartView.product_id Or Not cartView.quantity < 1 Then
                Dim cartViewTemp As CartView = db.CartView.Find(cartView.product_id, cartId)
                If cartViewTemp Is Nothing Then
                    cartView.cart_id = cartId
                    db.CartView.Add(cartView)
                    db.SaveChanges()
                Else
                    cartViewTemp.quantity += cartView.quantity
                    db.Entry(cartViewTemp).State = EntityState.Modified

                    db.SaveChanges()
                End If

            Else Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            Return New HttpStatusCodeResult(HttpStatusCode.OK)


        End Function

        ' GET: CartViews/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cartView As CartView = db.CartView.Find(id)
            If IsNothing(cartView) Then
                Return HttpNotFound()
            End If
            Return View(cartView)
        End Function

        ' POST: CartViews/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="cart_id,product_id,quantity")> ByVal cartView As CartView) As ActionResult
            If ModelState.IsValid Then
                db.Entry(cartView).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(cartView)
        End Function

        ' GET: CartViews/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cartView As CartView = db.CartView.Find(id)
            If IsNothing(cartView) Then
                Return HttpNotFound()
            End If
            Return View(cartView)
        End Function

        ' POST: CartViews/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim cartView As CartView = db.CartView.Find(id)
            db.CartView.Remove(cartView)
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
