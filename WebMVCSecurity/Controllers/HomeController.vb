Imports Microsoft.AspNet.Identity

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private db As DatabaseContext = New DatabaseContext()
    Function Index() As ActionResult
        Dim userId = User.Identity.GetUserId()
        Dim cart As UserCart = db.UserCart.FirstOrDefault(Function(e) e.user_id = userId)
        Dim cartId = cart.cart_id
        Dim listItemInCart = (From c In db.CartView Where c.cart_id = cartId).ToList()
        Session("numberOfCart") = listItemInCart.Count
        Debug.WriteLine("-----", listItemInCart.Count)



        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Dim listProducts As List(Of product) = db.product.ToList()
        Return View(listProducts)
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
