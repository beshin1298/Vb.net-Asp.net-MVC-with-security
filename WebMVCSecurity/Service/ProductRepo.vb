Public Interface ProductRepo
    Function GetAllListProduct() As List(Of product)
    Function GetProductByProductId(ByVal id) As product
End Interface
