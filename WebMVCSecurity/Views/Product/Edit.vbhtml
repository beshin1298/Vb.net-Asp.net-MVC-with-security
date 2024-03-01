@ModelType WebMVCSecurity.product
@Code
    ViewData("Title") = "Edit"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal d-flex">
        <div class="col-8">
            <h4>Product detail</h4>
            <hr />
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @Html.HiddenFor(Function(model) model.product_id)

            <div class="form-group">
                @Html.LabelFor(Function(model) model.name, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.name, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.name, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.quantity, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.quantity, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.quantity, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Image (Link image)</label>
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.image, New With {.htmlAttributes = New With {.class = "form-control", .onchange = "handleImageChange(this)"}})
                    @Html.ValidationMessageFor(Function(model) model.image, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.category_id, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownList("category_id", Nothing, htmlAttributes:=New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.category_id, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="Save" class="btn btn-primary mt-2 mb-2" />
                </div>
            </div>
        </div>
        <div class="row col-3 ">
            <img id="product-image" src="@Model.image" class="col-md-12 text-center p-4" style="width:100%; height:auto; object-fit:contain; display:block" />
        </div>
    </div>  End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

<script>
    function handleImageChange(input) {
        var selectedValue = input.value;

        console.log(selectedValue)
        document.getElementById("product-image").src = selectedValue;
    }
</script>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
