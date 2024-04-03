@ModelType IEnumerable(Of WebMVCSecurity.Order)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>List your order</h2>

@For Each item In Model
    @Using (Html.BeginForm("CreateShipping", "OrdersView", FormMethod.Post))
        @<div Class="card ">
            <div Class="card-header">
                Order card
            </div>
            <div Class="card-body">
                <h5 Class="card-title">Waiting for order</h5>
                <p Class="card-text">Number item in bill: @item.quantity</p>
                <p Class="card-text">Date create: @item.dateCreate</p>
                <button type="submit" Class="btn btn-primary">Go to order</button>
            </div>
        </div>  End Using

Next
