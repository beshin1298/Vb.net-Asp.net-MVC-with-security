@ModelType IEnumerable(Of WebMVCSecurity.AspNetUserRoles)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            User Name
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.AspNetRoles.Name)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
    <td>
        @Html.DisplayFor(Function(modelItem) item.User.UserName)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.AspNetRoles.Name)
    </td>
    <td>
        @Html.ActionLink("Edit", "Edit", New With {.id = item.UserId}) |
        @Html.ActionLink("Delete", "Delete", New With {.id = item.UserId, .roleId = item.RoleId})
    </td>
</tr>
Next

</table>
