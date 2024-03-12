Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Data.SqlClient
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
            Dim cartId As Integer = getCartId()
            Dim listItemInCart = (From c In db.CartView Where c.cart_id = cartId).ToList()
            Session("numberOfCart") = listItemInCart.Count
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
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="product_id,quantity")> ByVal cartView As CartView) As ActionResult
            Dim userId = User.Identity.GetUserId()
            If userId Is Nothing Then
                Return RedirectToAction("Login")
            End If
            If ModelState.IsValid Then
                Dim cartId As Integer = getCartId()
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

            End If

            Return RedirectToAction("About", "Home")


        End Function



        ' POST: CartViews/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal productId As Integer) As ActionResult

            If IsNothing(productId) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            Dim CartId As Integer = getCartId()
            Dim item As CartView = db.CartView.Where(Function(e) e.cart_id = CartId AndAlso e.product_id = productId).FirstOrDefault()
            If item IsNot Nothing Then
                If Request.Form("submitButton").Equals("decrease") Then
                    If item.quantity <= 1 Then
                        db.CartView.Remove(item)
                        db.SaveChanges()
                        Return RedirectToAction("Index")
                    Else
                        item.quantity -= 1
                    End If

                ElseIf Request.Form("submitButton").Equals("increase") Then
                    item.quantity += 1
                End If
                db.Entry(item).State = EntityState.Modified
                db.Entry(item).Property("quantity").IsModified = True
                db.SaveChanges()

            End If
            Return RedirectToAction("Index")
        End Function

        ' GET: CartViews/Delete/5
        Function Delete(ByVal productId As Integer?) As ActionResult

            If IsNothing(productId) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cartView As CartView = db.CartView.Find(productId)
            If IsNothing(cartView) Then
                Return HttpNotFound()
            End If
            Return View(cartView)
        End Function

        ' POST: CartViews/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal productId As Integer) As ActionResult
            Dim cartId As Integer = getCartId()
            Dim cartView As CartView = db.CartView.Find(productId, cartId)
            db.CartView.Remove(cartView)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Private Function getCartId()
            Dim userId = User.Identity.GetUserId()
            If userId IsNot Nothing Then
                Dim cart As UserCart = db.UserCart.FirstOrDefault(Function(e) e.user_id = userId)
                Return cart.cart_id
            Else Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
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
