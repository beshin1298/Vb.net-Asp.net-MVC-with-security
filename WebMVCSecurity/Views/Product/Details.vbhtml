@ModelType WebMVCSecurity.product
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Details</h2>

<div class="container my-5">
    <div class="row">
        <div class="col-md-5">
            <div class="main-img">
                <img class="img-fluid" src="@Model.image" alt="ProductS">
                <!-- Thêm hình ảnh xem trước khác (nếu cần) -->
            </div>
        </div>
        <div class="col-md-7">
            <div class="main-description px-2">
                <div class="category font-weight-bold">Category: @Model.category.name</div>
                <h1 class="product-title">@Model.name</h1>
                <p class="product-description"> Quantity in warehouse: @Model.quantity</p>

            </div>
            <div>
                @If Request.IsAuthenticated AndAlso User.IsInRole("Admin") Then
                    @Html.ActionLink("Edit", "Edit", New With {.id = Model.product_id}) 
                End If
                @Html.ActionLink("Back to List", "About", "Home")
            </div>
        </div>

    </div>
</div>

