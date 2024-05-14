Imports System.Net
Imports Microsoft.AspNet.Identity

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private db As DatabaseContext = New DatabaseContext()
    Function Index() As ActionResult
        Dim cartId As Integer = getCartId()
        Dim countItemInCart As Integer = (From c In db.CartView Where c.cart_id = cartId).ToList().Count
        Session("numberOfCart") = countItemInCart
        Dim newsList As List(Of news) = (From n In db.News).ToList()

        Return View(newsList)
    End Function

    Function About() As ActionResult
        ViewData("Message") = "My Shop"
        Dim emptyItem = New SelectListItem With {.Text = "-- Search by Category --", .Value = -1}
        ViewBag.category_id = New SelectList(db.category, "category_id", "name", Nothing).Prepend(emptyItem)
        Dim listProducts As List(Of product) = db.product.ToList()
        Dim cartId As Integer = getCartId()
        Dim listItemInCart = (From c In db.CartView Where c.cart_id = cartId).ToList()
        Session("numberOfCart") = listItemInCart.Count
        Dim productCart As ProductCart = New ProductCart With {.Products = listProducts}
        Return View(productCart)
    End Function

    <HttpPost()>
    <ActionName("Search")>
    Function Search(<Bind(Include:="category_id")> ByVal product As product) As ActionResult

        If product Is Nothing Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim listProducts As List(Of product)
        If product.category_id >= 0 Then
            listProducts = db.product.Where(Function(item) item.category_id = product.category_id).ToList()
        Else listProducts = db.product.ToList()
        End If
        Dim productCart As ProductCart = New ProductCart With {.Products = listProducts}
        Dim emptyItem = New SelectListItem With {.Text = "-- Search by Category --", .Value = -1}
        ViewBag.category_id = New SelectList(db.category, "category_id", "name", product.category_id).Prepend(emptyItem)
        Return View("~\Views\Home\About.vbhtml", productCart)
    End Function

    Function getCartId()

        If (Request.IsAuthenticated) Then
            Dim userId = User.Identity.GetUserId()
            Dim cart As UserCart = db.UserCart.FirstOrDefault(Function(e) e.user_id = userId)
            Dim cartId = cart.cart_id
            Return cartId
        Else Return Nothing
        End If

    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
