@ModelType IEnumerable(Of WebMVCSecurity.CartView)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Your Cart</h2>

<p>
    @Html.ActionLink("Shopping now", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.product_id)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.quantity)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.product_id)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.quantity)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.cart_id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.cart_id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.cart_id })
        </td>
    </tr>
Next

</table>
