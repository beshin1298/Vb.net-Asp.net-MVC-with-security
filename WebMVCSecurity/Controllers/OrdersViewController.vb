Imports Microsoft.AspNet.Identity

Namespace Controllers
    <Authorize()>
    Public Class OrdersViewController
        Inherits Controller

        Private db As DatabaseContext = New DatabaseContext()
        ' GET: OdersView
        Function Index() As ActionResult
            Dim userId = User.Identity.GetUserId()
            Dim cartId As Integer = getCartId()
            Dim countItemInCart As Integer = (From c In db.CartView Where c.cart_id = cartId).ToList().Count
            Session("numberOfCart") = countItemInCart
            Dim orders As List(Of Order)

            Using db As New DatabaseContext()
                orders = db.OdersView.Where(Function(o) o.user_id = userId) _
                             .GroupBy(Function(o) o.date_create) _
                             .Select(Function(g) New Order With {
                                 .dateCreate = g.Key,
                                 .quantity = g.Count()
                             }).ToList()
            End Using

            Return View(orders)
        End Function

        ' GET: OdersView/Details/5
        Function Details(ByVal id As Integer) As ActionResult
            Return View()
        End Function
        <HttpPost>
        <ActionName("CreateOrder")>
        Function CreateOrder() As ActionResult
            Try
                Dim dateNow As Date = Date.Now
                Dim userId = User.Identity.GetUserId()
                Dim cartId As Integer = getCartId()
                Dim listItemInCart = (From c In db.CartView Where c.cart_id = cartId).ToList()
                Dim orderView As OrdersView
                For Each item In listItemInCart
                    orderView = New OrdersView With {.product_id = item.product_id, .quantity = item.quantity, .user_id = userId, .date_create = dateNow}
                    db.OdersView.Add(orderView)
                    db.CartView.Remove(item)
                Next

                db.SaveChanges()


                Return RedirectToAction("Index")
            Catch ex As Exception
                Console.WriteLine(ex.InnerException.Message)
                Return View("Error")
            End Try
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

        <HttpPost>
        <ActionName("CreateShipping")>
        Function CreateShipping() As ActionResult
            Return View()
        End Function
    End Class
End Namespace