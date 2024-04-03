@ModelType IEnumerable(Of WebMVCSecurity.OrdersView)
@Code
ViewData("Title") = "View"
Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>View</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.product.name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.quantity)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.user_id)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.date_create)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.product.name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.quantity)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.user_id)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.date_create)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.id })
        </td>
    </tr>
Next

</table>
