Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private db As DatabaseContext = New DatabaseContext()
    Function Index() As ActionResult

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
