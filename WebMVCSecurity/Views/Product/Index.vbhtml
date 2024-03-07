@ModelType IEnumerable(Of WebMVCSecurity.product)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Products</h2>

@Using (Html.BeginForm("Search", "Product", FormMethod.Post))
    @Html.AntiForgeryToken()
    @<div class="d-flex gap-10">
        <div class="p-1">
            @Html.TextBox("SearchString", Nothing, New With {.class = "form-control"})
        </div>
       

        <div class="p-1">
            <button type="submit" class="btn btn-primary pa">
                <i class="fa fa-search" aria-hidden="true"></i>
            </button>
        </div>


    </div>

End Using
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.quantity)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.category.name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.price)
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.name)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.quantity)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.category.name)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.price)$
            </td>
            <td>
                <button type="button" class="btn btn-primary" onclick="window.location.href='@Url.Action("Edit", "Product", New With {.id = item.product_id})'">
                    <i class="fa fa-cog" aria-hidden="true"></i>
                </button>
                <button type="button" class="btn btn-success" onclick="window.location.href='@Url.Action("Details", "Product", New With {.id = item.product_id})'">
                    <i class="fa fa-info" aria-hidden="true"></i>
                </button>

                <button type="button" class="btn btn-danger" onclick="location.href='@Url.Action("Delete", "Product", New With {.id = item.product_id})'">
                    <i class="fa fa-trash-o" aria-hidden="true"></i>

                </button>
            </td>
        </tr>
    Next

</table>
<button type="button" class="btn btn-primary" onclick="window.location.href='@Url.Action("Create", "Product")'">
    <i class="fa fa-plus" aria-hidden="true"></i>
</button>
