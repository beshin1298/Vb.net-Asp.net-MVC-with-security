@ModelType WebMVCSecurity.order_shipping
@Code
    ViewData("Title") = "CreateShipping"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Create Shipping</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">

        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})

        <div class="form-group">
            <label>Receiver</label>
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.customer_name, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.customer_name, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            <label>Address</label>
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.shipping_address, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.shipping_address, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group mt-2">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="ORDER" class="btn btn-warning" />
            </div>
        </div>
    </div>
End Using


