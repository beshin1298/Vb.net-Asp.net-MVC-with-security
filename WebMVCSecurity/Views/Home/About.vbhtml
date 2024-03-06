@ModelType ProductCart

@Code
    ViewData("Title") = "About"
End Code

<main aria-labelledby="title">
    <h2 id="title">@ViewData("Title").</h2>
    <h3>@ViewData("Message")</h3>

    <div class="container mt-5 ">
        <h1 class="mb-4">Danh sách sản phẩm</h1>
        @Using Html.BeginForm("Search", "Home", FormMethod.Post)
            @<div Class="p-2">
                @Html.DropDownList("category_id", Nothing, New With {.class = "form-control", .onchange = "this.form.submit()"})
            </div>
        End Using


        <div Class="row">
            @For Each item In Model.Products

                @<div Class="col-md-4 pb-5">
                    <div Class="card">
                        <img src="@item.image" Class="card-img-top" alt="Product 1" height="369">
                        <div Class="card-body">
                            <h5 Class="card-title">@item.name</h5>
                            <p Class="card-text">Phân loại: @item.category.name</p>
                            <p Class="card-text">Số lượng trong kho: @item.quantity</p>



                            @Using (Html.BeginForm("AddToCart", "CartViews", FormMethod.Post))
                                @Html.AntiForgeryToken()
                                @<div Class="form-row align-items-center d-flex gap-2 form-group">
                                    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                                    <div Class="p-2">
                                        <a href='@Url.Action("Details", "Product", New With {.id = item.product_id})' Class="btn btn-primary">Details</a>
                                    </div>
                                    <div Class="p-2">

                                        @Html.HiddenFor(Function(model) model.CartView.product_id, New With {.Value = item.product_id, .htmlAttributes = New With {.class = "form-control"}})
                                        @Html.EditorFor(Function(model) model.CartView.quantity, New With {.htmlAttributes = New With {.class = "form-control"}})
                                        @Html.ValidationMessageFor(Function(model) model.CartView.quantity, "", New With {.class = "text-danger"})
                                    </div>
                                    <div Class="p-2">
                                        <Button Class="btn bg-warning" type="submit"><i class="fa fa-cart-plus fa-lg" aria-hidden="true"></i></Button>
                                    </div>
                                </div>
                            End Using
                        </div>
                    </div>
                </div>

            Next

        </div>
    </div>

</main>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
