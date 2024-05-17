Imports System.Data.Entity
Public Class ProductService
    Implements ProductRepo
    Private db As New DatabaseContext
    Public Function GetAllListProduct() As List(Of product) Implements ProductRepo.GetAllListProduct
        Return db.product.Include(Function(p) p.category).ToList()

    End Function

    Public Function GetProductByProductId(id As Object) As product Implements ProductRepo.GetProductByProductId
        Dim product As product = db.product.Find(id)
        Return product
    End Function
End Class
